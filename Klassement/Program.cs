namespace Klassement
{
    internal class Program
    {
        static Dictionary<string, int> _ranking = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            bool keepRunning = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Welkom bij het Klassement Beheer Systeem!");
                Console.WriteLine("Kies een optie uit het menu:");
                Console.WriteLine();
                Console.WriteLine("1.Toon het klassement");
                Console.WriteLine("2.Zoek de score van een deelnemer");
                Console.WriteLine("3.Pas de score van een deelnemer aan of voeg een nieuwe deelnemer toe");
                Console.WriteLine("4.Toon de gemiddelde score");
                Console.WriteLine("5.Toon de deelnemer met de hoogste score");
                Console.WriteLine("6.Stop het programma");
                Console.WriteLine();
                Console.Write("Maak uw keuze: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowRanking();
                        break;
                    case "2":
                        ShowScore();
                        break;
                    case "3":
                        AddOrUpdateScore();
                        break;
                    case "4":
                        ShowAverage();
                        break;
                    case "5":
                        ShowHighest();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                }
            } while (keepRunning);
        }

        static void ShowRanking()
        {
            Console.WriteLine("Klassement:");
            //foreach (KeyValuePair<string, int> pair in _ranking)
            //{
            //    Console.WriteLine($"- {pair.Key}: {pair.Value} punten.");
            //}
            foreach (string name in _ranking.Keys)
            {
                Console.WriteLine($"- {name}: {_ranking[name]} punten.");
            }

            Console.ReadKey(true);
        }

        static void ShowScore()
        {
            Console.Write("Geef de naam van een deelnemer: ");
            string name = Console.ReadLine();

            if(_ranking.TryGetValue(name, out int score))
            {
                Console.WriteLine($"{name} heeft {score} punten.");
            }
            else
            {
                Console.WriteLine($"{name} staat niet in het klassement.");
            }

            Console.ReadKey(true);
        }

        static void AddOrUpdateScore()
        {
            Console.Write("Geef de naam van een deelnemer: ");
            string name = Console.ReadLine();
            Console.Write("Geef de nieuwe score: ");
            int score = int.Parse(Console.ReadLine());

            if(_ranking.ContainsKey(name))
            {
                //Naam bestaat reeds in klassement
                _ranking[name] = score;
                Console.WriteLine($"De score van {name} is bijgewerkt naar {score} punten.");
            }
            else
            {
                //Nieuwe deelnemer
                _ranking.Add(name, score);
                Console.WriteLine($"{name} is toegevoegd aan het klassement met {score} punten.");
            }

            Console.ReadKey(true);
        }

        static void ShowAverage()
        {
            //double average = _ranking.Average(x => x.Value);

            double sum = 0;

            foreach (int score in _ranking.Values)
            {
                sum += score;
            }

            double average = sum / _ranking.Count;

            Console.WriteLine($"De gemiddelde score van alle deelnemers is: {average} punten.");
            Console.ReadKey(true);
        }

        static void ShowHighest()
        {
            //var highest = _ranking.MaxBy(kvp => kvp.Value);

            KeyValuePair<string, int> highestPair = _ranking.First();
            foreach(var pair in _ranking)
            {
                if(pair.Value > highestPair.Value)
                {
                    highestPair = pair;
                }
            }

            Console.WriteLine($"De deelnemer met de hoogste score is {highestPair.Key} met {highestPair.Value} punten.");

            Console.ReadKey(true);
        }
    }
}
