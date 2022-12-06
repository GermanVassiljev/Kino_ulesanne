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
    public partial class Register : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader lugeja;
        public Register()
        {
            InitializeComponent();
        }

        private void regY_btn_Click(object sender, EventArgs e)
        {
            if (nimi_txt.Text.Trim() != string.Empty && parool.Text.Trim() != string.Empty && parool2.Text.Trim() != string.Empty && calendar.SelectionRange.Start.ToString()!= string.Empty)
            {
                if (parool.Text == parool2.Text)
                {
                    if (parool.Text.Length > 10)
                    {
                        bool vaataInt = parool.Text.Any(char.IsDigit);
                        if (vaataInt != false)
                        {
                            cmd = new SqlCommand("SELECT * FROM Kasutajad", connect);
                            connect.Open();
                            lugeja = cmd.ExecuteReader();
                            bool kontrolli = false;
                            while (lugeja.Read())
                            {
                                if (nimi_txt.Text != lugeja["kasutajaNimi"].ToString())
                                {
                                    kontrolli = true;
                                    break;
                                }
                            }
                            connect.Close();
                            if (kontrolli)
                            {
                                cmd = new SqlCommand("INSERT INTO Kasutajad (kasutajaNimi, parool, synnipaev) VALUES (@login,@parool, @synnipaev)", connect);
                                connect.Open();
                                cmd.Parameters.AddWithValue("@login", nimi_txt.Text);
                                cmd.Parameters.AddWithValue("@parool", parool.Text);
                                cmd.Parameters.AddWithValue("@synnipaev", calendar.Text);
                                cmd.ExecuteNonQuery();
                                connect.Close();
                                MessageBox.Show("Olete registreerunud!");
                                Sissepaas paas = new Sissepaas();
                                this.Visible = false;
                                paas.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("See sisselogimine on juba olemas.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Parool peab sisaldama numbreid");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vähemalt kümme tähemärki");
                    }
                }
                else
                {
                    MessageBox.Show("Kontrollige parooli");
                }

            }
            else
            {
                MessageBox.Show("Kirjutage vajalikud andmed");
            }
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
