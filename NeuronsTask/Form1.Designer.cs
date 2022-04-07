namespace NeuronsTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.addNeuron = new System.Windows.Forms.Button();
            this.neuronsCount = new System.Windows.Forms.NumericUpDown();
            this.updateNetwork = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(570, 287);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // addNeuron
            // 
            this.addNeuron.Location = new System.Drawing.Point(12, 305);
            this.addNeuron.Name = "addNeuron";
            this.addNeuron.Size = new System.Drawing.Size(75, 23);
            this.addNeuron.TabIndex = 1;
            this.addNeuron.Text = "add";
            this.addNeuron.UseVisualStyleBackColor = true;
            this.addNeuron.Click += new System.EventHandler(this.addNeuron_Click);
            // 
            // neuronsCount
            // 
            this.neuronsCount.Location = new System.Drawing.Point(93, 307);
            this.neuronsCount.Name = "neuronsCount";
            this.neuronsCount.Size = new System.Drawing.Size(120, 20);
            this.neuronsCount.TabIndex = 2;
            // 
            // updateNetwork
            // 
            this.updateNetwork.Location = new System.Drawing.Point(12, 334);
            this.updateNetwork.Name = "updateNetwork";
            this.updateNetwork.Size = new System.Drawing.Size(75, 23);
            this.updateNetwork.TabIndex = 3;
            this.updateNetwork.Text = "update";
            this.updateNetwork.UseVisualStyleBackColor = true;
            this.updateNetwork.Click += new System.EventHandler(this.updateNetwork_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updateNetwork);
            this.Controls.Add(this.neuronsCount);
            this.Controls.Add(this.addNeuron);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.neuronsCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button addNeuron;
        private System.Windows.Forms.NumericUpDown neuronsCount;
        private System.Windows.Forms.Button updateNetwork;
    }
}

