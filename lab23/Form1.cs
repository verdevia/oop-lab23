using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab23
{
    public partial class Form1 : Form
    {
        private const int scale = 50; // масштаб
        private const double step = 0.1; // крок

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawFunction(double a)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            Pen pen = new Pen(Color.Blue);

            double t = 0;
            double x_prev = FunctionX(t, a);
            double y_prev = FunctionY(t, a);
            t += step;

            while (t <= 2 * Math.PI)
            {
                double x = FunctionX(t, a);
                double y = FunctionY(t, a);

                g.DrawLine(pen, (float)(x_prev * scale + pictureBox1.Width / 2),
                                  (float)(-y_prev * scale + pictureBox1.Height / 2),
                                  (float)(x * scale + pictureBox1.Width / 2),
                                  (float)(-y * scale + pictureBox1.Height / 2));

                x_prev = x;
                y_prev = y;
                t += step;
            }
        }

        private double FunctionX(double t, double a)
        {
            return a * (t - Math.Sin(t) * Math.Sin(t));
        }

        private double FunctionY(double t, double a)
        {
            return a * (t - Math.Cos(t) * Math.Cos(t));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a;
            if (double.TryParse(textBox1.Text, out a))
            {
                DrawFunction(a);
            }
            else
            {
                MessageBox.Show("Введіть коректне значення 'a'");
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxes();
        }

        private void DrawAxes()
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black);

            // Ось X
            g.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            // Ось Y
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            // Позначки на осі X
            for (int i = -10; i <= 10; i++)
            {
                g.DrawString(i.ToString(), Font, Brushes.Black, pictureBox1.Width / 2 + i * scale - 5, pictureBox1.Height / 2 + 5);
            }

            // Позначки на осі Y
            for (int i = -10; i <= 10; i++)
            {
                g.DrawString((-i).ToString(), Font, Brushes.Black, pictureBox1.Width / 2 - 20, pictureBox1.Height / 2 - i * scale - 10);
            }
        }
    }
}
