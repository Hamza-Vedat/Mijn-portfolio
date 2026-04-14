// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Overzicht van alle spelers
// ======================================================

using System;                      
using System.Drawing;              
using System.Windows.Forms;       
using GameScoreApp.Controllers;   // Voor SpelerController (om data uit database te halen)
using GameScoreApp.Models;         // Voor Speler model (de klasse Speler)

namespace GameScoreApp.Views
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een formulier)
    // : Form: Dit is een Windows Form (een scherm)
    public partial class SpelerOverzichtForm : Form
    {
        // VARIABELEN (Controls op het scherm)
        // private: Alleen binnen deze klasse te gebruiken
        private DataGridView dgvSpelers;           // Tabel waarin de spelers worden getoond
        private Button btnToevoegen;              
        private Button btnBewerken;                
        private Button btnVerwijderen;             
        private Button btnTerug;                   
        private SpelerController spelerController; // Controller om data uit database te halen

        // CONSTRUCTOR (Wordt aangeroepen als het formulier wordt gemaakt)
        public SpelerOverzichtForm()
        {
            // Maak een nieuw SpelerController object aan
            spelerController = new SpelerController();

            // InitializeComponent: Maakt alle knoppen en de tabel aan
            InitializeComponent();

            // SetupFlappyBirdTheme: Stelt de kleuren in (Flappy Bird thema)
            SetupFlappyBirdTheme();

            // LoadSpelers: Haalt alle spelers uit de database en toont ze in de tabel
            LoadSpelers();
        }

        // INITIALIZECOMPONENT (Maakt het scherm)
        private void InitializeComponent()
        {
            // Instellingen voor het formulier zelf
            this.Text = "Overzicht Spelers - Flappy Bird";  
            this.Size = new Size(900, 600);               
            this.StartPosition = FormStartPosition.CenterScreen; 

            // DATAGRIDVIEW (Tabel met spelers)
            dgvSpelers = new DataGridView();
            dgvSpelers.Location = new Point(20, 50);        
            dgvSpelers.Size = new Size(840, 400);           
            dgvSpelers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dgvSpelers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    
            dgvSpelers.MultiSelect = false;                 // Alleen één rij tegelijk selecteren
            dgvSpelers.ReadOnly = true;                     // Gebruiker kan niets veranderen in de tabel
            dgvSpelers.AllowUserToAddRows = false;          // Gebruiker kan geen nieuwe rijen toevoegen

            // BUTTONS 
            btnToevoegen = CreateButton("➕ TOEVOEGEN", 150, 470);   
            btnBewerken = CreateButton("✏️ BEWERKEN", 350, 470);     
            btnVerwijderen = CreateButton("❌ VERWIJDEREN", 550, 470); 
            btnTerug = CreateButton("◀ TERUG", 750, 470);            

            // EVENTS 
            btnToevoegen.Click += BtnToevoegen_Click;    
            btnBewerken.Click += BtnBewerken_Click;      
            btnVerwijderen.Click += BtnVerwijderen_Click; 
            btnTerug.Click += (s, e) => this.Close();    

            // CONTROLS TOEVOEGEN 
            this.Controls.Add(dgvSpelers);       
            this.Controls.Add(btnToevoegen);   
            this.Controls.Add(btnBewerken);    
            this.Controls.Add(btnVerwijderen);  
            this.Controls.Add(btnTerug);        
        }
        // CREATEBUTTON
        // text: De tekst op de knop 
        // x: Horizontale positie (van links)
        // y: Verticale positie (van boven)
        private Button CreateButton(string text, int x, int y)
        {
            Button btn = new Button();                         
            btn.Text = text;                                   
            btn.Size = new Size(140, 40);                      
            btn.Location = new Point(x, y);                    // Zet de knop op de juiste plek
            btn.Font = new Font("Press Start 2P", 8, FontStyle.Regular); 
            btn.ForeColor = Color.White;                       
            btn.BackColor = Color.FromArgb(45, 106, 79);       
            btn.FlatStyle = FlatStyle.Flat;                    
            return btn;                                        // Geef de knop terug
        }

        // SETUPFLAPPYBIRDTHEME (Stelt de kleuren in)
        private void SetupFlappyBirdTheme()
        {
            this.BackColor = Color.FromArgb(78, 192, 233);

            // Tabel instellingen
            dgvSpelers.BackgroundColor = Color.White;           
            dgvSpelers.GridColor = Color.FromArgb(30, 58, 95); 
            dgvSpelers.DefaultCellStyle.Font = new Font("Arial", 10); 
            dgvSpelers.ColumnHeadersDefaultCellStyle.Font = new Font("Press Start 2P", 9); 
            dgvSpelers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 58, 95); 
            dgvSpelers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
        }
        // LOADSPELERS (Haalt spelers uit de database en toont ze)
        private void LoadSpelers()
        {
            // Haal alle spelers op via de controller
            var spelers = spelerController.GetAllSpelers();

            // Zet de spelers in de tabel (DataGridView)
            dgvSpelers.DataSource = null;      // Eerst leegmaken
            dgvSpelers.DataSource = spelers;   // Dan vullen met spelers

            // Verberg de ID kolom (gebruiker heeft die niet nodig)
            if (dgvSpelers.Columns.Contains("SpelerID"))
                dgvSpelers.Columns["SpelerID"].Visible = false;

            // Zet de kolomtitels in het Nederlands
            if (dgvSpelers.Columns.Contains("Voornaam"))
                dgvSpelers.Columns["Voornaam"].HeaderText = "Voornaam";
            if (dgvSpelers.Columns.Contains("Achternaam"))
                dgvSpelers.Columns["Achternaam"].HeaderText = "Achternaam";
            if (dgvSpelers.Columns.Contains("Email"))
                dgvSpelers.Columns["Email"].HeaderText = "Email";
            if (dgvSpelers.Columns.Contains("Geboortedatum"))
            {
                dgvSpelers.Columns["Geboortedatum"].HeaderText = "Geboortedatum";
                dgvSpelers.Columns["Geboortedatum"].DefaultCellStyle.Format = "dd-MM-yyyy";
            }
        }
        // TOEVOEGEN KNOP (Nieuwe speler toevoegen)
        private void BtnToevoegen_Click(object sender, EventArgs e)
        {
            // Open het toevoeg scherm
            SpelerToevoegenForm form = new SpelerToevoegenForm();

            // ShowDialog() toont het scherm als een pop-up
            // DialogResult.OK betekent dat de gebruiker op "OPSLAAN" heeft geklikt
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSpelers();  // Ververs de lijst (nieuwe speler is toegevoegd)
                MessageBox.Show("Speler succesvol toegevoegd!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // BEWERKEN KNOP (Geselecteerde speler bewerken)
        private void BtnBewerken_Click(object sender, EventArgs e)
        {
            // Controleer of er een speler is geselecteerd
            // CurrentRow: De rij die de gebruiker heeft geselecteerd
            if (dgvSpelers.CurrentRow != null)
            {
                // Haal de geselecteerde speler op uit de tabel
                Speler selected = (Speler)dgvSpelers.CurrentRow.DataBoundItem;

                // Open het bewerk scherm met de geselecteerde speler
                SpelerBewerkenForm form = new SpelerBewerkenForm(selected);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSpelers();  // Ververs de lijst (speler is gewijzigd)
                    MessageBox.Show("Speler succesvol bijgewerkt!", "Succes",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Geen speler geselecteerd
                MessageBox.Show("Selecteer eerst een speler!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // VERWIJDEREN KNOP (Geselecteerde speler verwijderen)
        private void BtnVerwijderen_Click(object sender, EventArgs e)
        {
            // Controleer of er een speler is geselecteerd
            if (dgvSpelers.CurrentRow != null)
            {
                // Haal de geselecteerde speler op
                Speler selected = (Speler)dgvSpelers.CurrentRow.DataBoundItem;

                // BEVESTIGINGSVRAAG (User Story: Verwijderen speler)
                // Vraag aan de gebruiker of hij/zij zeker is
                DialogResult result = MessageBox.Show(
                    $"Weet je zeker dat je speler '{selected.VolledigeNaam}' wilt verwijderen?\n\n" +
                    "Alle scores van deze speler worden ook verwijderd!",
                    "Bevestiging",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);  // Waarschuwingsicoon (geel driehoekje)

                // Als de gebruiker op "JA" klikt, verwijder dan de speler
                if (result == DialogResult.Yes)
                {
                    // Roep de DeleteSpeler methode aan in de controller
                    int rows = spelerController.DeleteSpeler(selected.SpelerID);

                    // rows is het aantal verwijderde rijen (1 = succes, 0 = mislukt)
                    if (rows > 0)
                    {
                        LoadSpelers();  // Ververs de lijst (speler is weg)
                        MessageBox.Show("Speler is verwijderd!", "Succes",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fout bij verwijderen speler.", "Fout",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Als de gebruiker op "NEE" klikt, gebeurt er niets
            }
            else
            {
                // Geen speler geselecteerd
                MessageBox.Show("Selecteer eerst een speler!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}