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

namespace stoktakip
{
    public partial class frmUrunEkle : Form
    {
        public frmUrunEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data source=DESKTOP-97RV99T;Initial Catalog=Stok_Takip;Integrated Security = True");

        private void frmUrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into urunler(barkodno,urunad,miktar,satisfiyat,toplamfiyat) values(@barkodno,@urunad,@miktar,@satisfiyat,@toplamfiyat)", baglanti);
            komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
            komut.Parameters.AddWithValue("@urunad", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@miktar", txtMiktar.Text);
            komut.Parameters.AddWithValue("@satisfiyat", txtSatisFiyat.Text);
            komut.Parameters.AddWithValue("@toplamfiyat", txtToplamFiyat.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Başarıyla Eklendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }

            }
        }
    }
}
