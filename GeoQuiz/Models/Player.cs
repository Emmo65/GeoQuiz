using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Einfaches Datenmodell für einen Spieler.
/// Enthält nur Felder, die die UI/Logik braucht.
/// </summary>
public class Player
{
	public long PlayerId { get; set; }
	public string Username { get; set; } = "";
}
