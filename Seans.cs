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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //DateTimePicker()
            cmd = new SqlCommand("SELECT * FROM Seans WHERE esindusId=@id", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@id", kasutaja_nimi.ID);
            try
            {
                using (SqlDataReader lug = cmd.ExecuteReader())
                {
                    while (lug.Read())
                    {
                        if ((lug["paev"])== calendar)
                        {
                            aeg_lbl.Text = (lug["aeg"].ToString());
                        }
                    }                   
                }
            }
            finally
            {
                connect.Close();
            }
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
                        esindus_lbl.Text = (lug["nimetus"].ToString());
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
