using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiProj
{
    class Emoji : Sprite
    {
        protected int _radius;

        public Emoji(Point center, Point velocity, Color color) : base(center, velocity, color)
        {
            _radius = 75;
        }

        public Emoji(Point center, Point velocity) : base(center, velocity)
        {
            _radius = 75;
        }

        public Rectangle GetBounds()
        {
            int x = base.center.X - this._radius;
            int y = base.center.Y - this._radius;
            int width = this._radius * 2;
            int height = width;

            Rectangle rect = new Rectangle(x, y, width, height);
            return rect;
        }

        public override void Draw(Graphics g)
        {
            Rectangle bounds = GetBounds();

            // draw the face
            Pen myPen = new Pen(Color.Black, 3);
            g.DrawEllipse(myPen, bounds);

            // fill the face
            SolidBrush myBrush = new SolidBrush(base.backColor);
            g.FillEllipse(myBrush, bounds);

            // fill the eyes
            SolidBrush eyeBrush = new SolidBrush(Color.Black);
            g.FillEllipse(eyeBrush, new Rectangle(base.center.X + 20, base.center.Y - 45, 20, 40));
            g.FillEllipse(eyeBrush, new Rectangle(base.center.X - 40, base.center.Y - 45, 20, 40));
        }

        public override void Move(bool loop, bool bounce, int minX, int maxX, int minY, int maxY)
        {
            int remainingDist;
            int remainingDisplacement;
            int newPos;
            int bouncingForce = 65;

            if (loop)
            {
                if (center.X <= minX)
                {
                    center.X = maxX;
                }
                else if (center.X >= maxX)
                {
                    center.X = minX;
                }

                if (center.Y >= maxY)
                {
                    center.Y = minY;
                }
                else if (center.Y <= minY)
                {
                    center.Y = maxY;
                }
            }
            else
            {
                if (center.X >= maxX)
                {
                    center.X = maxX;
                }

                if (center.X <= minX)
                {
                    center.X = minX;
                }

                if (center.Y >= maxY)
                {
                    center.Y = maxY;
                }

                if (center.Y <= minY)
                {
                    center.Y = minY;
                }
            }

            if (!loop && bounce)
            {
                if (center.X >= maxX)
                {
                    remainingDist = maxX - center.X;
                    remainingDisplacement = velocity.X - remainingDist;
                    newPos = maxX - remainingDisplacement;

                    center.X = (newPos - bouncingForce);
                }

                if (center.X <= minX)
                {
                    remainingDist = minX + center.X;
                    remainingDisplacement = velocity.X + remainingDist;
                    newPos = minX + remainingDisplacement;

                    center.X = (newPos + bouncingForce);
                }

                if (center.Y >= maxY)
                {
                    remainingDist = maxY - center.Y;
                    remainingDisplacement = velocity.Y - remainingDist;
                    newPos = maxY - remainingDisplacement;

                    center.Y = (newPos - bouncingForce);
                }

                if (center.Y <= minY)
                {
                    remainingDist = minY + center.Y;
                    remainingDisplacement = velocity.Y + remainingDist;
                    newPos = minY + remainingDisplacement;

                    center.Y = (newPos + bouncingForce);
                }
            }
        }
    }
}
