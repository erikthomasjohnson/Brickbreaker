using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickbreaker
{
    class Wall
    {
        int side;
        string wallSide;
        public Wall()
        {
        }
        public void WallDisplay()
        {
            WallShape(4);
            WallShape(115);
        }
        public void WallShape(int left)
        {
            for (int i = 0; i < 26; i++)
            {
                side = i;
                wallSide = "|";
                Console.SetCursorPosition(left, side);
                Console.Write(wallSide);
            }
        }
    }
}
