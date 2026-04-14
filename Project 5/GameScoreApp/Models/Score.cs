// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Model class voor Score
// ======================================================

using System; 

namespace GameScoreApp.Models
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een score)
    public class Score
    {
        // PROPERTIES (Eigenschappen van een score)
        // get; set; = we kunnen de waarde lezen (get) en veranderen (set)
        // Dit is de C# manier om variabelen te maken die je van buitenaf kunt gebruiken

        // INT in de database, IDENTITY(1,1) → past in int in C#
        public int ScoreID { get; set; }
        // Dit is een FOREIGN KEY naar Speler.SpelerID
        public string SpelerID { get; set; }
        public int ScoreValue { get; set; }
        public DateTime Datum { get; set; }

        // SpelerNaam: De volledige naam van de speler (voornaam + achternaam)
        // Deze komt uit de database via een JOIN met de Speler tabel
        public string SpelerNaam { get; set; }
        // ScoreWeergave: Geeft de score als string
        // Handig voor in de listview (alleen tekst, geen getal)
        public string ScoreWeergave
        {
            get { return ScoreValue.ToString(); }
        }
    }
}