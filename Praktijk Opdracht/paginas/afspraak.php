<?php
/**
 * User: Hamza Oraloglu
 * Date: 25.09.2025
 * File: afspraak.php
 */
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Afspraak Maken - Tandarts Den Bosch</title>
    <link rel="stylesheet" href="../style/stylesheet2.css">
</head>
<body>
<?php include '../includes/header.php'; ?>
<?php include '../includes/nav.php'; ?>

<main>


    <section class="afspraak-formulier">
        <h2>AFSPRAAK FORMULIER</h2>
        <form action="#" method="post">
            <!-- Persoonlijke gegevens -->
            <div class="form-group">
                <h3>Persoonlijke Gegevens</h3>

                <label for="voornaam">Voornaam *</label>
                <input type="text" id="voornaam" name="voornaam" required>

                <label for="achternaam">Achternaam *</label>
                <input type="text" id="achternaam" name="achternaam" required>

                <label for="geboortedatum">Geboortedatum *</label>
                <input type="date" id="geboortedatum" name="geboortedatum" required>

                <label for="email">E-mailadres *</label>
                <input type="email" id="email" name="email" required>

                <label for="telefoon">Telefoonnummer *</label>
                <input type="tel" id="telefoon" name="telefoon" required>
            </div>

            <!-- Afspraak details -->
            <div class="form-group">
                <h3>Afspraak Details</h3>

                <label for="behandeling">Type behandeling *</label>
                <select id="behandeling" name="behandeling" required>
                    <option value="">Kies een behandeling</option>
                    <option value="controle">Controle</option>
                    <option value="gevul">Vulling</option>
                    <option value="kroon">Kroon</option>
                    <option value="anders">Anders</option>
                </select>

                <label for="tandarts">Voorkeur tandarts</label>
                <select id="tandarts" name="tandarts">
                    <option value="">Geen voorkeur</option>
                    <option value="dr-jansen">Dr. Jhon Smith</option>
                    <option value="dr-meijer">Dr. Emily Jones</option>

                </select>

                <label for="datum">Gewenste datum *</label>
                <input type="date" id="datum" name="datum" min="<?php echo date('Y-m-d'); ?>" required>

                <label for="tijd">Gewenste tijd *</label>
                <select id="tijd" name="tijd" required>
                    <option value="">Kies een tijd</option>
                    <option value="08:30">08:30</option>
                    <option value="09:00">09:00</option>
                    <option value="09:30">09:30</option>
                    <option value="10:00">10:00</option>
                    <option value="10:30">10:30</option>
                    <option value="11:00">11:00</option>
                    <option value="11:30">11:30</option>
                    <option value="13:00">13:00</option>
                    <option value="13:30">13:30</option>
                    <option value="14:00">14:00</option>
                    <option value="14:30">14:30</option>
                    <option value="15:00">15:00</option>
                    <option value="15:30">15:30</option>
                    <option value="16:00">16:00</option>
                    <option value="16:30">16:30</option>
                </select>
            </div>

            <!-- Opmerkingen -->
            <div class="form-group">
                <label for="opmerkingen">Speciale opmerkingen of klachten</label>
                <textarea id="opmerkingen" name="opmerkingen" rows="4" placeholder="Beschrijf eventuele klachten of speciale verzoeken..."></textarea>
            </div>

            <!-- Bevestiging -->
            <div class="form-group">
                <label class="checkbox-label">
                    <input type="checkbox" name="bevestiging" required>
                    Ik ga akkoord met de <a href="#">privacyverklaring</a> en bevestig dat de ingevulde gegevens correct zijn *
                </label>
            </div>

            <button type="submit">Afspraak Versturen</button>
        </form>
    </section>

    <section class="contact-info">
        <h2>Telefonisch Afspraak Maken</h2>
        <p>Liever telefonisch een afspraak maken? Bel ons tijdens kantooruren:</p>
        <p><strong>Telefoon: 073-6897955</strong></p>
        <p>Maandag - Vrijdag: 08:00 - 17:00</p>
    </section>

    <section class="spoed">
        <h2>⚠️ Spoedgevallen</h2>
        <p>Voor spoedgevallen buiten kantooruren kunt u bellen met ons spoednummer:</p>
        <p><strong>06-12345678</strong></p>
    </section>
</main>

<?php include '../includes/footer.php'; ?>
</body>
</html>