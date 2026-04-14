// ======================================================
// Auteur:           Hamza Oraloglu
// Aanmaakdatum:     30-03-2026
// Omschrijving:     Startscherm met menu (Flappy Bird thema)
// ======================================================

using System;                    
using System.Drawing;              
using System.Windows.Forms;       // Voor Windows Forms (buttons, labels, etc.)
using GameScoreApp.Controllers;   // Niet direct nodig, maar voor als we later data nodig hebben

namespace GameScoreApp.Views
{
    // public: Deze klasse is overal in het project te gebruiken
    // class: Dit is een klasse (een blauwdruk voor een formulier)
    // : Form: Dit is een Windows Form (een scherm)
    public partial class StartForm : Form
    {
        // VARIABELEN (Controls op het scherm)
        // private: Alleen binnen deze klasse te gebruiken
        private Button btnStart;           
        private Button btnSpelers;         
        private Button btnScores;          
        private Button btnTop10;           
        private Button btnAfsluiten;       
        private Label lblTitle;            
        private Label lblSubTitle;         

        // CONSTRUCTOR (Wordt aangeroepen als het formulier wordt gemaakt)
        public StartForm()
        {
            // InitializeComponent: Maakt alle knoppen en labels aan
            InitializeComponent();

            // SetupFlappyBirdTheme: Stelt de kleuren in (Flappy Bird thema)
            SetupFlappyBirdTheme();
        }
        // INITIALIZECOMPONENT (Maakt het scherm)
        private void InitializeComponent()
        {
            // Instellingen voor het formulier zelf
            this.Text = "GameScore - Flappy Bird";  
            this.Size = new Size(800, 600);        
            this.StartPosition = FormStartPosition.CenterScreen; // Midden op het scherm
            this.FormBorderStyle = FormBorderStyle.FixedSingle;  // Kan niet worden vergroot/verkleind

            // TITEL (FLAPPY BIRD)
            lblTitle = new Label();
            lblTitle.Text = "FLAPPY BIRD";                         
            lblTitle.Font = new Font("Press Start 2P", 24, FontStyle.Bold); 
            lblTitle.Size = new Size(500, 60);                      
            lblTitle.Location = new Point(150, 80);                 
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;     // Tekst midden in de label

            // SUBTITEL (SCORE TRACKER)
            lblSubTitle = new Label();
            lblSubTitle.Text = "SCORE TRACKER";
            lblSubTitle.Font = new Font("Press Start 2P", 14, FontStyle.Regular);
            lblSubTitle.Size = new Size(400, 40);
            lblSubTitle.Location = new Point(200, 140);
            lblSubTitle.TextAlign = ContentAlignment.MiddleCenter;

            // BUTTONS
            btnStart = CreateButton("START", 310, 200);       
            btnSpelers = CreateButton("SPELERS", 310, 270);   
            btnScores = CreateButton("SCORES", 310, 340);     
            btnTop10 = CreateButton("TOP 10", 310, 410);      
            btnAfsluiten = CreateButton("AFSLUITEN", 310, 480); 

            // EVENTS (Wat gebeurt er als je op een knop klikt?)
            btnSpelers.Click += BtnSpelers_Click;   // SPELERS → open spelers overzicht
            btnScores.Click += BtnScores_Click;     // SCORES → open scores overzicht
            btnTop10.Click += BtnTop10_Click;       // TOP 10 → open top 10 scherm
            btnAfsluiten.Click += (s, e) => Application.Exit(); // AFSLUITEN → sluit programma

            // CONTROLS TOEVOEGEN (Alles op het scherm zetten)
            this.Controls.Add(lblTitle);      
            this.Controls.Add(lblSubTitle);   
            this.Controls.Add(btnStart);      
            this.Controls.Add(btnSpelers);    
            this.Controls.Add(btnScores);    
            this.Controls.Add(btnTop10);      
            this.Controls.Add(btnAfsluiten);  
        }
        // CREATEBUTTON (Maakt een knop aan met het Flappy Bird thema)
        // text: De tekst op de knop (bijv. "START")
        // x: Horizontale positie (van links)
        // y: Verticale positie (van boven)
        private Button CreateButton(string text, int x, int y)
        {
            Button btn = new Button();                         // Maak een nieuwe knop
            btn.Text = text;                                   // Zet de tekst op de knop
            btn.Size = new Size(180, 45);                     
            btn.Location = new Point(x, y);                    // Zet de knop op de juiste plek
            btn.Font = new Font("Press Start 2P", 10, FontStyle.Regular);
            btn.ForeColor = Color.White;                      
            btn.BackColor = Color.FromArgb(45, 106, 79);       
            return btn;                                       
        }
        // SETUPFLAPPYBIRDTHEME (Stelt de kleuren in)
        private void SetupFlappyBirdTheme()
        {
            // Achtergrond van het formulier
            this.BackColor = Color.FromArgb(78, 192, 233);

            // Titel kleur
            lblTitle.ForeColor = Color.FromArgb(247, 212, 74);

            // Subtitel kleur
            lblSubTitle.ForeColor = Color.White;
        }
        // SPELERS KNOP (Open het spelers overzicht)
        private void BtnSpelers_Click(object sender, EventArgs e)
        {
            // Maak een nieuw SpelerOverzichtForm object aan
            SpelerOverzichtForm form = new SpelerOverzichtForm();

            // ShowDialog() toont het scherm als een pop-up
            // De gebruiker kan niet terug naar het startscherm totdat hij dit scherm sluit
            form.ShowDialog();
        }
        // SCORES KNOP (Open het scores overzicht)
        private void BtnScores_Click(object sender, EventArgs e)
        {
            ScoreOverzichtForm form = new ScoreOverzichtForm();
            form.ShowDialog();
        }
        // TOP 10 KNOP
        private void BtnTop10_Click(object sender, EventArgs e)
        {
            Top10Form form = new Top10Form();
            form.ShowDialog();
        }
    }
}