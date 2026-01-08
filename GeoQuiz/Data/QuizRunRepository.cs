using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace GeoQuiz;

/// <summary>
/// Repository zum Speichern von Quizrunden in der Datenbank.
/// </summary>
public class QuizRunRepository
{
	private readonly string _connectionString;

	public QuizRunRepository(string connectionString)
	{
		_connectionString = connectionString;
	}

	/// <summary>
	/// Speichert eine abgeschlossene Quizrunde in der Tabelle quiz_run.
	/// </summary>
	public void InsertRun(
		long playerId,
		QuizMode mode,
		int totalPoints,
		long? continentId,
		DateTime startedAt,
		DateTime finishedAt)
	{
		using var conn = new NpgsqlConnection(_connectionString);
		conn.Open();

		using var cmd = new NpgsqlCommand(
			@"INSERT INTO public.quiz_run
              (player_id, mode, total_points, continent_id, started_at, finished_at)
              VALUES
              (@playerId, @mode, @points, @continentId, @startedAt, @finishedAt);",
			conn);

		cmd.Parameters.AddWithValue("playerId", playerId);
		cmd.Parameters.AddWithValue("mode", (short)mode);
		cmd.Parameters.AddWithValue("points", totalPoints);
		cmd.Parameters.AddWithValue("continentId",
			continentId.HasValue ? continentId.Value : DBNull.Value);
		cmd.Parameters.AddWithValue("startedAt", startedAt);
		cmd.Parameters.AddWithValue("finishedAt", finishedAt);

		cmd.ExecuteNonQuery();
	}
}
