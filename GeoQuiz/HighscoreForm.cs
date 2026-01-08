using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace GeoQuiz
{
    public partial class HighscoreForm : Form
    {
        public HighscoreForm()
        {
            InitializeComponent();
        }

        // OPTIONAL: Kann bleiben oder gelöscht werden (macht nichts kaputt)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Lädt die Top 10 Highscores (alle Spieler) aus der Datenbank
        /// und zeigt sie im DataGridView an.
        /// </summary>
        private void HighscoreForm_Load(object sender, EventArgs e)
        {
			gridHighscores.Rows.Clear();

			using (var conn = new NpgsqlConnection(DatabaseConfig.ConnectionString))
			{
				conn.Open();

				NpgsqlCommand cmd;

				// 🔹 NUR AKTUELLER SPIELER
				if (rdoCurrent.Checked)
				{
					if (AppState.CurrentPlayer == null)
						return;

					cmd = new NpgsqlCommand(@"
                SELECT 
                    p.username,
                    qr.total_points,
                    qr.finished_at
                FROM quiz_run qr
                JOIN player p ON p.player_id = qr.player_id
                WHERE qr.player_id = @playerId
                ORDER BY qr.total_points DESC
                LIMIT 10;
            ", conn);

					cmd.Parameters.AddWithValue("@playerId", AppState.CurrentPlayer.PlayerId);
				}
				// 🔹 ALLE SPIELER (GLOBAL)
				else
				{
					cmd = new NpgsqlCommand(@"
                SELECT 
                    p.username,
                    qr.total_points,
                    qr.finished_at
                FROM quiz_run qr
                JOIN player p ON p.player_id = qr.player_id
                ORDER BY qr.total_points DESC
                LIMIT 10;
            ", conn);
				}

				using (cmd)
				using (var reader = cmd.ExecuteReader())
				{
					int rank = 1;

					while (reader.Read())
					{
						gridHighscores.Rows.Add(
							rank,
							reader.GetString(0),                      // Username
							reader.GetInt32(1),                       // Punkte
							reader.GetDateTime(2).ToLocalTime()
								.ToString("dd.MM.yyyy HH:mm")         // Datum
						);
						rank++;
					}
				}
			}

		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
			HighscoreForm_Load(sender, e);
		}
    }
}
