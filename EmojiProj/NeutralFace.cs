using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiProj
{
    sealed class NeutralFace : Emoji
    {
        public NeutralFace(Point center, Point velocity) : base(center, velocity)
        {
            backColor = Color.Orange;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Rectangle bounds = new Rectangle(base.center.X - 30, base.center.Y + 5, 60, 50);
            Pen myPen = new Pen(Color.Black, 3);

            Point start = new Point(center.X - 30, center.Y + 25);
            Point end = new Point(center.X + 25, center.Y + 25);
            g.DrawLine(myPen, start, end);
        }
    }
}
