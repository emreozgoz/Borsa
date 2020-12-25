using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Borsa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            string kur = txtKur.Text;
            double n1,sonuc, n2;
            n1 = double.Parse(txtCevirme.Text);
            n2 = double.Parse(kur.Replace(".",","));
            sonuc = n1 *n2;
            txtSonuc.Text = sonuc.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlTextReader rdr = new XmlTextReader(" http://www.tcmb.gov.tr/kurlar/today.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(rdr);
            dataGridView1.DataSource = ds.Tables["Currency"];
            for (int i = 0; i < 20; i++)
            {
                comboBox1.Items.Add ( dataGridView1.Rows[i].Cells[10].Value.ToString());
            }
            int[] sayilar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,13,14 };
            for (int i = 5; i < 11; i++)
            {
                dataGridView1.Columns[sayilar[i-1]].Visible = false;
            }
            dataGridView1.Columns["CurrencyName"].Visible = false;
            dataGridView1.Columns["BanknoteBuying"].Visible = false;
            dataGridView1.Columns["CurrencyCode"].DisplayIndex = 3;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string colnum = dataGridView1.Columns[3].Name;
            for (int i = 0; i < 20; i++)
            {
                if (comboBox1.SelectedIndex == i)
                {
                    txtKur.Text = dataGridView1.Rows[i].Cells[colnum].Value.ToString();
                }
            }
            txtCevirme.Clear();
            txtSonuc.Clear();
        }

        private void txtCevirme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

      
    }
}
