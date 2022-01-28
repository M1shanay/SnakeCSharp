using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursWinForms
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Game newGame;
        public Form()
        {
            InitializeComponent();
            newGame = new Game(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            Controls.Remove(trackBar1);
            Controls.Remove(trackBar2);
            Controls.Remove(label1);
            Controls.Remove(label2);
            Controls.Remove(label3);
            Controls.Remove(label4);
            trackBar1.Dispose();
            trackBar2.Dispose();
            label1.Dispose();
            label2.Dispose();
            label3.Dispose();
            label4.Dispose();
            button1.Dispose();
            newGame.GameStart(trackBar1.Value);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                newGame.SetSize(0);
                label1.Text = "Маленькая";
            }
            if (trackBar1.Value == 1)
            {
                newGame.SetSize(1);
                label1.Text = "Обычная";
            }
            if (trackBar1.Value == 2)
            {
                newGame.SetSize(2);
                label1.Text = "Большая";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0)
            {
                newGame.SetDiff(0);
                label2.Text = "Без";
            }
            if (trackBar2.Value == 1)
            {
                newGame.SetDiff(5);
                label2.Text = "Низкое";
            }
            if (trackBar2.Value == 2)
            {
                newGame.SetDiff(10);
                label2.Text = "Среднее";
            }
            if (trackBar2.Value == 3)
            {
                newGame.SetDiff(15);
                label2.Text = "Высокое";
            }
        }
    }
}
