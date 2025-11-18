using MiniVille;

namespace MiniVille
{
    public class Piles
    {
        public List<Cards> AvailableCards = new List<Cards> { };
        //On fait appel au struct CardsInfo via la classe Cards dans laquelle il est contenu
        //Les noms de certaines variables sont ici en français pour des raisons d'affichage
        private static Cards.CardsInfo champBle = new Cards.CardsInfo(0, "Blue", 1, "Champs de blé", "Recevez 1 pièce", 1, 1, 1);
        private static Cards.CardsInfo ferme = new Cards.CardsInfo(1, "Blue", 2, "Ferme", "Recevez 1 pièce", 2, 2, 1);
        private static Cards.CardsInfo boulangerie = new Cards.CardsInfo(2, "Green", 1, "Boulangerie", "Recevez 2 pièces", 2, 3, 2);
        private static Cards.CardsInfo cafe = new Cards.CardsInfo(3, "Red", 2, "Café", "Recevez 1 pièce du joueur qui a lancé le dé", 3, 3, 1);
        private static Cards.CardsInfo superette = new Cards.CardsInfo(4, "Green", 2, "Superette", "Recevez 3 pièces", 4, 4, 3);
        private static Cards.CardsInfo foret = new Cards.CardsInfo(5, "Blue", 2, "Forêt", "Recevez 1 pièce", 5, 5, 1);
        private static Cards.CardsInfo restaurant = new Cards.CardsInfo(6, "Red", 4, "Restaurant", "Recevez 2 pièces du joueur qui a lancé le dé", 4, 5, 2);
        private static Cards.CardsInfo stade = new Cards.CardsInfo(7, "Blue", 6, "Stade", "Recevez 4 pièces", 6, 6, 4);

        //Pourrais être remplacé par une liste
        public Dictionary<int, Cards.CardsInfo> dico = new Dictionary<int, Cards.CardsInfo>
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


        public Piles()
        {
            InitializeCards();
        }

        private void InitializeCards()
        {
            //On remplie la liste AvailableCards avec un exemplaire de chaque carte 6 fois d'affilées
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 8; j++) AvailableCards.Add(new Cards(dico[j]));
            }
        }

        /// La fonction ToString() sert à retourner un string lorsqu'une référence à une instance de la classe est écrite dans un emplacement où un string est attendu 
        public override string ToString()
        {
            string toString = string.Format("Cartes disponibles : \n");
            //Pour chaque type de batiment afficher un compte du nombre d'exemplaire du batîment encore en boutique ainsi que des infos détaillés
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
                toString += string.Format("{0} * {1} - {2} [{3}] : {4} - {5}$ \n", cardCount, dico[i].Name, dico[i].Color, dico[i].Dice1, dico[i].Effect, dico[i].Cost);
            }

            return toString;
        }
    }
}