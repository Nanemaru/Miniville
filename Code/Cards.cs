namespace MiniVille_chez_ouam
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

        public struct CardsInfo
        {
            public CardsInfo(int id, string color, int cost, string name, string effect, int dice, int gain)
            {
                Id = id;
                Color = color;
                Cost = cost;
                Name = name;
                Effect = effect;
                Dice = dice;
                Gain = gain;
            }

            public int Id { get; set; }
            public string Color { get; set; }
            public int Cost { get; set; }
            public string Name { get; set; }
            public string Effect { get; set; }
            public int Dice { get; set; }
            public int Gain { get; set; }
        }

        public override string ToString()
        {
            return $"[{Dice}] {Color} - {Name} : {Effect} - {Cost}$";
        }
    }
}