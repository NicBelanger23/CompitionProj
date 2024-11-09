using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitionProj
{
    internal class Ball
    {
        public static Ball b = new Ball();
        double X;
        double Y;
        public int Xr;
        public int Yr;

        public double Angle = -10;
        public double Speed = 1.0;
        public bool Moving = false;
        public Ball()
        {
            reset();
        }
        void reset()
        {
            X = Level.Width / 2;
            Y = Level.Height / 2;
            Xr = (int)X;
            Yr = (int)Y;
            Speed = 1;

            Moving = false;
        }
        public void Update()
        {
            if(!Moving) return;
            double x = X + (Math.Cos(Angle) * Speed);
            double y = Y + (Math.Sin(Angle) * Speed);

            //handel Y
            if(y <= 0)
            {
                Angle *= -1;
                Y += Math.Sin(Angle);
            }
            else if (y >= Level.Height)
            {
                Angle *= -1;
                Y += Math.Sin(Angle);
            }
            else
            {
                Y = y;
            }


            //handel X
            if (x <= 0)
            {
                if (Wall.Player1.withinRange((int)Y))
                {
                    Angle = 3.14 - Angle;
                    X += Math.Sin(Angle);
                    Speed += 0.5f;
                }
                else
                {
                    reset();
                    Wall.Player2.score++;
                }

            }
            else if (x >= Level.Width)
            {
                if (Wall.Player2.withinRange((int)Y))
                {
                    Angle = 3.14 - Angle;
                    Y += Math.Cos(Angle);
                    Speed += 0.5f;
                }
                else {
                    reset();
                    Wall.Player1.score++;
                }

            }
            else
            {
                X = x;
            }

            Xr = (int)X;
            Yr = (int)Y;
        }

    }
}
