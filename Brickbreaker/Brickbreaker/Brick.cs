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
        List<string> brickTop = new List<string> { " ", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", "-", " " };
        List<string> brickMiddle = new List<string> { "|", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "$", "|" };
        List<string> brickBlank = new List<string> { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
        int brickRows;
        int brickColumns;
        int brickCount;
        List<int> brickPositionJoin;
        List<List<int>> brickPositionJoinList = new List<List<int>>();
        int setBrickPositionLeft;
        int setBrickPositionTop;
        List<int> setBrickPositionLeftList;
        public Brick()
        {
            brickPositionLeft = new List<int> { 14, 38, 62, 86 };
            brickPositionTop = new List<int> { 1, 5, 9 };
            brickColumns = brickPositionLeft.Count();
            brickRows = brickPositionTop.Count();
            brickCount = brickColumns * brickRows;
        }
        public void BrickResize(int levelBrickSet)
        {
            int calculate = 120 / (levelBrickSet + 2);
            for (int i = 1; i < calculate - 1; i++)
            {
                setBrickPositionLeft = calculate * i;
                //setBrickPositionTop =
                setBrickPositionLeftList = new List<int>
                {
                    setBrickPositionLeft
                };
            }
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
