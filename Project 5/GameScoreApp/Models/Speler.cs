// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Model class voor Speler
// ======================================================

using System; 

namespace GameScoreApp.Models
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een speler)
    public class Speler
    {
        // PROPERTIES (Eigenschappen van een speler)
        // get; set; = we kunnen de waarde lezen (get) en veranderen (set)
        // Dit is de C# manier om variabelen te maken die je van buitenaf kunt gebruiken

        public string SpelerID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public DateTime Geboortedatum { get; set; }

        public string VolledigeNaam
        {
            get { return Voornaam + " " + Achternaam; }
        }
    }
}