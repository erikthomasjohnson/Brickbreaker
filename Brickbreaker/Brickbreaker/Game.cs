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
        int levelOne = 100;
        int levelTwo = 80;
        int levelThree = 60;
        int levelFour = 40;
        int levelWin = 20;
        int gameLevel;
        int levelNumber;
        int brickCount;
        List<int> scores = new List<int>();
        int scoreUpdate;
        public Game()
        {
            levelNumber = 1;
            scoreUpdate = 1;
        }
        public void RunGame(int newGameLevel)
        {
            Console.CursorVisible = false;
            GameSplash(newGameLevel);
            newBall.newBrick.BrickCountResize(levelNumber * 2);
            newBall.newBrick.BrickPositionJoin();
            brickCount = newBall.newBrick.BrickCount();
            newBall.newBrick.BrickDisplay();
            newWall.WallDisplay();
            newBall.touchPaddle.PaddleReset();
            newBall.BallReset();
            scoreUpdate = 0;
            RunGameLoop(newGameLevel);
        }
        public void RunGameLoop(int newGameLevel)
        {
            while (!Console.KeyAvailable)
            {
                BallBounce();
                GameOverLose();
                Score();
                if (newBall.BrickProgress() == brickCount)
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
            if (levelNumber == 1 && gameLevel == brickCount)
            {
                levelNumber++;
                newBall.BrickReset();
                return levelTwo;     
            }
            if (levelNumber == 2 && gameLevel == brickCount)
            {
                levelNumber++;
                newBall.BrickReset();
                return levelThree;
            }
            if (levelNumber == 3 && gameLevel == brickCount)
            {
                levelNumber++;
                newBall.BrickReset();
                return levelFour;
            }
            while (levelNumber == 4 && gameLevel == brickCount)
            {
                levelNumber++;
                newBall.BrickReset();
                return levelWin;
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
                Console.SetCursorPosition(55, 17);
                Console.Write("SCORE  ");
                Console.Write(scores.Sum());
            }
            if (newGameLevel == levelThree)
            {
                Console.WriteLine("LEVEL THREE");
                Console.SetCursorPosition(55, 17);
                Console.Write("SCORE  ");
                Console.Write(scores.Sum());
            }
            if (newGameLevel == levelFour)
            {
                Console.WriteLine("LEVEL FOUR");
                Console.SetCursorPosition(55, 17);
                Console.Write("SCORE  ");
                Console.Write(scores.Sum());
            }
            if (newGameLevel == levelWin)
            {
                GameOverLoop("WIN");
            }
            Thread.Sleep(2000);
        }
        public void Score()
        {
            int brickProgress = newBall.BrickProgress();
            if (brickProgress >= scoreUpdate)
            {
                int score = levelNumber * 10 * (newBall.BrickProgress());
                scores.Add(score);
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("SCORE");
                Console.WriteLine(scores.Sum());
                Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
                if (brickProgress > scoreUpdate)
                {
                    scoreUpdate = brickProgress;
                }
                scoreUpdate++;
            }
        }
        public void GameOverLoop(string playerStatus)
        {
            for (int i = 0; i < 150; i++)
            {
                if ((i + 1) % 37 == 0)
                {
                    Console.SetCursorPosition(5, i + 60);
                    Console.WriteLine("YOU                                                                                                     {0}", playerStatus);
                    Thread.Sleep(100);
                }
                if ((i + 1) % 23 == 0)
                {
                    Console.SetCursorPosition(15, i + 60);
                    Console.WriteLine("YOU                                                                                 {0}", playerStatus);
                    Thread.Sleep(100);
                }
                if ((i + 1) % 13 == 0)
                {
                    Console.SetCursorPosition(25, i + 60);
                    Console.WriteLine("YOU                                                             {0}", playerStatus);
                    Thread.Sleep(100);
                }
                if ((i + 1) % 7 == 0)
                {
                    Console.SetCursorPosition(35, i + 60);
                    Console.WriteLine("YOU                                         {0}", playerStatus);
                    Thread.Sleep(100);
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.SetCursorPosition(45, i + 60);
                    Console.WriteLine("YOU                     {0}", playerStatus);
                    Thread.Sleep(100);
                }
                else
                {
                    Console.SetCursorPosition(55, i + 60);
                    Console.WriteLine("YOU {0}", playerStatus);
                    Thread.Sleep(100);
                }
                while (Console.KeyAvailable)
                {
                    i = 150;
                    break;
                }
            }
            GameOverRestart();
        }
        public void GameOverLose()
        {
            if (ballMoveTop >= 30)
            {
                ballMoveTop = 60;
                GameOverLoop("LOSE");
            }
        }
        public void GameOverRestart()
        {
            Console.CursorTop = Console.CursorTop + 10;
            Console.CursorLeft = 55;
            Console.Write("SCORE  ");
            Console.Write(scores.Sum());
            Console.CursorTop = Console.CursorTop + 10;
            Thread.Sleep(3000);
            newBall.BrickReset();
            levelNumber = 1;
            scores.Clear();
            RunGame(100);
        }
    }
}
