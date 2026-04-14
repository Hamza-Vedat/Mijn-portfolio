using System;

namespace UltimateFootballQuiz
{
    class Program
    {
        static List<int> scoresGeschiedenis = new List<int>();

        static void Main(string[] args)
        {
            bool opnieuwSpelen = true;

            while (opnieuwSpelen)
            {
                Console.Clear();
                int totaalScore = 0;

                // INTRO
                ShowIntro();
                // RONDE 1 - 3 KENNISVRAGEN
                totaalScore = Ronde1(totaalScore);
                if (totaalScore < 20)
                {
                    EindScore(totaalScore);
                    scoresGeschiedenis.Add(totaalScore);

                    Console.Write("Quiz opnieuw spelen? (ja/nee): ");
                    string keuze = Console.ReadLine().ToLower();
                    opnieuwSpelen = (keuze == "ja");
                    continue;
                }
                // RONDE 2 - MINISPEL 1
                totaalScore = Ronde2(totaalScore);
                if (totaalScore < 30)
                {
                    EindScore(totaalScore);
                    scoresGeschiedenis.Add(totaalScore);

                    Console.Write("Quiz opnieuw spelen? (ja/nee): ");
                    string keuze = Console.ReadLine().ToLower();
                    opnieuwSpelen = (keuze == "ja");
                    continue;
                }
                // RONDE 3 - 3 INSCHATTINGSVRAGEN
                totaalScore = Ronde3(totaalScore);
                if (totaalScore < 50)
                {
                    EindScore(totaalScore);
                    scoresGeschiedenis.Add(totaalScore);

                    Console.Write("Quiz opnieuw spelen? (ja/nee): ");
                    string keuze = Console.ReadLine().ToLower();
                    opnieuwSpelen = (keuze == "ja");
                    continue;
                }
                // RONDE 4 - MINISPEL 2
                totaalScore = Ronde4(totaalScore);
                if (totaalScore < 65)
                {
                    EindScore(totaalScore);
                    scoresGeschiedenis.Add(totaalScore);

                    Console.Write("Quiz opnieuw spelen? (ja/nee): ");
                    string keuze = Console.ReadLine().ToLower();
                    opnieuwSpelen = (keuze == "ja");
                    continue;
                }
                // RONDE 5 - 3 GEHEUGENVRAGEN
                totaalScore = Ronde5(totaalScore);

                // EINDSCORE
                EindScore(totaalScore);
                scoresGeschiedenis.Add(totaalScore);

                // OPNIEUW SPELEN?
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nQuiz opnieuw spelen? (ja/nee): ");
                Console.ResetColor();
                string antwoord = Console.ReadLine().ToLower();

                if (antwoord != "ja")
                {
                    opnieuwSpelen = false;
                }
            }
            // SCORES TONEN
            ToonAlleScores();
        }
        // INTRO MET ANIMATIE
        static void ShowIntro()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*** WELKOM BIJ ULTIMATE FOOTBAL QUIZ ***");

            // Animatie: knipperende tekst
            for (int i = 3; i > 0; i--)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nQuiz start over {i} seconden...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        // RONDE 1 - 3 KENNISVRAGEN
        static int Ronde1(int huidigeScore)
        {
            Console.Clear();
            Console.WriteLine("*** RONDE 1: KENNISVRAGEN ***");
            Console.ResetColor();

            string[] vragen = 
            {
                "Wie won de Champions League in 2023?\nA) Manchester City\nB) Real Madrid\nC) Bayern München",
                "Welk land won het WK voetbal in 2018?\nA) Duitsland\nB) Frankrijk\nC) Brazilië",
                "Voor welke club speelt N'Golo Kanté sinds 2026?\nA) FC Barcelona\nB) Paris Saint-Germain\nC) Fenerbahce"
            };

            char[] juisteAntwoorden = { 'A', 'B', 'C' };
            int score = huidigeScore;

            for (int i = 0; i < vragen.Length; i++)
            {
                Console.WriteLine($"\nVraag {i + 1}:");
                Console.WriteLine(vragen[i]);
                Console.Write("\nJouw antwoord (A/B/C): ");
                char antwoord = Console.ReadLine().ToUpper()[0];

                if (antwoord == juisteAntwoorden[i])
                {
                    Console.WriteLine("Goed antwoord! +10 punten");
                    score += 10;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Fout antwoord! 0 punten");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nEindscore Ronde 1: {score} punten");

            if (score >= 20)
            {
                Console.WriteLine("Gefeliciteerd! Je gaat door naar Ronde 2!");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helaas! Je hebt te weinig punten.");
                Console.ResetColor();
            }

            Thread.Sleep(2000);
            return score;
        }

        // RONDE 2 - MINISPEL 1: PENALTY SCHIETEN
        static int Ronde2(int huidigeScore)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** RONDE 2: PENALTY SCHIETEN ***");
            Console.ResetColor();
            Console.WriteLine("\nPENALTY SCHIETEN!");
            Console.WriteLine("Kies waar je schiet:");
            Console.WriteLine("[1] Links");
            Console.WriteLine("[2] Midden");
            Console.WriteLine("[3] Rechts");

            Random rnd = new Random();
            int keeperKeuze = rnd.Next(1, 4);

            Console.Write("\nJouw keuze (1-3): ");
            string input = Console.ReadLine();
            int spelerKeuze;

            if (int.TryParse(input, out spelerKeuze) && spelerKeuze >= 1 && spelerKeuze <= 3)
            {
                if (spelerKeuze != keeperKeuze)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("GOAL! +15 punten");
                    huidigeScore += 15;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("REDDING! 0 punten");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ongeldige keuze! 0 punten");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nTotale score: {huidigeScore} punten");

            if (huidigeScore >= 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Je gaat door naar Ronde 3!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helaas! Je gaat niet door.");
                Console.ResetColor();
            }

            Thread.Sleep(2000);
            return huidigeScore;
        }
        // RONDE 3 - 3 INSCHATTINGSVRAGEN
        static int Ronde3(int huidigeScore)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** RONDE 3: INSCHATTINGSVRAGEN ***");
            Console.ResetColor();

            string[] vragen = 
            {
                "Hoeveel goals heeft Lionel Messi ongeveer gescoord in zijn carrière?\nA) 350 goals\nB) 550 goals\nC) 800 goals",
                "Hoeveel goals worden er gemiddeld per wedstrijd gescoord in de Champions League?\nA) Ongeveer 1 goal\nB) Ongeveer 2,5 goals\nC) Ongeveer 5 goals",
                "Hoeveel keer heeft Real Madrid de Champions League gewonnen?\nA) 6 keer\nB) 10 keer\nC) 14 keer"
            };

            char[] juisteAntwoorden = { 'C', 'B', 'C' };
            int score = huidigeScore;
            int correct = 0;

            for (int i = 0; i < vragen.Length; i++)
            {
                Console.WriteLine($"\nVraag {i + 1}:");
                Console.WriteLine(vragen[i]);
                Console.Write("\nJouw antwoord (A/B/C): ");
                var input = Console.ReadLine();
                char antwoord = input.ToUpper()[0];

                if (antwoord == juisteAntwoorden[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Correct! +10 punten");
                    score += 10;
                    correct++;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Fout! 0 punten");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nAantal correct: {correct}/3");
            Console.WriteLine($"Totale score: {score} punten");

            if (correct >= 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Gefeliciteerd! Je gaat door naar Ronde 4!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helaas! Je gaat niet door.");
                Console.ResetColor();
            }
            Thread.Sleep(2000);
            return score;
        }

        // RONDE 4 - MINISPEL 2: SNELLE REACTIE
        static int Ronde4(int huidigeScore)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** RONDE 4: SNELLE REACTIE ***");
            Console.ResetColor();

            Console.WriteLine("\nSNELLE REACTIE!");
            Console.WriteLine("Je hebt 5 seconden...");
            Console.WriteLine("\nVRAAG: In welk jaar won Nederland het EK?");
            Console.Write("\nAntwoord: ");

            bool beantwoord = false;
            string antwoord = "";
            DateTime startTijd = DateTime.Now;

            while ((DateTime.Now - startTijd).TotalSeconds < 5 && !beantwoord)
            {
                if (Console.KeyAvailable)
                {
                    antwoord = Console.ReadLine();
                    beantwoord = true;
                }
                Thread.Sleep(10);
            }

            if (!beantwoord)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nTe laat! 0 punten");
                Console.ResetColor();
            }
            else
            {
                if (antwoord == "1988")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCorrect! +20 punten");
                    huidigeScore += 20;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nFout antwoord! 0 punten");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nTotale score: {huidigeScore} punten");

            if (huidigeScore >= 65)
            {
                Console.WriteLine("Je gaat door naar de FINALE RONDE!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helaas! Je gaat niet door.");
                Console.ResetColor();
            }

            Thread.Sleep(2000);
            return huidigeScore;
        }
        // RONDE 5 - 3 GEHEUGENVRAGEN
        static int Ronde5(int huidigeScore)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*** RONDE 5: GEHEUGENVRAGEN ***");
            Console.ResetColor();
            Console.WriteLine("\nOnthoud wat je eerder hebt geantwoord!");

            string[] vragen =
            {
                "Hoeveel goals heeft Lionel Messi ongeveer gescoord in zijn carrière?\nA) 350 goals\nB) 550 goals\nC) 800 goals",
                "Hoeveel keer heeft Real Madrid de Champions League gewonnen?\nA) 6 keer\nB) 10 keer\nC) 14 keer",
                "Voor welke club speelt N'Golo Kanté sinds 2026?\nA) FC Barcelona\nB) Paris Saint-Germain\nC) Fenerbahce"
            };

            char[] juisteAntwoorden = { 'C', 'C', 'C' };
            int score = huidigeScore;

            for (int i = 0; i < vragen.Length; i++)
            {
                Console.WriteLine($"\nVraag {i + 1}:");
                Console.WriteLine(vragen[i]);
                Console.Write("\nJouw antwoord (A/B/C): ");
                char antwoord = Console.ReadLine().ToUpper()[0];

                if (antwoord == juisteAntwoorden[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Goed onthouden! +15 punten");
                    score += 15;
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Fout! 0 punten");
                    Console.ResetColor();
                }
                Thread.Sleep(1000);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nEindscore deze ronde: {score - huidigeScore} punten");
            Console.WriteLine($"Totale score: {score} punten");
            Console.ResetColor();
            Thread.Sleep(2000);
            return score;
        }

        // EINDSCORE TONEN
        static void EindScore(int score)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*** EINDSCORE ***");
            Console.ResetColor();

            Console.WriteLine($"\nJe hebt {score} punten gehaald!");

            if (score >= 80)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (score >= 60)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (score >= 40)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.ResetColor();
            Thread.Sleep(2000);
        }
        // ALLE SCORES TONEN
        static void ToonAlleScores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** SCORE GESCHIEDENIS ***");
            Console.ResetColor();

            if (scoresGeschiedenis.Count == 0)
            {
                Console.WriteLine("\nEr zijn nog geen scores.");
            }
            else
            {
                Console.WriteLine("\nJouw scores per beurt:");
                for (int i = 0; i < scoresGeschiedenis.Count; i++)
                {
                    Console.WriteLine($"Beurt {i + 1}: {scoresGeschiedenis[i]} punten");
                }
            }
            Console.WriteLine("\nDruk op een toets om af te sluiten...");
            Console.ReadKey();
        }
    }
}