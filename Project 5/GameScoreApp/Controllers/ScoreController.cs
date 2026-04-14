// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Controller voor Score (CRUD operaties)
// ======================================================

// using: Dit zijn bibliotheken (kant-en-klare code van C#)
using System;                      
using System.Collections.Generic;  // Voor List<> (lijsten van objecten)
using System.Data.SqlClient;       // Voor verbinding met SQL Server (ADO.NET)
using GameScoreApp.Models;         

namespace GameScoreApp.Controllers
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor objecten)
    public class ScoreController
    {
        // CONNECTION STRING (Verbindingsinformatie voor de database)
        // private: Alleen binnen deze klasse te gebruiken
        // static: Wordt één keer aangemaakt, niet steeds opnieuw
        // @: Zorgt dat we backslashes (\) kunnen gebruiken zonder problemen

        private static string connectionString = @"Data Source=HamzaVedat\SQLEXPRESS;Initial Catalog=GameScoreDB;Integrated Security=True;TrustServerCertificate=True";
       
        // TrustServerCertificate=True        → Sla certificaatcontrole over (voor testen)


        // ALLE SCORES OPHALEN (SELECT * FROM Score)
        // public: Deze methode is overal te gebruiken
        // List<Score>: Geeft een lijst van Score objecten terug
        public List<Score> GetAllScores()
        {
            // Maak een lege lijst aan waar we alle scores in stoppen
            List<Score> scores = new List<Score>();

            // SQL query: Haal alle scores op met de naam van de speler erbij
            // INNER JOIN: Koppelt de Score tabel aan de Speler tabel via SpelerID
            // ORDER BY s.Datum DESC: Nieuwste scores eerst
            string sqlQuery = @"SELECT s.ScoreID, s.SpelerID, s.ScoreValue, s.Datum, 
                                        sp.Voornaam + ' ' + sp.Achternaam AS SpelerNaam
                                 FROM Score s
                                 INNER JOIN Speler sp ON s.SpelerID = sp.SpelerID
                                 ORDER BY s.Datum DESC";

            // using: Zorgt dat de verbinding automatisch wordt gesloten
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();  // Open de verbinding met de database

                    using (SqlDataReader reader = command.ExecuteReader())  // Voer de query uit
                    {
                        // while: Lees elke rij één voor één
                        while (reader.Read())
                        {
                            // Maak een nieuw Score object aan
                            Score score = new Score();

                            // Vul het object met de gegevens uit de database
                            score.ScoreID = (int)reader["ScoreID"];           
                            score.SpelerID = (string)reader["SpelerID"];     
                            score.ScoreValue = (int)reader["ScoreValue"];     
                            score.Datum = (DateTime)reader["Datum"];          
                            score.SpelerNaam = (string)reader["SpelerNaam"];  

                            // Voeg het object toe aan de lijst
                            scores.Add(score);
                        }
                    }
                }
            }

            // Geef de lijst met scores terug
            return scores;
        }

        // TOP 10 SCORES OPHALEN (Hoogste scores)
        // SELECT TOP 10: Haalt alleen de 10 hoogste scores op
        // ORDER BY s.ScoreValue DESC: Sorteer van hoog naar laag
        public List<Score> GetTop10Scores()
        {
            List<Score> scores = new List<Score>();

            string sqlQuery = @"SELECT TOP 10 s.ScoreID, s.SpelerID, s.ScoreValue, s.Datum, 
                                        sp.Voornaam + ' ' + sp.Achternaam AS SpelerNaam
                                 FROM Score s
                                 INNER JOIN Speler sp ON s.SpelerID = sp.SpelerID
                                 ORDER BY s.ScoreValue DESC";  // Sorteer op score (hoogste eerst)

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Score score = new Score();
                            score.ScoreID = (int)reader["ScoreID"];
                            score.SpelerID = (string)reader["SpelerID"];
                            score.ScoreValue = (int)reader["ScoreValue"];
                            score.Datum = (DateTime)reader["Datum"];
                            score.SpelerNaam = (string)reader["SpelerNaam"];

                            scores.Add(score);
                        }
                    }
                }
            }

            return scores;
        }

        //SCORES VAN EEN SPECIFIEKE SPELER
        // spelerID: De ID van de speler waarvan we scores willen zien
        // WHERE s.SpelerID = '{spelerID}': Alleen scores van die speler
        public List<Score> GetScoresBySpeler(string spelerID)
        {
            List<Score> scores = new List<Score>();

            // $: Zorgt dat we {spelerID} kunnen gebruiken in de string
            string sqlQuery = $@"SELECT s.ScoreID, s.SpelerID, s.ScoreValue, s.Datum, 
                                        sp.Voornaam + ' ' + sp.Achternaam AS SpelerNaam
                                 FROM Score s
                                 INNER JOIN Speler sp ON s.SpelerID = sp.SpelerID
                                 WHERE s.SpelerID = '{spelerID}'      -- Alleen deze speler
                                 ORDER BY s.Datum DESC"; //--Nieuwste eerst

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Score score = new Score();
                            score.ScoreID = (int)reader["ScoreID"];
                            score.SpelerID = (string)reader["SpelerID"];
                            score.ScoreValue = (int)reader["ScoreValue"];
                            score.Datum = (DateTime)reader["Datum"];
                            score.SpelerNaam = (string)reader["SpelerNaam"];

                            scores.Add(score);
                        }
                    }
                }
            }

            return scores;
        }
        // CREATE: NIEUWE SCORE TOEVOEGEN (INSERT)
        // score: Het Score object dat we willen toevoegen
        // return: Aantal rijen dat is toegevoegd (1 = succes, 0 = mislukt)
        public int AddScore(Score score)
        {
            // INSERT INTO: Voeg een nieuwe rij toe aan de Score tabel
            string sqlQuery = $"INSERT INTO Score (SpelerID, ScoreValue, Datum) VALUES ('{score.SpelerID}', {score.ScoreValue}, '{score.Datum.ToString("yyyy-MM-dd")}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();  // Geeft aantal rijen terug (1 of 0)
                }
            }
        }

        // UPDATE: SCORE BIJWERKEN (UPDATE)
        // score: Het Score object met de nieuwe waarden
        // WHERE ScoreID={score.ScoreID}: Alleen de score met deze ID wordt bijgewerkt
        public int UpdateScore(Score score)
        {
            string sqlQuery = $"UPDATE Score SET ScoreValue={score.ScoreValue}, Datum='{score.Datum.ToString("yyyy-MM-dd")}' WHERE ScoreID={score.ScoreID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();  // Geeft aantal rijen terug (1 of 0)
                }
            }
        }

        // DELETE: SCORE VERWIJDEREN (DELETE)
        // scoreID: De ID van de score die we willen verwijderen
        // WHERE ScoreID={scoreID}: Alleen de score met deze ID wordt verwijderd
        public int DeleteScore(int scoreID)
        {
            string sqlQuery = $"DELETE FROM Score WHERE ScoreID={scoreID}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();  // Geeft aantal rijen terug (1 of 0)
                }
            }
        }
    }
}