<?php
/**
 *  User: Hamza Oraloglu
 *  Date: 01.12.2025
 * File: footer.php
 */


?>

<footer>
    <p>Dierentehuis Den Bosch &copy; <?php echo date('Y'); ?></p>

    <?php if (isset($_SESSION['loggedin']) && $_SESSION['loggedin'] == true): ?>
        <p>
            Ingelogd als: <strong><?php echo $_SESSION['user_name']; ?></strong>
            |
            <a href="/REA_T3T4/Praktijk/Thema4/Praktijk Opdracht Dierentehuis/paginas/logout.php">Uitloggen</a>
        </p>
    <?php else: ?>
        <p>Niet ingelogd</p>
    <?php endif; ?>
</footer>

