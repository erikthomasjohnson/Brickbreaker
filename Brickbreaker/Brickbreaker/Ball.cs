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
        int ballReset;
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
            ballReset = 0;
            brickProgress = 0;
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
                if (left >= paddleMove + 2 && left <= paddleMove + 11)
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
            if (ballReset == 0)
            {
                moveLeft = 55;
                moveTop = 14;
                directionLeft = 1;
                directionTop = 1;
                ballReset++;
            }
            BallShape(moveLeft, moveTop);
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
        }
        public int BrickProgress()
        {
            return brickProgress;
        }
        public void BrickReset()
        {
            brickProgress = 0;
        }
        public void BallReset()
        {
            ballReset = 0;
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
    }
}
