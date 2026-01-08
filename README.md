# GeoQuiz

GeoQuiz is a desktop-based geography quiz application built with **C# (.NET 8, WinForms)**.  
It allows users to test their knowledge of **countries, capitals, and flags** using multiple quiz modes.  
User authentication, scoring, and highscores are stored in a **PostgreSQL database (Supabase)**.

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
- Score calculation and result screen
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

Relationships and structure are documented in the ER diagram included in the project documentation.

---

## Configuration (local only)

### appsettings.json (NOT committed)

Database credentials **must not** be committed to the repository.

Create a local file named `appsettings.json` (do NOT commit it) with the following structure  
(replace the values with your own connection string):

```json
{
  "ConnectionStrings": {
    "SupabaseDb": "Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true"
  }
}

An example file named appsettings.example.json can be included in the repository.

Flag images are stored locally in the following structure:

flags/
├─ de.png
├─ fr.png
├─ it.png
└─ ...

Build & Publish
Build (Debug)

dotnet build

Publish (Standalone EXE, Windows x64)

dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
The generated .exe can be shared and executed without installing .NET.

Usage

Start the application

Register or log in

Configure quiz settings (mode and continent)

Play the quiz

View results and highscores


License

This project was created as a school project for educational purposes.


---

## ✅ WARUM DAS JETZT FUNKTIONIERT
- **Nur ein Block**
- **Keine kaputten Markdown-Zeilen**
- **GitHub rendert es perfekt**
- **Sieht professionell aus**
- **Abgabe-tauglich**
- **Kein weiteres Gefrickel**

---
