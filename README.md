# GeoQuiz

Geografie-Quiz (WinForms, C# .NET 8) mit Ländern, Hauptstädten und Flaggen.
Login/Registrierung, 10 Fragen pro Runde, Punkte & Highscores (Supabase/PostgreSQL).

## Features
- Registrierung & Login (Passwort: Hash + Salt)
- Quiz-Modi:
  - Flagge → Land
  - Flagge → Hauptstadt
  - Land → Hauptstadt
  - Land → Flagge
  - Hauptstadt → Land
  - Hauptstadt → Flagge
- 10 Fragen / Runde, 4 Antworten, sofortiges Feedback
- Highscores aus Supabase (PostgreSQL)

## Setup (Entwicklung)
1. `appsettings.json` lokal anlegen (nicht committen)
2. Connection String eintragen

## Flags
Flaggen liegen im Ordner `flags/` und werden über `flag_path` (z.B. `flags/de.png`) geladen.

## Publish
```bash
```md
### Konfigurationsdatei
- `appsettings.json` **nicht committen** (enthält Zugangsdaten)
- Vorlage: `appsettings.example.json`
