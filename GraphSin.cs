using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int x = 0;
        private int y = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox1.Text);
            this.Controls.Remove(textBox1);
            this.Controls.Remove(textBox2);
            this.Controls.Remove(button1);
            this.Controls.Remove(label1);
            this.Controls.Remove(label2);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Size size = this.ClientSize;
            Pen pen = new Pen(Color.Blue);

            double[] px = new double[x];
            double[] py = new double[y];
            

            
            for (int ip = 0; ip < x; ip++)
            {
                px[ip] = Math.Sin(ip) * size.Width;
                py[ip] = size.Height - Math.Sin(ip) * size.Height;
            }

            for (int ip = 1; ip < x; ip++)
            {
                g.DrawLine(pen, (float)px[ip - 1], (float)py[ip - 1], (float)px[ip], (float)py[ip]);
                
            }
            
        }
    }
}
