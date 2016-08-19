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
        public Brick newBrick = new Brick();
        public Paddle touchPaddle = new Paddle();
        int directionLeft;
        int directionTop;
        int moveLeft;
        int moveTop;
        int left;
        int top;
        int reset;
        int brickPositionLeft;
        int brickPositionTop;
        int brickWidth;
        int brickHeight;
        int ballWidthLeft = -1;
        int ballWidthRight = -3;
        int ballHeightTop = -1;
        int ballHeightBottom = -2;
        int brickProgress;
        public Ball()
        {
            reset = 0;
            brickProgress = 0;
        }
        public void LoseLoop()
        {
            for (int i = 0; i < 200; i++)
            {
                if ((i + 1) % 37 == 0)
                {
                    Console.SetCursorPosition(5, i + 60);
                    Console.WriteLine("YOU                                                                                                     LOSE");
                    Thread.Sleep(100);
                }
                if ((i + 1) % 23 == 0)
                {
                    Console.SetCursorPosition(15, i + 60);
                    Console.WriteLine("YOU                                                                                 LOSE");
                    Thread.Sleep(100);
                }
                if ((i + 1) % 13 == 0)
                {
                    Console.SetCursorPosition(25, i + 60);
                    Console.WriteLine("YOU                                                             LOSE");
                    Thread.Sleep(100);
                }
                if ((i + 1) % 7 == 0)
                {
                    Console.SetCursorPosition(35, i + 60);
                    Console.WriteLine("YOU                                         LOSE");
                    Thread.Sleep(100);
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.SetCursorPosition(45, i + 60);
                    Console.WriteLine("YOU                     LOSE");
                    Thread.Sleep(100);
                }
                else
                {
                    Console.SetCursorPosition(55, i + 60);
                    Console.WriteLine("YOU LOSE");
                    Thread.Sleep(100);
                }
            }
        }
        public List<int> BallMove()
        {
            int paddleMove = touchPaddle.PaddleMove();
            left = Console.CursorLeft;
            top = Console.CursorTop;
            if (top < 24 || top > 24)
            {
                if (top <= 0)
                {
                    top = 0;
                    directionTop = 1;
                }
                if (top >= 30)
                {
                    top = 60;
                    LoseLoop();
                }
                if (left >= 111)
                {
                    left = 111;
                    directionLeft = -1;
                }
                if (left <= 6)
                {
                    left = 6;
                    directionLeft = 1;
                }
            }
            if (top == 24)
            {
                if (left >= paddleMove + 3 && left <= paddleMove + 11)
                {
                    directionTop = -1;
                    directionLeft = -1;
                }
                if (left >= paddleMove + 12 && left <= paddleMove + 15)
                {
                    directionTop = -1;
                    directionLeft = 0;
                }
                if (left >= paddleMove + 16 && left <= paddleMove + 25)
                {
                    directionTop = -1;
                    directionLeft = 1;
                }
            }
            BrickImpact();
            if (directionTop == 1){moveTop = top + directionTop;}
            if (directionTop == -1){moveTop = top + directionTop;}
            if (directionLeft == -1){moveLeft = left + directionLeft;}
            if (directionLeft == 1){moveLeft = left + directionLeft;}
            if (reset == 0)
            {
                moveLeft = 55;
                moveTop = 14;
                directionLeft = 1;
                directionTop = 1;
                reset++;
            }
            BallShape(moveLeft, moveTop);
            //BallSimple(moveLeft, moveTop);
            //BallComplex(moveLeft, moveTop);
            List<int> ballMove = new List<int>() { moveLeft, moveTop };
            return ballMove;
        }
        public void BrickImpact()
        {
            left = Console.CursorLeft;
            top = Console.CursorTop;
            brickWidth = newBrick.BrickWidth();
            brickHeight = 4;
            for (int i = 0; i < newBrick.BrickPositionJoinList().Count; i++)
            {
                brickPositionLeft = newBrick.BrickPositionJoinList()[i][0];
                brickPositionTop = newBrick.BrickPositionJoinList()[i][1];
                if (top >= brickPositionTop + ballHeightBottom && top <= brickPositionTop + brickHeight + ballHeightTop && left == brickPositionLeft + ballWidthRight)
                {
                    directionLeft = -1;
                    newBrick.RemoveBrick(brickPositionLeft, brickPositionTop);
                    brickProgress++;
                }
                if (top >= brickPositionTop + ballHeightBottom && top <= brickPositionTop + brickHeight + ballHeightTop && left == brickPositionLeft + brickWidth + ballWidthLeft)
                {
                    directionLeft = 1;
                    newBrick.RemoveBrick(brickPositionLeft, brickPositionTop);
                    brickProgress++;
                }
                if (top == brickPositionTop + ballHeightBottom && left >= brickPositionLeft + ballWidthRight + 1 && left <= brickPositionLeft + brickWidth + ballWidthLeft - 1)
                {
                    directionTop = -1;
                    newBrick.RemoveBrick(brickPositionLeft, brickPositionTop);
                    brickProgress++;
                }
                if (top == brickPositionTop + brickHeight + ballHeightTop && left >= brickPositionLeft + ballWidthRight + 1 && left <= brickPositionLeft + brickWidth + ballWidthLeft - 1)
                {
                    directionTop = 1;
                    newBrick.RemoveBrick(brickPositionLeft, brickPositionTop);
                    brickProgress++;
                }
            }
            //400 lines replaced by ^^^^^!
        }
        public int BrickProgress()
        {
            return brickProgress;
        }
        public void BallReset()
        {
            brickProgress = 0;
        }
        public void BallShape(int ballPositionLeft, int ballPositionTop)
        {
            string[] ballTop = new string[4] {" " ," " ," " ," "};
            string[] ballMid = new string[4] { " ", "{", "}", " " };
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 1);
            foreach (string shape in ballMid) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 2);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
        }
        public void BallSimple(int ballPositionLeft, int ballPositionTop)
        {
            string[] ballTop = new string[3] { " ", " ", " " };
            string[] ballMid = new string[3] { " ", "O", " " };
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 1);
            foreach (string shape in ballMid) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 2);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
        }
        public void BallComplex(int ballPositionLeft, int ballPositionTop)
        {
            string[] ballTop = new string[4] { " ", " ", " ", " " };
            string[] ballMid = new string[4] { " ", "{", "}", " " };
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 1);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 2);
            foreach (string shape in ballMid) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 3);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop + 4);
            foreach (string shape in ballTop) { Console.Write(shape); }
            Console.SetCursorPosition(ballPositionLeft, ballPositionTop);
        }
        public void SendBallReset()
        {
            reset = 0;
        }
    }
}
