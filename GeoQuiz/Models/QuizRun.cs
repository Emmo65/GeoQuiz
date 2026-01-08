using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Repräsentiert eine gespeicherte Quizrunde (DB-Tabelle quiz_run).
/// </summary>
public class QuizRun
{
	public long QuizRunId { get; set; }
	public long PlayerId { get; set; }
	public short Mode { get; set; }
	public DateTime StartedAt { get; set; }
	public DateTime FinishedAt { get; set; }
	public int TotalPoints { get; set; }
	public long? ContinentId { get; set; }
}
