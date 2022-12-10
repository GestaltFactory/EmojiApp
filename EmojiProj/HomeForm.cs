using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmojiProj
{
    public partial class HomeForm : Form
    {
        Emoji emoji;
        Graphics g;
        int saveX;
        int saveY;

        Label labelName;

        public HomeForm()
        {
            InitializeComponent();

            g = CreateGraphics();
            labelName = new Label();
            emoji = new SmileyFace(new Point(225, 225), new Point(45, 45));
        }

        private void ReloadRoundButton_Click(object sender, EventArgs e)
        {
            int random = Randomizer.random.Next(1, 4);
            saveX = emoji.center.X;
            saveY = emoji.center.Y;

            this.Controls.Add(labelName);
            labelName.Font = new Font("Arial", 12, FontStyle.Bold);
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            labelName.Location = new Point(saveX - 50, saveY - 100);

            if (random == 1)
            {
                emoji = new SmileyFace(new Point(saveX, saveY), new Point(45, 45));
                labelName.Text = "Smiley";
                emoji.Draw(g);
            }
            else if (random == 2)
            {
                emoji = new SadFace(new Point(saveX, saveY), new Point(45, 45));
                labelName.Text = "Sady";
                emoji.Draw(g);
            }
            else
            {
                emoji = new NeutralFace(new Point(saveX, saveY), new Point(45, 45));
                labelName.Text = "Neutry";
                emoji.Draw(g);
            }
        }

        private void HomeForm_Paint(object sender, PaintEventArgs e)
        {
            this.Controls.Add(labelName);
            labelName.Text = "Smiley";
            labelName.Font = new Font("Arial", 12, FontStyle.Bold);
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            labelName.Location = new Point(emoji.center.X - 50, emoji.center.Y - 100);
            emoji.Draw(g);
        }

        private void OrangeRoundButton_Click(object sender, EventArgs e)
        {
            emoji.backColor = Color.Orange;           
            emoji.Draw(g);
        }

        private void TomatoRoundButton_Click(object sender, EventArgs e)
        {
            emoji.backColor = Color.Tomato;
            emoji.Draw(g);
        }

        private void YellowRoundButton_Click(object sender, EventArgs e)
        {
            emoji.backColor = Color.Yellow;
            emoji.Draw(g);
        }

        private void RightRoundButton_Click(object sender, EventArgs e)
        {
            emoji.center.X += emoji.velocity.X;
            emoji.Move(WarpBorderCheckBox.Checked, BouncingCheckBox.Checked, 75, 510, 75, 685);
            Invalidate();
            emoji.Draw(g);
        }

        private void LeftRoundButton_Click(object sender, EventArgs e)
        {
            emoji.center.X -= emoji.velocity.X;
            emoji.Move(WarpBorderCheckBox.Checked, BouncingCheckBox.Checked, 75, 510, 75, 685);
            Invalidate();
            emoji.Draw(g);
        }

        private void UpRoundButton_Click(object sender, EventArgs e)
        {
            emoji.center.Y -= emoji.velocity.Y;
            emoji.Move(WarpBorderCheckBox.Checked, BouncingCheckBox.Checked, 75, 510, 75, 685);
            Invalidate();
            emoji.Draw(g);
        }

        private void DownRoundButton_Click(object sender, EventArgs e)
        {
            emoji.center.Y += emoji.velocity.Y;
            emoji.Move(WarpBorderCheckBox.Checked, BouncingCheckBox.Checked, 75, 510, 75, 685);
            Invalidate();
            emoji.Draw(g);
        }

        private void HomeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    emoji.center.X += emoji.velocity.X;                   
                    break;
                case Keys.A:
                    emoji.center.X -= emoji.velocity.X;
                    break;
                case Keys.W:
                    emoji.center.Y -= emoji.velocity.Y;
                    break;
                case Keys.S:
                    emoji.center.Y += emoji.velocity.Y;
                    break;
                default:
                    break;
            }

            emoji.Move(WarpBorderCheckBox.Checked, BouncingCheckBox.Checked, 75, 510, 75, 685);
            Invalidate();
            emoji.Draw(g);
        }

        private void WarpBorderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WarpBorderCheckBox.Checked)
            {
                BouncingCheckBox.Checked = false;
                BouncingCheckBox.Enabled = false;
            }
            else
            {
                BouncingCheckBox.Enabled = true;
            }
        }
    }
}
