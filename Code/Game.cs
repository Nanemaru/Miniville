using System;

namespace MiniVille
{
    public class Game
    {
        private Dice dice;
        private Player player;
        private Player ai;
        private Piles piles;

        public Game()
        {
            dice = new Dice();
            piles = new Piles();
            player = new Player("Joueur");
            ai = new Player("Ordinateur");

            // Cartes de départ
            var champ = piles.AvailableCards.First(c => c.Name == "Champs de blé");
            var boulangerie = piles.AvailableCards.First(c => c.Name == "Boulangerie");
            player.City.Add(champ);
            player.City.Add(boulangerie);
            ai.City.Add(champ);
            ai.City.Add(boulangerie);

            Start();
        }

        private void Start()
        {
            Console.WriteLine("=== MiniVilles ===");
            Console.WriteLine("Objectif : atteindre 20 pièces pour gagner !");
            //Boucle de gameplay
            while (true)
            {
                //Si la fonction PlayerTurn retourne true dans un des deux if, la partie prend fin
                if (PlayerTurn(player, ai)) break;
                if (PlayerTurn(ai, player, isAI: true)) break;
            }
        }

        private bool PlayerTurn(Player active, Player opponent, bool isAI = false)
        {
            Console.WriteLine($"\n--- Tour de {active.Name} ---");
            active.ShowCity();
            if (!isAI)
            {
                Console.WriteLine("Appuyez sur Entrée pour lancer le dé.");
                Console.ReadLine();
            }

            //On lance le dé
            int result = dice.Roll();

            // Activation des cartes
            opponent.ActivateCards(result, false, active);
            active.ActivateCards(result, true, opponent);

            // Vérifier victoire
            if (active.Money >= 20)
            {
                Console.WriteLine($"\n{active.Name} a gagné avec {active.Money} pièces !");
                return true;
            }

            // Achat de carte
            if (isAI)
            {
                Console.WriteLine($"{active.Name} a obtenu {result}.");
                AIBuyCard(active);

            }
            else
                PlayerBuyCard(active, result);

            return false;
        }

        private void PlayerBuyCard(Player player, int result)
        {
            /*
            Affichage dans un ordre précis pour des questionss de lisibilité
            - Résultat du dé
            - Nombre de pièces
            - Question au joueur
            */
            Console.WriteLine($"{player.Name} a obtenu {result}.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pièces : {0}", player.Money);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Souhaitez-vous acheter une carte ? (o/n)");
            string choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                case "o" | "oui" | "Oui":
                    {
                        List<int> alreadyDisplayedCards = new List<int>();
                        int cardCount = 0;
                        foreach (Cards c in piles.AvailableCards)
                        {
                            if (!alreadyDisplayedCards.Contains(c.Id))
                            {
                                alreadyDisplayedCards.Add(c.Id);
                                for (int i = 0; i < piles.AvailableCards.Count; i++)
                                {
                                    if (piles.AvailableCards[i].Id == c.Id)
                                    {
                                        cardCount++;
                                    }
                                }
                                Console.WriteLine("x{0} {1}", cardCount, c.Name);
                                cardCount = 0;
                            }
                        }
                        Console.WriteLine("Entrez le nom exact de la carte à acheter :");
                        string name = Console.ReadLine();


                        var card = piles.AvailableCards.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (card != null && player.Money >= card.Cost)
                        {
                            player.AddCard(card);
                            piles.AvailableCards.Remove(card);
                            Console.WriteLine($"{player.Name} achète {card.Name} !"); //good
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Achat impossible.");
                            break;
                        }
                    }
                case "n" | "non" | "Non":
                    {
                        Console.WriteLine("{0} n'achète rien", player.Name);
                    }
                default:
                    {
                        Console.WriteLine("Vous devez choisir une réponse valide.");
                        Continue;
                    }
            }
            }
        }

        private void AIBuyCard(Player ai)
        {
            var choix = piles.AvailableCards.Where(c => c.Cost <= ai.Money).ToList();
            if (choix.Count > 0)
            {
                var rand = new Random();
                var card = choix[rand.Next(choix.Count)];
                ai.AddCard(card);
                piles.AvailableCards.Remove(card);
                Console.WriteLine($"{ai.Name} achète {card.Name}."); //good
            }
            else
            {
                Console.WriteLine($"{ai.Name} ne peut rien acheter.");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Argent restant: {ai.Money}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}