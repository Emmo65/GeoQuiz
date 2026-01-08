using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace GeoQuiz;

/// <summary>
/// Stellt Funktionen zum sicheren Hashen und Überprüfen von Passwörtern bereit.
/// Verwendet PBKDF2 mit Salt (Standard in .NET).
/// </summary>
public static class PasswordHasher
{
	/// <summary>
	/// Erstellt aus einem Klartext-Passwort einen sicheren Hash und ein zufälliges Salt.
	/// Beides wird als Base64-String zurückgegeben und in der Datenbank gespeichert.
	/// </summary>
	/// <param name="password">Das vom Benutzer eingegebene Passwort</param>
	/// <returns>Tuple aus Hash und Salt (beide Base64-kodiert)</returns>
	public static (string Hash, string Salt) CreateHash(string password)
	{
		// Zufälliges Salt erzeugen (128 Bit)
		byte[] saltBytes = RandomNumberGenerator.GetBytes(16);

		// PBKDF2-Hash aus Passwort + Salt erzeugen
		using var pbkdf2 = new Rfc2898DeriveBytes(
			password,
			saltBytes,
			100_000,
			HashAlgorithmName.SHA256
		);

		// Hash berechnen (256 Bit)
		byte[] hashBytes = pbkdf2.GetBytes(32);

		// Salt und Hash als Base64 speichern (DB-freundlich)
		string salt = Convert.ToBase64String(saltBytes);
		string hash = Convert.ToBase64String(hashBytes);

		return (hash, salt);
	}

	/// <summary>
	/// Überprüft, ob ein eingegebenes Passwort zu dem gespeicherten Hash/Salt passt.
	/// </summary>
	/// <param name="password">Vom Benutzer eingegebenes Passwort</param>
	/// <param name="storedHash">In der DB gespeicherter Hash (Base64)</param>
	/// <param name="storedSalt">In der DB gespeichertes Salt (Base64)</param>
	/// <returns>true = Passwort korrekt, false = Passwort falsch</returns>
	public static bool Verify(string password, string storedHash, string storedSalt)
	{
		// Gespeichertes Salt wieder in Bytes umwandeln
		byte[] saltBytes = Convert.FromBase64String(storedSalt);

		// Hash mit demselben Salt erneut berechnen
		using var pbkdf2 = new Rfc2898DeriveBytes(
		password,
		saltBytes,
		100_000,
		HashAlgorithmName.SHA256
		);

		byte[] hashBytes = pbkdf2.GetBytes(32);
		string computedHash = Convert.ToBase64String(hashBytes);

		// Vergleich: stimmt der berechnete Hash mit dem gespeicherten überein?
		return computedHash == storedHash;
	}
}