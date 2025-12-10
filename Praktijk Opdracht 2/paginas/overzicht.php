<?php
/**
 * User: Hamza Oraloglu
 * Date: 26.11.2025
 * File: overzicht.php
 */
session_start();                     // Start de sessie (nodig voor logincontrole)
include '../includes/functions.php'; // Laadt de functies, inclusief loginfuncties
requireLogin();                      // Controleert of de gebruiker is ingelogd, anders redirect naar login
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Vrijwilligers Overzicht</title>
    <link rel='stylesheet' href='../style/stylesheet2.css'>
</head>
<body>

<header>
    <img src="../images/logo.png" alt="Logo" id="logo">
</header>

<?php include '../includes/nav.php'; ?>

<main>
    <div class="container">
        <section class="overview-section">
            <h1>Vrijwilligers Overzicht</h1>
            <p class="intro-text">
                Hier vindt u de contactgegevens van alle vrijwilligers van Dierentehuis Den Bosch.

            </p>

            <div class="volunteers-table">
                <table>
                    <thead>
                    <tr>
                        <th>Foto</th>  >
                        <th>Naam</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php foreach ($users as $user): ?> <!-- Doorloopt alle gebruikers in de lijst -->
                        <tr>
                            <td class="user-photo">
                                <img src="<?php echo $user['photo']; ?>"
                                     alt="<?php echo $user['name']; ?>">
                                <!-- Profielfoto van de vrijwilliger -->
                            </td>
                            <td class="user-name">
                                <?php echo $user['name']; ?> <!-- Naam van de vrijwilliger -->
                            </td>
                        </tr>
                    <?php endforeach; ?>
                    </tbody>
                </table>
            </div>
        </section>
    </div>
</main>

<?php include '../includes/footer.php'; ?> <!-- Footer van de website -->

</body>
</html>
