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
        int reset;
        public Paddle()
        {
            paddleMove = 45;
            reset = 0;
        }
        public void PaddleDisplay()
        {
            if (reset == 0)
            {
                paddleMove = 45;
                reset++;
            }
            else
            {
                paddleMove = PaddleMove();
            }
            PaddleShape();
        }
        public void PaddleShape()
        {
            string[] paddleTop = new string[30] { " ", " ", " ", " ", " ", " ", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", " ", " ", " ", " ", " ", " ", };
            string[] paddleSide = new string[30] { " ", " ", " ", " ", " ", "|", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "+", "|", " ", " ", " ", " ", " " };
            string[] paddleBottom = new string[30] { " ", " ", " ", " ", " ", " ", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", " ", " ", " ", " ", " ", " ", };
            Console.SetCursorPosition(paddleMove, 26);
            foreach (string shape01 in paddleTop) { Console.Write(shape01); }
            Console.SetCursorPosition(paddleMove, 27);
            foreach (string shape02 in paddleSide) { Console.Write(shape02); }
            Console.SetCursorPosition(paddleMove, 28);
            foreach (string shape03 in paddleTop) { Console.Write(shape03); }
        }
        public int PaddleMove()
        {
            while(!Console.KeyAvailable)
            {
                return paddleMove;
            }
            int cursorPosition = paddleMove;
            ConsoleKey keyPress = Console.ReadKey().Key;
            if (keyPress == ConsoleKey.LeftArrow)
            {
                int moveLeft = cursorPosition - 3;
                if (moveLeft <= 0)
                {
                    return 0;
                }
                else
                {
                    paddleMove = moveLeft;
                    return paddleMove;
                }
            }
            if (keyPress == ConsoleKey.RightArrow)
            {
                int moveRight = cursorPosition + 3;
                if (moveRight >= 90)
                {
                    return 90;
                }
                else
                {
                    paddleMove = moveRight;
                    return paddleMove;
                }
            }
            return paddleMove;
        }
        public void SendPaddleReset()
        {
            reset = 0;
        }
    }
}
