🎮 GameScore – Flappy Bird Score Tracker
Schoolproject | Koning Willem I College | Project Basis Standalone

📝 Projectbeschrijving
Ik heb een C# Windows Forms applicatie ontwikkeld voor een game ontwikkelaar. 
De applicatie houdt scores bij van spelers voor de game Flappy Bird. Wat eerst in Excel werd bijgehouden, is nu een volledige database-applicatie met gebruikersrollen en rechtenbeheer. 
De applicatie heeft een herkenbare Flappy Bird stijl met gele kleuren en pixelachtige elementen.

🎯 Doelen
Een goede database opzetten met rollen en rechten
Een C# Forms applicatie maken met MVC-structuur
Data inladen vanuit database met ADO.NET
CRUD-functionaliteiten realiseren voor spelers en scores

🛠️ Gebruikte technieken
C# Windows Forms
ADO.NET voor databasecommunicatie
Microsoft SQL Server
MVC architectuur
DevOps (Agile/Scrum)

🗃️ Database
De database bevat twee tabellen:
Speler – SpelerID (PK), voornaam, achternaam, email, geboortedatum
Score – ScoreID (PK), SpelerID (FK), ScoreValue, Datum

🔐 Rollen en rechten
Role	Rechten
Admin	Alles bekijken, toevoegen, wijzigen en verwijderen
Playeradmin	Alles bekijken, spelers beheren (geen scores aanpassen)
Reader	Alleen bekijken

📱 Functionaliteiten
Startscherm met menu
Overzicht van alle spelers (CRUD)
Overzicht van alle scores (CRUD)
Top 10 scores
Scores van specifieke speler bekijken (versneld)

📁 Documentatie
Data-analyse (Datadictionary / ERD / NORMA)
CREATE, INSERT, BEHEER en BACKUP scripts
Schetsen in Flappy Bird stijl
DevOps met user stories

▶️ Uitvoeren
Open de solution in Visual Studio
Voer de CREATE- en INSERT-scripts uit in SQL Server
Voer het BEHEER-script uit voor rollen en rechten
Build en run de applicatie
