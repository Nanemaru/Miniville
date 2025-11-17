using System;

namespace MiniVille
{

    public class Cards
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Color { get; private set; }
        public int Cost { get; private set; }
        public string Effect { get; private set; }
        public int Dice { get; private set; }
        public int Gain { get; private set; }

        public Cards(CardsInfo info)
        {
            Id = info.Id;
            Name = info.Name;
            Color = info.Color;
            Cost = info.Cost;
            Effect = info.Effect;
            Dice = info.Dice;
            Gain = info.Gain;
        }

        public override string ToString()
        {
            return $"[{Dice}] {Color} - {Name} : {Effect} - {Cost}$";
        }
    }
}
