using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 

        Model1 ent = new Model1();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ent.Urun.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            Urun tblu = new Urun();
            tblu.alis_fiyat = Convert.ToDouble(Txtbox1.Text);
            tblu.satis_fiyat = Convert.ToDouble(Txtbox2.Text);
            tblu.tur = Txtbox3.Text;
            double x = ((tblu.satis_fiyat - tblu.alis_fiyat) / tblu.satis_fiyat) * 100;
            tblu.kar_marji = x;
            ent.Urun.Add(tblu);
            ent.SaveChanges();
            Txtbox1.Clear();
            Txtbox2.Clear();
            Txtbox3.Clear();
            MessageBox.Show("Urun Eklendi");
            dataGridView1.DataSource = ent.Urun.ToList();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Txtbox1.Text);
            Urun tblu = ent.Urun.First(f => f.id == id);
            ent.Urun.Remove(tblu);
            ent.SaveChanges();
            MessageBox.Show("Urun Silindi");
            dataGridView1.DataSource = ent.Urun.ToList();

        }

        private void Txtbox_satisfiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Txtbox1.Text);
            Urun tblu = ent.Urun.First(f => f.id == id);
            tblu.satis_fiyat = Convert.ToDouble(Txtbox2.Text);
            tblu.tur = Txtbox3.Text;
            ent.SaveChanges();
            MessageBox.Show("Urun Güncellendi");
            dataGridView1.DataSource = ent.Urun.ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
