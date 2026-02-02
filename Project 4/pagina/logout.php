<?php
/**
 * User: Hamza Oraloglu
 * Date: 01.12.2025
 * File: logout.php
 */

// Start de sessie zodat we deze kunnen beëindigen
session_start();

// Verwijder alle gegevens uit de sessie
session_unset();

// Vernietig de hele sessie (gebruiker wordt volledig uitgelogd)
session_destroy();

// Stuur de gebruiker terug naar de loginpagina met een melding
header('Location: /Periode 4 Project/Project/pagina/login.php?message=loggedout');
exit;

