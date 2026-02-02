<?php
/**
 * User: Hamza Oraloglu
 * Date: 05.01.2026
 * File: index.php
 */


session_start();     //Start een sessie in PHP

include 'includes/db_functions_film_fabriek.php';   //Voeg een ander PHP-bestand toe en voer het uit

StartConnection("film_fabriek");   //Maakt verbinding met de database

?>

<!DOCTYPE html>

<html lang="nl">
<head>
    <meta charset="UTF-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Film Fabriek - Home</title>

    <link rel='stylesheet' href='styles/stylesheet.css'>
</head>
<body>

<header>
    <img src="images/film_fabriek_logo.png" alt="Film Fabriek Logo" id="logo">
</header>

<?php include 'includes/nav.php'; ?>

<?php include 'includes/main.php'; ?>

<?php include 'includes/footer.php'; ?>


</body>
</html>

