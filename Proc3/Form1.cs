using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;

namespace Proc3
{
    public partial class Form1 : Form
    {
        public int ArraySize { get { Int32.TryParse(arraySize.Text, out int value);return value; } }
        public int DifficultyParameter { get { Int32.TryParse(difficultyParameter.Text, out int value); return value; } }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            TimeCounting();
        }
        private void TimeCounting()
        {
            Solutions solutions = new Solutions(ArraySize, DifficultyParameter);
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch stopwatch1 = new Stopwatch();
            for (int i = 1; i <= 21; i += 2)
            {
                stopwatch1.Reset();
                stopwatch.Reset();
                stopwatch1.Start();
                solutions.OneThreadSolution();
                stopwatch1.Stop();
                stopwatch.Start();
                solutions.SolutionByMultipleThreads(i);
                stopwatch.Stop();
                chart1.Series[0].Points.AddXY(i,stopwatch.ElapsedMilliseconds);
                chart1.Series[1].Points.AddXY(i, stopwatch1.ElapsedMilliseconds);
            }
        }
    }
}
