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
        Ball newBall = new Ball();
        int ballMoveLeft;
        int ballMoveTop;
        int levelOne = 120;
        int levelTwo = 80;
        int levelThree = 50;
        int levelFour = 30;
        int levelWin = 25;
        int gameLevel;
        int levelNumber;
        List<int> scores = new List<int>();
        public Game()
        {
            levelNumber = 1;
        }
        public void RunGame(int newGameLevel)
        {
            Console.CursorVisible = false;
            GameSplash(newGameLevel);
            newBall.newBrick.BrickPositionJoin();
            newBall.newBrick.BrickDisplay();
            newWall.WallDisplay();
            newBall.touchPaddle.SendPaddleReset();
            newBall.SendBallReset();
            RunGameLoop(newGameLevel);
        }
        public void RunGameLoop(int newGameLevel)
        {
            while (!Console.KeyAvailable)
            {
                BallBounce();
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
            List<int> ballMoveLeftTop = new List<int>(newBall.BallMove());
            ballMoveLeft = ballMoveLeftTop[0];
            ballMoveTop = ballMoveLeftTop[1];
        }
        public void PaddleSlide()
        {
            newBall.touchPaddle.PaddleDisplay();
            Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
        }
        public int GameLevel()
        {
            gameLevel = newBall.BrickProgress();
            while (levelNumber == 1)
            {
                if (gameLevel == 12)
                {
                    levelNumber++;
                    newBall.BallReset();
                    return levelTwo;
                }     
            }
            while (levelNumber == 2)
            {
                if (gameLevel == 12)
                {
                    levelNumber++;
                    newBall.BallReset();
                    return levelThree;
                }
            }
            while (levelNumber == 3)
            {
                if (gameLevel == 12)
                {
                    levelNumber++;
                    newBall.BallReset();
                    return levelFour;
                }
            }
            while (levelNumber == 4)
            {
                if (gameLevel == 12)
                {
                    levelNumber++;
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
                Thread.Sleep(2000);
                RunGame(110);
            }
            Thread.Sleep(2000);
        }
        public void Score()
        {
            int score = levelNumber * (newBall.BrickProgress() + levelNumber) * (10 * levelNumber);
            scores.Add(score);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("SCORE");
            Console.WriteLine(scores.Sum());
            Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
        }
    }
}
