<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: bewerk.php
 */

session_start();     //Start een sessie in PHP

// Database functies inladen
include '../includes/db_functions_film_fabriek.php';
StartConnection();  // Verbind met de database

// Login controle
if (!isset($_SESSION['loggedin']) || $_SESSION['loggedin'] !== true)    // Controleer of de gebruiker niet is ingelogd:
                                                                       // - Als de sessievariabele 'loggedin' niet bestaat (!isset)
                                                                      // - Of als 'loggedin' niet gelijk is aan true (strikte vergelijking !== true
{
    header('Location: login.php');                                     //Als gebruiker niet ingelogd is redirect naar loginpagina
    exit;
}

// Film ID controle
if (!isset($_GET['film_id']))  // Controleer of de 'film_id' parameter niet in de URL aanwezig is
{
    die("Film ID ontbreekt!");  // Stop het script en geef een foutmelding: "Film ID ontbreekt!"
}

$film_id = $_GET['film_id'];   // Haal film_id op uit GET parameter

// Film gegevens ophalen
$filmQuery = "SELECT * FROM films WHERE film_id = " . $film_id;      // Maak een SQL-query om alle gegevens van de film met het opgegeven film_id op te halen
$filmResult = ExecuteQuery($filmQuery);                              // Voer de SQL-query uit en sla het resultaat op in $filmResult
$film = $filmResult->fetch(PDO::FETCH_ASSOC);

if (!$film)
{
    die("Film niet gevonden!");
}

// Form verwerking        // Haal nieuwe gegevens uit formulier
if ($_SERVER['REQUEST_METHOD'] === 'POST')
{
    $titel = $_POST['titel'];
    $beschrijving = $_POST['beschrijving'];
    $genre_id = $_POST['genre_id'];
    $release_date = $_POST['release_date'];

    // Film bijwerken
    $query = "
        UPDATE films 
        SET titel = '$titel',
            beschrijving = '$beschrijving',
            genre_id = '$genre_id',
            release_date = '$release_date'
        WHERE film_id = $film_id
    ";                                                              //update film gegevens op basis van film_id
                                                                   // Alleen de rij bijwerken waar film_id overeenkomt met $film_id

    $result = ExecuteQuery($query);               // ExecuteQuery voert SQL-update uit

    if ($result)
    {
        header("Location: overzicht.php");
        exit();
    }
    else
    {
        $error = "Er is een fout opgetreden bij het bijwerken van de film.";
    }
}
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Film Bewerken - Film Fabriek</title>
    <link rel='stylesheet' href='../styles/stylesheet.css'>
</head>
<body>

<header>
    <img src="../images/film_fabriek_logo.png" alt="Film Fabriek Logo" id="logo">
</header>

<?php include '../includes/nav.php'; ?>

<main>
    <section class="overzicht-header">
        <h1>Film Bewerken</h1>
    </section>

    <section class="form-section">
        <form method="POST" action="bewerk.php?film_id=<?php echo $film_id; ?>">
            <div class="form-group">
                <label for="titel">Titel:</label>
                <input type="text" id="titel" name="titel" value="<?php echo $film['titel']; ?>" required>
            </div>

            <div class="form-group">
                <label for="beschrijving">Beschrijving:</label>
                <textarea id="beschrijving" name="beschrijving" required rows="5"><?php echo $film['beschrijving']; ?></textarea>
            </div>

            <div class="form-group">
                <label for="genre_id">Genre:</label>
                <select id="genre_id" name="genre_id" required>
                    <?php
                    $genresQuery = "SELECT genre_id, genre_naam FROM genres ORDER BY genre_naam";
                    $genresResult = ExecuteQuery($genresQuery);
                    $genres = $genresResult->fetchAll(PDO::FETCH_ASSOC);

                    foreach ($genres as $genre):
                        ?>
                        <option value="<?php echo $genre['genre_id']; ?>" <?php echo ($film['genre_id'] == $genre['genre_id']) ? 'selected' : ''; ?>>
                            <?php echo $genre['genre_naam']; ?>
                        </option>
                    <?php endforeach; ?>
                </select>
            </div>

            <div class="form-group">
                <label for="release_date">Release Datum:</label>
                <input type="date" id="release_date" name="release_date" value="<?php echo $film['release_date']; ?>" required>
            </div>

            <div class="form-actions">
                <button type="submit" class="btn btn-primary">
                    Opslaan
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
