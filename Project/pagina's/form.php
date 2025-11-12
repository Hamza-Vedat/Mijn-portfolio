<?php session_start(); ?>
<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <title>McDonald's Zelftest</title>
    <link rel="stylesheet" href="/style/stylesheet.css">
</head>

<body>
<header>

</header>

<?php include '../includes/nav.php'; ?>

<main>
    <div class="background-container">
        <div class="form-container">
            <h1>McDonald's Zelftest</h1>
            <p>Beantwoord de vragen om jouw perfecte menu te ontdekken!</p>

            <form method="post" action="McDonald_Advies_Resultaat.php">
                <!-- Naam -->
                <div class="question">
                    <label><strong>Je naam:</strong></label><br>
                    <input type="text" name="name" required style="padding: 8px; width: 300px; margin-top: 10px;">
                </div>

                <!-- Vraag 1 -->
                <div class="question">
                    <h3>1. Hoe vaak gaat u naar McDonald's?</h3>
                    <input type="radio" name="q1" value="10" required> Vaak (1x per week of vaker)<br>
                    <input type="radio" name="q1" value="5"> Soms (1-2x per maand)<br>
                    <input type="radio" name="q1" value="0"> Zelden (minder dan 1x per maand)
                </div>

                <!-- Vraag 2 -->
                <div class="question">
                    <h3>2. Gebruikt u de McDonald's app voor kortingen of bestellingen?</h3>
                    <input type="radio" name="q2" value="10" required> Ja, regelmatig<br>
                    <input type="radio" name="q2" value="5"> Soms<br>
                    <input type="radio" name="q2" value="0"> Nee, nooit
                </div>

                <!-- Vraag 3 -->
                <div class="question">
                    <h3>3. Wat bestelt u meestal bij McDonald's?</h3>
                    <input type="radio" name="q3" value="10" required> Hamburgers (Big Mac, Quarter Pounder)<br>
                    <input type="radio" name="q3" value="10"> Kipproducten (McChicken, Crispy Chicken)<br>
                    <input type="radio" name="q3" value="5"> Anders (salades, wraps)<br>
                    <input type="radio" name="q3" value="5"> Happy Meal
                </div>

                <!-- Vraag 4 -->
                <div class="question">
                    <h3>4. Wat vindt u van de duurzame verpakkingen?</h3>
                    <input type="radio" name="q4" value="10" required> Zeer positief<br>
                    <input type="radio" name="q4" value="5"> Neutraal<br>
                    <input type="radio" name="q4" value="0"> Negatief
                </div>

                <!-- Vraag 5 -->
                <div class="question">
                    <h3>5. Hoe schoon vindt u het restaurant?</h3>
                    <input type="radio" name="q5" value="10" required> Altijd schoon<br>
                    <input type="radio" name="q5" value="5"> Meestal schoon<br>
                    <input type="radio" name="q5" value="0"> Vaak niet schoon
                </div>

                <!-- Vraag 6 -->
                <div class="question">
                    <h3>6. Hoe vriendelijk vindt u het personeel?</h3>
                    <input type="radio" name="q6" value="10" required> Zeer vriendelijk<br>
                    <input type="radio" name="q6" value="5"> Redelijk vriendelijk<br>
                    <input type="radio" name="q6" value="0"> Onvriendelijk
                </div>

                <!-- Vraag 7 -->
                <div class="question">
                    <h3>7. Wat is uw favoriete manier om te bestellen?</h3>
                    <input type="radio" name="q7" value="10" required> Aan de balie<br>
                    <input type="radio" name="q7" value="10"> Zelfservicescherm<br>
                    <input type="radio" name="q7" value="10"> McDonalds app<br>
                    <input type="radio" name="q7" value="10"> Drive-through
                </div>

                <!-- Vraag 8 -->
                <div class="question">
                    <h3>8. Vindt u McDonald's een goede plek voor kinderen?</h3>
                    <input type="radio" name="q8" value="10" required> Zeer geschikt<br>
                    <input type="radio" name="q8" value="5"> Redelijk geschikt<br>
                    <input type="radio" name="q8" value="0"> Niet geschikt
                </div>

                <!-- Vraag 9 -->
                <div class="question">
                    <h3>9. Zou u korting willen als u een herbruikbare beker meeneemt?</h3>
                    <input type="radio" name="q9" value="10" required> Ja, zeker<br>
                    <input type="radio" name="q9" value="5"> Misschien<br>
                    <input type="radio" name="q9" value="0"> Nee
                </div>

                <!-- Vraag 10 -->
                <div class="question">
                    <h3>10. Zou u snellere wifi willen in de McDonald's?</h3>
                    <input type="radio" name="q10" value="10" required> Ja, zeker<br>
                    <input type="radio" name="q10" value="5"> Neutraal<br>
                    <input type="radio" name="q10" value="0"> Nee
                </div>

                <!-- Vraag 11 -->
                <div class="question">
                    <h3>11. Wat vindt u van de zitplaatsen in het restaurant?</h3>
                    <input type="radio" name="q11" value="10" required> Zeer comfortabel<br>
                    <input type="radio" name="q11" value="5"> Redelijk comfortabel<br>
                    <input type="radio" name="q11" value="0"> Oncomfortabel
                </div>

                <!-- Vraag 12 -->
                <div class="question">
                    <h3>12. Wat vindt u van de sfeer in de McDonald's?</h3>
                    <input type="radio" name="q12" value="10" required> Zeer aangenaam<br>
                    <input type="radio" name="q12" value="5"> Neutraal<br>
                    <input type="radio" name="q12" value="0"> Slechts
                </div>

                <!-- Vraag 13 -->
                <div class="question">
                    <h3>13. Waarom kiest u voor McDonald's?</h3>
                    <input type="radio" name="q13" value="10" required> Smaak van het eten<br>
                    <input type="radio" name="q13" value="10"> Snelheid en gemak<br>
                    <input type="radio" name="q13" value="10"> Prijs/kwaliteit verhouding<br>
                    <input type="radio" name="q13" value="10"> Gezelligheid voor kinderen
                </div>

                <!-- Vraag 14 -->
                <div class="question">
                    <h3>14. Zou u meer internationale gerechten willen op het menu?</h3>
                    <input type="radio" name="q14" value="10" required> Ja, zeker<br>
                    <input type="radio" name="q14" value="5"> Misschien<br>
                    <input type="radio" name="q14" value="0"> Nee
                </div>

                <!-- Vraag 15 -->
                <div class="question">
                    <h3>15. Wat is uw favoriete tijd om McDonald's te bezoeken?</h3>
                    <input type="radio" name="q15" value="10" required> Lunchtijd (12:00-14:00)<br>
                    <input type="radio" name="q15" value="10"> Avondeten (17:00-19:00)<br>
                    <input type="radio" name="q15" value="10"> Late avond (na 19:00)<br>
                    <input type="radio" name="q15" value="10"> Ochtend/ontbijt
                </div>
                <!-- === SLIDERS === -->

                <!-- Aantal bezoeken per maand -->
                <div class="sliderBox">
                    <p class="vraag"><strong>16. Hoeveel geld geeft u gemiddeld uit bij de McDonald's?</strong></p>
                    <input type="range" min="0" max="250" value="0" name="hoevaak" class="slider" id="tandHoevaak" required>
                    <label for="tandHoevaak" class="value" id="hoeveelWaarde">0</label>
                </div>
                <br>

                <!-- Gemiddelde uitgave per bezoek -->
                <div class="sliderBox">
                    <p class="vraag"><strong>17. Hoeveel caloriën eet u gemiddeld bij de McDonald's?</strong></p>
                    <input type="range" min="0" max="5000"
                           value="<?php echo isset($_POST['hoelang']) ? $_POST['hoelang'] : 0; ?>"
                           name="hoelang" class="slider" id="tandHoelang" required>
                    <label for="tandHoelang" class="valueNext" id="hoeveelWaarde2">
                        <?php echo isset($_POST['hoelang']) ? $_POST['hoelang'] : 0; ?>
                    </label>
                </div>

                <script>
                    // Slider 1 - Geld uitgave
                    const slider1 = document.getElementById('tandHoevaak');
                    const label1 = document.getElementById('hoeveelWaarde');
                    label1.textContent = slider1.value;
                    slider1.addEventListener('input', () => label1.textContent = slider1.value);

                    // Slider 2 - Calorieën
                    const slider2 = document.getElementById('tandHoelang');
                    const label2 = document.getElementById('hoeveelWaarde2');
                    label2.textContent = slider2.value;
                    slider2.addEventListener('input', () => label2.textContent = slider2.value);
                </script>


                <button type="submit" class="submit-btn">Advies Ontvangen</button>
            </form>
        </div>
    </div>
</main>

<?php include '../includes/footer.php'; ?>
</body>
</html>