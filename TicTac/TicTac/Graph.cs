using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTac
{

    class Graph
    {
        private static Graphics gObject;

        public Graph(Graphics g)
        {
            gObject = g;
            setUpCanvas();
        }

        public void setUpCanvas()
        {
            Brush bg = new SolidBrush(Color.WhiteSmoke);
            Pen lines = new Pen(Color.Black,5);

            gObject.FillRectangle(bg, new Rectangle(0, 0, 500, 500));

            gObject.DrawLine(lines, new Point(125, 0), new Point(125, 500));
            gObject.DrawLine(lines, new Point(250, 0), new Point(250, 500));
            gObject.DrawLine(lines, new Point(0, 125), new Point(500, 125));
            gObject.DrawLine(lines, new Point(0, 250), new Point(500,250 ));
           // gObject.DrawLine(lines, new Point(0, 500), new Point(500, 500));
        }

        public static void drawX(Point loc)
        {
            Pen xPen = new Pen(Color.Red, 5);
            int xAbs = loc.X * 125;
            int yAbs = loc.Y * 125;

            gObject.DrawLine(xPen, xAbs, yAbs, xAbs + 125, yAbs + 125);
            gObject.DrawLine(xPen, xAbs+125, yAbs, xAbs, yAbs + 125);

        }

        public static void drawO(Point loc)
        {
            Pen oPen = new Pen(Color.Blue, 5);
            int xAbs=loc.X * 125;
            int yAbs = loc.Y * 125;
            gObject.DrawEllipse(oPen, xAbs+10, yAbs+10, 105, 105);
        }
    }
}
