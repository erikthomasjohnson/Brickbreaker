using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Brickbreaker
{
    class Game
    {
        Wall newWall = new Wall();
        Brick newBrick = new Brick();
        Ball newBall = new Ball();
        Paddle newPaddle = new Paddle();
        int ballMoveLeft;
        int ballMoveTop;
        int sendPaddleMove;
        int levelOne = 150;
        int levelTwo = 125;
        int levelThree = 100;
        int levelFour = 50;
        int levelWin = 25;
        int gameLevel;
        int zeroPlus;
        List<int> scores = new List<int>();
        public Game()
        {
            zeroPlus = 1;
        }
        public void RunGame(int newGameLevel)
        {
            Console.CursorVisible = false;
            GameSplash(newGameLevel);
            newWall.WallDisplay();
            newBrick.BrickDisplay();
            newBall.touchPaddle.PaddleShape();
            Console.SetCursorPosition(50, 15);
            RunGameLoop(newGameLevel);
        }
        public void RunGameLoop(int newGameLevel)
        {
            while (!Console.KeyAvailable)
            {
                BallBounce();
                newWall.WallDisplay();
                Score();
                if (newBall.BrickProgress() == 12)
                {
                    RunGame(GameLevel());
                }
                PaddleSlide();
                Thread.Sleep(newGameLevel);
            }
            PaddleSlide();
            RunGameLoop(newGameLevel);
        }
        public void BallBounce()
        {
            newBall.BallDisplay();
            ballMoveLeft = newBall.BallMove()[0];
            ballMoveTop = newBall.BallMove()[1];
        }
        public void PaddleSlide()
        {
            newBall.touchPaddle.PaddleDisplay();
            sendPaddleMove = Console.CursorLeft;
            Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
        }
        public int GameLevel()
        {
            gameLevel = newBall.BrickProgress();
            while (zeroPlus == 1)
            {
                if (gameLevel == 12)
                {
                    zeroPlus++;
                    newBall.BallReset();
                    return levelTwo;
                }     
            }
            while (zeroPlus == 2)
            {
                if (gameLevel == 12)
                {
                    zeroPlus++;
                    newBall.BallReset();
                    return levelThree;
                }
            }
            while (zeroPlus == 3)
            {
                if (gameLevel == 12)
                {
                    zeroPlus++;
                    newBall.BallReset();
                    return levelFour;
                }
            }
            while (zeroPlus == 4)
            {
                if (gameLevel == 12)
                {
                    zeroPlus++;
                    newBall.BallReset();
                    return levelWin;
                }
            }
            return levelOne;
        }
        public void GameSplash(int newGameLevel)
        {
            Console.Clear();
            Console.SetCursorPosition(55, 15);
            if (newGameLevel == levelOne)
            {
                Console.Write("LEVEL ONE");
            }
            if (newGameLevel == levelTwo)
            {
                Console.Write("LEVEL TWO");
            }
            if (newGameLevel == levelThree)
            {
                Console.Write("LEVEL THREE");
            }
            if (newGameLevel == levelFour)
            {
                Console.Write("LEVEL FOUR");
            }
            if (newGameLevel == levelWin)
            {
                for (int i = 0; i < 200; i++)
                {
                    if ((i + 1) % 37 == 0)
                    {
                        Console.SetCursorPosition(5, i + 60);
                        Console.WriteLine("YOU                                                                                                     WIN");
                        Thread.Sleep(100);
                    }
                    if ((i + 1) % 23 == 0)
                    {
                        Console.SetCursorPosition(15, i + 60);
                        Console.WriteLine("YOU                                                                                 WIN");
                        Thread.Sleep(100);
                    }
                    if ((i + 1) % 13 == 0)
                    {
                        Console.SetCursorPosition(25, i + 60);
                        Console.WriteLine("YOU                                                             WIN");
                        Thread.Sleep(100);
                    }
                    if ((i + 1) % 7 == 0)
                    {
                        Console.SetCursorPosition(35, i + 60);
                        Console.WriteLine("YOU                                         WIN");
                        Thread.Sleep(100);
                    }
                    if ((i + 1) % 3 == 0)
                    {
                        Console.SetCursorPosition(45, i + 60);
                        Console.WriteLine("YOU                     WIN");
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Console.SetCursorPosition(55, i + 60);
                        Console.WriteLine("YOU WIN");
                        Thread.Sleep(100);
                    }

                }
                Thread.Sleep(20000);
            }
            Thread.Sleep(2000);
        }
        public void Score()
        {
            int score = zeroPlus * (newBall.BrickProgress() + zeroPlus) * (10 * zeroPlus);
            scores.Add(score);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("SCORE");
            Console.WriteLine(scores.Sum());
            Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
        }
    }
}
