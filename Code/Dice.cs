using System;

namespace MiniVille
{
    public class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, 7); // 1 à 6
        }
    }
}
