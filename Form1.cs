using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDO_Sim
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        public void Control(bool b)
        {
            foreach (var control in Controls.Cast<Control>().Where(control => !(control is RichTextBox)))
            {
                control.Enabled = b;
            }
        }

        private readonly List<double> _baseChance = new List<double>
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

        private readonly List<double> _failUpChance = new List<double>
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

        private readonly List<int> _maxFails = new List<int>
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

        private readonly List<int> _failatfail = new List<int>
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

        private void Enchant1000(int n)
        {
            var vFails = 0;
            var tochkana = Convert.ToInt32(kzarka.Text) + 1;
            var ebanniyRandom = new Random();
            var list = new List<int>();
            for (var i = 0; i < Convert.ToInt32(cnt.Text); i++)
            {
                if (fails.InvokeRequired)
                {
                    fails.Invoke(new Action(() => vFails = Convert.ToInt32(fails.Text)));
                }
                var end = 0;
                while (end == 0)
                {
                    var zatochil = ebanniyRandom.Next(1, 100);
                    double chance;
                    if (Convert.ToInt32(vFails) >= _maxFails[n])
                    {
                        chance = _baseChance[n] + (_maxFails[n]*_failUpChance[n]);
                    }
                    else
                    {
                        chance = _baseChance[n] + (Convert.ToDouble(vFails)*_failUpChance[n]);
                    }
                    if (zatochil <= chance)
                    {
                        list.Add(Convert.ToInt32(vFails));
                        end = 1;
                    }
                    else
                    {
                        vFails = vFails + _failatfail[n];
                    }
                }
                // Thread.Sleep(10);
            }
            if (hist.InvokeRequired)
            {
                hist.Invoke(new Action(() =>
                {
                    hist.AppendText(
                        $"Точка на {tochkana} завершилась. Начинали с {fails.Text} фейлов, в среднем заходило с: {Math.Round((double) list.Sum()/list.Count)}, минимум с: {list.Min()}, максимум с: {list.Max()}.\r\n");

                }));
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => Control(true)));
            }
            else Control(true);
        }

        private void Enchant(int n)
        {
                var ebanniyRandom = new Random();
                double chance;
                var tochkana = Convert.ToInt32(kzarka.Text);
                if (Convert.ToInt32(fails.Text) >= _maxFails[n])
                {
                    chance = _baseChance[n] + (_maxFails[n]*_failUpChance[n]);
                }
                else
                {
                    chance = _baseChance[n] + (Convert.ToDouble(fails.Text)*_failUpChance[n]);
                }
                var zatochil = ebanniyRandom.Next(1, 100);
                primerno.Text = $"~{chance.ToString(CultureInfo.InvariantCulture)}%";
            if (zatochil <= chance)
            {
                kzarka.Text = Convert.ToString(tochkana + 1);
                hist.AppendText($"Точка на {kzarka.Text} завершилась на {fails.Text} фейлах. Кубик сролил {zatochil}.\r\n");
                fails.Text = @"0";
                primerno.Text = @"~";
            }
            else
            {
                fails.Text = Convert.ToString(Convert.ToInt32(fails.Text) + _failatfail[n]);
            }
        }

        public void EnchantReal(int startFrom,int target,IReadOnlyList<int> eFails,int price15,int price20,int pricemem)
        {
            var success15 = new List<int>();
            var fail15 = new List<int>();
            var success20 = new List<int>();
            var fail20 = new List<int>();
            var f17 = 0;
            var f18 = 0;
            var f19 = 0;
            var f20 = 0;
            var enchant = startFrom;
            var fail = eFails[enchant];
            var ebanniyRandom = new Random();
            while (enchant!=target)
            {
                //Enchant
                double chance;
                if (enchant == 19 && f20 != 0) fail = f20;
                if (enchant == 18 && f19 != 0) fail = f19;
                if (enchant == 17 && f18 != 0) fail = f18;
                if (enchant == 16 && f17 != 0) fail = f17;
                if (fail >= _maxFails[enchant])
                {
                    chance = _baseChance[enchant] + (_maxFails[enchant] * _failUpChance[enchant]);
                }
                else
                {
                    chance = _baseChance[enchant] + (Convert.ToDouble(fail) * _failUpChance[enchant]);
                }
                var zatochil = ebanniyRandom.Next(1, 100);

                //
                if (zatochil <= chance)
                {
                    var failmsg = fail;
                    var enchantmsg = enchant+1;
                    if (enchant < 20)
                    {
                        if (enchant == 16 && f17 != 0)
                        {
                            f17 = 0;
                            enchant++;
                            fail = f18 != 0 ? f18 : eFails[enchant];
                            success20.Add(17);
                        }
                        else if (enchant == 17 && f18 != 0)
                        {
                            f18 = 0;
                            enchant++;
                            fail = f19 != 0 ? f19 : eFails[enchant];
                            success20.Add(18);
                        }
                        else if (enchant == 18 && f19 != 0)
                        {
                            f19 = 0;
                            enchant++;
                            fail = f20 != 0 ? f20 : eFails[enchant];
                            success20.Add(19);
                        }
                        else if (enchant == 19 && f20 != 0)
                        {
                            f20 = 0;
                            enchant++;
                            success20.Add(20);
                        }
                        else
                        {
                            if (enchant >= 15)
                            {
                                success20.Add(enchant+1);
                            }
                            if(enchant < 15)
                            {
                                success15.Add(enchant + 1);
                            }
                            enchant++;
                            if (enchant < 20) fail = eFails[enchant];                            
                        }
                    }
                    if (InvokeRequired)
                    {
                        var enchant1 = enchantmsg;
                        var fail1 = failmsg;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchant1} завершилась на {fail1} фейлах. Кубик сролил {zatochil}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
                    else hist.AppendText($"Точка на {enchantmsg} завершилась на {failmsg} фейлах. Кубик сролил {zatochil}.\r\n");
                }
                else
                {
                    if (InvokeRequired)
                    {
                        var enchant1 = enchant;
                        var fail1 = fail;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchant1+1} сфейлилась на {fail1} фейлах > {fail1 + _failatfail[enchant1]}. Кубик сролил {zatochil}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
                    else hist.AppendText($"Точка на {enchant - 1} сфейлилась на {fail} фейлах. Кубик сролил {zatochil}.\r\n");
                    if (enchant >= 16 && enchant < 20)
                    {
                        if (enchant == 16)
                        {
                            f17 = fail + _failatfail[enchant];
                            fail = eFails[enchant - 1];
                            fail20.Add(17);
                        }
                        if (enchant == 17)
                        {
                            f18 = fail + _failatfail[enchant];
                            fail = eFails[enchant - 1];
                            fail20.Add(18);
                        }
                        if (enchant == 18)
                        {
                            f19 = fail + _failatfail[enchant];
                            fail = eFails[enchant - 1];
                            fail20.Add(19);
                        }
                        if (enchant == 19)
                        {
                            f20 = fail + _failatfail[enchant];
                            fail = eFails[enchant - 1];
                            fail20.Add(20);
                        }
                        if (enchant > 16) enchant--;
                    }
                    else
                    {
                        fail = fail + _failatfail[enchant];
                        if (enchant<15) fail15.Add(enchant);
                        if (enchant==15) fail20.Add(16);
                    }
                }
                Thread.Sleep(10);
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => hist.AppendText("--------------------------------------------------\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков до 15: {success15.Count}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков до 15: {fail15.Count}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на 16: {success20.Count(i => i==16)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на 16: {fail20.Count(i => i == 16)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на 17: {success20.Count(i => i == 17)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на 17: {fail20.Count(i => i == 17)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на 18: {success20.Count(i => i == 18)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на 18: {fail20.Count(i => i == 18)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на 19: {success20.Count(i => i == 19)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на 19: {fail20.Count(i => i == 19)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на 20: {success20.Count(i => i == 20)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на 20: {fail20.Count(i => i == 20)}.\r\n")));
                Invoke(new Action(() => hist.AppendText("--------------------------------------------------\r\n")));
                //15
                long c = success15.Count*price15;
                long c2 = fail15.Count*price15;
                long c3 = fail15.Count*5;
                long c4 = c3*pricemem;
                long total15 = c + c2 + c4;
                //
                //20
                long m = success20.Count*price20;
                long m2 = fail20.Count*price20;
                long m3 = fail20.Count*10;
                long m4 = m3*pricemem;
                long total20 = m + m2 + m4;
                //                         
                if (startFrom<15) Invoke(new Action(() => hist.AppendText($"Суммарно потрачено денег до 15 точки: {total15.ToString("N0",CultureInfo.CreateSpecificCulture("ru-RU"))}.\r\n")));
                if (target>15) Invoke(new Action(() => hist.AppendText($"Суммарно потрачено денег от 15 точки: {total20.ToString("N0",CultureInfo.CreateSpecificCulture("ru-RU"))}.\r\n\r\n\r\n")));
                Invoke(new Action(() => Control(true)));
                Invoke(new Action(() => hist.ScrollToCaret()));
            }
            else Control(true);
        }

        private void tochka_Click(object sender, EventArgs e)
        {
            var en = Convert.ToInt32(kzarka.Text);
            if (en < 20) Enchant(en);
        }
        
        private async void enchant1000_Click(object sender, EventArgs e)
        {            
            var en = Convert.ToInt32(kzarka.Text);
            if (en < 20)
            {
                Control(false);
                await Task.Factory.StartNew(() => Enchant1000(en));
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new Frm2();
            frm.ShowDialog();
        }
    }
}
