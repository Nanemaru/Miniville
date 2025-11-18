namespace MiniVille
{

    public class Cards
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Color { get; private set; }
        public int Cost { get; private set; }
        public string Effect { get; private set; }
        public int Dice1 { get; private set; }
        public int Dice2 { get; private set; }
        public int Gain { get; private set; }

        public Cards(CardsInfo info)
        {
            Id = info.Id;
            Name = info.Name;
            Color = info.Color;
            Cost = info.Cost;
            Effect = info.Effect;
            Dice1 = info.Dice1;
            Dice2 = info.Dice2;
            Gain = info.Gain;
        }

        public struct CardsInfo
        {
            public CardsInfo(int id, string color, int cost, string name, string effect, int dice1, int dice2, int gain)
            {
                Id = id;
                Color = color;
                Cost = cost;
                Name = name;
                Effect = effect;
                Dice1 = dice1;
                Dice2 = dice2;
                Gain = gain;
            }

            public int Id { get; set; }
            public string Color { get; set; }
            public int Cost { get; set; }
            public string Name { get; set; }
            public string Effect { get; set; }
            public int Dice1 { get; set; }
            public int Dice2 { get; set; }
            public int Gain { get; set; }
        }

        public override string ToString()
        {
            return $"[{Dice1}] {Color} - {Name} : {Effect} - {Cost}$";
        }
    }
}