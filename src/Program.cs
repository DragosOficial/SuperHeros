namespace SuperHeros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista dostępnych bohaterów
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Wizard("Czarodziej", 500, Colors.green, 0));
            heroes.Add(new Knight("Rycerz", 700, Colors.red, 1));
            heroes.Add(new Soldier("Żołnierz", 650, Colors.yellow, 1));
            // Lista dostępnych bohaterów

            // Ilość graczy (Hero)
            Hero player1;
            Hero player2;
            // Ilość graczy (Hero)

            // Pętle odpowiadające za wybór postaci
            bool isChosed = false;
            do
            {
                isChosed = ChooseHero(out player1, 1, ref heroes);
            } while (!isChosed);

            do
            {
                isChosed = ChooseHero(out player2, 2, ref heroes);
            } while (!isChosed);
            // Pętle odpowiadające za wybór postaci

            bool isPlayer1Turn = true;

            // Pętla głównej gry
            do
            {
                Console.Clear();
                switch (player1.Color)
                {
                    case Colors.red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Colors.green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Colors.yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Gracz 1");
                Console.WriteLine(player1);

                switch (player2.Color)
                {
                    case Colors.red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Colors.green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Colors.yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        break;
                }
                Console.CursorTop = 0;
                Console.CursorLeft = 25;
                Console.WriteLine("Gracz 2");
                Console.CursorTop = 1;
                Console.CursorLeft = 25;
                Console.WriteLine(player2);
                Console.ResetColor();

                Hero actualPlayer = isPlayer1Turn ? player1 : player2;
                Hero otherPlayer = isPlayer1Turn ? player2 : player1;

                Console.WriteLine($"\nRuch gracza: {(isPlayer1Turn ? 1 : 2)}");
                Console.WriteLine("\nCo chcesz zrobić?");
                Console.WriteLine("1. Podstawowy atak");
                Console.WriteLine("2. Obanażuj rany");
                if(actualPlayer is IFirstAidKit && actualPlayer.ActualFirstAidKits > 0)
                {
                    Console.WriteLine("3. Apteczka Wojskowa");
                }

                if(actualPlayer is ISpecialAttack && !actualPlayer.UsedSpecialAttack)
                {
                    Console.WriteLine("4. Specjalny atak");
                }

                ConsoleKey key;
                do
                {
                    key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.D1:
                            actualPlayer.DefaultAttack(otherPlayer);
                            break;
                        case ConsoleKey.D2:
                            actualPlayer.Heal();
                            break;
                        case ConsoleKey.D3:
                            if(actualPlayer is IFirstAidKit && actualPlayer.ActualFirstAidKits > 0)
                            {
                                ((IFirstAidKit)actualPlayer).FirstAidKit();
                                actualPlayer.ActualFirstAidKits--;
                            }
                            else if(actualPlayer is IFirstAidKit && actualPlayer.ActualFirstAidKits > 0)
                            {
                                actualPlayer.Heal();
                            }
                            break;
                        case ConsoleKey.D4:
                            if(actualPlayer is ISpecialAttack && !actualPlayer.UsedSpecialAttack)
                            {
                                ((ISpecialAttack)actualPlayer).SpecialAttack(otherPlayer);
                                actualPlayer.UsedSpecialAttack = true;
                            }
                            else
                            {
                                actualPlayer.DefaultAttack(otherPlayer);
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nie ma dostępnego takiego ruchu!");
                            Console.ResetColor();
                            break;
                    }

                    if(player1.ActualHP == 0 || player2.ActualHP == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Niestety Gracz {(isPlayer1Turn ? 2 : 1)} zginął!");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Wygrywa Gracz {(isPlayer1Turn ? 1 : 2)}!");
                        Console.ResetColor();
                    }
                    else
                    {
                        isPlayer1Turn = !isPlayer1Turn;
                    }

                } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3 && key != ConsoleKey.D4);

                Console.ReadKey();

            } while (player1.ActualHP > 0 && player2.ActualHP > 0);
        }
        // Pętla głównej gry

        // Statyczna funkcja wybrania bohatera
        static bool ChooseHero(out Hero hero, int player, ref List<Hero> heroes)
        {
            Console.Clear();
            Console.WriteLine($"Gracz {player} wybiera swoją postać:");
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {heroes[i].Name}");
            }

            int num;
            int.TryParse(Console.ReadLine(), out num);

            if(num >= 1 && num <= heroes.Count)
            {
                hero = heroes[num - 1];
                heroes.Remove(hero);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie ma dostępnego takiego bohatera!");
                Console.ResetColor();
                Console.ReadKey();
                hero = null;
                return false;
            }
        }
        // Statyczna Funkcja wybrania bohatera
    }
}