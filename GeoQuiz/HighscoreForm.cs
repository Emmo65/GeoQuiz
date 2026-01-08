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

            using var conn = new NpgsqlConnection(DatabaseConfig.ConnectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(
                @"select p.username, q.total_points, q.finished_at
                  from public.quiz_run q
                  join public.player p on p.player_id = q.player_id
                  order by q.total_points desc, q.finished_at desc
                  limit 10;", conn);

            using var reader = cmd.ExecuteReader();

            int rank = 1;
            while (reader.Read())
            {
                string username = reader.GetString(0);
                int points = reader.GetInt32(1);
                DateTime finishedAt = reader.GetDateTime(2);

                gridHighscores.Rows.Add(rank, username, points, finishedAt.ToShortDateString());
                rank++;
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
