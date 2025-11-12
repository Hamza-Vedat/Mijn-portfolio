<?php
$title = 'Samen vooruit – Goed om te weten';
$brand = 'Samen vooruit';

$base = './assets/';

$assets = [
        'hero'  => $base . 'hero.jpg',
        'card1' => $base . 'card1.jpg',
        'card2' => $base . 'card2.jpg',
        'card3' => $base . 'card3.jpg',
        'card4' => $base . 'card4.jpg',
        'card5' => $base . 'card5.jpg',
        'card6' => $base . 'card6.jpg',
        'help1' => $base . 'help1.jpg',
        'help2' => $base . 'help2.jpg',
        'help3' => $base . 'help3.jpg'
];

// Links voor elke kaart
$links_initiatives = [
        'https://art19.com/shows/de-reis-van-de-hamburger',
        'https://www.mcdonalds.com/nl/nl-nl/goed-om-te-weten/Europese-Toegankelijkheidswet.html',
        'https://www.mcdonalds.com/nl/nl-nl/goedomteweten/Voeding.html',
        'https://www.mcdonalds.com/nl/nl-nl/goedomteweten/Planet.html',
        'https://www.mcdonalds.com/nl/nl-nl/goedomteweten/goedebuur.html',
        'https://www.mcdonalds.com/nl/nl-nl/goedomteweten/Werkgeverschap.html'
];

$links_help = [
        'https://www.mcdonalds.com/content/mcdonalds/nl/nl-nl/goed-om-te-weten/voedingswaarde',
        'https://www.mcdonalds.com/nl/nl-nl/nutrition-calculator.html',
        'https://www.mcdonalds.com/nl/nl-nl/contact/meer-weten.html'
];
?>
<!doctype html>
<html lang="nl">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title><?= htmlspecialchars($title) ?></title>
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-white text-gray-900">
<header class="bg-white border-b border-gray-200">
    <div class="max-w-6xl mx-auto px-4 py-3 flex items-center justify-between">
        <h1 class="font-extrabold text-xl"><?= htmlspecialchars($brand) ?></h1>
        <nav class="space-x-6 font-medium">
            <a href="#initiatives" class="hover:underline">Initiatieven</a>
            <a href="#help" class="hover:underline">We helpen je</a>
        </nav>
    </div>
</header>

<main id="main">
    <section class="max-w-6xl mx-auto px-4 py-16 grid md:grid-cols-2 gap-10 items-center">
        <div>
            <h2 class="text-5xl font-extrabold mb-6">Samen vooruit</h2>
            <p class="text-lg text-gray-700 mb-6">
                Al meer dan 50 jaar verwelkomen we gasten. Wie nauw verbonden is met de samenleving, deelt verantwoordelijkheid
                en neemt initiatieven om samen oplossingen te vinden.
            </p>
            <a href="#initiatives" class="bg-yellow-400 px-5 py-3 rounded-xl font-semibold hover:bg-yellow-300">Ontdek initiatieven</a>
        </div>
        <img src="<?= $assets['hero'] ?>" alt="Samen vooruit" class="rounded-3xl shadow-xl w-full aspect-[4/3] object-cover">
    </section>

    <section id="initiatives" class="bg-gray-50 py-16">
        <div class="max-w-6xl mx-auto px-4">
            <h2 class="text-3xl font-extrabold mb-10">Initiatieven</h2>
            <div class="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
                <?php for ($i = 1; $i <= 6; $i++): ?>
                    <article class="bg-white border rounded-3xl overflow-hidden shadow hover:shadow-xl transition">
                        <img src="<?= $assets['card'.$i] ?>" alt="Initiatief <?= $i ?>" class="w-full aspect-[4/3] object-cover">
                        <div class="p-5">
                            <h3 class="text-xl font-bold mb-2">Initiatief <?= $i ?></h3>
                            <p class="text-gray-700 mb-4">Beschrijving van initiatief <?= $i ?>.</p>
                            <a href="<?= $links_initiatives[$i-1] ?>" target="_blank" class="font-semibold text-black hover:underline">Ontdek meer →</a>
                        </div>
                    </article>
                <?php endfor; ?>
            </div>
        </div>
    </section>

    <section id="help" class="py-16">
        <div class="max-w-6xl mx-auto px-4">
            <h2 class="text-3xl font-extrabold mb-10">We helpen je graag verder</h2>
            <div class="grid sm:grid-cols-2 lg:grid-cols-3 gap-6">
                <?php for ($i = 1; $i <= 3; $i++): ?>
                    <article class="bg-white border rounded-3xl overflow-hidden shadow hover:shadow-xl transition">
                        <img src="<?= $assets['help'.$i] ?>" alt="Hulp <?= $i ?>" class="w-full aspect-[16/9] object-cover">
                        <div class="p-5">
                            <h3 class="text-xl font-bold mb-2">Hulp <?= $i ?></h3>
                            <p class="text-gray-700 mb-4">Korte beschrijving van hulp <?= $i ?>.</p>
                            <a href="<?= $links_help[$i-1] ?>" target="_blank" class="font-semibold text-black hover:underline">Lees meer →</a>
                        </div>
                    </article>
                <?php endfor; ?>
            </div>
        </div>
    </section>
</main>

<footer>
    <?php include '../includes/footer.php'; ?>
</footer>
</body>
</html>