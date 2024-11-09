using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace CompitionProj
{
    internal class Wall
    {

        //This section of code was generated using ChatGPT
        //-------------------------

        // Import the GetAsyncKeyState function from user32.dll
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private const int VK_SPACE = 0x20; // Virtual key code for the Space key

        private const int VK_W = 0x57;
        private const int VK_S = 0x53;
        private const int VK_I = 0x49;
        private const int VK_K = 0x4B;

        //end of GPT code
        //-------------------------

        //mapping player inputs
        public int[] player1Keys = { VK_W, VK_S };
        public int[] player2Keys = { VK_I, VK_K };


        public int position = 2;
        public int score = 0;
        public static Wall Player1 = new Wall();
        public static Wall Player2 = new Wall();


        public void moveUp()
        {
            if (position < Level.Height)
            {
                position++;
            }
        }
        public void moveDown()
        {
            if (position > 0)
            {
                position--;
            }
        }

        public void Input(bool player1)
        {
            int[] mykeys = player1? player1Keys : player2Keys;
            if ((GetAsyncKeyState(mykeys[0]) & 0x8000) != 0)
            {
                moveUp();
            }
            if ((GetAsyncKeyState(mykeys[1]) & 0x8000) != 0)
            {
                moveDown();
            }
            if((GetAsyncKeyState(VK_SPACE) & 0x8000) != 0)
            {
                Ball.b.Moving = true;
            }

        }

        public bool withinRange(int h)
        {
            return (h < position + 3) && (h > position - 3);

        }
    }
    
}
