using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Brickbreaker
{
    class Ball
    {
        Paddle touchPaddle = new Paddle();
        int paddleMove;
        int directionLeft;
        int directionTop;
        int moveLeft;
        int moveTop;
        int left;
        int top;
        public Ball()
        {
        }
        public void BallDisplay(int paddleMove)
        {
            BallMoveAngle(paddleMove);
            BallMove();
        }
        public List<int> BallMove()
        {
            left = Console.CursorLeft;
            top = Console.CursorTop;
            if (top <= 0)
            {
                top = 0;
                directionTop = 1;
            }
            if (top >= 27)
            {
                top = 27;
                directionTop = -1;
            }
            if (left >= 117)
            {
                left = 117;
                directionLeft = -1;
            }
            if (left <= 0)
            {
                left = 0;
                directionLeft = 1;
            }
            if (directionTop == 1)
            {
                moveTop = top + directionTop;
            }
            if (directionTop == -1)
            {
                moveTop = top + directionTop;
            }
            if (directionLeft == -1)
            {
                moveLeft = left + directionLeft;
            }
            if (directionLeft == 1)
            {
                moveLeft = left + directionLeft;
            }
            BallShape(moveLeft, moveTop);
            //BallSimple(moveLeft, moveTop);
            List<int> ballMove = new List<int>() { moveLeft, moveTop };
            return ballMove;
        }
        public void BallMoveAngle(int PaddleMove)
        {
            left = Console.CursorLeft;
            top = Console.CursorTop;
            if (top == 25)
            {
                if (left == paddleMove + 7)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 8)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 9)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 10)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 11)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 12)
                {
                    directionLeft = -2;
                    directionTop = -1;
                }
                if (left == paddleMove + 19)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 20)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 21)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 22)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 23)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 24)
                {
                    directionLeft = 2;
                    directionTop = -1;
                }
                if (left == paddleMove + 13)
                {
                    directionLeft = -1;
                    directionTop = -1;
                }
                if (left == paddleMove + 14)
                {
                    directionLeft = -1;
                    directionTop = -1;
                }
                if (left == paddleMove + 15)
                {
                    directionLeft = -1;
                    directionTop = -1;
                }
                if (left == paddleMove + 16)
                {
                    directionLeft = 1;
                    directionTop = -1;
                }
                if (left == paddleMove + 17)
                {
                    directionLeft = 1;
                    directionTop = -1;
                }
                if (left == paddleMove + 18)
                {
                    directionLeft = 1;
                    directionTop = -1;
                }
            }
        }
        public void BallShape(int ballPositionLeft, int ballPositionTop)
        {
            string[] ballTop = new string[4] {" " ," " ," " ," "};
            string[] ballSide = new string[4] { " ", "{", "}", " " };
            string[] ballBottom = new string[4] { " ", "", " ", " " };
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 1);
            foreach (string shape in ballSide) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 2);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
        }
        public void BallSimple(int ballPositionLeft, int ballPositionTop)
        {
            string[] ballTop = new string[3] { " ", " ", " " };
            string[] ballSide = new string[3] { " ", "O", " " };
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 1);
            foreach (string shape in ballSide) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 2);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
        }
    }
}
