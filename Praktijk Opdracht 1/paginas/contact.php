
<?php
/**
 * User: Hamza Oraloglu
 * Date: 25.09.2025
 * File: contact.php
 */
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contact - Tandarts Den Bosch</title>
    <link rel="stylesheet" href="../style/stylesheet2.css">
</head>
<body>

<?php include '../includes/header.php'; ?>
<?php include '../includes/nav.php'; ?>

<main>

    <section class="contact-form">
        <h2>CONTACTFORMULIER</h2>
        <form action="#" method="post">
            <label for="name">Naam *</label>
            <input type="text" id="name" name="name" required>

            <label for="email">E-mail *</label>
            <input type="email" id="email" name="email" required>

            <label for="phone">Telefoonnummer</label>
            <input type="tel" id="phone" name="phone">

            <label for="message">Vraag *</label>
            <textarea id="message" name="message" required></textarea>

            <button type="submit">Verzenden</button>
        </form>
    </section>

    <section class="contact-info">
        <h2>Tandarts Den Bosch</h2>
        <p>Hesselsstraat 2D, 5213 XD 's Hertogenbosch</p>
        <p>Telefoon: 073-6897955</p>
        <p>Email: <a href="mailto:info@tandartsdenbosch.nl">info@tandartsdenbosch.nl</a></p>
    </section>
</main>

<?php include '../includes/footer.php'; ?>
</body>
</html>