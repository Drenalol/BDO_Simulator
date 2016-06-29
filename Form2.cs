using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            var start = Convert.ToInt16(sFrom.Text);
            var end = Convert.ToInt16(sEnd.Text);
            if (end <= 5 && jewels.Checked)
            {
                if (start == 0) { start = 15; }
                if (start == 1) { start = 16; }
                if (start == 2) { start = 17; }
                if (start == 3) { start = 18; }
                if (start == 4) { start = 19; }
                if (end == 1) { end = 16; }
                if (end == 2) { end = 17; }
                if (end == 3) { end = 18; }
                if (end == 4) { end = 19; }
                if (end == 5) { end = 20; }
                Enabled = false;
                var qwe = Application.OpenForms.OfType<MainFrm>().Single();
                var lst = new List<int>
                {
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    Convert.ToInt16(Na16.Text),
                    Convert.ToInt16(Na17.Text),
                    Convert.ToInt16(Na18.Text),
                    Convert.ToInt16(Na19.Text),
                    Convert.ToInt16(Na20.Text)
                };
                qwe.Control(false);
                await Task.Factory.StartNew(() => qwe.EnchantReal_Jewel(start, end, lst,Convert.ToInt32(priceMemories.Text)));
                Close();
            }
            if (!jewels.Checked)
            {
                Enabled = false;
                var qwe = Application.OpenForms.OfType<MainFrm>().Single();
                var lst = new List<int>
                {
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
                    0,
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
                    Convert.ToInt16(Na20.Text)
                };
                qwe.Control(false);
                await
                    Task.Factory.StartNew(
                        () =>
                            qwe.EnchantReal(Convert.ToInt16(sFrom.Text), Convert.ToInt16(sEnd.Text), lst,
                                Convert.ToInt32(priceEnormal.Text), Convert.ToInt32(priceE16.Text),
                                Convert.ToInt32(priceMemories.Text)));
                Close();
            }
        }

        private void Frm2_Load(object sender, EventArgs e)
        {
            if (File.Exists("BDO_sim.xml"))
            {
                var doc = XDocument.Load("BDO_sim.xml");
                if (doc.Root != null)
                {
                    Na8.Text = doc.Root.Element("n8")?.Attribute("value").Value;
                    Na9.Text = doc.Root.Element("n9")?.Attribute("value").Value;
                    Na10.Text = doc.Root.Element("n10")?.Attribute("value").Value;
                    Na11.Text = doc.Root.Element("n11")?.Attribute("value").Value;
                    Na12.Text = doc.Root.Element("n12")?.Attribute("value").Value;
                    Na13.Text = doc.Root.Element("n13")?.Attribute("value").Value;
                    Na14.Text = doc.Root.Element("n14")?.Attribute("value").Value;
                    Na15.Text = doc.Root.Element("n15")?.Attribute("value").Value;
                    Na16.Text = doc.Root.Element("n16")?.Attribute("value").Value;
                    Na17.Text = doc.Root.Element("n17")?.Attribute("value").Value;
                    Na18.Text = doc.Root.Element("n18")?.Attribute("value").Value;
                    Na19.Text = doc.Root.Element("n19")?.Attribute("value").Value;
                    Na20.Text = doc.Root.Element("n20")?.Attribute("value").Value;
                    priceEnormal.Text = doc.Root.Element("price15")?.Attribute("value").Value;
                    priceE16.Text = doc.Root.Element("price20")?.Attribute("value").Value;
                    priceMemories.Text = doc.Root.Element("pricememories")?.Attribute("value").Value;
                    sFrom.Text = doc.Root.Element("startfrom")?.Attribute("value").Value;
                    sEnd.Text = doc.Root.Element("target")?.Attribute("value").Value;
                }
            }
            foreach (var control in Controls.Cast<Control>().Where(control => control is TextBox))
            {
                control.TextChanged += (o, args) =>
                {
                    SaveXml();
                };
            }
        }

        private void SaveXml()
        {
            if (File.Exists("BDO_sim.xml"))
            {
                var doc = XDocument.Load("BDO_sim.xml");
                doc.Root?.Element("n8")?.SetAttributeValue("value",Na8.Text);
                doc.Root?.Element("n9")?.SetAttributeValue("value", Na9.Text);
                doc.Root?.Element("n10")?.SetAttributeValue("value", Na10.Text);
                doc.Root?.Element("n11")?.SetAttributeValue("value", Na11.Text);
                doc.Root?.Element("n12")?.SetAttributeValue("value", Na12.Text);
                doc.Root?.Element("n13")?.SetAttributeValue("value", Na13.Text);
                doc.Root?.Element("n14")?.SetAttributeValue("value", Na14.Text);
                doc.Root?.Element("n15")?.SetAttributeValue("value", Na15.Text);
                doc.Root?.Element("n16")?.SetAttributeValue("value", Na16.Text);
                doc.Root?.Element("n17")?.SetAttributeValue("value", Na17.Text);
                doc.Root?.Element("n18")?.SetAttributeValue("value", Na18.Text);
                doc.Root?.Element("n19")?.SetAttributeValue("value", Na19.Text);
                doc.Root?.Element("n20")?.SetAttributeValue("value", Na20.Text);
                doc.Root?.Element("price15")?.SetAttributeValue("value", priceEnormal.Text);
                doc.Root?.Element("price20")?.SetAttributeValue("value", priceE16.Text);
                doc.Root?.Element("pricememories")?.SetAttributeValue("value", priceMemories.Text);
                doc.Root?.Element("startfrom")?.SetAttributeValue("value", sFrom.Text);
                doc.Root?.Element("target")?.SetAttributeValue("value", sEnd.Text);
                doc.Save("BDO_sim.xml");
            }
        }

        private void jewels_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var control in Controls.Cast<Control>().Where(control => (string) control.Tag != "j"))
            {
                control.Visible = !jewels.Checked;
            }
        }
    }
}
