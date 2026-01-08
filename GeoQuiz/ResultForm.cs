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
	public partial class ResultForm : Form
	{
		private readonly int _points;

		/// <summary>
		/// Ergebnisfenster bekommt die erreichten Punkte übergeben.
		/// </summary>
		public ResultForm(int points)
		{
			InitializeComponent();
			_points = points;
		}

		private void ResultForm_Load(object sender, EventArgs e)
		{
			// Punkte anzeigen
			lblPoints.Text = $"{_points} Punkte";
		}

		private void btnNewQuiz_Click(object sender, EventArgs e)
		{
			// Zurück zur SetupForm (ShowDialog-Kette)
			this.Close();
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			// Logout anfordern: SetupForm schließt sich danach und Login erscheint wieder
			AppState.CurrentPlayer = null;
			AppState.LogoutRequested = true;
			this.Close();
		}
	}
}

