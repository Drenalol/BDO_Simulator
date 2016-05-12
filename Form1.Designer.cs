namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tochka = new System.Windows.Forms.Button();
            this.fails = new System.Windows.Forms.TextBox();
            this.hist = new System.Windows.Forms.RichTextBox();
            this.kzarka = new System.Windows.Forms.TextBox();
            this.primerno = new System.Windows.Forms.Label();
            this.enchant1000 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tochka
            // 
            this.tochka.Location = new System.Drawing.Point(17, 90);
            this.tochka.Name = "tochka";
            this.tochka.Size = new System.Drawing.Size(95, 23);
            this.tochka.TabIndex = 0;
            this.tochka.Text = "Enchant once";
            this.tochka.UseVisualStyleBackColor = true;
            this.tochka.Click += new System.EventHandler(this.tochka_Click);
            // 
            // fails
            // 
            this.fails.Location = new System.Drawing.Point(98, 64);
            this.fails.Name = "fails";
            this.fails.Size = new System.Drawing.Size(75, 20);
            this.fails.TabIndex = 2;
            this.fails.Text = "0";
            this.fails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hist
            // 
            this.hist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hist.Location = new System.Drawing.Point(0, 119);
            this.hist.Name = "hist";
            this.hist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.hist.Size = new System.Drawing.Size(510, 487);
            this.hist.TabIndex = 5;
            this.hist.Text = "";
            // 
            // kzarka
            // 
            this.kzarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kzarka.Location = new System.Drawing.Point(98, 5);
            this.kzarka.Name = "kzarka";
            this.kzarka.Size = new System.Drawing.Size(75, 53);
            this.kzarka.TabIndex = 7;
            this.kzarka.Text = "0";
            this.kzarka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // primerno
            // 
            this.primerno.AutoSize = true;
            this.primerno.Location = new System.Drawing.Point(179, 67);
            this.primerno.Name = "primerno";
            this.primerno.Size = new System.Drawing.Size(14, 13);
            this.primerno.TabIndex = 8;
            this.primerno.Text = "~";
            // 
            // enchant1000
            // 
            this.enchant1000.Location = new System.Drawing.Point(118, 90);
            this.enchant1000.Name = "enchant1000";
            this.enchant1000.Size = new System.Drawing.Size(75, 23);
            this.enchant1000.TabIndex = 9;
            this.enchant1000.Text = "Enchant";
            this.enchant1000.UseVisualStyleBackColor = true;
            this.enchant1000.Click += new System.EventHandler(this.enchant1000_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "CLS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(315, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Source data (Korea, OLD maybe)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lvl. enchant";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Fails";
            // 
            // cnt
            // 
            this.cnt.Location = new System.Drawing.Point(199, 92);
            this.cnt.Name = "cnt";
            this.cnt.Size = new System.Drawing.Size(58, 20);
            this.cnt.TabIndex = 15;
            this.cnt.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "times.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 606);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enchant1000);
            this.Controls.Add(this.primerno);
            this.Controls.Add(this.kzarka);
            this.Controls.Add(this.hist);
            this.Controls.Add(this.fails);
            this.Controls.Add(this.tochka);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(526, 645);
            this.MinimumSize = new System.Drawing.Size(526, 645);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDO Enchant Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tochka;
        private System.Windows.Forms.TextBox fails;
        private System.Windows.Forms.RichTextBox hist;
        private System.Windows.Forms.TextBox kzarka;
        private System.Windows.Forms.Label primerno;
        private System.Windows.Forms.Button enchant1000;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cnt;
        private System.Windows.Forms.Label label3;
    }
}

