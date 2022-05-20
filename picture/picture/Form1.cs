using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace picture
{
    public partial class Form1 : Form
    {
        int Instrument = 0;
        Pen p = new Pen(Color.Black, 1);
        Pen p1 = new Pen(Color.White, 1);
        Bitmap buf;
        Graphics gr;
        public Form1()
        {
            InitializeComponent();
            buf = new Bitmap(pic.Width, pic.Height);
            gr = Graphics.FromImage(buf);
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (Instrument == 1)
                gr.DrawLine(p, e.X, e.Y, pic.Width/2, pic.Height/2);
            if (Instrument == 2)
                gr.DrawRectangle(p, e.X, e.Y, 20, 20);
            if (Instrument == 3)
                gr.DrawLine(p, e.X, e.Y, e.X + 10, e.Y - 10);
            pic.Image = buf;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Instrument = 1;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Instrument = 2;
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Instrument = 3;
        }

        private void MnuCol_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p = new Pen(colorDialog1.Color);
            }
        }

        private void pic_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                gr.Clear(Color.White);
            pic.Image = buf;
        }
    }
}
