using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RPG_simulátor_2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vytvoření statistik DAN
            int unavenost = 0;
            int level = 1;
            Dictionary<string, int> stats = new Dictionary<string, int>();
            stats.Add("STR", 10);
            stats.Add("DEX", 10);
            stats.Add("INT", 10);

            //pole atributu karel
            string[] pole = { "STR", "DEX", "INT" };



            //Určí jméno Vítek
            Console.WriteLine("Zadej jméno charaktera: ");
            string jmeno = Console.ReadLine();

            do
            {
                // vypsání ui karel
                Console.Clear();
                Console.WriteLine($"Jsi unavený na {unavenost}%");
                Console.WriteLine("Chcete jít na quest nebo spánek ? Q/S");
                string odpoved = Console.ReadLine().ToLower().Trim();
                //spanek nebo quest Dan
                if (odpoved == "s")
                {
                    Console.Clear();
                    Console.WriteLine($"{jmeno} bude spát jestě {unavenost} sekund.");
                    Thread.Sleep(unavenost * 1000);
                    Console.WriteLine($"{jmeno} už je vzhůru.");
                    unavenost = 0;
                    Console.WriteLine("Pro pokračování stiskni libovolné tlačítko...");
                    Console.ReadKey();
                }
                else if (odpoved == "q")
                {
                    Console.Clear();
                    // Určí stat questy Vítek
                    Random random = new Random();
                    Random rnd = new Random();
                    string quest = pole[random.Next(0, pole.Length)];
                    Console.WriteLine($"Jdeš na quest na {quest}, vrať se za {level * 10} sekund.\n...");
                    Thread.Sleep(level * 10000);

                    if (random.Next(0, 101) > unavenost)
                    {
                        level++;
                        stats[quest] += 10;
                        Console.WriteLine($"{jmeno} se vrátil z questu jako rybička.\n---------------------------------  ");
                        Console.WriteLine($"{jmeno} má lvl {level} a vlastnosti:");
                        // vypsání kolekce
                        foreach (var item in stats)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                        unavenost += 10;
                        Console.WriteLine("Pro pokračování stiskni libovolné tlačítko...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"{jmeno} zemřel.");
                        Console.WriteLine("Pro ukončení stiskni libovolné tlačítko...");
                        Console.ReadKey();
                        break;
                    }
                }

            } while (true);

        }
    }
}
