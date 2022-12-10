using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Drawing;

namespace EmojiProj
{
    class RoundButton : Button
    {      
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(1, 1, ClientSize.Width - 4, ClientSize.Height - 4);
            Region = new Region(grPath);
            base.OnPaint(e);
        }
    }
}


