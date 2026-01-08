using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoQuiz
{
    public partial class SetupForm : Form

    {
        public SetupForm()
        {
            InitializeComponent();
        }

        private void SetupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			// Wenn wir aus dem Setup heraus wirklich "Logout" gemacht haben,
			// soll die App NICHT beendet werden. LoginForm wartet (ShowDialog-Kette)
			// und wird automatisch wieder sichtbar.
			if (AppState.CurrentPlayer == null)
				return;

			// Wenn SetupForm normal geschlossen wird (X), beenden wir die Anwendung.
			Application.Exit();
		}

        private void btnStart_Click(object sender, EventArgs e)
        {
            var settings = BuildSettings();

            this.Hide();

            // QuizForm modal öffnen. Erst nach dem Schließen geht es weiter.
            using (var quizForm = new QuizForm(settings))
            {
                quizForm.ShowDialog();
            }

            // Wenn im ResultForm Logout gewählt wurde, schließen wir SetupForm,
            // damit wir wieder zur LoginForm zurückkehren (ShowDialog-Kette).
            if (AppState.LogoutRequested)
            {
                AppState.LogoutRequested = false; // zurücksetzen für später
                this.Close();
                return;
            }

            // Sonst: SetupForm wieder anzeigen (z.B. für "Neues Quiz")
            this.Show();
        }

        private void btnHighscore_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (var highscore = new HighscoreForm())
            {
                highscore.ShowDialog();
            }

            this.Show();
        }

        private void rdoWorldwide_CheckedChanged(object sender, EventArgs e)
        {
            cmbContinent.Enabled = rdoContinent.Checked;

        }

        private void rdoContinent_CheckedChanged(object sender, EventArgs e)
        {
            cmbContinent.Enabled = rdoContinent.Checked;

        }

        /// <summary>
        /// Wandelt die Auswahl aus der UI (ComboBox Text) in den internen QuizMode um.
        /// Dadurch ist die Logik unabhängig von UI-Texten.
        /// </summary>
        private QuizMode GetSelectedMode()
        {
            string modeText = cmbMode.SelectedItem?.ToString() ?? "";

            return modeText switch
            {
                "Flagge → Land" => QuizMode.FlagToCountry,
                "Flagge → Hauptstadt" => QuizMode.FlagToCapital,
                "Land → Hauptstadt" => QuizMode.CountryToCapital,
                "Land → Flagge" => QuizMode.CountryToFlag,
                "Hauptstadt → Land" => QuizMode.CapitalToCountry,
                "Hauptstadt → Flagge" => QuizMode.CapitalToFlag,
                _ => throw new InvalidOperationException("Bitte einen Quiz-Modus auswählen.")
            };

        }

        /// <summary>
        /// Erstellt QuizSettings aus den aktuellen UI-Einstellungen.
        /// KontinentId wird später sauber aus der DB gemappt (SOLL-01).
        /// </summary>
        private QuizSettings BuildSettings()
        {
			long? continentId = null;

			// Wenn Kontinent gewählt ist, mappen wir den Namen auf die feste ID
			if (rdoContinent.Checked)
			{
				string selected = cmbContinent.SelectedItem?.ToString() ?? "";

				continentId = selected switch
				{
					"Europa" => 1,
					"Asien" => 2,
					"Afrika" => 3,
					"Nordamerika" => 4,
					"Südamerika" => 5,
					"Ozeanien" => 6,
					_ => throw new InvalidOperationException("Bitte einen Kontinent auswählen.")
				};
			}

			return new QuizSettings
			{
				Mode = GetSelectedMode(),
				ContinentId = continentId
			};
		}

        private void btnLogout_Click(object sender, EventArgs e)
        {
			AppState.CurrentPlayer = null;
			this.Close(); // LoginForm wird wieder sichtbar (ShowDialog-Kette)
		}
    }
}
