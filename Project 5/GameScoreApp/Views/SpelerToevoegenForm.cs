// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Speler toevoegen formulier
// ======================================================

using System;                      
using System.Drawing;             
using System.Windows.Forms;       
using GameScoreApp.Controllers;   // Voor SpelerController (om data in database te zetten)
using GameScoreApp.Models;         // Voor Speler model (de klasse Speler)

namespace GameScoreApp.Views
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een formulier)
    // : Form: Dit is een Windows Form (een scherm)
    public partial class SpelerToevoegenForm : Form
    {
        // VARIABELEN (Controls op het scherm)
        // private: Alleen binnen deze klasse te gebruiken
        private TextBox txtSpelerID;        
        private TextBox txtVoornaam;        
        private TextBox txtAchternaam;      
        private TextBox txtEmail;           
        private DateTimePicker dtpGeboortedatum; 
        private Button btnOpslaan;          
        private Button btnAnnuleren;        
        private SpelerController controller; 

        // CONSTRUCTOR (Wordt aangeroepen als het formulier wordt gemaakt)
        public SpelerToevoegenForm()
        {
            // Maak een nieuw SpelerController object aan
            controller = new SpelerController();

            // InitializeComponent: Maakt alle invoervelden en knoppen aan
            InitializeComponent();

            // SetupFlappyBirdTheme
            SetupFlappyBirdTheme();
        }
        // INITIALIZECOMPONENT (Maakt het scherm)
        private void InitializeComponent()
        {
            // Instellingen voor het formulier zelf
            this.Text = "Speler Toevoegen - Flappy Bird";  
            this.Size = new Size(500, 450);               
            this.StartPosition = FormStartPosition.CenterParent; // Midden boven het parent venster
            this.FormBorderStyle = FormBorderStyle.FixedDialog;  // Kan niet worden vergroot/verkleind                 

            // SPELERID (Invoerveld)
            Label lblSpelerID = new Label()
            {
                Text = "SpelerID:",
                Location = new Point(30, 30),
                Size = new Size(120, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            // TextBox: waarin de gebruiker de SpelerID kan typen
            txtSpelerID = new TextBox()
            {
                Location = new Point(150, 30),
                Size = new Size(280, 25)
            };
            // VOORNAAM 
            Label lblVoornaam = new Label()
            {
                Text = "Voornaam:",
                Location = new Point(30, 70),
                Size = new Size(120, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            txtVoornaam = new TextBox()
            {
                Location = new Point(150, 70),
                Size = new Size(280, 25)
            };
            // ACHTERNAAM
            Label lblAchternaam = new Label()
            {
                Text = "Achternaam:",
                Location = new Point(30, 110),
                Size = new Size(120, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            txtAchternaam = new TextBox()
            {
                Location = new Point(150, 110),
                Size = new Size(280, 25)
            };
            // EMAIL
            Label lblEmail = new Label()
            {
                Text = "Email:",
                Location = new Point(30, 150),
                Size = new Size(120, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            txtEmail = new TextBox()
            {
                Location = new Point(150, 150),
                Size = new Size(280, 25)
            };
            // GEBOORTEDATUM
            Label lblGeboortedatum = new Label()
            {
                Text = "Geboortedatum:",
                Location = new Point(30, 190),
                Size = new Size(120, 25),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            dtpGeboortedatum = new DateTimePicker()
            {
                Location = new Point(150, 190),
                Size = new Size(280, 25),
                Format = DateTimePickerFormat.Short,  
                MaxDate = DateTime.Now                // Geen toekomstige datums
            };

            // BUTTONS 
            btnOpslaan = new Button()
            {
                Text = "OPSLAAN",
                Location = new Point(120, 260),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(45, 106, 79), 
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnAnnuleren = new Button()
            {
                Text = "ANNULEREN",
                Location = new Point(260, 260),
                Size = new Size(100, 40),
                BackColor = Color.FromArgb(45, 106, 79),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // EVENTS 
            btnOpslaan.Click += BtnOpslaan_Click;
            btnAnnuleren.Click += (s, e) => this.DialogResult = DialogResult.Cancel; 

            // CONTROLS TOEVOEGEN (Alles op het scherm zetten)

            this.Controls.Add(lblSpelerID);
            this.Controls.Add(txtSpelerID);
            this.Controls.Add(lblVoornaam);
            this.Controls.Add(txtVoornaam);
            this.Controls.Add(lblAchternaam);
            this.Controls.Add(txtAchternaam);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblGeboortedatum);
            this.Controls.Add(dtpGeboortedatum);
            this.Controls.Add(btnOpslaan);
            this.Controls.Add(btnAnnuleren);
        }

        // SETUPFLAPPYBIRDTHEME
        private void SetupFlappyBirdTheme()
        {
            this.BackColor = Color.FromArgb(78, 192, 233);
        }

        // OPSLAAN KNOP (Nieuwe speler toevoegen)
        private void BtnOpslaan_Click(object sender, EventArgs e)
        {
            // VALIDATIE (Controleer of alle velden correct zijn ingevuld)
            // SpelerID mag niet leeg zijn
            if (string.IsNullOrWhiteSpace(txtSpelerID.Text))
            {
                MessageBox.Show("SpelerID mag niet leeg zijn!", "Validatie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Stop hier, ga niet verder
            }

            // Voornaam mag niet leeg zijn
            if (string.IsNullOrWhiteSpace(txtVoornaam.Text))
            {
                MessageBox.Show("Voornaam mag niet leeg zijn!", "Validatie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Achternaam mag niet leeg zijn
            if (string.IsNullOrWhiteSpace(txtAchternaam.Text))
            {
                MessageBox.Show("Achternaam mag niet leeg zijn!", "Validatie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email mag niet leeg zijn en moet een @ bevatten
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email is verplicht en moet een '@' teken bevatten!", "Validatie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // MAAK EEN NIEUW SPELER OBJECT MET DE INGEVULDE GEGEVENS=
            Speler speler = new Speler
            {
                SpelerID = txtSpelerID.Text.Trim(),           // Verwijder spaties voor/na
                Voornaam = txtVoornaam.Text.Trim(),           // Verwijder spaties voor/na
                Achternaam = txtAchternaam.Text.Trim(),       // Verwijder spaties voor/na
                Email = txtEmail.Text.Trim(),                 // Verwijder spaties voor/na
                Geboortedatum = dtpGeboortedatum.Value        // Geselecteerde datum
            };
            // SLA DE NIEUWE SPELER OP IN DE DATABASE
            int result = controller.AddSpeler(speler);

            // result is het aantal toegevoegde rijen (1 = succes, 0 = mislukt)
            if (result > 0)
            {
                // Succes: toon een melding en sluit het formulier
                MessageBox.Show("Speler succesvol toegevoegd!", "Succes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;  // Vertel het parent venster: "het is gelukt"
                this.Close();                         // Sluit dit formulier
            }
            else
            {
                // Fout: toon een foutmelding (SpelerID bestaat waarschijnlijk al)
                MessageBox.Show("Fout bij toevoegen speler. SpelerID bestaat mogelijk al.", "Fout",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}