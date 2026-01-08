using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Erzeugt aus Länder-Daten eine Quizrunde mit 10 Fragen und je 4 Antwortoptionen.
/// Enthält keine UI und keinen DB-Code.
/// </summary>
public class QuizEngine
{
	private readonly Random _random = new();

	/// <summary>
	/// Generiert eine Liste von genau 10 Fragen.
	/// </summary>
	public List<QuizQuestion> GenerateQuestions(List<Country> countries, QuizSettings settings)
	{
		if (countries.Count < 4)
			throw new InvalidOperationException("Zu wenig Länder für 4 Antwortmöglichkeiten.");

		// 10 unterschiedliche Länder als Basis für 10 Fragen
		var questionCountries = countries
			.OrderBy(_ => _random.Next())
			.Take(10)
			.ToList();

		var questions = new List<QuizQuestion>();

		foreach (var correct in questionCountries)
		{
			var q = BuildQuestion(countries, correct, settings.Mode);
			questions.Add(q);
		}

		return questions;
	}

	/// <summary>
	/// Baut eine einzelne Frage abhängig vom QuizMode.
	/// </summary>
	private QuizQuestion BuildQuestion(List<Country> all, Country correct, QuizMode mode)
	{
		// 3 falsche Länder auswählen (nicht das korrekte)
		var wrongCountries = all
			.Where(c => c.CountryId != correct.CountryId)
			.OrderBy(_ => _random.Next())
			.Take(3)
			.ToList();

		// Optionen (4) erstellen: 1 korrekt + 3 falsch
		var options = new List<QuizOption>();

		// Korrekte Option je nach Modus
		options.Add(CreateOptionForMode(correct, mode));

		// Falsche Optionen je nach Modus
		foreach (var w in wrongCountries)
			options.Add(CreateOptionForMode(w, mode));

		// Optionen mischen und CorrectIndex bestimmen
		options = options.OrderBy(_ => _random.Next()).ToList();
		int correctIndex = options.FindIndex(o => IsCorrectOption(o, correct, mode));

		// Prompt je nach Modus
		var question = new QuizQuestion
		{
			PromptText = CreatePromptText(correct, mode),
			PromptImagePath = CreatePromptImagePath(correct, mode),
			Options = options,
			CorrectIndex = correctIndex
		};

		return question;
	}

	/// <summary>
	/// Erstellt eine Option (Text/Bild) passend zum Modus.
	/// </summary>
	private QuizOption CreateOptionForMode(Country c, QuizMode mode)
	{
		return mode switch
		{
			QuizMode.FlagToCountry => new QuizOption { Text = c.Name },
			QuizMode.FlagToCapital => new QuizOption { Text = c.Capital },
			QuizMode.CountryToCapital => new QuizOption { Text = c.Capital },
			QuizMode.CapitalToCountry => new QuizOption { Text = c.Name },

			// Für Flag-Optionen: ImagePath setzen. Text kann leer bleiben.
			QuizMode.CountryToFlag => new QuizOption { Text = "", ImagePath = c.FlagPath },
			QuizMode.CapitalToFlag => new QuizOption { Text = "", ImagePath = c.FlagPath },

			_ => throw new NotSupportedException("Unbekannter QuizMode.")
		};
	}

	/// <summary>
	/// Prüft, ob eine Option zur korrekten Antwort passt.
	/// </summary>
	private bool IsCorrectOption(QuizOption option, Country correct, QuizMode mode)
	{
		return mode switch
		{
			QuizMode.FlagToCountry => option.Text == correct.Name,
			QuizMode.FlagToCapital => option.Text == correct.Capital,
			QuizMode.CountryToCapital => option.Text == correct.Capital,
			QuizMode.CapitalToCountry => option.Text == correct.Name,

			QuizMode.CountryToFlag => option.ImagePath == correct.FlagPath,
			QuizMode.CapitalToFlag => option.ImagePath == correct.FlagPath,

			_ => false
		};
	}

	/// <summary>
	/// Prompt-Text abhängig vom Modus.
	/// Bei Flag-Modi ist PromptText kurz, weil das Bild den Hauptprompt liefert.
	/// </summary>
	private string CreatePromptText(Country correct, QuizMode mode)
	{
		return mode switch
		{
			QuizMode.FlagToCountry => "Zu welcher Nation gehört diese Flagge?",
			QuizMode.FlagToCapital => "Welche Hauptstadt gehört zu dieser Flagge?",
			QuizMode.CountryToCapital => $"Welche Hauptstadt gehört zu {correct.Name}?",
			QuizMode.CountryToFlag => $"Welche Flagge gehört zu {correct.Name}?",
			QuizMode.CapitalToCountry => $"Zu welchem Land gehört die Hauptstadt {correct.Capital}?",
			QuizMode.CapitalToFlag => $"Welche Flagge gehört zur Hauptstadt {correct.Capital}?",
			_ => "Frage"
		};
	}

	/// <summary>
	/// Gibt bei Flag-Prompt-Modi den Pfad/URL der Flagge zurück.
	/// Sonst null.
	/// </summary>
	private string? CreatePromptImagePath(Country correct, QuizMode mode)
	{
		return mode switch
		{
			QuizMode.FlagToCountry => correct.FlagPath,
			QuizMode.FlagToCapital => correct.FlagPath,
			_ => null
		};
	}
}

