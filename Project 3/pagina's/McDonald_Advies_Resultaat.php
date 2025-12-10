<?php
// Resultatenpagina - Scoreberekening en Advies
session_start(); // Start de sessie – nodig om gegevens van de gebruiker te bewaren

// Controleer of het formulier niet is ingevuld én er geen advies in de sessie staat
if (!isset($_POST['q1']) && !isset($_SESSION['advies'])) //Combineert voorwaarden.
{
    header("Location: form.php"); // Stuur de gebruiker terug naar het formulier
    exit(); // Stop de verdere uitvoering van de code
}

// Als er al een advies in de sessie staat en het formulier niet opnieuw is ingevuld
if (isset($_SESSION['advies']) && !isset($_POST['q1']))
{
    // Haal de eerder opgeslagen gegevens uit de sessie
    $advies = $_SESSION['advies'];      // Advies dat eerder berekend is
    $totalScore = $_SESSION['score'];   // Totaalscore uit de sessie
    $userName = $_SESSION['userName'];  // Gebruikersnaam uit de sessie
} else
{
    // Nieuw formulier is ingevuld – nu de score berekenen

    $totalScore = 0; // Startwaarde van de score

    // Tel de punten van alle vragen bij elkaar op
    $totalScore += (int)$_POST['q1'];   // (int) zet waarde om naar een geheel getal - Telt een waarde bij een variabele op.
    $totalScore += (int)$_POST['q2'];
    $totalScore += (int)$_POST['q3'];
    $totalScore += (int)$_POST['q4'];
    $totalScore += (int)$_POST['q5'];
    $totalScore += (int)$_POST['q6'];
    $totalScore += (int)$_POST['q7'];
    $totalScore += (int)$_POST['q8'];
    $totalScore += (int)$_POST['q9'];
    $totalScore += (int)$_POST['q10'];
    $totalScore += (int)$_POST['q11'];
    $totalScore += (int)$_POST['q12'];
    $totalScore += (int)$_POST['q13'];
    $totalScore += (int)$_POST['q14'];
    $totalScore += (int)$_POST['q15'];

    // Advies bepalen met if / elseif / else
    $advies = "";            // Lege variabelen aanmaken
    $afbeelding = "";
    $informatieLink = "";
    $popupContent = "";

    // Verschillende adviezen afhankelijk van de score
    if ($totalScore > 120) // Als score hoger is dan 120
    {
        $advies = "Big Mac Menu"; // Advies wordt Big Mac
        $afbeelding = '../image/bigmac.jpeg'; // Afbeelding instellen
        $informatieLink = "#"; // (kan later een echte link zijn)
        $popupContent = "Het Big Mac Menu is onze meest iconische keuze! Bevat de beroemde Big Mac met twee 100% rundvleesschijven, Big Mac-saus, krokante sla, gesmolten kaas, augurken en uien op een sesamzaadbroodje. Geserveerd met krokante friet en een verfrissende drank. Perfect voor liefhebbers van klassieke hamburgers!"; // Extra info
    }
    elseif ($totalScore >= 90) // Als score tussen 90 en 120 ligt
    {
        $advies = "McChicken Menu";
        $afbeelding = '../image/mchicken.jpeg';
        $informatieLink = "#";
        $popupContent = "Het McChicken Menu biedt een heerlijke krokante kipburger gemaakt van 100% kippenvlees. Met frisse sla en romige mayonaise op een zachte broodje. Kom genieten van deze lichte en smaakvolle optie, geserveerd met gouden friet en een drank naar keuze. Ideaal voor kip-liefhebbers!";
    }
    elseif ($totalScore >= 60) // Als score tussen 60 en 89 ligt
    {
        $advies = "Vegan Burger Menu";
        $afbeelding = '../image/vegan.jpeg';
        $informatieLink = "#";
        $popupContent = "Ons Vegan Burger Menu is speciaal ontwikkeld voor plantaardige voeding! Deze 100% veganistische burger bevat een plantaardige schotel met verse groenten, veganistische saus en een volkoren broodje. Een smaakvol en bewust alternatief, perfect voor iedereen die kiest voor meer plantaardige opties.";
    }
    else // Als de score lager is dan 60
    {
        $advies = "Happy Meal";
        $afbeelding = '../image/happymeal.jpeg';
        $informatieLink = "#";
        $popupContent = "Het Happy Meal maakt kinderen blij! Bevat een leuke speelgoedverrassing en heerlijk eten afgestemd op kinderen. Kies uit verschillende hoofdopties zoals kipnuggets of een hamburger, met appelslices en een drankje. De perfecte keuze voor gezinnen en jonge gasten!";
    }

    // Resultaten opslaan in de sessie zodat ze bewaard blijven
    $_SESSION['advies'] = $advies;
    $_SESSION['score'] = $totalScore;
    $_SESSION['userName'] = $_POST['name'];
    $_SESSION['informatieLink'] = $informatieLink;
    $_SESSION['afbeelding'] = $afbeelding;
    $_SESSION['popupContent'] = $popupContent;
}

// Haal de waarden opnieuw uit de sessie (voor we ze tonen)
$userName = $_SESSION['userName'];
$informatieLink = $_SESSION['informatieLink'];
$afbeelding = $_SESSION['afbeelding'];
$popupContent = $_SESSION['popupContent'];

// Dynamische begroeting op basis van het tijdstip
$currentHour = date('H'); // Haalt het huidige uur op (00–23)
if ($currentHour < 12) // Voor 12 uur
{
    $greeting = "Goedemorgen";
}
elseif ($currentHour < 18) // Tussen 12 en 18 uur
{
    $greeting = "Goedemiddag";
}
else // Na 18 uur
{
    $greeting = "Goedenavond";
}

// Controleren of de pop-up getoond moet worden
$showPopup = isset($_GET['show_info']) && $_GET['show_info'] == 'true'; // true als show_info in de URL staat
?>

<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <title>Jouw Advies</title>
    <link rel="stylesheet" href="../style/stylesheet.css"> <!-- Koppeling naar CSS -->
    <style>
        .popup-overlay
        {
            display: <?php echo $showPopup ? 'flex' : 'none'; ?>; // Pop-up tonen of verbergen
        }
    </style>
</head>
<body>
<header>
    <!-- Hier kan eventueel een header of logo komen -->
</header>

<?php include '../includes/nav.php'; ?> <!-- Include: navigatiebalk invoegen -->

<main>
    <div class="background-container">
        <div class="container">
            <h1>Jouw McDonald's Advies</h1>

            <!-- Begroeting met de naam van de gebruiker -->
            <div class="welcome-message">
                <h2><?php echo $greeting . ' ' . $userName; ?>!</h2>
                <p>Bedankt voor het invullen van onze vragenlijst. Hieronder vind je jouw persoonlijke advies.</p>
            </div>

            <!-- Gebruikersinformatie en score -->
            <div class="score">
                <p>Naam: <?php echo $userName; ?></p> <!-- Toont naam -->
                <p>Score: <?php echo $totalScore; ?> punten</p> <!-- Toont totaalpunten -->
                <p>Datum: <?php echo date("d-m-Y H:i"); ?></p> <!-- Toont huidige datum/tijd -->
            </div>

            <!-- Adviesblok -->
            <div class="advies-box">
                <div class="advies-title">Advies: <?php echo $advies; ?></div> <!-- Titel van advies -->
                <img src="<?php echo $afbeelding; ?>" alt="<?php echo $advies; ?>" class="advies-image"> <!-- Afbeelding -->

                <div class="advies-beschrijving">
                    <?php
                    // Switch-structuur: tekst tonen afhankelijk van advies
                    switch($advies)
                    {
                        case "Big Mac Menu":
                            echo "U houdt van klassieke smaken. Dit menu past goed bij u.";
                            break; // Stop de switch na deze case
                        case "McChicken Menu":
                            echo "U kiest vaak voor kip en frisse smaken.";
                            break;
                        case "Vegan Burger Menu":
                            echo "U let op gezondheid en probeert nieuwe dingen.";
                            break;
                        case "Happy Meal":
                            echo "U houdt van een eenvoudige maaltijd of eet graag met kinderen.";
                            break;
                    }
                    ?>
                </div>

                <!-- Link om pop-up te openen -->
                <div class="info-link">
                    <a href="?show_info=true" class="button">
                        Meer informatie over <?php echo $advies; ?>
                    </a>
                </div>

                <!-- Navigatieknoppen -->
                <div class="center-buttons">
                    <a href="../index.php" class="button">Terug naar Home</a>
                    <a href="form.php" class="button">Nieuwe Test</a>
                </div>

                <!-- Pop-up venster -->
                <div class="popup-overlay">
                    <div class="popup-content">
                        <div class="popup-title">Meer over <?php echo $advies; ?></div>
                        <div class="popup-text">
                            <?php echo $popupContent; ?> <!-- Tekst uit sessie -->
                        </div>
                        <a href="?" class="close-btn">Sluiten</a> <!-- Sluitknop -->
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>

<?php include '../includes/footer.php'; ?> <!-- Footer invoegen -->
</body>
</html>
