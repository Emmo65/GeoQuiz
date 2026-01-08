using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Speichert den aktuellen Zustand der App (z.B. eingeloggter Spieler).
/// Dadurch müssen wir nicht überall Parameter durchreichen.
/// </summary>
public static class AppState
{
	/// <summary>
	/// Der aktuell eingeloggte Spieler. Null = niemand eingeloggt.
	/// </summary>
	public static Player? CurrentPlayer { get; set; }

	/// <summary>
	/// Wird gesetzt, wenn der Benutzer im Ergebnisfenster "Logout" wählt.
	/// Dann schließen wir Setup/Quiz automatisch und landen wieder im Login.
	/// </summary>
	public static bool LogoutRequested { get; set; } = false;

}

