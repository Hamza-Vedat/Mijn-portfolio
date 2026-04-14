// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Controller voor Speler (CRUD operaties)
// ======================================================

// using: Dit zijn bibliotheken
using System;                      
using System.Collections.Generic;  
using System.Data.SqlClient;       // Voor verbinding met SQL Server (ADO.NET)
using GameScoreApp.Models;         // Voor het Speler model (de klasse Speler)

namespace GameScoreApp.Controllers
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor objecten)
    public class SpelerController
    {
        // CONNECTION STRING (Verbindingsinformatie voor de database)
        // private: Alleen binnen deze klasse te gebruiken
        // static: Wordt één keer aangemaakt, niet steeds opnieuw
        // @: Zorgt dat we backslashes (\) kunnen gebruiken zonder problemen

        private static string connectionString = @"Data Source=HamzaVedat\SQLEXPRESS;Initial Catalog=GameScoreDB;Integrated Security=True;TrustServerCertificate=True";
        
        // TrustServerCertificate=True        → Sla certificaatcontrole over (voor testen)

        // ALLE SPELERS OPHALEN (SELECT * FROM Speler)
        // public: Deze methode is overal te gebruiken
        // List<Speler>: Geeft een lijst van Speler objecten terug
        public List<Speler> GetAllSpelers()
        {
            // Maak een lege lijst aan waar we alle spelers in stoppen
            List<Speler> spelers = new List<Speler>();

            // SQL query: Haal alle spelers op, gesorteerd op voornaam
            // ORDER BY Voornaam: Sorteer alfabetisch op voornaam
            string sqlQuery = "SELECT SpelerID, Voornaam, Achternaam, Email, Geboortedatum FROM Speler ORDER BY Voornaam";

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
                            // Maak een nieuw Speler object aan
                            Speler speler = new Speler();

                            // Vul het object met de gegevens uit de database
                            speler.SpelerID = (string)reader["SpelerID"];           
                            speler.Voornaam = (string)reader["Voornaam"];           
                            speler.Achternaam = (string)reader["Achternaam"];       
                            speler.Email = (string)reader["Email"];                 
                            speler.Geboortedatum = (DateTime)reader["Geboortedatum"]; 

                            // Voeg het object toe aan de lijst
                            spelers.Add(speler);
                        }
                    }
                }
            }

            // Geef de lijst met spelers terug
            return spelers;
        }
        // CREATE: NIEUWE SPELER TOEVOEGEN (INSERT)
        // speler: Het Speler object dat we willen toevoegen
        // return: Aantal rijen dat is toegevoegd (1 = succes, 0 = mislukt)
        public int AddSpeler(Speler speler)
        {
            // INSERT INTO: Voeg een nieuwe rij toe aan de Speler tabel
            // {speler.SpelerID}: De waarde die de gebruiker heeft ingevuld
            // .ToString("yyyy-MM-dd"): Datum in het formaat dat SQL Server begrijpt
            string sqlQuery = $"INSERT INTO Speler (SpelerID, Voornaam, Achternaam, Email, Geboortedatum) VALUES ('{speler.SpelerID}', '{speler.Voornaam}', '{speler.Achternaam}', '{speler.Email}', '{speler.Geboortedatum.ToString("yyyy-MM-dd")}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();  // Geeft aantal rijen terug (1 of 0)
                }
            }
        }
        // UPDATE: SPELER BIJWERKEN (UPDATE)
        // speler: Het Speler object met de nieuwe waarden
        // WHERE SpelerID='{speler.SpelerID}': Alleen de speler met deze ID wordt bijgewerkt
        public int UpdateSpeler(Speler speler)
        {
            // UPDATE: Wijzig een bestaande rij in de Speler tabel
            string sqlQuery = $"UPDATE Speler SET Voornaam='{speler.Voornaam}', Achternaam='{speler.Achternaam}', Email='{speler.Email}', Geboortedatum='{speler.Geboortedatum.ToString("yyyy-MM-dd")}' WHERE SpelerID='{speler.SpelerID}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();  // Geeft aantal rijen terug (1 of 0)
                }
            }
        }

        // DELETE: SPELER VERWIJDEREN (DELETE)
        // spelerID: De ID van de speler die we willen verwijderen
        // WHERE SpelerID='{spelerID}': Alleen de speler met deze ID wordt verwijderd
        public int DeleteSpeler(string spelerID)
        {
            string sqlQuery = $"DELETE FROM Speler WHERE SpelerID='{spelerID}'";

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