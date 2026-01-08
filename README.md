# GeoQuiz

GeoQuiz is a desktop-based geography quiz application built with C# (.NET 8, WinForms).
It allows users to test their knowledge of countries, capitals, and flags through multiple quiz modes.
The application includes user authentication, scoring, continent-based filtering, and persistent highscores stored in a PostgreSQL database (Supabase).

---

## Features

- User registration and login (password hash + salt)
- Multiple quiz modes:
  - Flag → Country
  - Flag → Capital
  - Country → Capital
  - Country → Flag
  - Capital → Country
  - Capital → Flag
- 10 questions per quiz round
- 4 answer options per question
- Immediate feedback after each answer
- Score calculation
- Highscores stored in PostgreSQL (Supabase)
- Continent-based filtering
- Flag images displayed directly inside answer buttons

---

## Technologies

- C# (.NET 8, WinForms)
- PostgreSQL (Supabase)
- Npgsql
- Visual Studio 2022 or newer

---

## Database

Core tables used by the application:

- player
- country
- quiz_run

Relationships and structure are documented in the ER diagram provided in the project documentation.

---

## Configuration (local only)

### appsettings.json (NOT committed)

Database credentials must NOT be committed to the repository.

Create a local file named `appsettings.json` with the following structure
(replace the values with your own connection string):

{
  "ConnectionStrings": {
    "SupabaseDb": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
  }
}

An example file named `appsettings.example.json` can be included in the repository.

---

## Flags

Flag images are stored locally in the following structure:

flags/
- de.png
- fr.png
- it.png
- ...

The database stores relative paths (e.g. `flags/de.png`), which are resolved at runtime.

---

## Build & Publish

### Build (Debug)

dotnet build

### Publish (Standalone EXE, Windows x64)

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

The generated `.exe` can be shared and executed without installing .NET.

---

## Usage

1. Start the application
2. Register or log in
3. Configure quiz settings (mode and continent)
4. Play the quiz
5. View results and highscores

---

## License

This project was created as a school project for educational purposes.
