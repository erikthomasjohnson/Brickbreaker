using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Brickbreaker
{
    class Game
    {
        Brick newBrick = new Brick();
        Ball newBall = new Ball();
        Paddle newPaddle = new Paddle();
        int ballMoveLeft;
        int ballMoveTop;
        int paddleMoveLeft;
        public Game()
        {
        }
        private static Timer TimerA;
        public void RunGame()
        {
            Console.CursorVisible = false;
            newBrick.BrickDisplay();
            newPaddle.PaddleShape();
            Console.SetCursorPosition(47, 26);
            Console.Write("Press Arrow Key to Begin!");
            SetTimerA();
            for (int i = 0; i < 5000; i++)
            {
                newPaddle.PaddleDisplay();
                paddleMoveLeft = Console.CursorLeft;
                Console.SetCursorPosition(ballMoveLeft, ballMoveTop);
            }
        }
        public void SetTimerA()
        {
            TimerA = new Timer(100);
            TimerA.Elapsed += OnTimedEventA;
            TimerA.AutoReset = true;
            TimerA.Enabled = true;
            GC.KeepAlive(TimerA);
        }
        public void OnTimedEventA(Object source, ElapsedEventArgs e)
        {
            BallBounce();
        }
        public void BallBounce()
        {
            newBall.BallDisplay(paddleMoveLeft);
            ballMoveLeft = newBall.BallMove()[0];
            ballMoveTop = newBall.BallMove()[1];
        }
    }
}
