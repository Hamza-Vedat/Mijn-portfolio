/*Auteur: Seth van der Linden, Hamza Oraloglu
aanmaakdatum: 25-3-2025

<JavaScript-bestand>*/

document.addEventListener("DOMContentLoaded", function() 
{

    if (window.location.pathname === "/index.html") 
        {
        var ingang="Welkom bij onze website"
        alert("Welkom bij onze website");
        //alert(typeof ingang);

        var bedrijf="SafeDrive"
        alert("SafeDrive")
        //alert(typeof bedrijf);

        var student =1200
        alert(student)
        //alert(typeof student);

        var tevredenheidscore = 98
        alert(tevredenheidscore)
        //alert(typeof tevredenheidscore)

        var ervaring = prompt("Heb je al rijervaring?").toLowerCase()
        if (ervaring == "ja")
        {
        document.getElementById("result1").innerHTML = "Bekijk dan ons half gevorded pakket";
        }

        else if (ervaring == "nee")
        {
        document.getElementById("result2").innerHTML = "Bekijk dan ons beginnende pakket";
        }
    }

        if (window.location.pathname === "/pages/contact.html")
        {
            var proefles = prompt("Wil je gratis proefles?").toUpperCase()
        if (proefles == "JA")
        {
        document.getElementById("resulta").innerHTML = "Neem dan contact met ons op";
        }

        else if (proefles == "NEE")
        {
        document.getElementById("resultb").innerHTML = "Ik denk dat je nog eens goed moet nadenken";
        }
        }
}); 

