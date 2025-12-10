<?php
/**
 * Functions for user authentication and management
 */

// Array of 5 users
$users = [
    [   // Gebruiker 1
        'id' => 1,
        'username' => 'hamza',        // Gebruikersnaam
        'password' => 'hamza123',     // Wachtwoord (onversleuteld)
        'name' => 'Hamza Vedat',      // Volledige naam
        'photo' => '../images/user-icon.png' // Profielfoto
    ],
    [   // Gebruiker 2
        'id' => 2,
        'username' => 'jeroen',
        'password' => 'jeroen123',
        'name' => 'Jeroen Verhoeven',
        'photo' => '../images/user-icon.png'
    ],
    [   // Gebruiker 3
        'id' => 3,
        'username' => 'bakker',
        'password' => 'bakker123',
        'name' => 'Thomas Bakker',
        'photo' => '../images/user-icon.png'
    ],
    [   // Gebruiker 4
        'id' => 4,
        'username' => 'sanne',
        'password' => 'sanne123',
        'name' => 'Sanne Meijer',
        'photo' => '../images/icon-women.jpg'
    ],
    [   // Gebruiker 5
        'id' => 5,
        'username' => 'visser',
        'password' => 'visser123',
        'name' => 'Mark Visser',
        'photo' => '../images/user-icon.png'
    ]
];

/**
 * Check if user login is successful
 */
function checkLogin($username, $password, $users)
{
    // Doorzoek de lijst van gebruikers
    foreach ($users as $user)
    {
        // Controleer of gebruikersnaam en wachtwoord overeenkomen
        if ($user['username'] === $username && $user['password'] === $password)
        {
            return $user; // Inloggen geslaagd: geef de gebruiker terug
        }
    }
    return false; // Inloggen mislukt
}

/**
 * Check if user is logged in using session
 */
function isLoggedIn()
{
    // Controleer of de sessie aangeeft dat de gebruiker is ingelogd
    return isset($_SESSION['loggedin']) && $_SESSION['loggedin'] === true;
}

/**
 * Redirect to login page if not logged in
 */
function requireLogin()
{
    // Als gebruiker niet is ingelogd → stuur naar loginpagina
    if (!isLoggedIn())
    {
        header('Location: login.php'); // Doorverwijzing
        exit; // Stop het script
    }
}
?>
