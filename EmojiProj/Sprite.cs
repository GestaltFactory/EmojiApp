using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiProj
{
    public abstract class Sprite
    {
        public Point center;
        public Point velocity;
        public Color backColor;

        protected Sprite(Point center, Point velocity, Color color)
        {
            this.center = center;
            this.velocity = velocity;
            this.backColor = color;
        }

        protected Sprite(Point center, Point velocity)
        {
            this.center = center;
            this.velocity = velocity;
        }

        public abstract void Move(bool loop, bool bounce, int minX, int maxX, int minY, int maxY);
        public abstract void Draw(Graphics g);
    }
}
