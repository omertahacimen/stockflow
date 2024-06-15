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
    public partial class frmSatisListeleme : Form
    {
        public frmSatisListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data source=DESKTOP-97RV99T;Initial Catalog=Stok_Takip;Integrated Security = True");
        DataSet ds = new DataSet();
        

        private void frmSatisListeleme_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();
        }
        private void Kayıt_Göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from satislar", baglanti);
            adtr.Fill(ds, "satislar");
            dataGridView1.DataSource = ds.Tables["satislar"];
            baglanti.Close();

        }
    }
}
