using System;
using System.Threading;
using System.Collections.Generic;


namespace Uppgift_6._4
{
    class Program
    {
        static void Main(string[] args)
        {

            int maxKortPoäng = 11;
            int minKortPoäng = 2;
            int maxPoäng = 21;

            List<string> namnVinnare = new List<string>();
            Random slump = new Random();
            string senasteVinnaren = "Ingen har vunnit än";

            Console.WriteLine("Välkommen till 21:an!");

            string menyVal = "0";
            while (menyVal != "5")
            {

                meny();

                menyVal = Console.ReadLine();
                switch (menyVal)
                {
                    // Spela en omgång av 21:an
                    case "1":

                        int datornsPoäng = 0;
                        int spelarensPoäng = 0;
                        Console.WriteLine("Nu kommer två kort dras per spelare");
                        datornsPoäng += slump.Next(minKortPoäng, maxKortPoäng);
                        spelarensPoäng += slump.Next(minKortPoäng, maxKortPoäng);
                        spelarensPoäng += slump.Next(minKortPoäng, maxKortPoäng);

                        // Låt användaren dra fler kort
                        string kortVal = "";
                        while (kortVal != "n" && spelarensPoäng <= maxPoäng)
                        {
                            Thread.Sleep(900);
                            Console.WriteLine($"Din poäng: {spelarensPoäng}");
                            Thread.Sleep(900);
                            Console.WriteLine($"Datorns poäng: {datornsPoäng}");
                            Thread.Sleep(900);
                            Console.WriteLine();
                            Console.WriteLine("Vill du ha ett till kort? (j/n)");
                            Console.WriteLine("Tryck på r för att se reglerna");

                            kortVal = Console.ReadLine();

                            switch (kortVal)
                            {
                                case "j":
                                    int nyPoäng = slump.Next(minKortPoäng, maxKortPoäng);
                                    spelarensPoäng += nyPoäng;
                                    Thread.Sleep(400);
                                    Console.WriteLine($"Ditt nya kort är värt {nyPoäng} poäng");
                                    Console.WriteLine();
                                    Thread.Sleep(400);
                                    Console.WriteLine($"Din totalpoäng är {spelarensPoäng}");
                                    break;

                                case "n":
                                    break;


                                case "r":
                                    regler();
                                    Console.WriteLine();
                                    break;


                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Du valde inte ett giltigt alternativ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }

                        }

                        // Gå tillbaka till huvudmenyn om användaren har över 21
                        if (spelarensPoäng > maxPoäng)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Du har mer än {maxPoäng} och har förlorat");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        // Datorn drar kort tills den vinner eller går över 21
                        while (datornsPoäng < spelarensPoäng && datornsPoäng <= maxPoäng)
                        {
                            int datornsNyaPoäng = slump.Next(1, 11);
                            datornsPoäng += datornsNyaPoäng;
                            Console.WriteLine($"Datorn drog ett kort värt {datornsNyaPoäng}");
                            Thread.Sleep(500);
                            Console.WriteLine();
                        }

                        Console.WriteLine($"Din poäng: {spelarensPoäng}");
                        Console.WriteLine($"Datorns poäng: {datornsPoäng}");

                        // Undersök vem som vann
                        if (datornsPoäng > maxPoäng)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Du har vunnit!");
                            Console.WriteLine("Skriv in ditt namn");


                            Console.ForegroundColor = ConsoleColor.White;
                            senasteVinnaren = Console.ReadLine();


                            namnVinnare.Add(senasteVinnaren);
                        }

                        if (datornsPoäng == spelarensPoäng)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("det blev oavgjort");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        if (datornsPoäng == 21 || spelarensPoäng > 21)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Datorn har vunnit!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }


                        break;

                    // Visa senaste vinnaren
                    case "2":
                        Console.WriteLine($"Senaste vinnaren: {senasteVinnaren}");

                        foreach (string namn in namnVinnare)
                        {
                            Console.WriteLine($"här är namnen på alla som har vunnit {namn}");
                        }
                        break;




                    // anropa spelets regler
                    case "3":
                        regler();
                        break;





                    // spelaren får bestämma kortens värde
                    case "4":
                        Console.WriteLine("vad vill du att ett kort max kan vara värt?");
                        maxKortPoäng = int.Parse(Console.ReadLine()) + 1;

                        Console.WriteLine("vad vill du att ett kort minst kan vara värt?");
                        minKortPoäng = int.Parse(Console.ReadLine()) + 1;

                        Console.WriteLine("vad vill du ha för högsta nummer?");
                        maxPoäng = int.Parse(Console.ReadLine());




                        break;

                    // Gör ingenting (programmet avslutas)
                    case "5":
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du valde inte ett giltigt alternativ");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                // Tom rad innan nästa körning
                Console.WriteLine();
            }
            static void regler()
            {
                Console.WriteLine("Ditt mål är att tvinga datorn att få mer än 21 poäng.");
                Console.WriteLine("Du får poäng genom att dra kort, varje kort har 1-10 poäng.");
                Console.WriteLine("Om du får mer än 21 poäng har du förlorat.");
                Console.WriteLine("Både du och datorn får två kort i början. Därefter får du");
                Console.WriteLine("dra fler kort tills du är nöjd eller får över 21.");
                Console.WriteLine("När du är färdig drar datorn kort till den har");
                Console.WriteLine("mer poäng än dig eller över 21 poäng.");
            }
            static void meny()
            {
                // Skriv ut huvudmenyn
                Thread.Sleep(300);
                Console.WriteLine("Välj ett alternativ");
                Thread.Sleep(300);
                Console.WriteLine("1. Spela 21:an");
                Thread.Sleep(300);
                Console.WriteLine("2. Visa senaste vinnaren");
                Thread.Sleep(300);
                Console.WriteLine("3. Spelets regler");
                Thread.Sleep(300);
                Console.WriteLine("4. ändra inställningarna");
                Thread.Sleep(300);
                Console.WriteLine("5. Avsluta programmet");


                // Tom rad innan användarens val körs
                Console.WriteLine();

            }
        }
    }
}