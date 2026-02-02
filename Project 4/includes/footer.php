<?php
/**
 *  User: Hamza Oraloglu
 *  Date: 05.01.2026
 * File: footer.php
 */


?>

<footer>
    <p>Film Fabriek &copy; <?php echo date('Y'); ?> | <?php echo date('d-m-Y'); ?></p>

    <?php if (isset($_SESSION['loggedin']) && $_SESSION['loggedin'] == true): ?>
        <p>
            Ingelogd als: <strong><?php echo $_SESSION['username']; ?></strong>
            |
            <a href="/Project/pagina/logout.php">Uitloggen</a>
        </p>
    <?php else: ?>
        <p>Niet ingelogd</p>
    <?php endif; ?>
</footer>

