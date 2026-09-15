namespace Övning_5_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool körBankomat = true;
            int saldo = 0;

            while (körBankomat)
            {
                Console.WriteLine("Välkommen till Bankomaten!");
                Console.WriteLine("--------------------------");
                Console.WriteLine("[I]nsättning\n[U]ttag\n[S]aldo\n[A]vsluta");
                Console.WriteLine("--------------------------");
                Console.Write("Val: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.KeyChar)
                {
                    case 'i':
                        {
                            saldo += Insättning();
                            break;
                        }
                    case 'u':
                        {
                            saldo -= Uttag(saldo);
                            break;
                        }
                    case 's':
                        {
                            Saldo(saldo);
                            break;
                        }
                    case 'a':
                        {
                            körBankomat = Avsluta(körBankomat);
                            Console.WriteLine("Bankomaten avslutas. Hejdå!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Inkorrekt inmatning. Försök igen!");
                            break;
                        }
                }
            }
        }

        static int Insättning()
        {
            Console.Write("Hur mycket vill du sätta in: ");
            string strBelopp = Console.ReadLine();
            bool success = int.TryParse(strBelopp, out int belopp);
            if (success)
            {
                if (belopp > 0 && belopp <= 10000)
                {
                    Console.WriteLine($"{belopp} kr insatt på ditt konto");
                    return belopp;
                }
                else
                {
                    Console.WriteLine("Du får inte sätta in mer än 10 000 kr \nSe lagen om penningtvätt.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine("Inkorrekt inmatning. Försök igen");
                return 0;
            }
        }

        static void Saldo(int saldo)
        {
            Console.WriteLine($"Du har {saldo} kr på ditt konto.");
        }

        static int Uttag(int saldo)
        {
            Console.Write("Hur mycket vill du ta ut: ");
            string strBelopp = Console.ReadLine();
            bool success = int.TryParse(strBelopp, out int belopp);
            if (success && belopp <= saldo && belopp != 0)
            {
                Console.WriteLine($"Uttag genomförts. Ditt nya saldo är: {saldo - belopp}");
                return belopp;
            }
            else if (success && belopp > saldo || belopp == 0)
            {
                Console.WriteLine("Ditt saldo är för lågt för att genomföra detta uttag.");
                return 0;
            }
            else
            {
                Console.WriteLine("Inkorrekt inmatning. Försök igen!");
                return 0;
            }
        }

        static bool Avsluta(bool körBankomat)
        {
            return körBankomat = false;
        }
    }
}
