using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Dice
    {
        private Random rdm = new Random();

        public static Dice() { }

        public static int Roll()
        {
            int result = rdm.Next(1, 7);
            return result;
        }

    }
}
