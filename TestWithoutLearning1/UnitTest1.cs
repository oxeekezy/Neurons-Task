using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NeuronsTask.Neurons;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace TestWithoutLearning1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestMethod1()
        {

            //net.Layers[1].Neurons[0].SetFakeWeights(0.3, -0.3, 0.7);
            //net.Layers[1].Neurons[1].SetFakeWeights(-0.5, 0.7, -0.9);

            //net.Layers[2].Neurons[0].SetFakeWeights(0.1, 0.2);

            var dataset = GetDataset(0, 100, 10);

            //var dataset = new List<(double, double[])>
            //{
            //    (0,new double[]{0,0,0,1,0 }),
            //    (0,new double[]{0,0,1,0,0 }),
            //    (0,new double[]{0,0,1,1 ,0}),
            //    (1,new double[]{0,1,0,0 ,0}),
            //    (1,new double[]{0,1,0,1 ,0}),
            //    (1,new double[]{0,1,1,0,0 }),
            //    (1,new double[]{0,1,1,1 ,0}),
            //    (0,new double[]{1,0,0,0 ,0}),
            //    (0,new double[]{1,0,0,1,0 }),
            //    (0,new double[]{1,0,1,0 ,0}),
            //    (0,new double[]{1,0,1,1 ,0}),
            //    (1,new double[]{1,1,0,0 ,0}),
            //    (1,new double[]{1,1,0,1 ,0}),
            //    (1,new double[]{1,1,1,1 ,0}),

            //};

            //var dataset = new List<(double, double[])>
            //{
            //    (2,new double[]{6,3 }),
            //    (4,new double[]{16,4 }),
            //    (20,new double[]{100,5 }),
            //    (1,new double[]{100,100 }),
            //    (8,new double[]{16,2 })

            //};

            var topology = new Topology(1, 1, 0.000000001,8);
            var net = new NeuralNetwork(topology);
            var diffPow2 = net.Learn(dataset, 10000);

            var results = new List<float>();
            foreach (var data in dataset)
            {
                results.Add((float)net.FeedForward(data.Item2).Output);
            }



            List<string> a = new List<string>();
            List<PointF> approc = new List<PointF>();
            int x = 1;

            for (int i = 0; i < results.Count; i++)
            {
                var ex = dataset[i].Item1;
                var ac = results[i];

                a.Add(ex + "\t->" + ac);

                approc.Add(new PointF(x, results[i]));
                x += 10;
            }
            a.Add("ABS error: "+diffPow2.ToString());

            a.Add("\nTest result [95]: " + net.FeedForward(95).Output.ToString());
            a.Add("Test result [625]: " + net.FeedForward(625).Output.ToString());

            Main m = new Main(a, dataset, approc);
            m.ShowDialog();

        }

        public List<PointF> GetApproc(List<PointF> res)
        {
            return res;
        }
        

        public void SetSeries(Chart chart,string name, params PointF[] points) 
        {
            chart.Series.Add(name);
            Series series = chart.Series.FindByName(name);
            series.ChartType = SeriesChartType.FastLine;
            series.BorderWidth = 3;

            foreach (PointF point in points) 
            {
                series.Points.AddXY(point.X, point.Y);
            }
        }

        public PointF[] GetSqrt(int start, int end, int step) 
        {
            List<PointF> points = new List<PointF>();

            for (int i = start; i < end; i += step) 
            {
                points.Add(new PointF(i, (float)Math.Sqrt(i)));
            }

            return points.ToArray();
        }

        public List<(double, double[])> GetDataset(int start, int end, int step) 
        {
            List<(double, double[])> dataset = new List<(double, double[])>();

            for (int i = start; i < end; i += step) 
            {
                (double, double[]) n = (Math.Round(Math.Sqrt(i),3), new double[] { i });
                dataset.Add(n);
            }

            return dataset;
        }


    }
}
