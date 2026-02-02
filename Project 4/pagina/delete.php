<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: verwijder.php
 */

session_start();   //Start een sessie

// Database functies inladen
include '../includes/db_functions_film_fabriek.php';
StartConnection();   //maakt verbinding met de database via $pdo

// Login controle
if (!isset($_SESSION['loggedin']) || $_SESSION['loggedin'] !== true)     // Controleer of de gebruiker niet is ingelogd:
                                                                         // - Als de sessievariabele 'loggedin' niet bestaat (!isset)
                                                                         // - Of als 'loggedin' niet gelijk is aan true (strikte vergelijking !== true
{
    header('Location: login.php');   //Als gebruiker niet ingelogd is redirect naar loginpagina
    exit;
}

// Film ID controle
if (!isset($_GET['film_id']))  // Controleer of de 'film_id' parameter niet in de URL aanwezig is
{
    die("Film ID ontbreekt!");  // Stop het script en geef een foutmelding: "Film ID ontbreekt!"
}


$film_id = $_GET["film_id"];  // Haal de film_id op uit de URL (GET parameter)

// Film delete
$query = "DELETE FROM films WHERE film_id = " . $film_id;
// Maak een SQL-query om de film met het opgegeven film_id te verwijderen uit de tabel 'films'

$result = ExecuteQuery($query);
// Voer de SQL-query uit en sla het resultaat op in $result


if ($result)
{
    header("Location: overzicht.php");
    exit();
} else
{
    die("Er is een fout opgetreden bij het verwijderen van de film.");
}
?>