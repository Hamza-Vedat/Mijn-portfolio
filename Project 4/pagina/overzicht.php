<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: overzicht.php
 */

session_start(); // Sessie starten

// Database functies inladen
include '../includes/db_functions_film_fabriek.php';
StartConnection();   //maakt verbinding met de database via $pdo

// Login kontrol
if (!isset($_SESSION['loggedin']) || $_SESSION['loggedin'] !== true)
{
    header('Location: login.php');  // Als gebruiker niet ingelogd is redirect naar loginpagina
    exit;
}

// Genre filter
$genre = isset($_GET['genre']) ? $_GET['genre'] : '';  // Haal genre op uit GET parameter (URL) of leeg als niet ingesteld

// SQL query maken
$sql = "
    SELECT film_id, titel, beschrijving, afbeelding, genre_id, release_date   
    FROM films
";
// Selecteer alle kolommen van films tabel

// WHERE voorwaarde toevoegen
$whereConditions = array();     // Array om eventuele filter voorwaarden in te zetten

// Genre filter toevoegen
if (!empty($genre))
{
    $whereConditions[] = "genre_id = '$genre'";   // Voeg genre filter toe aan array
}

// WHERE voorwaarde toevoegen
if (!empty($whereConditions))  // Controleer of er voorwaarden in de array $whereConditions staan
{
    $sql .= " WHERE " . implode(" AND ", $whereConditions);  // Voeg alle voorwaarden samen met AND
}

$sql .= " ORDER BY release_date ASC";       // Sorteer resultaten op release datum oplopend

// Alle films ophalen
$result = ExecuteQuery($sql);         // ExecuteQuery voert SQL uit en haalt resultaat op
if ($result)
{
    $films = $result->fetchAll(PDO::FETCH_ASSOC);     // fetchAll  haal alle rijen als associatieve array
} else {
    $films = array();
    echo "<p Er is een fout opgetreden bij het laden van de films.</p>";
}

// Genres ophalen voor filter dropdown
$genresSql = "SELECT genre_id, genre_naam FROM genres ORDER BY genre_naam";
$genresResult = ExecuteQuery($genresSql);
if ($genresResult)
{
    $alleGenres = $genresResult->fetchAll(PDO::FETCH_ASSOC);
}
else
{
    $alleGenres = array();
}

// Genre namen array maken
$genreNamen = [];
foreach ($alleGenres as $g)
{
    $genreNamen[$g['genre_id']] = $g['genre_naam'];
}
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Film Overzicht - Film Fabriek</title>
    <link rel='stylesheet' href='../styles/stylesheet.css'>
</head>
<body>

<header>
    <img src="../images/film_fabriek_logo.png" alt="Film Fabriek Logo" id="logo">
</header>

<?php include '../includes/nav.php'; ?>

<main>
    <!-- Filter Sectie -->
    <section class="filter-sectie">
        <h3>Filter op Genre</h3>

        <form method="GET" action="overzicht.php">
            <div class="filter-container">
                <select name="genre">
                    <option value="">Alle genres</option>
                    <?php
                    foreach ($alleGenres as $g)
                    {
                        if ($genre == $g['genre_id'])
                        {
                            echo '<option value="' . $g['genre_id'] . '" selected>' . $g['genre_naam'] . '</option>';
                        }
                        else
                        {
                            echo '<option value="' . $g['genre_id'] . '">' . $g['genre_naam'] . '</option>';
                        }
                    }
                    ?>
                </select>
                <button type="submit">Filter</button>
                <a href="overzicht.php">Reset</a>
                <!-- Film Toevoegen button -->
                <a href="toevoegen.php" class="toevoegen-btn">
                    + Film Toevoegen
                </a>
            </div>
        </form>
    </section>

    <section class="all-films">
        <h2>
            Alle Films (<?php echo count($films); ?>) //PHP telt het aantal films in de $films array en toont dit in de titel
        </h2>


        <div class="films-container">
            <?php
            if (!empty($films))                // Controleer of de $films array niet leeg is
            {
                foreach ($films as $film)     // Loop door elke film in de $films array
                {
                    // Genre naam ophalen uit array
                    $genreNaam = isset($genreNamen[$film['genre_id']]) ? $genreNamen[$film['genre_id']] : 'Onbekend';// Haal de genre naam op uit de $genreNamen array
                                                                                                                     // Als het genre_id bestaat in $genreNamen, gebruik de naam
                    ?>
                    <div class="film-card">
                        <img src="../images/<?php echo $film['afbeelding']; ?>"
                             alt="<?php echo $film['titel']; ?>"
                             class="film-image">

                        <div class="film-info">
                            <h3><?php echo $film['titel']; ?></h3>

                            <p class="film-genre">
                                <strong>Genre:</strong>
                                <?php echo $genreNaam; ?>
                            </p>

                            <p class="film-description">
                                <?php echo $film['beschrijving']; ?>
                            </p>

                            <p class="film-release_date">
                                <strong>Release datum:</strong>
                                <?php echo $film['release_date']; ?>
                            </p>

                            <!-- Bewerk en Verwijder knoppen -->
                            <div class="film-actions">
                                <a href="bewerk.php?film_id=<?php echo $film['film_id']; ?>" class="bewerk-link">
                                    Bewerk
                                </a>
                                <a href="delete.php?film_id=<?php echo $film['film_id']; ?>"
                                   onclick="return confirm('Weet je zeker dat je deze film wilt verwijderen?');"
                                   class="verwijder-link">
                                    Verwijder
                                </a>
                            </div>
                        </div>
                    </div>
                    <?php
                }
            }
            else
            {
                echo "<p>Geen films gevonden in de database.</p>";
            }
            ?>
        </div>
    </section>
</main>

<?php include '../includes/footer.php'; ?>

</body>
</html>