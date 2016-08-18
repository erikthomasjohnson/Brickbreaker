using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickbreaker
{
    class Paddle
    {
        int paddleMove;
        public Paddle()
        {
            paddleMove = 20;
        }
        public void PaddleDisplay()
        {
            paddleMove = PaddleMove();
            PaddleShape();
        }
        public int PaddleShape()
        {
            string[] paddleTop = new string[30] { " ", " ", " ", " ", " ", " ", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", " ", " ", " ", " ", " ", " ", };
            string[] paddleSide = new string[30] { " ", " ", " ", " ", " ", "|", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "|", " ", " ", " ", " ", " " };
            Console.SetCursorPosition(paddleMove, 26);
            foreach (string shape01 in paddleTop) { Console.Write(shape01); }
            Console.SetCursorPosition(paddleMove, 27);
            foreach (string shape02 in paddleSide) { Console.Write(shape02); }
            Console.SetCursorPosition(paddleMove, 28);
            foreach (string shape03 in paddleTop) { Console.Write(shape03); }
            return paddleMove;
        }
        public int PaddleMove()
        {
            int cursorPosition = paddleMove;
            ConsoleKey keyPress = Console.ReadKey().Key;
            if (keyPress == ConsoleKey.LeftArrow)
            {
                int moveLeft = cursorPosition - 5;
                if (moveLeft <= 0)
                {
                    return 0;
                }
                else
                {
                    return moveLeft;
                }
            }
            if (keyPress == ConsoleKey.RightArrow)
            {
                int moveRight = cursorPosition + 5;
                if (moveRight >= 90)
                {
                    return 90;
                }
                else
                {
                    return moveRight;
                }
            }
            return 50;
        }
    }
}
