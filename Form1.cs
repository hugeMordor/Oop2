using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Oop2
{
    public partial class Form1 : Form
    {
        bool isFirstTime = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetGcd getGcd = new GetGcd();
            if (radioButton1.Checked 
                && textBox1.Text != "" && textBox2.Text != "")
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                textBox5.Text = Convert.ToString(getGcd.GetGcdByEuclid(a, b, out long timeEuclid));
                textBox6.Text = Convert.ToString(getGcd.GetGcdByStein(a, b, out long timeStein));
                if (isFirstTime)
                {
                    textBox5.Text = Convert.ToString(getGcd.GetGcdByEuclid(a, b, out timeEuclid));
                    textBox6.Text = Convert.ToString(getGcd.GetGcdByStein(a, b, out timeStein));
                    isFirstTime = false;
                }
                textBox7.Text = Convert.ToString(timeEuclid);
                textBox8.Text = Convert.ToString(timeStein);

                DrawHistogram(getGcd.times);

                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            if (radioButton2.Checked 
                && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                int c = Convert.ToInt32(textBox3.Text);
                textBox5.Text = Convert.ToString(getGcd.GetGcdByEuclid(a, b, c));
            }
            if (radioButton3.Checked 
                && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "")
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                int c = Convert.ToInt32(textBox3.Text);
                int d = Convert.ToInt32(textBox4.Text);
                textBox5.Text = Convert.ToString(getGcd.GetGcdByEuclid(a, b, c, d));
            }
            if (radioButton4.Checked 
                && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox9.Text != "")
            {
                int a = Convert.ToInt32(textBox1.Text);
                int b = Convert.ToInt32(textBox2.Text);
                int c = Convert.ToInt32(textBox3.Text);
                int d = Convert.ToInt32(textBox4.Text);
                int f = Convert.ToInt32(textBox9.Text);
                textBox5.Text = Convert.ToString(getGcd.GetGcdByEuclid(a, b, c, d, f));
            }
            textBox5.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox9.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox9.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }
        private void DrawHistogram(List<Tuple<int, int, long>> times, string orientation = "Vertical")
        {
            Axis axisX = new Axis();
            Axis axisY = new Axis();

            axisX.Title = "время, ticks";
            axisY.Title = "Результат вычислений";

            chart1.Series.Clear();
            chart1.Series.Add("Число1");
            chart1.Series.Add("Число2");

            if (orientation == "Horizontal")
            {
                chart1.Series["Число1"].ChartType = SeriesChartType.Bar;
                chart1.Series["Число2"].ChartType = SeriesChartType.Bar;
            }

            foreach (var item in times)
            {
                chart1.Series["Число1"].Points.AddXY(item.Item3, item.Item1);
                chart1.Series["Число2"].Points.AddXY(item.Item3, item.Item2);
            }

            chart1.ChartAreas[0].Area3DStyle.Enable3D = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 12);
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "2";
            chart1.ChartAreas[0].AxisX = axisX;
            chart1.ChartAreas[0].AxisY = axisY;

            chart1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    class GetGcd
    {
        Stopwatch stopwatch = new Stopwatch();
        public List<Tuple<int, int, long>> times = new List<Tuple<int, int, long>>();
        int count = 0;
        public int GetGcdByEuclid(int a, int b, out long time)
        {
            stopwatch.Start();
            int Gcd = GetGcdByEuclid(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            return Gcd;
        }
        public int GetGcdByEuclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;

            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return Math.Max(a, b);
        }
        public int GetGcdByEuclid(int a, int b, int c)
        {
            return GetGcdByEuclid(GetGcdByEuclid(a, b), c);
        }
        public int GetGcdByEuclid(int a, int b, int c, int d)
        {
            return GetGcdByEuclid(GetGcdByEuclid(GetGcdByEuclid(a, b), c), d);
        }
        public int GetGcdByEuclid(int a, int b, int c, int d, int f)
        {
            return GetGcdByEuclid(GetGcdByEuclid(GetGcdByEuclid(GetGcdByEuclid(a, b), c), d), f);
        }
        public int GetGcdByStein(int a, int b, out long time)
        {
            stopwatch.Start();
            int Gcd = GetGcdByStein(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            return Gcd;
        }
        private int GetGcdByStein(int a, int b)
        {
            stopwatch.Stop();
            long time = stopwatch.ElapsedTicks;
            if (count > 0)
            {
                times.Add(new Tuple<int, int, long>(a, b, time));
            }
            count++;
            stopwatch.Reset();
            stopwatch.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) 
            {
                count = 0;
                return a; 
            }
            if (a == 0)
            {
                count = 0;
                return b;
            }
            if (b == 0)
            {
                count = 0;
                return a;
            }

            if (a % 2 == 0)
            {
                if (b % 2 == 0) return 2 * GetGcdByStein(a / 2, b / 2);
                return GetGcdByStein(a / 2, b);
            }
            if (b % 2 == 0) return GetGcdByStein(a, b / 2);
            if (a > b) return GetGcdByStein((a - b) / 2, b);
            return GetGcdByStein(a, (b - a) / 2);
        }
    }
}