<?php
/*
 * Hamza Oraloglu
 * Studentnummer: 513743
 * Database functies voor Film Fabriek
 */

$pdo = null;  // $pdo → Globale variabele die de databaseverbinding opslaat
              // PDO (PHP Data Objects) wordt gebruikt om verbinding te maken met MySQL
function StartConnection($dbName = "film_fabriek")
{
    global $pdo;

    $dbHost = "localhost";

    if(!$dbName)
    {
        $dbName = "film_fabriek";
    }
    $dbUser = "root";
    $dbPassword = "";
    // Database login gegevens (user en wachtwoord)

    try
    {
        $pdo = new PDO("mysql:host=$dbHost;dbname=$dbName", $dbUser, $dbPassword);   // Maak PDO verbinding met MySQL
    }
    catch (PDOException $e)
    {
        echo "<h1>Database error:</h1>";
        echo $e->getMessage();
        die();                                       // Als verbinding mislukt → foutmelding tonen en script stoppen
    }
}

function ExecuteQuery($sql)
{
    global $pdo;

    try
    {
        $result = $pdo->query($sql);  // Voer de SQL query uit en sla resultaat op
        return $result;
    }
    catch (PDOException $e)
    {
        echo 'Er is een probleem met ophalen van de gegevens: ' . $e->getMessage();
        die();                          // Foutmelding bij mislukte query
    }
}

function ShowResultsInTable($result)
{
    $rows = $result->fetchAll(PDO::FETCH_ASSOC);

    if (empty($rows))
    {
        echo "Geen resultaten gevonden";
        return;                               // Als er geen resultaten zijn bericht tonen
    }

    echo "<table border='1' cellpadding='5' cellspacing='0'>";

    echo "<tr>";
    foreach (array_keys($rows[0]) as $column)
    {
        echo "<th>$column</th>";             // Kolomnamen tonen in de tabel header
    }
    echo "</tr>";

    foreach ($rows as $row)
    {
        echo "<tr>";
        foreach ($row as $value)
        {
            echo "<td>$value</td>";       // Rijwaarden tonen in tabel
        }
        echo "</tr>";
    }
    echo "</table>";
}
// NIEUW: Login
function checkLogin($username, $password)
{
    $sql = "SELECT * FROM users WHERE username = '$username' AND password = '$password'"; // SQL query controleer of gebruiker bestaat met opgegeven username en password
    $result = ExecuteQuery($sql);
    return $result->fetch(PDO::FETCH_ASSOC);                     // Haal eerste resultaat op als associatieve array gebruiker gegevens
}
?>
