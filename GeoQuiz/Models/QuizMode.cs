using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Definiert die unterstützten Quiz-Modi.
/// Die Reihenfolge ist egal, aber die Werte bleiben stabil für Speicherung.
/// </summary>
public enum QuizMode
{
	FlagToCountry = 1,
	FlagToCapital = 2,
	CountryToCapital = 3,
	CountryToFlag = 4,
	CapitalToCountry = 5,
	CapitalToFlag = 6
}

