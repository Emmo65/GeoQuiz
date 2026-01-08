using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuiz;

/// <summary>
/// Repräsentiert ein Land aus der Datenbank.
/// FlagPath ist ein Pfad oder später eine URL (Supabase Storage).
/// </summary>
public class Country
{
	public long CountryId { get; set; }
	public string Name { get; set; } = "";
	public string Capital { get; set; } = "";
	public string FlagPath { get; set; } = "";
	public long ContinentId { get; set; }
}
	