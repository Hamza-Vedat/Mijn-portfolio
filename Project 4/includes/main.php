<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: main.php
 */

?>

<main>

    <section class="welcome-section">
        <h2>Welkom bij Film Fabriek</h2>
        <p>Ontdek duizenden films en beheer je eigen collectie.</p>

        <?php if (isset($_SESSION['loggedin']) && $_SESSION['loggedin']): ?>   <!-- Controleer of gebruiker ingelogd is -->
            <div class="user-greeting">
                <p>Hallo <strong><?php echo $_SESSION['username']; ?></strong>! Fijn dat je er weer bent.</p>  <!-- Persoonlijk welkom bericht voor ingelogde gebruiker -->
            </div>
        <?php endif; ?>
    </section>


    <section class="featured-films">
        <h2>Uitgelichte Films</h2>

        <div class="films-container">
            <?php
            $sql = "
                SELECT titel, beschrijving, afbeelding, genre_naam, release_date
                FROM films
                INNER JOIN genres ON films.genre_id = genres.genre_id
                LIMIT 3
            ";

            //selecteer 3 uitgelichte films met hun genre

            $result = ExecuteQuery($sql);
            $films = $result->fetchAll(PDO::FETCH_ASSOC);

            // Haal alle resultaten op als associatieve array

            if (!empty($films))              // Controleer of de $films array niet leeg is
            {
                foreach ($films as $film)    // Loop door elke film in de $films array
                {
                    ?>
                    <div class="film-card">
                        <img src="images/<?php echo $film['afbeelding']; ?>"
                             alt="<?php echo $film['titel']; ?>"
                             class="film-image">

                        <div class="film-info">
                            <h3><?php echo $film['titel']; ?></h3>

                            <p class="film-genre">
                                <strong>Genre:</strong>
                                <?php echo $film['genre_naam']; ?>
                            </p>

                            <p class="film-description">

                                <?php echo $film['beschrijving']; ?>
                            </p>
                            <p class="film-release_date">

                                <?php echo $film['release_date']; ?>
                            </p>
                        </div>
                    </div>
                    <?php
                }
            } else
            {
                echo "<p>Geen films gevonden.</p>";
            }
            ?>
        </div>
    </section>

</main>