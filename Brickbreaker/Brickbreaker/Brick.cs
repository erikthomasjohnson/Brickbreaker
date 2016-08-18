using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickbreaker
{
    class Brick
    {
        public Brick()
        {
        }
        public void BrickDisplay()
        {
            BrickShape(14, 0);
            BrickShape(14, 4);
            BrickShape(14, 8);
            BrickShape(38, 0);
            BrickShape(38, 4);
            BrickShape(38, 8);
            BrickShape(62, 0);
            BrickShape(62, 4);
            BrickShape(62, 8);
            BrickShape(86, 0);
            BrickShape(86, 4);
            BrickShape(86, 8);
        }
        public void BrickShape(int left, int top)
        {
            int topHighHigh = top + 1;
            int topHighMid = top + 2;
            int topLowMid = top + 3;
            int topLowLow = top + 4;
            string[] brickTop = new string[20] { " ", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", " " };
            string[] brickSide = new string[20] { "|", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "|" };
            Console.SetCursorPosition(left, topHighHigh);
            foreach (string shape in brickTop) { Console.Write(shape); }
            Console.SetCursorPosition(left, topHighMid);
            foreach (string shape in brickSide) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowMid);
            foreach (string shape in brickSide) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowLow);
            foreach (string shape in brickTop) { Console.Write(shape); }
        }
        public void BrickClear(int left, int top)
        {
            int topHighHigh = top + 1;
            int topHighMid = top + 2;
            int topLowMid = top + 3;
            int topLowLow = top + 4;
            string[] brickBlank = new string[20] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            Console.SetCursorPosition(left, topHighHigh);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topHighMid);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowMid);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowLow);
            foreach (string shape in brickBlank) { Console.Write(shape); }
        }
    }
}
