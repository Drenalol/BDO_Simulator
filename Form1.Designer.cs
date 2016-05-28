namespace BDO_Sim
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
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
            this.real = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tochka
            // 
            this.tochka.Location = new System.Drawing.Point(17, 90);
            this.tochka.Name = "tochka";
            this.tochka.Size = new System.Drawing.Size(95, 23);
            this.tochka.TabIndex = 2;
            this.tochka.Text = "Усилить разок";
            this.tochka.UseVisualStyleBackColor = true;
            this.tochka.Click += new System.EventHandler(this.tochka_Click);
            // 
            // fails
            // 
            this.fails.Location = new System.Drawing.Point(98, 64);
            this.fails.Name = "fails";
            this.fails.Size = new System.Drawing.Size(75, 20);
            this.fails.TabIndex = 1;
            this.fails.Text = "0";
            this.fails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fails.TextChanged += new System.EventHandler(this.fails_TextChanged);
            // 
            // hist
            // 
            this.hist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hist.Location = new System.Drawing.Point(0, 119);
            this.hist.Name = "hist";
            this.hist.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.hist.Size = new System.Drawing.Size(609, 487);
            this.hist.TabIndex = 5;
            this.hist.Text = "";
            // 
            // kzarka
            // 
            this.kzarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.kzarka.Location = new System.Drawing.Point(98, 5);
            this.kzarka.Name = "kzarka";
            this.kzarka.Size = new System.Drawing.Size(75, 53);
            this.kzarka.TabIndex = 0;
            this.kzarka.Text = "0";
            this.kzarka.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.kzarka.TextChanged += new System.EventHandler(this.kzarka_TextChanged);
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
            this.enchant1000.TabIndex = 4;
            this.enchant1000.Text = "Усилить";
            this.enchant1000.UseVisualStyleBackColor = true;
            this.enchant1000.Click += new System.EventHandler(this.enchant1000_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Source data (Korea)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ур. усиления";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Фейлов";
            // 
            // cnt
            // 
            this.cnt.Location = new System.Drawing.Point(199, 92);
            this.cnt.Name = "cnt";
            this.cnt.Size = new System.Drawing.Size(58, 20);
            this.cnt.TabIndex = 3;
            this.cnt.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "раз.";
            // 
            // real
            // 
            this.real.Location = new System.Drawing.Point(414, 89);
            this.real.Name = "real";
            this.real.Size = new System.Drawing.Size(183, 23);
            this.real.TabIndex = 17;
            this.real.Text = "Почти реальная точка";
            this.real.UseVisualStyleBackColor = true;
            this.real.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 606);
            this.Controls.Add(this.real);
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
            this.MaximumSize = new System.Drawing.Size(625, 645);
            this.MinimumSize = new System.Drawing.Size(625, 645);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BDO Enchant Simulator 1.2 by Drenalol";
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
        private System.Windows.Forms.Button real;
    }
}

