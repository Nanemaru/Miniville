using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniville
{
    public class Piles
    {
        public List<Cards> AvailableCards = new List<Cards> { };

        private Cards champBle = new Cards(0, "Bleu", 1, "Champs de blé", "Recevez 1 pièce", 1, 1);
        private Cards ferme = new Cards(1, "Bleu", 2, "Ferme", "Recevez 1 pièce", 1, 1);
        private Cards boulangerie = new Cards(2, "Vert", 1, "Boulangerie", "Recevez 2 pièces", 2, 2);
        private Cards cafe = new Cards(3, "Rouge ", 2, "Café", "Recevez 1 pièce du joueur qui a lancé le dé", 3, 1);
        private Cards superette = new Cards(4, "Vert ", 2, "Superette", "Recevez 3 pièces", 4, 3);
        private Cards foret = new Cards(5, "Bleu ", 2, "Forêt", "Recevez 1 pièce", 5, 1);
        private Cards restaurant = new Cards(6, "Rouge ", 4, "Restaurant", "Recevez 2 pièces du joueur qui a lancé le dé", 5, 2);
        private Cards stade = new Cards(7, "Bleu ", 6, "Stade", "Recevez 4 pièces", 6, 4);

        Dictionary<int, Cards> dico = new Dictionary<int, Cards>
        {
            {0, champBle},
            {1, ferme},
            {2, boulangerie},
            {3, cafe},
            {4, superette},
            {5, foret},
            {6, restaurant},
            {7, stade},
        };


        public Piles(/* List<Cards> availableCards */)
        {
            // AvailableCards = availableCards;
            InitializeCards();
        }

        private void InitializeCards()
        {
            for (int i = 0; i < 6; i++)
            {
                /*
                AvailableCards.Add(champBle);
                AvailableCards.Add(ferme);
                AvailableCards.Add(boulangerie);
                AvailableCards.Add(cafe);
                AvailableCards.Add(superette);
                AvailableCards.Add(foret);
                AvailableCards.Add(restaurant);
                AvailableCards.Add(stade);
                */
                for (int j = 0; j < 8; j++) AvailableCards.Add(dico[j].Value);
            }
        }

        public override string ToString()
        {
            string toString = string.Format("Cartes disponibles : \n");
            for (int i = 0; i < 8; i++)
            {
                int cardCount = 0;
                foreach (var Cards in AvailableCards)
                {
                    if (Cards.Id == i)
                    {
                        cardCount++;
                    }
                }

                toString += string.Format("{0} * {1} - {2} [{3}] : {4} - {5}$ \n", cardCount, dico[i].Name, dico[i].Color, dico[i].Dice, dico[i].Effect, dico[i].Cost);
            }

            return toString;
        }
    }
}
