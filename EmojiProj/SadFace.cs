using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiProj
{
    sealed class SadFace : Emoji
    {
        public SadFace(Point center, Point velocity) : base(center, velocity)
        {
            backColor = Color.Tomato;
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            Rectangle bounds = new Rectangle(base.center.X - 30, base.center.Y + 5, 60, 50);
            Pen myPen = new Pen(Color.Black, 3);

            g.DrawArc(myPen, bounds, 0.0f, -180.0f);
        }
    }
}
