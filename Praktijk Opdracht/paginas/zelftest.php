<?php
/**
 * User: Hamza Oraloglu
 * Date: 25.09.2025
 * File: zelftest.php
 */
?>
<?php
if ($_SERVER["REQUEST_METHOD"] == "POST")
{
    // Alle antwoorden optellen
    $score = array_sum($_POST);
}
?>

<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Doe de Tandtest - Tandartspraktijk Den Bosch</title>
    <link rel="stylesheet" href="../style/stylesheet.css">
</head>
<body>
<?php include '../includes/header.php'; ?>
<?php include '../includes/nav.php'; ?>

<main>
    <?php if ($_SERVER["REQUEST_METHOD"] == "POST")
    { ?>
        <div class="result-container">
            <div class="score-display">Uw score: <?php echo $score; ?> punten</div>

            <?php if ($score > 80)
            { ?>
                <div class="result-excellent">
                    <h3>Uitslag: U verzorgt uw gebit uitstekend!</h3>
                    <p>Fantastisch! Uw mondhygiëne is voorbeeldig. Blijf zo doorgaan om uw gezonde glimlach te behouden.</p>
                </div>
            <?php } elseif ($score >= 60)
            { ?>
                <div class="result-good">
                    <h3>Uitslag: U verzorgt uw gebit goed.</h3>
                    <p>Goed bezig! Maar er zijn nog punten voor verbetering. Bekijk onze tips om uw mondhygiëne te perfectioneren.</p>
                </div>
            <?php } elseif ($score >= 20)
            { ?>
                <div class="result-moderate">
                    <h3>Uitslag: U verzorgt uw gebit matig.</h3>
                    <p>Er is ruimte voor verbetering. Een bezoek aan de tandarts voor advies is verstandig. Waarschijnlijk ervaart u al gebitsproblemen.</p>
                </div>
            <?php } else
            { ?>
                <div class="result-poor">
                    <h3>Uitslag: U verzorgt uw gebit onvoldoende.</h3>
                    <p>Uw mondgezondheid heeft dringend aandacht nodig. Maak zo snel mogelijk een afspraak bij de tandarts.</p>
                </div>
            <?php } ?>

            <br>
            <a href="afspraak.php" class="cta-button">Maak direct een afspraak</a>
            <br><br>
            <a href="zelftest.php">Doe de test opnieuw</a>
        </div>
    <?php } else
    { ?>
        <form method="POST" action="zelftest.php">
            <?php
            echo '<div class="vraag">
                    <p><strong>1. Hoe vaak poets je je tanden per dag?</strong></p>
                    <label><input type="radio" name="vraag1" value="10" required> ≥ 2 keer per dag</label><br>
                    <label><input type="radio" name="vraag1" value="5"> 1 keer per dag</label><br>
                    <label><input type="radio" name="vraag1" value="-10"> Minder dan 1 keer per dag</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>2. Hoe lang duurt je poetsbeurt meestal?</strong></p>
                    <label><input type="radio" name="vraag2" value="10" required> ≥ 2 minuten</label><br>
                    <label><input type="radio" name="vraag2" value="5"> 1-2 minuten</label><br>
                    <label><input type="radio" name="vraag2" value="0"> Minder dan 1 minuut</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>3. Hoe vaak flos je of gebruik je een rager tussen je tanden?</strong></p>
                    <label><input type="radio" name="vraag3" value="10" required> Minimaal 1 keer per dag</label><br>
                    <label><input type="radio" name="vraag3" value="5"> Een paar keer per week</label><br>
                    <label><input type="radio" name="vraag3" value="0"> Zelden of nooit</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>4. Hoe vaak drink je suikerhoudende dranken (frisdrank, vruchtensap)?</strong></p>
                    <label><input type="radio" name="vraag4" value="10" required> Zelden of nooit</label><br>
                    <label><input type="radio" name="vraag4" value="5"> 1-3 glazen per dag</label><br>
                    <label><input type="radio" name="vraag4" value="-5"> Meer dan 3 glazen per dag</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>5. Hoe vaak eet je zoet tussendoortjes (snoep, koek, chocola)?</strong></p>
                    <label><input type="radio" name="vraag5" value="10" required> Zelden of nooit</label><br>
                    <label><input type="radio" name="vraag5" value="5"> 1-2 keer per dag</label><br>
                    <label><input type="radio" name="vraag5" value="-5"> Vaker dan 2 keer per dag</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>6. Gebruik je een elektrische tandenborstel?</strong></p>
                    <label><input type="radio" name="vraag6" value="10" required> Ja</label><br>
                    <label><input type="radio" name="vraag6" value="5"> Nee</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>7. Gebruik je een fluoride tandpasta?</strong></p>
                    <label><input type="radio" name="vraag7" value="10" required> Ja</label><br>
                    <label><input type="radio" name="vraag7" value="5"> Nee</label>
                  </div>';

            echo '<div class="vraag">
                    <p><strong>8. Rook je?</strong></p>
                    <label><input type="radio" name="vraag8" value="10" required> Nee</label><br>
                    <label><input type="radio" name="vraag8" value="-10"> Ja</label>
                  </div>';
            ?>

            <button type="submit">Bereken mijn score</button>
        </form>
    <?php } ?>
</main>

<?php include '../includes/footer.php'; ?>
</body>
</html>
