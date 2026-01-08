using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoQuiz;
using Npgsql;

namespace GeoQuiz;

/// <summary>
/// Kapselt alle Datenbankzugriffe für Spieler (Registrierung / Login).
/// UI-Code (Forms) ruft nur diese Methoden auf und enthält kein SQL.
/// </summary>
public class PlayerRepository
{
	private readonly string _connectionString;

	/// <summary>
	/// Repository bekommt den Connection String beim Erstellen übergeben.
	/// Dadurch ist die Klasse testbar und nicht an globale Variablen gebunden.
	/// </summary>
	public PlayerRepository(string connectionString)
	{
		_connectionString = connectionString;
	}

	/// <summary>
	/// Legt einen neuen Spieler an (Username muss eindeutig sein).
	/// Das Passwort wird gehasht + gesalzen gespeichert (kein Klartext).
	/// </summary>
	/// <returns>true = erstellt, false = Username existiert bereits</returns>
	public bool CreatePlayer(string username, string password)
	{
		// 1) Hash + Salt erzeugen
		var (hash, salt) = PasswordHasher.CreateHash(password);

		// 2) Insert versuchen
		using var conn = new NpgsqlConnection(_connectionString);
		conn.Open();

		using var cmd = new NpgsqlCommand(
			@"insert into public.player (username, password_hash, password_salt)
              values (@username, @hash, @salt);", conn);

		cmd.Parameters.AddWithValue("username", username);
		cmd.Parameters.AddWithValue("hash", hash);
		cmd.Parameters.AddWithValue("salt", salt);

		try
		{
			cmd.ExecuteNonQuery();
			return true;
		}
		catch (PostgresException ex) when (ex.SqlState == "23505")
		{
			// 23505 = unique_violation (username existiert bereits)
			return false;
		}
	}

	/// <summary>
	/// Prüft Login-Daten. Wenn erfolgreich, gibt es den Player zurück.
	/// Wenn nicht erfolgreich, wird null zurückgegeben.
	/// </summary>
	public Player? TryLogin(string username, string password)
	{
		using var conn = new NpgsqlConnection(_connectionString);
		conn.Open();

		// Wir lesen ID, Hash und Salt aus der DB
		using var cmd = new NpgsqlCommand(
			@"select player_id, password_hash, password_salt
              from public.player
              where username = @username;", conn);

		cmd.Parameters.AddWithValue("username", username);

		using var reader = cmd.ExecuteReader();

		if (!reader.Read())
		{
			// Username existiert nicht
			return null;
		}

		long playerId = reader.GetInt64(0);
		string storedHash = reader.GetString(1);
		string storedSalt = reader.GetString(2);

		// Passwort prüfen
		bool ok = PasswordHasher.Verify(password, storedHash, storedSalt);
		if (!ok)
			return null;

		// Erfolgreich -> Player zurückgeben
		return new Player
		{
			PlayerId = playerId,
			Username = username
		};
	}
}

