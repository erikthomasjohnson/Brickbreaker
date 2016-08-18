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
        int brickLeftLeftBottom;
        int brickLeftMidBottom;
        int brickRightMidBottom;
        int brickRightRightBottom;
        int brickLeftLeftCenter;
        int brickLeftMidCenter;
        int brickRightMidCenter;
        int brickRightRightCenter;
        int brickLeftLeftTop;
        int brickLeftMidTop;
        int brickRightMidTop;
        int brickRightRightTop;
        public Ball()
        {
            brickLeftLeftBottom = 0;
            brickLeftMidBottom = 0;
            brickRightMidBottom = 0;
            brickRightRightBottom = 0;
            brickLeftLeftCenter = 0;
            brickLeftMidCenter = 0;
            brickRightMidCenter = 0;
            brickRightRightCenter = 0;
            brickLeftLeftTop = 0;
            brickLeftMidTop = 0;
            brickRightMidTop = 0;
            brickRightRightTop = 0;
        }
        public void BallDisplay()
        {
            //BallMove();
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
                    for(int i = 0; i < 200; i++)
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
            if (directionLeft == -2)
            {
                moveLeft = left + directionLeft;
            }
            if (directionLeft == 2)
            {
                moveLeft = left + directionLeft;
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
            if (top == 8 && left > 11 && left < 34)
                while (brickLeftLeftBottom == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(14, 8);
                    brickLeftLeftBottom++;
                }
            if (top == 8 && left > 34 && left < 58)
                while (brickLeftMidBottom == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(38, 8);
                    brickLeftMidBottom++;
                }
            if (top == 8 && left > 58 && left < 82)
                while (brickRightMidBottom == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(62, 8);
                    brickRightMidBottom++;
                }
            if (top == 8 && left > 82 && left < 106)
                while (brickRightRightBottom == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(86, 8);
                    brickRightRightBottom++;
                }
            if (top == 4 && left > 11 && left < 34)
                while (brickLeftLeftCenter == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(14, 4);
                    brickLeftLeftCenter++;
                }
            if (top == 4 && left > 34 && left < 58)
                while (brickLeftMidCenter == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(38, 4);
                    brickLeftMidCenter++;
                }
            if (top == 4 && left > 58 && left < 82)
                while (brickRightMidCenter == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(62, 4);
                    brickRightMidCenter++;
                }
            if (top == 4 && left > 82 && left < 106)
                while (brickRightRightCenter == 0)
                {
                    directionTop = -1;
                    newBrick.BrickClear(86, 4);
                    brickRightRightCenter++;
                }
            if (top <= 12 && top >= 8)
            {
                if (left > 11 && left < 34)
                {
                    while (brickLeftLeftBottom == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(14, 8);
                        brickLeftLeftBottom++;
                    }
                }
                if (left == 11)
                {
                    while (brickLeftLeftBottom == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(14, 8);
                        brickLeftLeftBottom++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftLeftBottom == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(14, 8);
                        brickLeftLeftBottom++;
                    }
                }
                if (left >= 34 && left <= 58)
                {
                    while (brickLeftMidBottom == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(38, 8);
                        brickLeftMidBottom++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftMidBottom == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(38, 8);
                        brickLeftMidBottom++;
                    }
                }
                if (left == 58)
                {
                    while (brickLeftMidBottom == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(38, 8);
                        brickLeftMidBottom++;
                    }
                }
                if (left >= 58 && left <= 82)
                {
                    while (brickRightMidBottom == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(62, 8);
                        brickRightMidBottom++;
                    }
                }
                if (left == 58)
                {
                    while (brickRightMidBottom == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(62, 8);
                        brickRightMidBottom++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightMidBottom == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(62, 8);
                        brickRightMidBottom++;
                    }
                }
                if (left >= 82 && left <= 106)
                {
                    while (brickRightRightBottom == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(86, 8);
                        brickRightRightBottom++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightRightBottom == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(86, 8);
                        brickRightRightBottom++;
                    }
                }
                if (left == 106)
                {
                    while (brickRightRightBottom == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(86, 8);
                        brickRightRightBottom++;
                    }
                }
            }
            if (top <= 8 && top >= 4)
            {
                if (left > 11 && left < 34)
                {
                    while (brickLeftLeftCenter == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(14, 4);
                        brickLeftLeftCenter++;
                    }
                }
                if (left == 11)
                {
                    while (brickLeftLeftCenter == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(14, 4);
                        brickLeftLeftCenter++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftLeftCenter == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(14, 4);
                        brickLeftLeftCenter++;
                    }
                }
                if (left > 34 && left < 58)
                {
                    while (brickLeftMidCenter == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(38, 4);
                        brickLeftMidCenter++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftMidCenter == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(38, 4);
                        brickLeftMidCenter++;
                    }
                }
                if (left == 58)
                {
                    while (brickLeftMidCenter == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(38, 4);
                        brickLeftMidCenter++;
                    }
                }
                if (left > 58 && left < 82)
                {
                    while (brickRightMidCenter == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(62, 4);
                        brickRightMidCenter++;
                    }
                }
                if (left == 58)
                {
                    while (brickRightMidCenter == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(62, 4);
                        brickRightMidCenter++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightMidCenter == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(62, 4);
                        brickRightMidCenter++;
                    }
                }
                if (left > 82 && left < 106)
                {
                    while (brickRightRightCenter == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(86, 4);
                        brickRightRightCenter++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightRightCenter == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(86, 4);
                        brickRightRightCenter++;
                    }
                }
                if (left == 106)
                {
                    while (brickRightRightCenter == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(86, 4);
                        brickRightRightCenter++;
                    }
                }
            }
            if (top <= 4 && top >= 0)
            {
                if (left > 11 && left < 34)
                {
                    while (brickLeftLeftTop == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(14, 0);
                        brickLeftLeftTop++;
                    }
                }
                if (left == 11)
                {
                    while (brickLeftLeftTop == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(14, 0);
                        brickLeftLeftTop++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftLeftTop == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(14, 0);
                        brickLeftLeftTop++;
                    }
                }
                if (left > 34 && left < 58)
                {
                    while (brickLeftMidTop == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(38, 0);
                        brickLeftMidTop++;
                    }
                }
                if (left == 34)
                {
                    while (brickLeftMidTop == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(38, 0);
                        brickLeftMidTop++;
                    }
                }
                if (left == 58)
                {
                    while (brickLeftMidTop == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(38, 0);
                        brickLeftMidTop++;
                    }
                }
                if (left > 58 && left < 82)
                {
                    while (brickRightMidTop == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(62, 0);
                        brickRightMidTop++;
                    }
                }
                if (left == 58)
                {
                    while (brickRightMidTop == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(62, 0);
                        brickRightMidTop++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightMidTop == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(62, 0);
                        brickRightMidTop++;
                    }
                }
                if (left > 82 && left < 106)
                {
                    while (brickRightRightTop == 0)
                    {
                        directionTop = 1;
                        newBrick.BrickClear(86, 0);
                        brickRightRightTop++;
                    }
                }
                if (left == 82)
                {
                    while (brickRightRightTop == 0)
                    {
                        directionLeft = -1;
                        newBrick.BrickClear(86, 0);
                        brickRightRightTop++;
                    }
                }
                if (left == 106)
                {
                    while (brickRightRightTop == 0)
                    {
                        directionLeft = 1;
                        newBrick.BrickClear(86, 0);
                        brickRightRightTop++;
                    }
                }
            }
        }
        public int BrickProgress()
        {
            int brickProgress =
           brickLeftLeftBottom +
           brickLeftMidBottom +
           brickRightMidBottom +
           brickRightRightBottom +
           brickLeftLeftCenter +
           brickLeftMidCenter +
           brickRightMidCenter +
           brickRightRightCenter +
           brickLeftLeftTop +
           brickLeftMidTop +
           brickRightMidTop +
           brickRightRightTop;
            return brickProgress;
        }
        public void BallReset()
        {
            brickLeftLeftBottom = 0;
            brickLeftMidBottom = 0;
            brickRightMidBottom = 0;
            brickRightRightBottom = 0;
            brickLeftLeftCenter = 0;
            brickLeftMidCenter = 0;
            brickRightMidCenter = 0;
            brickRightRightCenter = 0;
            brickLeftLeftTop = 0;
            brickLeftMidTop = 0;
            brickRightMidTop = 0;
            brickRightRightTop = 0;
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
    }
}
