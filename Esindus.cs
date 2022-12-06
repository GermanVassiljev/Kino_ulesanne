using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_ulesanne
{
    public partial class Esindus : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        public Esindus()
        {
            InitializeComponent();
        }
        int id_number = 0;
        public void lugemine_tabel(object sender, EventArgs e)
        {
            using (SqlDataReader luge = cmd.ExecuteReader())
            {
                while (luge.Read())
                {
                    id_number++;
                }
            }
                
        }

        private void seans_btn_Click(object sender, EventArgs e)
        {
            Seans seans = new Seans();
            this.Visible = false;
            seans.Visible = true;
        }

        private void paremale_Click(object sender, EventArgs e)
        {
            id_number-=1;
            cmd=new SqlCommand("SELECT * FROM Esindus WHERE esindusId=@id_number", connect);
            connect.Open();           
            cmd.Parameters.AddWithValue("@id_number", id_number);
            try { 
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        string x = (lug["pilt"].ToString());
                        Esindus_pbox.Image = System.Drawing.Image.FromFile(@"..\..\Piltid\" + x);
                        Esindus_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x = (lug["nimetus"].ToString());
                        nimi_lbl.Text = "Nimi: "+x;
                    }

                }
            }
            finally
            {
               connect.Close(); 
            }
            
        }

        private void Esindus_Load(object sender, EventArgs e)
        {
            cmd=new SqlCommand("SELECT * FROM Esindus WHERE esindusId=1", connect);
            connect.Open();
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        string x = (lug["pilt"].ToString());
                        Esindus_pbox.Image = System.Drawing.Image.FromFile(@"..\..\Piltid\" + x);
                        Esindus_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x = (lug["nimetus"].ToString());
                        nimi_lbl.Text = "Nimi: " + x;
                        x = (lug["autor"].ToString());
                        autor_lbl.Text = "Autor: " + x;
                        x = (lug["vabastamine_aeg"].ToString());
                        aeg_lbl.Text = "Vabastamine aeg: " + x;
                        x = (lug["zanrId"].ToString());
                    }

                }
            }
            finally
            {
                connect.Close();
            }
            cmd = new SqlCommand("SELECT zanrnimi FROM Zanr WHERE zanrId=@x");
            connect.Open();
            //cmd.Parameters.AddWithValue("@x", x);
            try
            {
                
            }
            finally
            {

                connect.Close();
            }
        }
    }
}
