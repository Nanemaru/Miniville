using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniVille_chez_ouam
{
    internal class Player
    {
        public string Name;
        public int Money;
        public List<Cards> City;

        public Player(string name)
        {
            Name = name;
            Money = 3;
            City = new List<Cards>();
        }

        public void AddCard(Cards card)
        {
            if (Money >= card.Cost)
            {
                Money -= card.Cost;
                City.Add(card);
                Console.WriteLine("{0} achète une carte {1}.", Name, card.Name);
            }
            else { Console.WriteLine("{0} n'a pas assez d'argent pour acheter une carte {1}", Name, card.Name); }
        }

        public void ActivateCard(int diceValue, bool isCurrentPlayer)
        {
            foreach (Cards c in City)
            {
                if (diceValue == c.Dice)
                {
                    if (c.Color == "Blue")
                    {
                        Money += c.Gain;
                    }
                    else if (c.Color == "Green" && isCurrentPlayer)
                    {
                        Money += c.Gain;
                    }
                    else if (c.Color == "Red" && !isCurrentPlayer)
                    {
                        Money += c.Gain;
                    }
                }
            }
        }

        public void ShowCity()
        {
            List<int> alreadyDone = new List<int>();
            Console.WriteLine("\nVille de {0} :", Name);
            foreach (Cards c in City)
            {
                if (!alreadyDone.Contains(c.Id))
                {
                    alreadyDone.Add(c.Id);
                    string space = " ";
                    int numberOfCards = 3;
                    switch (c.Color)
                    {
                        case "Green":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            break;
                        case "Blue":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case "Red":
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                    }
                    Console.Write("+==============+\n| Activation:{0} |\n|              |\n|              |\n|              |\n|              |\n|              |\n|{1}", c.Dice, c.Name);
                    for (int i = (14 - c.Name.Length); i > 0; i--)
                    {
                        Console.Write(space);
                    }
                    Console.Write("|\n|              |\n|Cost:{0}$       |\n|Gain:{1}$       |\n+==============+\n       x{2}", c.Cost, c.Gain, numberOfCards);
                }
            }
        }
    }
}

