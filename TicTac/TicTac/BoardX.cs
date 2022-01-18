using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace TicTac
{
    class BoardX
    {
        public int movesMade = 0;


        private Rectangle[,] slots = new Rectangle[3, 3];
        private Holder[,] holders = new TicTac.Holder[3, 3];

        public const int X= 0;
        public const int O = 1;
        public const int B = 2;

        public void initBoard()
        {
            for (int x = 0; x < 3; x++) 
            {
                for (int y = 0; y < 3; y++) 
                {
                    slots[x, y] = new Rectangle(x * 125, y * 125, 125, 125);
                    holders[x, y] = new Holder();
                    holders[x, y].setValue(B);
                    holders[x, y].setLocation(new Point(x, y));
                }
            }
        }

        public void detectHit(Point loc)
        {
            if (loc.Y <= 500)
            {
                int x = 0;
                int y = 0;
                if (loc.X < 125)
                {
                    x = 0;
                }
                else if (loc.X > 125 && loc.X < 250)
                {
                    x = 1;
                }
                else if (loc.X > 250)
                {
                    x = 2;
                }
                if (loc.Y < 125)
                {
                    y = 0;
                }
                else if (loc.Y > 125 && loc.Y < 250)
                {
                    y = 1;
                }
                else if (loc.Y > 250 && loc.Y < 500)
                {
                    y = 2;
                }
                
                

                if(movesMade%2==0)
                {
                    Graph.drawX(new Point(x,y));
                }
                else
                {
                    Graph.drawO(new Point(x, y));
                }
                movesMade++;
            }


        }

    }

    class Holder
    {
        private Point location;
        private int value = BoardX.B;

        public void setLocation(Point p)
        {
            location = p;
        }
        public Point getLocation()
        {
            return location;
        }
        public void setValue (int i)
        {
            value = i;


        }
        public int getValue()
        {
            return value;
        }
    }
}
