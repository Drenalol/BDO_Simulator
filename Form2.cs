using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDO_Sim
{
    public partial class Frm2 : Form
    {
        public Frm2()
        {
            InitializeComponent();
        }

        private async void poehali_Click(object sender, EventArgs e)
        {
            Enabled = false;
            var qwe = Application.OpenForms.OfType<MainFrm>().Single();
            var lst = new List<int> {0, 0, 0, 0, 0, 0, 0,
                Convert.ToInt16(Na8.Text),
                Convert.ToInt16(Na9.Text),
                Convert.ToInt16(Na10.Text),
                Convert.ToInt16(Na11.Text),
                Convert.ToInt16(Na12.Text),
                Convert.ToInt16(Na13.Text),
                Convert.ToInt16(Na14.Text),
                Convert.ToInt16(Na15.Text),
                Convert.ToInt16(Na16.Text),
                Convert.ToInt16(Na17.Text),
                Convert.ToInt16(Na18.Text),
                Convert.ToInt16(Na19.Text),
                Convert.ToInt16(Na20.Text)};
            qwe.Control(false);
            await Task.Factory.StartNew(() => qwe.EnchantReal(Convert.ToInt16(sFrom.Text), Convert.ToInt16(sEnd.Text), lst, Convert.ToInt32(priceEnormal.Text), Convert.ToInt32(priceE16.Text), Convert.ToInt32(priceMemories.Text)));
            Close();
        }
    }
}
