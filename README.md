GeoQuiz

GeoQuiz is a desktop-based geography quiz application built with C# (.NET 8, WinForms).
It allows users to test their knowledge of countries, capitals, and flags, including multiple quiz modes, user authentication, scoring, and highscores stored in a PostgreSQL database (Supabase).

Features

User registration and login (password hash + salt)

Quiz modes:

Flag to Country

Flag to Capital

Country to Capital

Country to Flag

Capital to Country

Capital to Flag

10 questions per quiz round

4 answer options per question

Immediate feedback after each answer

Score calculation

Highscores stored in PostgreSQL (Supabase)

Continent-based filtering

Flag images displayed directly inside answer buttons

Technologies

C# (.NET 8, WinForms)

PostgreSQL (Supabase)

Npgsql

Visual Studio 2022 or newer

Database

Core tables:

player

country

quiz_run

Configuration (local only)

Create a local file named appsettings.json (do NOT commit it).
Use this structure (replace the values with your own connection string):

ConnectionStrings
SupabaseDb = Host=...;Port=5432;Database=postgres;Username=...;Password=...;SSL Mode=Require;Trust Server Certificate=true

An example file named appsettings.example.json can be included in the repository.

Flags

Flag images are stored locally in the folder:
flags/

The database stores relative paths such as flags/de.png, which are resolved at runtime.

Build and Publish

Build:
dotnet build

Publish (Windows x64):
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

Usage

Start the application

Register or log in

Configure quiz settings (mode and continent)

Play the quiz

View results and highscores

License
This project was created as a school project for educational purposes.
