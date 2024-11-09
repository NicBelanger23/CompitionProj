using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitionProj
{
    internal class Level
    {
        public static Level Instance = new Level();
        public static int Width = 80;
        public static int Height = 20;
        public void DisplayLevel()
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine($"Score: {Wall.Player1.score} - {Wall.Player2.score}");
            for (int i = 0; i < Height; i++)
            {
                createLine((Height-1)  - i);
            }
        }

        void createLine(int h)
        {
            string result = "";
            for (int x = 0; x < Width; x++)
            {
                if ((h == Ball.b.Yr) && x == Ball.b.Xr)
                {
                    result += "O";
                    continue;
                }

                if ((x == 0) && Wall.Player1.withinRange(h))
                {
                    result += "|";
                    continue;
                }
                if ((x == Width-1) && Wall.Player2.withinRange(h))
                {
                    result += "|";
                    continue;
                }
                result += "-";

            }
            Console.WriteLine(result);
        }
    }
}
