<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: toevoeg.php
 */

session_start();    //Start een sessie in PHP

// Database functies inladen
include '../includes/db_functions_film_fabriek.php';  //Voeg een ander PHP-bestand toe en voer het uit
StartConnection();     //Maakt verbinding met de database

// Login controle
if (!isset($_SESSION['loggedin']) || $_SESSION['loggedin'] !== true)        // Controleer of de gebruiker niet is ingelogd:
                                                                            // - Als de sessievariabele 'loggedin' niet bestaat (!isset)
                                                                           // - Of als 'loggedin' niet gelijk is aan true (strikte vergelijking !== true)
{
    header('Location: login.php');  // Als de gebruiker niet is ingelogd, word je naar de loginpagina gestuurd
    exit;          //stopt de uitvoering van de code
}

// Form verwerking
if ($_SERVER['REQUEST_METHOD'] === 'POST')    // Controleer of het formulier is ingediend via POST
{
    $titel = $_POST['titel'];                 // Haalt de titel op uit het formulier
    $beschrijving = $_POST['beschrijving'];   // Haalt de beschrijving op uit het formulier
    $genre_id = $_POST['genre_id'];           // Haalt de geselecteerde genre_id op
    $release_date = $_POST['release_date'];   // Haalt de release datum op uit het formulier

    $user_id = 1;                             //  user_id Huidige gebruiker ID

    // Film toevoegen
    $query = "
        INSERT INTO films (titel, beschrijving, genre_id, release_date, user_id) 
        VALUES (
            '$titel',
            '$beschrijving',
            '$genre_id',
            '$release_date',
            '$user_id'
        )
    ";
    //voegt de filmgegevens toe aan de 'films' tabel

    $result = ExecuteQuery($query);  // Voer de SQL-query $query uit en sla het resultaat op in $result

    if ($result)
    {
        header("Location: overzicht.php");   //Als het toevoegen succesvol is redirect naar overzichtpagina
        exit();
    }
    else
    {
        $error = "Er is een fout opgetreden bij het toevoegen van de film.";
    }
}
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Film Toevoegen - Film Fabriek</title>
    <link rel='stylesheet' href='../styles/stylesheet.css'>
</head>
<body>

<header>
    <img src="../images/film_fabriek_logo.png" alt="Film Fabriek Logo" id="logo">
</header>

<?php include '../includes/nav.php'; ?>

<main>
    <section class="overzicht-header">
        <h1>Film Toevoegen</h1>
    </section>

    <section class="form-section">
        <form method="POST" action="toevoegen.php">
            <div class="form-group">
                <label for="titel">Titel:</label>
                <input type="text" id="titel" name="titel" required>
            </div>

            <div class="form-group">
                <label for="beschrijving">Beschrijving:</label>
                <textarea id="beschrijving" name="beschrijving" required rows="5"></textarea>
            </div>

            <div class="form-group">
                <label for="genre_id">Genre:</label>
                <select id="genre_id" name="genre_id" required>
                    <option value="">Kies een genre</option>
                    <?php
                    // Bereid de SQL-query voor: haal genre_id en genre_naam uit de tabel 'genres' en sorteer alfabetisch
                    $genresQuery = "SELECT genre_id, genre_naam FROM genres ORDER BY genre_naam";

                    // Voer de query uit en sla het resultaat op in $genresResult
                    $genresResult = ExecuteQuery($genresQuery);

                    // Haal alle rijen op als een associatieve array (key-value array)
                    $genres = $genresResult->fetchAll(PDO::FETCH_ASSOC);

                    // Start een lus voor elk genre in de array
                    foreach ($genres as $genre):
                        ?>
                        <!-- Maak een HTML <option> element -->
                        <option value="<?php echo $genre['genre_id']; ?>">
                            <?php echo $genre['genre_naam']; ?>
                        </option>
                        <!--
        <?php echo $genre['genre_id']; ?>    //Wordt gebruikt bij het verzenden van het formulier om te weten welk genre is geselecteerd
        <?php echo $genre['genre_naam']; ?>  //Wordt weergegeven in de dropdown voor de gebruiker
    -->
                    <?php endforeach; ?>

                </select>
            </div>

            <div class="form-group">
                <label for="release_date">Release Datum:</label>
                <input type="date" id="release_date" name="release_date" required>
            </div>

            <div class="form-actions">
                <button type="submit" class="btn btn-primary">
                    Film Toevoegen
                </button>
                <a href="overzicht.php" class="btn btn-secondary">
                    Annuleren
                </a>
            </div>
        </form>
    </section>
</main>

<?php include '../includes/footer.php'; ?>

</body>
</html>