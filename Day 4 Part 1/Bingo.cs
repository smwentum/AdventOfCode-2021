using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4_Part_1
{
    internal class Bingo
    {
        public int square { get; set; }
        public bool marked { get; set; }
        public Bingo()
        {

        }

        public Bingo(int number)
        {
            marked = false;
            square = number;    
        }
    }
}
