using MiniVille;

namespace MiniVille
{
    internal class Player
    {
        public string Name;
        public int Money = 3;
        public List<Cards> City = new List<Cards>;

        public Player(string name)
        {
            Name = name;
        }

        public void AddCard(Cards card)
        {
            if (Money >= card.Cost)
            {
                Money -= card.Cost;
                City.Add(card);
            }
            else { Console.WriteLine("{0} n'a pas assez d'argent pour acheter une carte {1}", Name, card.Name); }
        }

        public void ActivateCards(int diceValue, bool isCurrentPlayer, Player opponent)
        {
            foreach (Cards c in City)
            {
                if (diceValue == c.Dice)
                {
                    if (c.Color == "Bleu")
                    {
                        Money += c.Gain;
                    }
                    else if (c.Color == "Vert" && isCurrentPlayer)
                    {
                        Money += c.Gain;
                    }
                    else if (c.Color == "Rouge" && !isCurrentPlayer)
                    {
                        if (opponent.Money >= 2 && c.Gain == 2)
                        {
                            Money += 2;
                            opponent.Money -= 2;
                        }
                        else if (opponent.Money >= 1)
                        {
                            Money += 1;
                            opponent.Money -= 1;
                        }
                    }
                }
            }
        }

        public void ShowCity()
        {
            List<int> alreadyDone = new List<int>();
            List<int> alreadyCount = new List<int>();
            Console.WriteLine("\nVille de {0} :", Name);
            foreach (Cards c in City)
            {
                if (!alreadyDone.Contains(c.Id))
                {
                    alreadyDone.Add(c.Id);
                    string space = " ";
                    int cardCount = 0;
                    for (int i = 0; i < City.Count; i++)
                    {
                        if (City[i].Id == c.Id)
                        {
                            cardCount++;
                        }
                    }
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
                    Console.Write("|\n|              |\n|Cost:{0}$       |\n|Gain:{1}$       |\n+==============+\n       x{2}\n", c.Cost, c.Gain, cardCount);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}