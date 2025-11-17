using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        public class Cards
    {
        public int _id;
        public string _color;
        public int _cost;
        public string _name;
        public string _effect;
        public int _dice;
        public int _gain;

        /// Dictionnaire pour associer les id et les noms des cartes <Key, Value>
        public Dictionary<int, string> cardsDictionnary = new Dictionary<int, string>()
        {
            {0, "Champs de blé" } , {1, "Ferme"}, {2, "Boulangerie"}, {3, "Café"} ,
            {4, "Superette"}, {5, "Forêt"}, {6, "Restaurant"}, {7, "Stade"}
        };

        public Cards(CardsInfo info)
        {
            _id = info.Id;
            _color = info.Color;
            _cost = info.Cost;
            _name = info.Name;
            _effect = info.Effect;
            _dice = info.Dice;
            _gain = info.Gain; 
        }

        public void SetInfos(int id)
        {
            switch (id)
            {
                case 0: //Champ de blé
                    _dice = 1;
                    _color = "blue";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 1 pièce";
                    _gain = 1;
                    _cost = 1;
                    break;

                case 1: //Ferme
                    _dice = 1;
                    _color = "blue";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 1 pièce";
                    _gain = 1;
                    _cost = 2;
                    break;

                case 2: //Boulangerie
                    _dice = 2;
                    _color = "green";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 2 pièce";
                    _gain = 2;
                    _cost = 1;
                    break;

                case 3: //Café
                    _dice = 3;
                    _color = "red";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 1 pièce du joueur qui a lancé le dé";
                    _gain = 2;
                    _cost = 2;
                    break;

                case 4: //Superette
                    _dice = 4;
                    _color = "green";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 3 pièces";
                    _gain = 3;
                    _cost = 2;
                    break;

                case 5: //Forêt
                    _dice = 5;
                    _color = "blue";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 1 pièce ";
                    _gain = 1;
                    _cost = 2;
                    break;

                case 6: //Restaurant
                    _dice = 5;
                    _color = "red";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 2 pièces du joueur qui a lancé le dé ";
                    _gain = 2;
                    _cost = 4;
                    break;

                case 7: //Stade
                    _dice = 6;
                    _color = "blue";
                    _name = cardsDictionnary[id];
                    _effect = "Recevez 4 pièce";
                    _gain = 4;
                    _cost = 6;
                    break;
            }
        }


        public override string ToString()
        {
            string cardInfos = String.Format("Carte tirée : {0}\n", this._name);
            cardInfos += String.Format("Couleur : {0}\n", this._color);
            cardInfos += String.Format("Effet : {0}\n, GAIN : {1}\n", this._effect, this._gain);
            cardInfos += String.Format("Prix : {0}\n", this._cost);
            cardInfos += String.Format("Valeur activation : {0}\n", this._dice);

            return cardInfos;
        }
    }
}
