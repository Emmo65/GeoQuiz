using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Eine Quizfrage mit genau vier Antwortoptionen (eine korrekt).
/// Kann Text- und/oder Bild-Prompts unterstützen.
/// </summary>
public class QuizQuestion
{
	public string PromptText { get; set; } = "";      // z.B. "Welche Hauptstadt gehört zu Deutschland?"
	public string? PromptImagePath { get; set; }      // z.B. Flaggenpfad, wenn Modus Flag->...

	public List<QuizOption> Options { get; set; } = new();
	public int CorrectIndex { get; set; }             // 0..3
}

/// <summary>
/// Eine einzelne Antwortmöglichkeit.
/// Bei Flag-Optionen kann ImagePath gesetzt sein; bei Text-Optionen Text.
/// </summary>
public class QuizOption
{
	public string Text { get; set; } = "";
	public string? ImagePath { get; set; }
}

