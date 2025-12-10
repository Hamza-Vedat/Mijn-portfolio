/* 
Portfolio projecten
Auteur: Hamza Oraloglu
Datum: 05-06-2025
*/

// 1. VARIABELEN 

var menuToggle = document.getElementById('menu-toggle'); // Hamburger menu icoon
var menuClose = document.getElementById('menu-close');   // Sluitknop (X)
var mobileMenu = document.getElementById('mobile-menu'); // Het mobiele menu zelf

// 2. FUNCTIE MET PARAMETER

function toggleMenu(shouldShow) 
{
    // Deze functie regelt het tonen/verbergen van het menu
    if (shouldShow) 
    {
        mobileMenu.style.display = 'flex';       // Menu zichtbaar maken
        document.body.style.overflow = 'hidden'; // Scrollen uitschakelen
    } 
    else 
    {
        mobileMenu.style.display = 'none';       // Menu verbergen
        document.body.style.overflow = '';       // Scrollen weer inschakelen
    }
}

// 3. EVENT LISTENERS 

if (menuToggle && menuClose && mobileMenu) 
  {
    // Alleen uitvoeren als alle elementen bestaan
    menuToggle.addEventListener('click', function() 
    {
        toggleMenu(true);  // Menu openen bij klik hamburger icoon
    });
    
    menuClose.addEventListener('click', function() 
    {
        toggleMenu(false); // Menu sluiten bij klik X icoon
    });
}

// 4. ARRAY 

var vaardigheden = 
[
    ["HTML", 7],  // [vaardigheid, score]
    ["CSS", 7],
    ["JavaScript", 6],
    ["Figma", 8],
    ["Photoshop", 7],
    ["Premiere Pro", 7]
];

// 5. FUNCTIE DIE ARRAY VERWERKT 

function toonScore(vaardigheidNaam) 
{
    var scoreText = "";
    // FOR LOOP (checklist vereiste)
    for (var i = 0; i < vaardigheden.length; i++) 
      {
        if (vaardigheden[i][0] === vaardigheidNaam) 
        {
            scoreText = "Score voor " + vaardigheden[i][0] + ": " + vaardigheden[i][1] + "/10";
            document.getElementById("score-display").textContent = scoreText;
            return; // Stop de functie als gevonden
        }
    }
}

// 6. DYNAMISCHE CONTENT GENERATIE

var skillItems = document.querySelectorAll(".skill-item"); // QUERYSELECTOR 
// FOR LOOP (checklist vereiste)
for (var i = 0; i < skillItems.length; i++) 
  {
    var item = skillItems[i];
    var titel = item.querySelector("h3").textContent; // Vaardigheidsnaam ophalen
    
    // Array doorzoeken 
    for (var j = 0; j < vaardigheden.length; j++) 
    {
        if (vaardigheden[j][0] === titel) 
          {
            // Element aanmaken (DOM manipulatie)
            var p = document.createElement("p");
            p.textContent = "Score: " + vaardigheden[j][1] + "/10";
            item.appendChild(p); // Toevoegen aan DOM
            break; // Stop de loop als gevonden
        }
    }
}