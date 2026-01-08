namespace GeoQuiz
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();
        }



        

        private void btnLogin_Click_1(object sender, EventArgs e)
		{
			lblStatus.Text = "";

			var (username, password) = ReadCredentials();

			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				lblStatus.Text = "Bitte Benutzername und Passwort eingeben.";
				return;
			}

			var player = _playerRepo.TryLogin(username, password);
			if (player == null)
			{
				lblStatus.Text = "Login fehlgeschlagen. Benutzername oder Passwort falsch.";
				return;
			}

			AppState.CurrentPlayer = player;

			this.Hide();

			// SetupForm wird modal geöffnet. Erst wenn sie geschlossen wird, geht es hier weiter.
			using (var setup = new SetupForm())
			{
				setup.ShowDialog();
			}

			// Wenn SetupForm geschlossen wurde, zeigen wir LoginForm wieder.
			this.Show();

			if (AppState.CurrentPlayer == null)
			{
				ResetLoginUi();
			}


		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			lblStatus.Text = "";

			var (username, password) = ReadCredentials();

			// Einfache Eingabeprüfung
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				lblStatus.Text = "Bitte Benutzername und Passwort eingeben.";
				return;
			}

			// Spieler anlegen
			bool created = _playerRepo.CreatePlayer(username, password);
			if (!created)
			{
				lblStatus.Text = "Benutzername existiert bereits.";
				return;
			}

			// Nach Registrierung direkt einloggen
			var player = _playerRepo.TryLogin(username, password);
			AppState.CurrentPlayer = player;

			this.Hide();

			// SetupForm wird modal geöffnet. Erst wenn sie geschlossen wird, geht es hier weiter.
			using (var setup = new SetupForm())
			{
				setup.ShowDialog();
			}



			// Wenn SetupForm geschlossen wurde, zeigen wir LoginForm wieder.
			this.Show();

			if (AppState.CurrentPlayer == null)
			{
				ResetLoginUi();
			}


		}
		private readonly PlayerRepository _playerRepo = new PlayerRepository(DatabaseConfig.ConnectionString);
		/// <summary>
		/// Liest Username und Passwort aus den Textboxen und trimmt Leerzeichen.
		/// </summary>
		private (string Username, string Password) ReadCredentials()
		{
			return (txtUsername.Text.Trim(), txtPassword.Text);
		}

		/// <summary>
		/// Setzt die Eingabefelder und Statusanzeige zurück (z.B. nach Logout).
		/// </summary>
		private void ResetLoginUi()
		{
			txtUsername.Text = "";
			txtPassword.Text = "";
			lblStatus.Text = "";
			txtUsername.Focus();
		}

	}
}
