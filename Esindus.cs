using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_ulesanne
{
    public partial class Esindus : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        public int zanridID;
        public Esindus()
        {
            InitializeComponent();
        }
        public int id_number = 1;
        public int lugemine_esindus()
        {
            int lugemine = 0;
            cmd = new SqlCommand("SELECT * FROM Esindus", connect);
            connect.Open();
            using (SqlDataReader luge = cmd.ExecuteReader())
            {
                while (luge.Read())
                {
                    lugemine++;
                }
            }
            connect.Close();
            return lugemine;
                
        }

        private void seans_btn_Click(object sender, EventArgs e)
        {
            kasutaja_nimi.ID=id_number;
            Seans seans = new Seans();
            this.Visible = false;
            seans.Visible = true;
        }

        private void paremale_Click(object sender, EventArgs e)
        {
            id_number -=1;
            if (id_number <= 0)
            {
                id_number = lugemine_esindus();

            }
            cmd = new SqlCommand("SELECT * FROM Esindus WHERE esindusId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", id_number);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        Esindus_pbox.Image = System.Drawing.Image.FromFile(@"..\..\Piltid\" + (lug["pilt"].ToString()));
                        Esindus_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        nimi_lbl.Text = "Nimi: " + (lug["nimetus"].ToString());
                        autor_lbl.Text = "Autor: " + (lug["autor"].ToString());
                        aeg_lbl.Text = "Vabastamine aeg: " + (lug["vabastamine_aeg"].ToString());
                        zanridID = Int16.Parse((lug["zanrId"].ToString()));
                    }

                }
            }
            finally
            {
                connect.Close();
            }
            cmd = new SqlCommand("SELECT zanrnimi FROM Zanr WHERE zanrId=@x", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@x", zanridID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        zanr_lbl.Text = "Žanr: " + (lug["zanrnimi"].ToString());
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
            string x;
            
            cmd=new SqlCommand("SELECT * FROM Esindus WHERE esindusId=1", connect);
            connect.Open();
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        x = (lug["pilt"].ToString());
                        Esindus_pbox.Image = System.Drawing.Image.FromFile(@"..\..\Piltid\" + x);
                        Esindus_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x = (lug["nimetus"].ToString());
                        nimi_lbl.Text = "Nimi: " + x;
                        x = (lug["autor"].ToString());
                        autor_lbl.Text = "Autor: " + x;
                        x = (lug["vabastamine_aeg"].ToString());                       
                        aeg_lbl.Text = "Vabastamine aeg: " + x;
                        zanridID = Int16.Parse((lug["zanrId"].ToString())); 
                    }

                }
            }
            finally
            {
                connect.Close();
            }
            cmd = new SqlCommand("SELECT zanrnimi FROM Zanr WHERE zanrId=@x", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@x", zanridID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        x = (lug["zanrnimi"].ToString());
                        zanr_lbl.Text = "Žanr: " + x;
                    }
                }

            }
            finally
            {

                connect.Close();
            }
        }

        private void vasakule_Click(object sender, EventArgs e)
        {
            string x;
            id_number += 1;
            if (id_number > lugemine_esindus())
            {
                id_number = id_number-lugemine_esindus();
            }
            cmd = new SqlCommand("SELECT * FROM Esindus WHERE esindusId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", id_number);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        x = (lug["pilt"].ToString());
                        Esindus_pbox.Image = System.Drawing.Image.FromFile(@"..\..\Piltid\" + x);
                        Esindus_pbox.SizeMode = PictureBoxSizeMode.StretchImage;
                        x = (lug["nimetus"].ToString());
                        nimi_lbl.Text = "Nimi: " + x;
                        x = (lug["autor"].ToString());
                        autor_lbl.Text = "Autor: " + x;
                        x = (lug["vabastamine_aeg"].ToString());
                        aeg_lbl.Text = "Vabastamine aeg: " + x;
                        zanridID = Int16.Parse((lug["zanrId"].ToString()));
                    }

                }
            }
            finally
            {
                connect.Close();
            }
            cmd = new SqlCommand("SELECT zanrnimi FROM Zanr WHERE zanrId=@x", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@x", zanridID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        x = (lug["zanrnimi"].ToString());
                        zanr_lbl.Text = "Žanr: " + x;
                    }
                }

            }
            finally
            {

                connect.Close();
            }
        }
    }
}
