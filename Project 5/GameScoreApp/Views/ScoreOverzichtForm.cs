// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Overzicht van alle scores
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
    public class ScoreOverzichtForm : Form
    {
        // VARIABELEN (Controls op het scherm)
        // private: Alleen binnen deze klasse te gebruiken
        private DataGridView dgvScores;      // Tabel waarin de scores worden getoond
        private Button btnToevoegen;         
        private Button btnBewerken;           
        private Button btnVerwijderen;        
        private Button btnTerug;             
        private ScoreController scoreController; // Controller om data uit database te halen

        // CONSTRUCTOR (Wordt aangeroepen als het formulier wordt gemaakt)
        public ScoreOverzichtForm()
        {
            // Maak een nieuw ScoreController object aan
            scoreController = new ScoreController();

            // InitializeComponent: Maakt alle knoppen en de tabel aan
            InitializeComponent();

            // SetupFlappyBirdTheme: Stelt de kleuren in (Flappy Bird thema)
            SetupFlappyBirdTheme();

            // LoadScores: Haalt alle scores uit de database en toont ze in de tabel
            LoadScores();
        }

        // INITIALIZECOMPONENT (Maakt het scherm)
        private void InitializeComponent()
        {
            // Instellingen voor het formulier zelf
            this.Text = "Overzicht Scores - Flappy Bird";  
            this.Size = new Size(900, 600);               
            this.StartPosition = FormStartPosition.CenterScreen;

            // DATAGRIDVIEW (Tabel met scores)
            dgvScores = new DataGridView();
            dgvScores.Location = new Point(20, 50);        
            dgvScores.Size = new Size(840, 400);           
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Kolommen vullen de breedte
            dgvScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Hele rij selecteren
            dgvScores.MultiSelect = false;                 // Alleen één rij tegelijk selecteren
            dgvScores.ReadOnly = true;                     // Gebruiker kan niets veranderen in de tabel
            dgvScores.AllowUserToAddRows = false;          // Gebruiker kan geen nieuwe rijen toevoegen

            // BUTTONS (Knoppen)
            btnToevoegen = CreateButton("➕ TOEVOEGEN", 150, 470);   
            btnBewerken = CreateButton("✏️ BEWERKEN", 350, 470);     
            btnVerwijderen = CreateButton("❌ VERWIJDEREN", 550, 470); 
            btnTerug = CreateButton("◀ TERUG", 750, 470);            

            // EVENTS
            btnToevoegen.Click += BtnToevoegen_Click;    
            btnBewerken.Click += BtnBewerken_Click;      
            btnVerwijderen.Click += BtnVerwijderen_Click; 
            btnTerug.Click += (s, e) => this.Close();    

            // CONTROLS TOEVOEGEN (Alles op het scherm zetten)
            this.Controls.Add(dgvScores);       // Tabel toevoegen
            this.Controls.Add(btnToevoegen);    // Toevoegen knop toevoegen
            this.Controls.Add(btnBewerken);     // Bewerken knop toevoegen
            this.Controls.Add(btnVerwijderen);  // Verwijderen knop toevoegen
            this.Controls.Add(btnTerug);        // Terug knop toevoegen
        }

        // CREATEBUTTON (Maakt een knop aan met het Flappy Bird thema)
        // text: De tekst op de knop (bijv. "TOEVOEGEN")
        // x: Horizontale positie (van links)
        // y: Verticale positie (van boven)
        private Button CreateButton(string text, int x, int y)
        {
            Button btn = new Button();                         // Maak een nieuwe knop
            btn.Text = text;                                   // Zet de tekst op de knop
            btn.Size = new Size(140, 40);                      
            btn.Location = new Point(x, y);                    // Zet de knop op de juiste plek
            btn.Font = new Font("Press Start 2P", 8, FontStyle.Regular); 
            btn.ForeColor = Color.White;                       
            btn.BackColor = Color.FromArgb(45, 106, 79);       
            btn.FlatStyle = FlatStyle.Flat;                    
            return btn;                                        // Geef de knop terug
        }

        // SETUPFLAPPYBIRDTHEME 
        private void SetupFlappyBirdTheme()
        {
            // Achtergrond van het formulier
            this.BackColor = Color.FromArgb(78, 192, 233);

            // Tabel instellingen
            dgvScores.BackgroundColor = Color.White;           
            dgvScores.GridColor = Color.FromArgb(30, 58, 95); 
            dgvScores.DefaultCellStyle.Font = new Font("Arial", 10); 
            dgvScores.ColumnHeadersDefaultCellStyle.Font = new Font("Press Start 2P", 9); 
            dgvScores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95); 
            dgvScores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
        }

        // LOADSCORES (Haalt scores uit de database en toont ze)
        private void LoadScores()
        {
            // Haal alle scores op via de controller
            var scores = scoreController.GetAllScores();

            // Zet de scores in de tabel (DataGridView)
            dgvScores.DataSource = null;      // Eerst leegmaken
            dgvScores.DataSource = scores;    // Dan vullen met scores

            // KOLOMNAMEN IN HET NEDERLANDS (gebruikersvriendelijk)
            // Verberg de ID kolommen (gebruiker heeft die niet nodig)
            if (dgvScores.Columns.Contains("ScoreID"))
                dgvScores.Columns["ScoreID"].Visible = false;
            if (dgvScores.Columns.Contains("SpelerID"))
                dgvScores.Columns["SpelerID"].Visible = false;

            // Zet de kolomtitels in het Nederlands
            if (dgvScores.Columns.Contains("SpelerNaam"))
                dgvScores.Columns["SpelerNaam"].HeaderText = "Speler";
            if (dgvScores.Columns.Contains("ScoreValue"))
                dgvScores.Columns["ScoreValue"].HeaderText = "Score";
            if (dgvScores.Columns.Contains("Datum"))
            {
                dgvScores.Columns["Datum"].HeaderText = "Datum";
                // Zet de datum in Nederlands formaat (dd-mm-yyyy)
                dgvScores.Columns["Datum"].DefaultCellStyle.Format = "dd-MM-yyyy";
            }
        }

        // BUTTON CLICK EVENTS
        // TOEVOEGEN knop: Toont een melding (nog niet gemaakt)
        private void BtnToevoegen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Score toevoegen komt later!", "Info");
        }

        // BEWERKEN knop: Check of er een score geselecteerd is
        private void BtnBewerken_Click(object sender, EventArgs e)
        {
            // CurrentRow: De rij die de gebruiker heeft geselecteerd
            if (dgvScores.CurrentRow != null)  // Er is een score geselecteerd
            {
                MessageBox.Show("Score bewerken komt later!", "Info");
            }
            else  // Geen score geselecteerd
            {
                MessageBox.Show("Selecteer eerst een score!", "Info");
            }
        }

        // VERWIJDEREN knop: Check of er een score geselecteerd is
        private void BtnVerwijderen_Click(object sender, EventArgs e)
        {
            if (dgvScores.CurrentRow != null)  // Er is een score geselecteerd
            {
                MessageBox.Show("Score verwijderen komt later!", "Info");
            }
            else  // Geen score geselecteerd
            {
                MessageBox.Show("Selecteer eerst een score!", "Info");
            }
        }
    }
}