﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuronsTask.Neurons;
using NeuronsTask.Funcs;

namespace NeuronsTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Neuron n = new Neuron(new double[] {5,8,10});
            //MessageBox.Show(n.Calculation()+"\n"+n.GetWeights() + "\n" + n._bias+"\n\n"+ new Functions().OneDivideSqrt(35.93));

            NeuronsNetwork nn = new NeuronsNetwork(3);
            string n = string.Empty;
            double[] newV = nn.UpdateNeuronsNetwork(nn.oldValues);



            for (int i = 0; i < nn.oldValues.Length; i++)
                n += $"[neuron {i}] old: {nn.oldValues[i]} \t new: {newV[i]}\n";


            richTextBox1.Text = n;   

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}