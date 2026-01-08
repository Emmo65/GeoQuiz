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
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

---

## 3) `appsettings.example.json` anlegen (damit dein Repo vollständig ist)
1) Rechtsklick → Neu → Textdokument
2) Name: **appsettings.example.json**
3) Inhalt:

```json
{
  "ConnectionStrings": {
    "SupabaseDb": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
  }
}
