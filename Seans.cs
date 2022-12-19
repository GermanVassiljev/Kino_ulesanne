using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_ulesanne
{
    public partial class Seans : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd; 

        public Seans()
        {
            InitializeComponent();
        }
        List<int> esindus_seansid = new List<int>();
        public int lugemine_esindus()
        {
            int lugemine = 0;
            cmd = new SqlCommand("SELECT * FROM Seans WHERE esindusId=@id", connect);
            cmd.Parameters.AddWithValue("@id", kasutaja_nimi.ID);
            connect.Open();
            using (SqlDataReader luge = cmd.ExecuteReader())
            {
                while (luge.Read())
                {
                    esindus_seansid.Add(Int16.Parse(luge["seansId"].ToString()));
                    lugemine++;
                }
            }
            lugemine = lugemine - 1;
            connect.Close();
            return lugemine;

        }
        private void Seans_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT nimetus FROM Esindus WHERE esindusId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", kasutaja_nimi.ID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        esindus_lbl.Text = "Esindus: " + (lug["nimetus"].ToString());
                    }

                }
            }
            finally
            {
                connect.Close();
            }
        }        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string calendarText = calendar.ToString();
            calendarText = calendarText.Substring(44);
            calendarText = calendarText.Substring(0, calendarText.Length-9);

            cmd = new SqlCommand("SELECT * FROM Seans WHERE esindusId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", kasutaja_nimi.ID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        string PaevText = lug["paev"].ToString();
                        PaevText = PaevText.Substring(0, PaevText.Length-9);
                        if (PaevText == calendarText)
                        {
                            aeg_lbl.Text = "Aeg: "+(lug["aeg"].ToString());
                            saal_lbl.Text = "Saal: " + (lug["saalId"].ToString());

                        }
                    }
                }
            }
            finally
            {
                connect.Close();
            }
        }
        public int aeg_arv = 1;

        private void paremale_Click_1(object sender, EventArgs e)
        {
            string calendarText = calendar.ToString();
            calendarText = calendarText.Substring(44);
            calendarText = calendarText.Substring(0, calendarText.Length - 9);

            aeg_arv = aeg_arv - 1;
            if (aeg_arv <= -1)
            {
                aeg_arv = lugemine_esindus();
            }
            MessageBox.Show(aeg_arv.ToString());
            cmd = new SqlCommand("SELECT * FROM Seans WHERE seansId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", esindus_seansid[1]);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        string PaevText = lug["paev"].ToString();
                        PaevText = PaevText.Substring(0, PaevText.Length - 9);
                        if (PaevText == calendarText)
                        {
                            aeg_lbl.Text = "Aeg: " + (lug["aeg"].ToString());
                            saal_lbl.Text = "Saal: " + (lug["saalId"].ToString());

                        }

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
