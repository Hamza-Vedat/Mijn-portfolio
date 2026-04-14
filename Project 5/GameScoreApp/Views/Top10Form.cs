// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Top 10 hoogste scores
// ======================================================

using System;                      
using System.Drawing;              
using System.Windows.Forms;       
using GameScoreApp.Controllers;   // Voor ScoreController (om data uit database te halen)
using GameScoreApp.Models;         // Voor Score model (de klasse Score)

namespace GameScoreApp.Views
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een formulier)
    // : Form: Dit is een Windows Form (een scherm)
    public class Top10Form : Form
    {
        // VARIABELEN (Controls op het scherm)
        // private: Alleen binnen deze klasse te gebruiken
        private DataGridView dgvTop10;           // Tabel waarin de top 10 scores worden getoond
        private Button btnTerug;                 
        private ScoreController scoreController; // Controller om data uit database te halen

        // CONSTRUCTOR (Wordt aangeroepen als het formulier wordt gemaakt)
        public Top10Form()
        {
            // Maak een nieuw ScoreController object aan
            scoreController = new ScoreController();

            // InitializeComponent: Maakt de tabel en de knop aan
            InitializeComponent();

            // SetupFlappyBirdTheme: Stelt de kleuren in (Flappy Bird thema)
            SetupFlappyBirdTheme();

            // LoadTop10: Haalt de top 10 scores uit de database en toont ze
            LoadTop10();
        }

        // INITIALIZECOMPONENT (Maakt het scherm)
        private void InitializeComponent()
        {
            // Instellingen voor het formulier zelf
            this.Text = "Top 10 Scores - Flappy Bird";  
            this.Size = new Size(800, 550);            
            this.StartPosition = FormStartPosition.CenterScreen; 

            // DATAGRIDVIEW (Tabel met top 10 scores)
            dgvTop10 = new DataGridView();
            dgvTop10.Location = new Point(20, 50);        
            dgvTop10.Size = new Size(740, 400);           
            dgvTop10.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolommen vullen de breedte
            dgvTop10.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Hele rij selecteren
            dgvTop10.ReadOnly = true;                     
            dgvTop10.AllowUserToAddRows = false;        
            dgvTop10.RowHeadersVisible = false;           // Geen rijnummers tonen (we hebben zelf een kolom "Positie")

            // BUTTONS
            btnTerug = CreateButton("◀ TERUG", 620, 470); 

            // EVENTS
            btnTerug.Click += (s, e) => this.Close();  

            // CONTROLS TOEVOEGEN (Alles op het scherm zetten)=
            this.Controls.Add(dgvTop10);       // Tabel toevoegen
            this.Controls.Add(btnTerug);       // Terug knop toevoegen
        }

        // CREATEBUTTON 
        // text: De tekst op de knop (bijv. "◀ TERUG")
        // x: Horizontale positie (van links)
        // y: Verticale positie (van boven)
        private Button CreateButton(string text, int x, int y)
        {
            Button btn = new Button();                       
            btn.Text = text;                                   // Zet de tekst op de knop
            btn.Size = new Size(140, 40);                     
            btn.Location = new Point(x, y);                    // Zet de knop op de juiste plek
            btn.Font = new Font("Press Start 2P", 8, FontStyle.Regular);
            btn.ForeColor = Color.White;                     
            btn.BackColor = Color.FromArgb(45, 106, 79);     
            return btn;                                        // Geef de knop terug
        }

        // SETUPFLAPPYBIRDTHEME 
        private void SetupFlappyBirdTheme()
        {
            // Achtergrond van het formulier
            this.BackColor = Color.FromArgb(78, 192, 233);

            // Tabel instellingen
            dgvTop10.BackgroundColor = Color.White;         
            dgvTop10.GridColor = Color.FromArgb(30, 58, 95); 
            dgvTop10.DefaultCellStyle.Font = new Font("Arial", 10); 
            dgvTop10.ColumnHeadersDefaultCellStyle.Font = new Font("Press Start 2P", 9); 
            dgvTop10.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95); 
            dgvTop10.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
        }

        // LOADTOP10 (Haalt de top 10 scores uit de database en toont ze)
        private void LoadTop10()
        {
            // Haal de top 10 scores op via de controller
            // GetTop10Scores() geeft een lijst van Score objecten terug
            var scores = scoreController.GetTop10Scores();

            // MAAK EEN DATATABLE (tijdelijke tabel in het geheugen)
            // DataTable is handig omdat we een extra kolom "Positie" kunnen toevoegen
            var dataTable = new System.Data.DataTable();

            // Kolommen toevoegen
            dataTable.Columns.Add("Positie", typeof(int));    // Positie (1, 2, 3, ...)
            dataTable.Columns.Add("Speler", typeof(string));  
            dataTable.Columns.Add("Score", typeof(int));      
            dataTable.Columns.Add("Datum", typeof(DateTime)); 

            // VUL DE DATATABLE MET DE TOP 10 SCORES
            int positie = 1;  // Begin bij 1

            // foreach: Loop door alle scores in de lijst
            // score: Het huidige Score object in de loop
            foreach (Score score in scores)
            {
                // Voeg een nieuwe rij toe aan de DataTable
                // positie++: Eerst de waarde gebruiken, dan +1 doen
                // score.SpelerNaam: De naam van de speler
                // score.ScoreValue: Het aantal punten
                // score.Datum: De datum van de score
                dataTable.Rows.Add(positie++, score.SpelerNaam, score.ScoreValue, score.Datum);
            }

            // TOON DE DATATABLE IN DE DATAGRIDVIEW
            dgvTop10.DataSource = dataTable;  // Koppel de DataTable aan de tabel op het scherm

            dgvTop10.Columns["Datum"].DefaultCellStyle.Format = "dd-MM-yyyy";
        }
    }
}