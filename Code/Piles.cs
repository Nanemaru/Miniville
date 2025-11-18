using MiniVille;

namespace MiniVille
{
    public class Piles
    {
        public List<Cards> AvailableCards = new List<Cards> { };

        private static Cards.CardsInfo champBle = new Cards.CardsInfo(0, "Blue", 1, "Champs de blé", "Recevez 1 pièce", 1, 1);
        private static Cards.CardsInfo ferme = new Cards.CardsInfo(1, "Blue", 2, "Ferme", "Recevez 1 pièce", 1, 1);
        private static Cards.CardsInfo boulangerie = new Cards.CardsInfo(2, "Green", 1, "Boulangerie", "Recevez 2 pièces", 2, 2);
        private static Cards.CardsInfo cafe = new Cards.CardsInfo(3, "Red", 2, "Café", "Recevez 1 pièce du joueur qui a lancé le dé", 3, 1);
        private static Cards.CardsInfo superette = new Cards.CardsInfo(4, "Green", 2, "Superette", "Recevez 3 pièces", 4, 3);
        private static Cards.CardsInfo foret = new Cards.CardsInfo(5, "Blue", 2, "Forêt", "Recevez 1 pièce", 5, 1);
        private static Cards.CardsInfo restaurant = new Cards.CardsInfo(6, "Red", 4, "Restaurant", "Recevez 2 pièces du joueur qui a lancé le dé", 5, 2);
        private static Cards.CardsInfo stade = new Cards.CardsInfo(7, "Blue", 6, "Stade", "Recevez 4 pièces", 6, 4);

        Dictionary<int, Cards.CardsInfo> dico = new Dictionary<int, Cards.CardsInfo>
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
                for (int j = 0; j < 8; j++) AvailableCards.Add(new Cards(dico[j]));
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