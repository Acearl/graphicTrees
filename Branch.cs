using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
 
namespace graphicTrees
{
    public class Branch
    {
        int minLength = 90;
        int maxLength = 100;
        /*int minTheta = 0;
        int maxTheta = 180;*/
        public int posX { get; set; }
        public int posY { get; set; }
        public int rotation { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        
        public static Color color = Colors.Brown;
        Random rng = new Random();
        public Branch(int x, int y, int rot, int width, int length)
        {
            posX = x;
            posY = y;
            rotation = rot;
            this.width = width;
            this.length = length;

        }
        public Branch(int x, int y)
        {
            posX = x;
            posY = y;
        }
            public void move(int x, int y)
        {
            posX += x;
            posY += y;
        }

        public void setEndPoint(int x, int y)
        {
            posX = x;
            posY = y;
        }
        public void setEndPoint()
        {
            double theta = rng.NextDouble() * 180;
            length = rng.Next(minLength, maxLength);

            posX -= (int)Math.Round((length * (Math.Cos(theta * Math.PI / 180))));
            posY -= (int)Math.Round((length * (Math.Sin(theta * Math.PI / 180))));
        }

    }
}
