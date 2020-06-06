namespace WindowsFormsApp6
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
            this.V = new System.Windows.Forms.RichTextBox();
            this.R = new System.Windows.Forms.RichTextBox();
            this.VR = new System.Windows.Forms.RichTextBox();
            this.L = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.hamilbutton = new System.Windows.Forms.Button();
            this.ostbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // V
            // 
            this.V.Location = new System.Drawing.Point(52, 193);
            this.V.Name = "V";
            this.V.Size = new System.Drawing.Size(141, 146);
            this.V.TabIndex = 0;
            this.V.Text = "";
            // 
            // R
            // 
            this.R.Location = new System.Drawing.Point(199, 193);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(137, 146);
            this.R.TabIndex = 1;
            this.R.Text = "";
            // 
            // VR
            // 
            this.VR.Location = new System.Drawing.Point(342, 193);
            this.VR.Name = "VR";
            this.VR.Size = new System.Drawing.Size(142, 146);
            this.VR.TabIndex = 2;
            this.VR.Text = "";
            // 
            // L
            // 
            this.L.Location = new System.Drawing.Point(490, 193);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(143, 146);
            this.L.TabIndex = 3;
            this.L.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "см верш";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "см ребер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "верш и реб";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "список смежности";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 373);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DFS",
            "BFS"});
            this.comboBox1.Location = new System.Drawing.Point(262, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(73, 373);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // hamilbutton
            // 
            this.hamilbutton.Location = new System.Drawing.Point(304, 100);
            this.hamilbutton.Name = "hamilbutton";
            this.hamilbutton.Size = new System.Drawing.Size(75, 23);
            this.hamilbutton.TabIndex = 12;
            this.hamilbutton.Text = "гамильтон";
            this.hamilbutton.UseVisualStyleBackColor = true;
            this.hamilbutton.Click += new System.EventHandler(this.hamilbutton_Click_1);
            // 
            // ostbutton
            // 
            this.ostbutton.Location = new System.Drawing.Point(304, 71);
            this.ostbutton.Name = "ostbutton";
            this.ostbutton.Size = new System.Drawing.Size(75, 23);
            this.ostbutton.TabIndex = 13;
            this.ostbutton.Text = "остов";
            this.ostbutton.UseVisualStyleBackColor = true;
            this.ostbutton.Click += new System.EventHandler(this.ostbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ostbutton);
            this.Controls.Add(this.hamilbutton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L);
            this.Controls.Add(this.VR);
            this.Controls.Add(this.R);
            this.Controls.Add(this.V);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox V;
        private System.Windows.Forms.RichTextBox R;
        private System.Windows.Forms.RichTextBox VR;
        private System.Windows.Forms.RichTextBox L;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button hamilbutton;
        private System.Windows.Forms.Button ostbutton;
    }
}

