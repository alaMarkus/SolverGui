using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverGUI_0._1
{
    class MyGrid
    {

        private static Random rnd = new Random();

        private char[,] letterGrid;

        public char getLetter(int x,int y)
        {
            return letterGrid[x, y];
        }

        private char randomLetter()
        {
            char[] ab = new char[] { 'a', 'a', 'e', 'd', 'e', 'k', 'u', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'a', 'r', 's', 't', 'u', 'v', 'o', 'e', 'p', 'j', 'o', 'ä', 'ö' };
            int letter = rnd.Next(29);
            //Console.WriteLine(letter);
            char chosen = ab[letter];
            return chosen;
        }

        public MyGrid()
        {
            letterGrid = new char[4, 4];
            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    letterGrid[i, j] = randomLetter();
                }
            }
        }

    }
}
