using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWithoutLearning1
{
    public partial class Main : Form
    {
        List<string> hz = new List<string>();
        List<(double, double[])> dataset = new List<(double, double[])>();
        List<PointF> approcsimation = new List<PointF>();
        public Main(List<string> p, List<(double, double[])> ds, List<PointF> approc)
        {
            InitializeComponent();
            hz = p;
            dataset = ds;
            approcsimation = approc;    
        }


        private void Main_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnitTest1 test = new UnitTest1();

            var originalPints = test.GetSqrt(0, 100, 1);

            test.SetSeries(chart1, "original", originalPints);
            test.SetSeries(chart1, "aproc", approcsimation.ToArray());

            foreach (var h in hz)
            {
                richTextBox1.Text += h + "\n";
            }

            foreach (var data in dataset)
            {
                richTextBox2.Text += data.Item1.ToString() + "\n";

                foreach (var d in data.Item2)
                {
                    richTextBox2.Text += "->>" + d.ToString() + "\n\n";
                }
            }
        }
    }
}
