using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace GeoQuiz
{
    public partial class QuizForm : Form


    {
		

		// Speichert die 4 Antwortbuttons, damit wir sie per Index ansprechen können (A–D).
		private Button[] _answerButtons = Array.Empty<Button>();

		/// <summary>
		/// Initialisiert UI-Referenzen (z.B. Antwort-Buttons), die wir in mehreren Methoden brauchen.
		/// </summary>
		private void InitUi()
		{
			_answerButtons = new[] { btnA, btnB, btnC, btnD };
		}


		private readonly QuizSettings _settings;
        private List<QuizQuestion> _questions = new();
        private int _currentIndex = 0;
        private int _points = 0;
		private DateTime _quizStartedAt;



		/// <summary>
		/// Nur damit der Designer nicht kaputt geht.
		/// Das echte Quiz startet immer über QuizForm(settings).
		/// </summary>
		public QuizForm() : this(new QuizSettings { Mode = QuizMode.FlagToCountry, ContinentId = null })
		{
		}


		private void btnA_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            lblFeedback.Text = $"Ausgewählt: {clickedButton.Text}";
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            lblFeedback.Text = $"Ausgewählt: {clickedButton.Text}";

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            lblFeedback.Text = $"Ausgewählt: {clickedButton.Text}";
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            lblFeedback.Text = $"Ausgewählt: {clickedButton.Text}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
			_currentIndex++;

			if (_currentIndex >= _questions.Count)
			{
				if (AppState.CurrentPlayer != null)
				{
					var runRepo = new QuizRunRepository(DatabaseConfig.ConnectionString);

					runRepo.InsertRun(
						playerId: AppState.CurrentPlayer.PlayerId,
						mode: _settings.Mode,
						totalPoints: _points,
						continentId: _settings.ContinentId,
						startedAt: _quizStartedAt,
						finishedAt: DateTime.UtcNow
					);
				}

				// Quiz zu Ende → Ergebnisfenster modal öffnen (ShowDialog)
				using (var result = new ResultForm(_points))
				{
					result.ShowDialog();
				}

				// Danach QuizForm schließen → SetupForm (ShowDialog-Kette) wird wieder sichtbar
				this.Close();
				return;
			}

			// Nächste Frage anzeigen
			ShowQuestion();
		}

        public QuizForm(QuizSettings settings)
        {
            InitializeComponent();
			InitUi();


			_settings = settings;

            // Initiale Anzeige
            lblFeedback.Text = "";
            lblProgress.Text = "Frage 1/10";
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
			_quizStartedAt = DateTime.UtcNow;


			// 1) Länder laden (später: mit Kontinentfilter)
			var repo = new CountryRepository(DatabaseConfig.ConnectionString);
			var countries = repo.GetCountries(_settings.ContinentId);

			// 2) Fragen erzeugen
			var engine = new QuizEngine();
			_questions = engine.GenerateQuestions(countries, _settings);

			// 3) Erste Frage vorbereiten
			_currentIndex = 0;
			_points = 0;
			ShowQuestion();


			
		}

		/// <summary>
		/// Zeigt die aktuelle Frage inkl. Prompt, Flagge und Antwortoptionen an.
		/// </summary>
		private void ShowQuestion()
		{
			var question = _questions[_currentIndex];

			// Fortschritt anzeigen (z.B. Frage 3/10)
			lblProgress.Text = $"Frage {_currentIndex + 1}/{_questions.Count}";

			// Feedback zurücksetzen
			lblFeedback.Text = "";

			// Prompt-Text setzen
			lblPrompt.Text = question.PromptText;

			// Flagge anzeigen (falls vorhanden)
			if (!string.IsNullOrEmpty(question.PromptImagePath))
			{
				picFlag.Visible = true;

				// Aus relativem Pfad (z.B. "flags/de.png") einen absoluten Pfad machen
				string fullPath = Path.Combine(AppContext.BaseDirectory, question.PromptImagePath);

				// ImageLocation erwartet einen Pfad/URL. Mit dem absoluten Pfad klappt es zuverlässig.
				picFlag.ImageLocation = fullPath;
			}
			else
			{
				picFlag.Visible = false;
				picFlag.Image = null;
			}

			// Antwort-Buttons befüllen
			for (int i = 0; i < 4; i++)
			{
				var option = question.Options[i];
				var btn = _answerButtons[i];

				btn.Enabled = true;
				btn.Tag = i;

				// Vorheriges Bild sauber entfernen
				if (btn.Image != null)
				{
					btn.Image.Dispose();
					btn.Image = null;
				}

				// FLAGGEN-ANTWORT
				if (!string.IsNullOrEmpty(option.ImagePath))
				{
					string fullPath = Path.Combine(AppContext.BaseDirectory, option.ImagePath);

					using (var temp = Image.FromFile(fullPath))
					{
						// Zielgröße etwas kleiner als der Button, damit es nicht am Rand klebt
						var target = new Size(btn.Width - 10, btn.Height - 10);
						btn.Image = CreateScaledBitmap(temp, target);
					}

					btn.Text = "";
					btn.ImageAlign = ContentAlignment.MiddleCenter;
					btn.TextImageRelation = TextImageRelation.Overlay;
				}
				else
				{
					// TEXT-ANTWORT
					btn.Text = option.Text;
				}
			}


			// Der Spieler soll erst nach einer Antwort weiterklicken können
			btnNext.Enabled = false;
		}

		/// <summary>
		/// Skaliert ein Bild so, dass es in eine Zielgröße passt (Seitenverhältnis bleibt erhalten).
		/// Das Ergebnis ist ein neues Bitmap mit "contain/zoom"-Verhalten.
		/// </summary>
		private static Bitmap CreateScaledBitmap(Image source, Size targetSize)
		{
			var bmp = new Bitmap(targetSize.Width, targetSize.Height);

			using var g = Graphics.FromImage(bmp);
			g.Clear(Color.Transparent);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

			// Seitenverhältnis erhalten (contain)
			float ratioX = (float)targetSize.Width / source.Width;
			float ratioY = (float)targetSize.Height / source.Height;
			float ratio = Math.Min(ratioX, ratioY);

			int newW = (int)(source.Width * ratio);
			int newH = (int)(source.Height * ratio);

			int posX = (targetSize.Width - newW) / 2;
			int posY = (targetSize.Height - newH) / 2;

			g.DrawImage(source, new Rectangle(posX, posY, newW, newH));
			return bmp;
		}


		/// <summary>
		/// Wird aufgerufen, wenn der Spieler eine Antwort auswählt.
		/// </summary>
		private void AnswerButton_Click(object sender, EventArgs e)
		{
			if (sender is not Button btn)
				return;

			int selectedIndex = (int)btn.Tag;
			var question = _questions[_currentIndex];

			// Buttons deaktivieren, damit nur einmal geantwortet wird
			foreach (var b in _answerButtons)
				b.Enabled = false;

			if (selectedIndex == question.CorrectIndex)
			{
				lblFeedback.Text = "Richtig!";
				_points += 10;
			}
			else
			{
				lblFeedback.Text = "Falsch!";
			}

			// Nach einer Antwort darf weitergeklickt werden
			btnNext.Enabled = true;

		}

		
		




	}
}
