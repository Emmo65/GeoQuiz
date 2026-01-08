using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Einstellungen für eine Quizrunde (Modus + optionaler Kontinentfilter).
/// </summary>
public class QuizSettings
{
	public QuizMode Mode { get; set; }
	public long? ContinentId { get; set; } // null = weltweit
}
	