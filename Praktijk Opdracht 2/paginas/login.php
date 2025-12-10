<?php
/**
 * User: Hamza Oraloglu
 * Date: 26.11.2025
 * File: login.php
 */

// Start de sessie zodat we gebruikersgegevens kunnen opslaan
session_start();

// Laad het bestand met functies en gebruikersgegevens
include '../includes/functions.php';

// Controleer of het formulier is verstuurd met de POST-methode
if ($_SERVER['REQUEST_METHOD'] === 'POST')
{
    // Haal de ingevulde gebruikersnaam en wachtwoord op (of een lege string als ze niet bestaan)
    $username = $_POST['username'] ?? '';
    $password = $_POST['password'] ?? '';

    // Controleer of beide velden zijn ingevuld
    if (empty($username) || empty($password))
    {
        // Foutmelding wanneer velden leeg blijven
        $error = 'Gebruikersnaam en wachtwoord zijn verplicht.';
    }
    else
    {
        // Controleer of de inloggegevens overeenkomen met een gebruiker
        $user = checkLogin($username, $password, $users);

        // Als de inloggegevens correct zijn
        if ($user)
        {
            // Sla in de sessie op dat de gebruiker is ingelogd
            $_SESSION['loggedin'] = true;
            $_SESSION['username'] = $user['username'];
            $_SESSION['user_id'] = $user['id'];
            $_SESSION['user_name'] = $user['name'];

            // Stuur gebruiker door naar de overzichtspagina
            header('Location: overzicht.php');
            exit;
        }
        else
        {
            // Foutmelding bij onjuiste gebruikersnaam of wachtwoord
            $error = 'Ongeldige gebruikersnaam of wachtwoord.';
        }
    }
}
?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Inloggen - Dierentehuis Den Bosch</title>
    <link rel='stylesheet' href='../style/stylesheet2.css'>
</head>
<body>

<header>
    <!-- Logo van de website -->
    <img src="../images/logo.png" alt="Dierentehuis Den Bosch Logo" id="logo">
</header>

<!-- Navigatiemenu wordt ingeladen via include -->
<?php include '../includes/nav.php'; ?>

<main>
    <div class="container">
        <section class="login-section">
            <h1>Inloggen voor Vrijwilligers</h1>

            <!-- Toon foutmelding als die bestaat -->
            <?php if (isset($error)): ?>
                <div class="error-message">
                    <?php echo $error; ?>
                </div>
            <?php endif; ?>

            <!-- Inlogformulier -->
            <form method="POST" action="login.php" class="login-form">
                <div class="form-group">
                    <label for="username">Gebruikersnaam:</label>

                    <!-- Vul automatisch de eerder ingevulde gebruikersnaam in -->
                    <input type="text" id="username" name="username" required
                           value="<?php echo $_POST['username'] ?? ''; ?>">
                </div>

                <div class="form-group">
                    <label for="password">Wachtwoord:</label>

                    <!-- Wachtwoordveld (wordt niet herhaald bij foutmelding) -->
                    <input type="password" id="password" name="password" required>
                </div>

                <!-- Verstuurknop om in te loggen -->
                <button type="submit" class="btn login-btn">Inloggen</button>
            </form>

        </section>
    </div>
</main>

<!-- Footer wordt ingeladen via include -->
<?php include '../includes/footer.php'; ?>

</body>
</html>
