using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Enchant(int n, bool ths)
        {
            var baseChance = new List<double>
            {
                100, //1
                100, //2
                100, //3
                100, //4
                100, //5
                100, //6
                100, //7
                20, //8
                17.5, //9
                15, //10
                12.5, //11
                10, //12
                7.5, //13
                5, //14
                2.5, //15
                15, //16
                7.5, //17
                5, //18
                2, //19
                1.5 //20
            };
            var failUpChance = new List<double>
            {
                0, //1
                0, //2
                0, //3
                0, //4
                0, //5
                0, //6
                0, //7
                2.5, //8
                2, //9
                1.5, //10
                1.25, //11
                0.75, //12
                0.63, //13
                0.5, //14
                0.5, //15
                1.5, //16
                0.75, //17
                0.5, //18
                0.25, //19
                0.15 //20
            };
            var maxFails = new List<int>
            {
                0, //1
                0, //2
                0, //3
                0, //4
                0, //5
                0, //6
                0, //7
                13, //8
                14, //9
                15, //10
                16, //11
                18, //12
                20, //13
                25, //14
                25, //15
                25, //16
                35, //17
                44, //18
                90, //19
                124 //20
            };
            var failatfail = new List<int>
            {
                1, //1
                1, //2
                1, //3
                1, //4
                1, //5
                1, //6
                1, //7
                1, //8
                1, //9
                1, //10
                1, //11
                1, //12
                1, //13
                1, //14
                1, //15
                2, //16
                3, //17
                4, //18
                5, //19
                6 //20
            };
            if (ths)
            {
                fails.Tag = fails.Text;
                var skolko = 0;
                var tochkana = Convert.ToInt32(kzarka.Text);
                var ebanniyRandom = new Random();
                var list = new List<int>();
                for (var i = 0; i < Convert.ToInt32(cnt.Text); i++)
                {
                    var end = 0;
                    fails.Text = (string) fails.Tag;
                    while (end == 0)
                    {
                        var zatochil = ebanniyRandom.Next(0, 100);
                        double chance;
                        if (Convert.ToInt32(fails.Text) >= maxFails[n])
                        {
                            chance = baseChance[n] + (maxFails[n] * failUpChance[n]);
                        }
                        else
                        {
                            chance = baseChance[n] + (Convert.ToDouble(fails.Text) * failUpChance[n]);
                        }
                        if (zatochil <= chance)
                        {
                            list.Add(Convert.ToInt32(fails.Text));
                            skolko++;
                            end = 1;
                        }
                        else
                        {
                            fails.Text = Convert.ToString(Convert.ToInt32(fails.Text) + failatfail[n]);
                        }
                    }
                    Thread.Sleep(10);
                }
                fails.Text = (string)fails.Tag;
                hist.AppendText($"Enchant {tochkana + 1} done. Starts from {fails.Tag}, AVG: {Math.Round((double)list.Sum() / list.Count)}, MIN: {list.Min()}, MAX: {list.Max()}.\r\n");
                enchant1000.Enabled = true;                
            }
            else
            {
                var ebanniyRandom = new Random();
                double chance;
                var tochkana = Convert.ToInt32(kzarka.Text);
                if (Convert.ToInt32(fails.Text) >= maxFails[n])
                {
                    chance = baseChance[n] + (maxFails[n]*failUpChance[n]);
                }
                else
                {
                    chance = baseChance[n] + (Convert.ToDouble(fails.Text)*failUpChance[n]);
                }
                var zatochil = ebanniyRandom.Next(0, 100);
                primerno.Text = $"~{chance.ToString(CultureInfo.InvariantCulture)}%";
                if (zatochil <= chance)
                {
                    kzarka.Text = Convert.ToString(tochkana + 1);
                    hist.AppendText($"Enchant {kzarka.Text} done at {fails.Text} fails.\r\n");
                    fails.Text = @"0";
                    primerno.Text = @"~";
                }
                else
                {
                    fails.Text = Convert.ToString(Convert.ToInt32(fails.Text) + failatfail[n]);
                }
            }
        }

        private void tochka_Click(object sender, EventArgs e)
        {
            var tochkana = Convert.ToInt32(kzarka.Text);
            if (tochkana < 20) Enchant(tochkana,false);
        }

        private void enchant1000_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;            
            var tochkana = Convert.ToInt32(kzarka.Text);
            if (tochkana < 20) Enchant(tochkana, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hist.Clear();
            kzarka.Text = @"0";
            fails.Text = @"0";
            primerno.Text = @"~";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(
                "http://www.inven.co.kr/board/powerbbs.php?come_idx=3584&name=subject&keyword=%B0%AD%C8%AD&l=19419");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
