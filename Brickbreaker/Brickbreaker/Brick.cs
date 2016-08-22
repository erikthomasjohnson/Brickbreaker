using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickbreaker
{
    class Brick
    {
        List<int> brickPositionLeft;
        List<int> brickPositionTop;
        List<string> brickTop;
        List<string> brickMiddle;
        List<string> brickBlank;
        int brickRows;
        int brickColumns;
        int brickCount;
        List<int> brickPositionJoin;
        List<List<int>> brickPositionJoinList = new List<List<int>>();
        int setBrickPositionLeft;
        List<int> setBrickPositionLeftList = new List<int>();
        int resizeBrickCount;
        int windowWidth = 120;
        int negativeSpace = 2;
        int brickMoveDirection;
        int brickMovePosition;
        public Brick()
        {
            brickTop = new List<string> { " ", "-", " " };
            brickMiddle = new List<string> { "|", "$", "|" };
            brickBlank = new List<string> { " ", " ", " " };
            brickPositionLeft = new List<int> { 14, 38, 62, 86 };
            brickPositionTop = new List<int> { 3, 7, 11, 15 };
            brickColumns = brickPositionLeft.Count();
            brickRows = brickPositionTop.Count();
            brickCount = brickColumns * brickRows;
            brickMoveDirection = 1;
            brickMovePosition = 0;
        }
        public void BrickCountResize(int levelBrickSet)
        {
            resizeBrickCount = windowWidth / (levelBrickSet + negativeSpace);
            setBrickPositionLeftList.Clear();
            for (int i = 1; i < levelBrickSet + 1; i++)
            {
                setBrickPositionLeft = resizeBrickCount * i;
                setBrickPositionLeftList.Add(setBrickPositionLeft);
            }
            brickPositionLeft = setBrickPositionLeftList;
            BrickResize();
        }
        public void BrickResize()
        {
            brickTop.Clear();
            brickMiddle.Clear();
            brickBlank.Clear();
            brickTop.Add(" ");
            brickMiddle.Add("|");
            brickBlank.Add(" ");
            for (int i = 0; i < resizeBrickCount/2; i++)
            {
                brickTop.Add("-");
                brickMiddle.Add("$");
                brickBlank.Add(" ");
            }
            brickTop.Add(" ");
            brickMiddle.Add("|");
            brickBlank.Add(" ");
        }
        public int BrickWidth()
        {
            return brickTop.Count();
        }
        public int BrickCount()
        {
            return brickCount;
        }
        public void BrickPositionJoin()
        {
            brickColumns = brickPositionLeft.Count();
            brickRows = brickPositionTop.Count();
            brickCount = brickColumns * brickRows;
            brickPositionJoinList.Clear();
            for (int i = 0; i < brickRows; i++)
            {
                for (int ii = 0; ii < brickColumns; ii++)
                {
                    brickPositionJoin = new List<int>
                    {
                        brickPositionLeft[ii], brickPositionTop[i]
                    };
                    brickPositionJoinList.Add(brickPositionJoin);
                }
            }
        }
        public List<List<int>> BrickPositionJoinList()
        {
            return brickPositionJoinList;
        }
        public void RemoveBrick(int left, int top)
        {
            for (int i = 0; i < brickPositionJoinList.Count; i++)
            {
                if (brickPositionJoinList[i][0].Equals(left) && brickPositionJoinList[i][1].Equals(top))
                {
                    brickPositionJoinList.Remove(brickPositionJoinList[i]);
                    BrickClear(left, top);
                }
            }
        }
        public void BrickDisplay()
        {
            for(int i = 0; i < brickPositionJoinList.Count; i++)
            {
                BrickShape(brickPositionJoinList[i][0], brickPositionJoinList[i][1]);
            }
        }
        public void BrickMovement()
        {
            if (brickMoveDirection == -1)
            {
                for (int ii = 0; ii < brickPositionJoinList.Count; ii++)
                {
                    BrickClear(brickPositionJoinList[ii][0], brickPositionJoinList[ii][1]);
                    brickPositionJoinList[ii][0] = brickPositionJoinList[ii][0] + brickMoveDirection;
                }
            }
            if (brickMoveDirection == 1)
            {
                for (int ii = 0; ii < brickPositionJoinList.Count; ii++)
                {
                    BrickClear(brickPositionJoinList[ii][0], brickPositionJoinList[ii][1]);
                    brickPositionJoinList[ii][0] = brickPositionJoinList[ii][0] + brickMoveDirection;
                }
            }
            brickMovePosition++;
            if (brickMovePosition == 10) { brickMovePosition = 0; brickMoveDirection = -brickMoveDirection; }
        }
        public void BrickShape(int left, int top)
        {
            int topHighHigh = top ;
            int topHighMid = top + 1;
            int topLowMid = top + 2;
            int topLowLow = top + 3;
            Console.SetCursorPosition(left, topHighHigh);
            foreach (string shape in brickTop) { Console.Write(shape); }
            Console.SetCursorPosition(left, topHighMid);
            foreach (string shape in brickMiddle) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowMid);
            foreach (string shape in brickMiddle) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowLow);
            foreach (string shape in brickTop) { Console.Write(shape); }
        }
        public void BrickClear(int left, int top)
        {
            int topHighHigh = top ;
            int topHighMid = top + 1;
            int topLowMid = top + 2;
            int topLowLow = top + 3;
            Console.SetCursorPosition(left, topHighHigh);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topHighMid);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowMid);
            foreach (string shape in brickBlank) { Console.Write(shape); }
            Console.SetCursorPosition(left, topLowLow);
            foreach (string shape in brickBlank) { Console.Write(shape); }
        }
    }
}
