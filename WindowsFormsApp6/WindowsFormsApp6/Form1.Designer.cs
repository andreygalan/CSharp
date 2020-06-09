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
            this.L = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.hamilbutton = new System.Windows.Forms.Button();
            this.ostbutton = new System.Windows.Forms.Button();
            this.chrombutton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // V
            // 
            this.V.Location = new System.Drawing.Point(12, 109);
            this.V.Name = "V";
            this.V.Size = new System.Drawing.Size(339, 230);
            this.V.TabIndex = 0;
            this.V.Text = "";
            // 
            // L
            // 
            this.L.Location = new System.Drawing.Point(438, 109);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(350, 230);
            this.L.TabIndex = 3;
            this.L.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 345);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "открыть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // hamilbutton
            // 
            this.hamilbutton.Location = new System.Drawing.Point(138, 66);
            this.hamilbutton.Name = "hamilbutton";
            this.hamilbutton.Size = new System.Drawing.Size(239, 23);
            this.hamilbutton.TabIndex = 12;
            this.hamilbutton.Text = "Гамильтонов путь";
            this.hamilbutton.UseVisualStyleBackColor = true;
            this.hamilbutton.Click += new System.EventHandler(this.hamilbutton_Click_1);
            // 
            // ostbutton
            // 
            this.ostbutton.Location = new System.Drawing.Point(138, 37);
            this.ostbutton.Name = "ostbutton";
            this.ostbutton.Size = new System.Drawing.Size(239, 23);
            this.ostbutton.TabIndex = 13;
            this.ostbutton.Text = "количество остовных деревьев";
            this.ostbutton.UseVisualStyleBackColor = true;
            this.ostbutton.Click += new System.EventHandler(this.ostbutton_Click);
            // 
            // chrombutton
            // 
            this.chrombutton.Location = new System.Drawing.Point(383, 37);
            this.chrombutton.Name = "chrombutton";
            this.chrombutton.Size = new System.Drawing.Size(254, 23);
            this.chrombutton.TabIndex = 14;
            this.chrombutton.Text = "хроматическое число";
            this.chrombutton.UseVisualStyleBackColor = true;
            this.chrombutton.Click += new System.EventHandler(this.chrombutton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(383, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(254, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "максимальный поток";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(253, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "наименьшее реберное покрытие";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chrombutton);
            this.Controls.Add(this.ostbutton);
            this.Controls.Add(this.hamilbutton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.L);
            this.Controls.Add(this.V);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox V;
        private System.Windows.Forms.RichTextBox L;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button hamilbutton;
        private System.Windows.Forms.Button ostbutton;
        private System.Windows.Forms.Button chrombutton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}

