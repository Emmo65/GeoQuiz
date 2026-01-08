# GeoQuiz

GeoQuiz is a desktop-based geography quiz application built with **C# (.NET 8, WinForms)**.  
It allows users to test their knowledge of **countries, capitals, and flags**, with multiple quiz modes, user accounts, scoring, and highscores stored in a PostgreSQL database (Supabase).

---

## Features

- User registration & login  
  - Secure password handling (hash + salt)
- Multiple quiz modes:
  - Flag → Country
  - Flag → Capital
  - Country → Capital
  - Country → Flag
  - Capital → Country
  - Capital → Flag
- 10 questions per quiz round
- 4 answer options per question
- Immediate feedback (correct / wrong)
- Score calculation
- Highscore list stored in database
- Continent-based filtering
- Flag images displayed directly inside answer buttons

---

## Technologies

- **C# / .NET 8 (WinForms)**
- **PostgreSQL (Supabase)**
- **Npgsql**
- Visual Studio 2022+

---

## Project Structure (Short Overview)

- `Forms`
  - `LoginForm`
  - `SetupForm`
  - `QuizForm`
  - `ResultForm`
  - `HighscoreForm`
- `Data`
  - Repositories (Country, Player, QuizRun)
- `Logic`
  - QuizEngine
- `Models`
  - Country, Player, QuizQuestion, QuizSettings
- `Security`
  - PasswordHasher

---

## Database

The application uses a PostgreSQL database with (among others) the following tables:

- `player`
- `country`
- `quiz_run`

Relationships and structure are documented in the ER diagram provided in the project documentation.

---

## Configuration

### appsettings.json (NOT committed)

Database credentials must **not** be committed.

Create a local `appsettings.json` file based on the example below:

```json
{
  "ConnectionStrings": {
    "SupabaseDb": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
  }
}
An example file (appsettings.example.json) is included in the repository.

Flags
Flag images are stored locally:


flags/
 ├─ de.png
 ├─ fr.png
 ├─ it.png
 └─ ...
The database stores relative paths (e.g. flags/de.png), which are resolved at runtime.

Build & Publish
Build (Debug)


dotnet build
Publish (Standalone EXE, Windows x64)
bash
Code kopieren
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
The generated .exe can be shared and run without installing .NET.

Usage
Start the application

Register or log in

Configure quiz settings (mode, continent)

Play the quiz

View results and highscores

License
This project was created as a school project for educational purposes.



---

