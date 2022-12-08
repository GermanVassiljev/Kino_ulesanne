using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_ulesanne
{
    public partial class Sissepaas : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader lugeja;
        public Sissepaas()
        {
            InitializeComponent();
        }       
        private void regY_btn_Click(object sender, EventArgs e)
        {
            string x;
            cmd = new SqlCommand("SELECT * FROM Kasutajad", connect);
            connect.Open();
            lugeja = cmd.ExecuteReader();
            while (lugeja.Read())
            {
                if (nimi_txt.Text == lugeja["kasutajaNimi"].ToString() && parool.Text == lugeja["parool"].ToString())
                {
                    MessageBox.Show("Tere tulemast!");                   
                    Teater pohi = new Teater();
                    x = (lugeja["kasutajaNimi"].ToString());
                    kasutaja_nimi.nimi = x;
                        
                    this.Visible = false;
                    pohi.Visible = true;
                }
            }
            connect.Close();
        }
    }
}
