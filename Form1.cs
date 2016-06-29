using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
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

        private const double Version = 1.4;

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
                12.5,//15, //10
                10,//12.5, //11
                7.5,//10, //12
                5,//7.5, //13
                2.5,//5, //14
                1.25,//2.5, //15
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
                1.25,//1.5, //10
                1,//1.25, //11
                0.6,//0.75, //12
                0.5,//0.63, //13
                0.35,//0.5, //14
                0.25,//0.5, //15
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
            var enchantcurr = n;
            var tochkana = string.Empty;
            switch (enchantcurr + 1)
            {
                case 16:
                    {
                        tochkana = @"I";
                    }
                    break;
                case 17:
                    {
                        tochkana = @"II";
                    }
                    break;
                case 18:
                    {
                        tochkana = @"III";
                    }
                    break;
                case 19:
                    {
                        tochkana = @"IV";
                    }
                    break;
                case 20:
                    {
                        tochkana = @"V";
                    }
                    break;
                default:
                    {
                        tochkana = Convert.ToString(enchantcurr+1);
                    }
                    break;
            }
            var ebanniyRandom = new Random();
            var list = new List<int>();
            for (var i = 0; i < Convert.ToInt32(cnt.Text); i++)
            {
                if (fails.InvokeRequired)
                {
                    fails.Invoke(new Action(() => vFails = Convert.ToInt32(fails.Text)));
                }
                var end = false;
                while (end == false)
                {
                    var zatochil = ebanniyRandom.NextDouble();
                    double chance;
                    if (Convert.ToInt32(vFails) >= _maxFails[n])
                    {
                        chance = _baseChance[n] + (_maxFails[n]*_failUpChance[n]);
                    }
                    else
                    {
                        chance = _baseChance[n] + (Convert.ToDouble(vFails)*_failUpChance[n]);
                    }
                    if (zatochil <= chance/100)
                    {
                        list.Add(Convert.ToInt32(vFails));
                        end = true;
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
                //var tochkana = Convert.ToInt32(kzarka.Text);
                var tochkana = n;
                if (Convert.ToInt32(fails.Text) >= _maxFails[n])
                {
                    chance = _baseChance[n] + (_maxFails[n]*_failUpChance[n]);
                }
                else
                {
                    chance = _baseChance[n] + (Convert.ToDouble(fails.Text)*_failUpChance[n]);
                }
                var zatochil = ebanniyRandom.NextDouble();
                primerno.Text = $"~{chance.ToString(CultureInfo.InvariantCulture)}%";
            if (zatochil <= chance/100)
            {
                kzarka.Text = Convert.ToString(tochkana + 1);
                hist.AppendText($"Точка на {kzarka.Text} завершилась на {fails.Text} фейлах. Кубик сролил {Math.Round(zatochil*100,2)}.\r\n");
                fails.Text = @"0";
                primerno.Text = @"~";
            }
            else
            {
                fails.Text = Convert.ToString(Convert.ToInt32(fails.Text) + _failatfail[n]);
            }
        }

        public void EnchantReal(int startFrom,int target,IReadOnlyList<int> eFails,long price15, long price20, long pricemem)
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
                var zatochil = ebanniyRandom.NextDouble();

                //
                if (zatochil <= chance/100)
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
                        var enchant1 = string.Empty;
                        switch (enchantmsg)
                        {
                            case 16:
                                {
                                    enchant1 = @"I";
                                }
                                break;
                            case 17:
                                {
                                    enchant1 = @"II";
                                }
                                break;
                            case 18:
                                {
                                    enchant1 = @"III";
                                }
                                break;
                            case 19:
                                {
                                    enchant1 = @"IV";
                                }
                                break;
                            case 20:
                                {
                                    enchant1 = @"V";
                                }
                                break;
                            default:
                            {
                                enchant1 = Convert.ToString(enchantmsg);
                            }
                                break;
                        }
                        var fail1 = failmsg;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchant1} завершилась на {fail1} фейлах. Кубик сролил {Math.Round(zatochil * 100, 2)}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        var enchantcurr = enchant;
                        var enchantmsg = string.Empty;
                        switch (enchantcurr + 1)
                        {
                            case 16:
                                {
                                    enchantmsg = @"I";
                                }
                                break;
                            case 17:
                                {
                                    enchantmsg = @"II";
                                }
                                break;
                            case 18:
                                {
                                    enchantmsg = @"III";
                                }
                                break;
                            case 19:
                                {
                                    enchantmsg = @"IV";
                                }
                                break;
                            case 20:
                                {
                                    enchantmsg = @"V";
                                }
                                break;
                            default:
                                {
                                    enchantmsg = Convert.ToString(enchantcurr);
                                }
                                break;
                        }
                        var fail1 = fail;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchantmsg} сфейлилась на {fail1} фейлах > {fail1 + _failatfail[enchantcurr]}. Кубик сролил {Math.Round(zatochil * 100, 2)}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
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
                //Thread.Sleep(10);
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

        public void EnchantReal_Jewel(int startFrom, int target, IReadOnlyList<int> eFails, long price)
        {
            var success20Sum = new List<int>();
            var success20Cnt = new List<int>();
            var fail20Sum = new List<int>();
            var fail20Cnt = new List<int>();
            var f16 = 0;
            var f17 = 0;
            var f18 = 0;
            var f19 = 0;
            var f20 = 0;
            var enchant = startFrom;
            var fail = eFails[enchant];
            var ebanniyRandom = new Random();
            while (enchant != target)
            {
                //Enchant
                double chance;
                if (enchant == 19 && f20 != 0) fail = f20;
                if (enchant == 18 && f19 != 0) fail = f19;
                if (enchant == 17 && f18 != 0) fail = f18;
                if (enchant == 16 && f17 != 0) fail = f17;
                if (enchant == 15 && f16 != 0) fail = f16;
                if (fail >= _maxFails[enchant])
                {
                    chance = _baseChance[enchant] + (_maxFails[enchant] * _failUpChance[enchant]);
                }
                else
                {
                    chance = _baseChance[enchant] + (Convert.ToDouble(fail) * _failUpChance[enchant]);
                }
                var zatochil = ebanniyRandom.NextDouble();

                //
                if (zatochil <= chance / 100)
                {
                    var failmsg = fail;
                    var enchantmsg = enchant + 1;
                    if (enchant < 20)
                    {
                        if (enchant == 15 && f16 != 0)
                        {
                            f16 = 0;
                            enchant++;
                            fail = f17 != 0 ? f17 : eFails[enchant];
                            success20Sum.Add(2);
                            success20Cnt.Add(16);
                        }
                        else if (enchant == 16 && f17 != 0)
                        {
                            f17 = 0;
                            enchant++;
                            fail = f18 != 0 ? f18 : eFails[enchant];
                            success20Sum.Add(1);
                            success20Cnt.Add(17);
                        }
                        else if (enchant == 17 && f18 != 0)
                        {
                            f18 = 0;
                            enchant++;
                            fail = f19 != 0 ? f19 : eFails[enchant];
                            success20Sum.Add(1);
                            success20Cnt.Add(18);
                        }
                        else if (enchant == 18 && f19 != 0)
                        {
                            f19 = 0;
                            enchant++;
                            fail = f20 != 0 ? f20 : eFails[enchant];
                            success20Sum.Add(1);
                            success20Cnt.Add(19);
                        }
                        else if (enchant == 19 && f20 != 0)
                        {
                            f20 = 0;
                            enchant++;
                            success20Sum.Add(1);
                            success20Cnt.Add(20);
                        }
                        else
                        {
                            if (enchant >= 15)
                            {
                                success20Sum.Add(2);
                                success20Cnt.Add(enchantmsg);
                            }
                            enchant++;
                            if (enchant < 20) fail = eFails[enchant];
                        }
                    }
                    if (InvokeRequired)
                    {
                        var enchant1 = string.Empty;
                        switch (enchantmsg)
                        {
                            case 16:
                                {
                                    enchant1 = @"I";
                                }
                                break;
                            case 17:
                                {
                                    enchant1 = @"II";
                                }
                                break;
                            case 18:
                                {
                                    enchant1 = @"III";
                                }
                                break;
                            case 19:
                                {
                                    enchant1 = @"IV";
                                }
                                break;
                            case 20:
                                {
                                    enchant1 = @"V";
                                }
                                break;
                        }
                        var fail1 = failmsg;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchant1} завершилась на {fail1} фейлах. Кубик сролил {Math.Round(zatochil * 100, 2)}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        var enchantcurr = enchant;
                        var enchantmsg = string.Empty;
                        switch (enchantcurr + 1)
                        {
                            case 16:
                                {
                                    enchantmsg = @"I";
                                }
                                break;
                            case 17:
                                {
                                    enchantmsg = @"II";
                                }
                                break;
                            case 18:
                                {
                                    enchantmsg = @"III";
                                }
                                break;
                            case 19:
                                {
                                    enchantmsg = @"IV";
                                }
                                break;
                            case 20:
                                {
                                    enchantmsg = @"V";
                                }
                                break;
                        }
                        var fail1 = fail;
                        Invoke(new Action(() => hist.AppendText($"Точка на {enchantmsg} сфейлилась на {fail1} фейлах > {fail1 + 1}. Кубик сролил {Math.Round(zatochil * 100, 2)}.\r\n")));
                        Invoke(new Action(() => hist.ScrollToCaret()));
                    }
                    if (enchant >= 15 && enchant < 20)
                    {
                        if (enchant == 15)
                        {
                            f16 = fail + 1;
                            fail20Sum.Add(2);
                            fail20Cnt.Add(16);
                        }
                        if (enchant == 16)
                        {
                            f17 = fail + 1;
                            fail = eFails[enchant - 1];
                            fail20Sum.Add(1);
                            fail20Cnt.Add(17);
                        }
                        if (enchant == 17)
                        {
                            f18 = fail + 1;
                            fail = eFails[enchant - 2];
                            fail20Sum.Add(1);
                            fail20Cnt.Add(18);
                        }
                        if (enchant == 18)
                        {
                            f19 = fail + 1;
                            fail = eFails[enchant - 3];
                            fail20Sum.Add(1);
                            fail20Cnt.Add(19);
                        }
                        if (enchant == 19)
                        {
                            f20 = fail + 1;
                            fail = eFails[enchant - 4];
                            fail20Sum.Add(1);
                            fail20Cnt.Add(20);
                        }
                        enchant = 15;
                    }
                }
                //Thread.Sleep(10);
            }
            if (InvokeRequired)
            {
                Invoke(new Action(() => hist.AppendText("--------------------------------------------------\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на I: {success20Cnt.Count(i => i == 16)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на I: {fail20Cnt.Count(i => i == 16)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на II: {success20Cnt.Count(i => i == 17)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на II: {fail20Cnt.Count(i => i == 17)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на III: {success20Cnt.Count(i => i == 18)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на III: {fail20Cnt.Count(i => i == 18)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на IV: {success20Cnt.Count(i => i == 19)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на IV: {fail20Cnt.Count(i => i == 19)}.\r\n\r\n")));
                Invoke(new Action(() => hist.AppendText($"Успешных тыков на V: {success20Cnt.Count(i => i == 20)}.\r\n")));
                Invoke(new Action(() => hist.AppendText($"Неуспешных тыков на V: {fail20Cnt.Count(i => i == 20)}.\r\n")));
                Invoke(new Action(() => hist.AppendText("--------------------------------------------------\r\n")));
                //20
                long m1 = success20Sum.Sum() * price;
                long m2 = fail20Sum.Sum() * price;
                var total20 = m1 + m2;
                //                         
                Invoke(new Action(() => hist.AppendText($"Суммарно потрачено денег: {total20.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU"))}.\r\n\r\n\r\n")));
                Invoke(new Action(() => Control(true)));
                Invoke(new Action(() => hist.ScrollToCaret()));
            }
            else Control(true);
        }

        private void tochka_Click(object sender, EventArgs e)
        {
            var n = 0;
            if (kzarka.Text.Contains("I") || kzarka.Text.Contains("V"))
            {
                if (kzarka.Text == @"I") { n = 16; }
                if (kzarka.Text == @"II") { n = 17; }
                if (kzarka.Text == @"III") { n = 18; }
                if (kzarka.Text == @"IV") { n = 19; }
                if (kzarka.Text == @"V") { n = 20; }
            }
            else n = Convert.ToInt16(kzarka.Text);
            if (n < 20) Enchant(n);
        }
        
        private async void enchant1000_Click(object sender, EventArgs e)
        {
            var n = 0;
            if (kzarka.Text.Contains("I") || kzarka.Text.Contains("V"))
            {
                if (kzarka.Text == @"I") { n = 16; }
                if (kzarka.Text == @"II") { n = 17; }
                if (kzarka.Text == @"III") { n = 18; }
                if (kzarka.Text == @"IV") { n = 19; }
                if (kzarka.Text == @"V") { n = 20; }
            }
            else n = Convert.ToInt16(kzarka.Text);
            if (n < 20)
            {
                Control(false);
                await Task.Factory.StartNew(() => Enchant1000(n));
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

        private void fails_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double chance;
                var n = 0;
                if (kzarka.Text.Contains("I") || kzarka.Text.Contains("V"))
                {
                    if (kzarka.Text == @"I") {n = 16;}
                    if (kzarka.Text == @"II") { n = 17; }
                    if (kzarka.Text == @"III") { n = 18; }
                    if (kzarka.Text == @"IV") { n = 19; }
                    if (kzarka.Text == @"V") { n = 20; }
                }
                else n = Convert.ToInt16(kzarka.Text);
                if (Convert.ToInt32(fails.Text) >= _maxFails[n])
                {
                    chance = _baseChance[n] + (_maxFails[n] * _failUpChance[n]);
                }
                else
                {
                    chance = _baseChance[n] + (Convert.ToDouble(fails.Text) * _failUpChance[n]);
                }
                primerno.Text = $"~{chance.ToString(CultureInfo.InvariantCulture)}%";
            }
            catch
            {
                //                
            }
        }

        private void kzarka_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var n = Convert.ToInt16(kzarka.Text);
                switch (n)
                {
                    case 16:
                    {
                        kzarka.Text = @"I";
                    }
                        break;
                    case 17:
                    {
                        kzarka.Text = @"II";
                    }
                        break;
                    case 18:
                    {
                        kzarka.Text = @"III";
                    }
                        break;
                    case 19:
                    {
                        kzarka.Text = @"IV";
                    }
                        break;
                    case 20:
                    {
                        kzarka.Text = @"V";
                    }
                        break;
                }
                double chance;                
                if (Convert.ToInt32(fails.Text) >= _maxFails[n])
                {
                    chance = _baseChance[n] + (_maxFails[n]*_failUpChance[n]);
                }
                else
                {
                    chance = _baseChance[n] + (Convert.ToDouble(fails.Text)*_failUpChance[n]);
                }
                primerno.Text = $"~{chance.ToString(CultureInfo.InvariantCulture)}%";
            }
            catch
            {
                //                
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Text = @"BDO Enchant Simulator by Drenalol";
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.DownloadString("http://pastebin.com/raw/Frpr0ted");
                    var checkVersion = Convert.ToDouble(response, CultureInfo.GetCultureInfo("en-US"));
                    if (Version < checkVersion)
                    {
                        if (MessageBox.Show(
                            @"Появилась новая версия! Скачать?", @"Новая версия", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Asterisk
                            ) == DialogResult.Yes)
                        {
                            Process.Start("https://git.io/vrHja");
                        }
                    }
                }
            }
            catch
            {
                //
            }
        }
    }
}
