using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
            bool check = false;

            while (check == false)
            {
                Console.WriteLine("Souhaitez-vous acheter une carte ? (o/n)");
                string choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                    case "o":
                    {
                        Console.WriteLine(piles);
                        Console.WriteLine("\nEntrez le numéro de la carte à acheter :");
                        string input = Console.ReadLine();
                        bool testInput = int.TryParse(input, out int num);

                        while (testInput == false || num < 1 || num > 8)
                        {
                            int.TryParse(input, out num);
                            Console.WriteLine(piles);
                            Console.WriteLine("\nEntrez le numéro de la carte à acheter :");
                            input = Console.ReadLine();
                        }

                        string name = string.Empty;

                        switch (num)
                        {
                            case 1:
                                name = piles.dico[0].Name;
                                testInput = true;
                                break;
                            case 2:
                                name = piles.dico[1].Name;
                                testInput = true;
                                break;
                            case 3:
                                name = piles.dico[2].Name;
                                testInput = true;
                                break;
                            case 4:
                                name = piles.dico[3].Name;
                                testInput = true;
                                break;
                            case 5:
                                name = piles.dico[4].Name;
                                testInput = true;
                                break;
                            case 6:
                                name = piles.dico[5].Name;
                                testInput = true;
                                break;
                            case 7:
                                name = piles.dico[6].Name;
                                testInput = true;
                                break;
                            case 8:
                                name = piles.dico[7].Name;
                                testInput = true;
                                break;

                            default:
                                continue;

                        }

                        var card = piles.AvailableCards.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        
                        if (card != null && player.Money >= card.Cost)
                        {
                            player.AddCard(card);
                            piles.AvailableCards.Remove(card);
                            Console.WriteLine($"{player.Name} achète {card.Name} !"); //good
                            check = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Achat impossible.");
                            break;
                        }
                    }

                    case "n":
                    {
                        Console.WriteLine("{0} n'achète rien", player.Name);
                        check = true;
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Vous devez choisir une réponse valide.");
                        continue;
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