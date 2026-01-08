using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;


namespace GeoQuiz;

/// <summary>
/// Liefert Länder-Daten aus der Datenbank (Supabase Postgres).
/// </summary>
public class CountryRepository
{
	private readonly string _connectionString;

	public CountryRepository(string connectionString)
	{
		_connectionString = connectionString;
	}

	/// <summary>
	/// Lädt alle Länder (optional gefiltert nach Kontinent).
	/// Der Kontinentfilter ist Grundlage für SOLL-01.
	/// </summary>
	public List<Country> GetCountries(long? continentId)
	{
		var result = new List<Country>();

		using var conn = new NpgsqlConnection(_connectionString);
		conn.Open();

		// Optionaler Filter: Wenn continentId null ist, wird weltweit geladen.
		string sql =
			@"select country_id, name, capital, flag_path, continent_id
              from public.country
              where (@continentId is null) or (continent_id = @continentId);";

		using var cmd = new NpgsqlCommand(sql, conn);
		// Parameter explizit als BIGINT typisieren, damit Postgres bei NULL den Typ kennt.
		cmd.Parameters.Add("continentId", NpgsqlTypes.NpgsqlDbType.Bigint).Value =
			(object?)continentId ?? DBNull.Value;

		using var reader = cmd.ExecuteReader();
		while (reader.Read())
		{
			result.Add(new Country
			{
				CountryId = reader.GetInt64(0),
				Name = reader.GetString(1),
				Capital = reader.GetString(2),
				FlagPath = reader.GetString(3),
				ContinentId = reader.GetInt64(4)
			});
		}

		return result;
	}
}

