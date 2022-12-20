using Kino_ulesanne.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_ulesanne
{
    public partial class Saal : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        enum Nimetus { saal1, saal2, saal3, saal4, saal5 };
        PictureBox pilt_back = new PictureBox();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Saal));
        Label saal_txt = new Label();

        public Saal()
        {
            //InitializeComponent();
            pilt_back.Dock = DockStyle.Fill;
            pilt_back.Image = Image.FromFile(@"..\..\Piltid\background.jpg");
            pilt_back.SizeMode = PictureBoxSizeMode.StretchImage;
            pilt_back.Size = new Size(800, 450);
            pilt_back.Name = "pictureBox1";
            pilt_back.Location = new Point(0, 0);

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);

            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Saal";
            Text = "Saal";
            ((ISupportInitialize)pilt_back).EndInit();
            ResumeLayout(false);
            int MaxRida = 0;
            int MaxKoht = 0;
            if (kasutaja_nimi.SaalID==1)
            {
                Label_method(saal_txt, 25F, 300,15, 200,40,"Esimene Saal", Color.Maroon,Color.White);
                cmd = new SqlCommand("SELECT * FROM Saal WHERE saalId=@id", connect);
                connect.Open();
                cmd.Parameters.AddWithValue("@id", kasutaja_nimi.SaalID);
                try
                {
                    using (SqlDataReader lug = cmd.ExecuteReader())
                    {
                        while (lug.Read())
                        {
                            MaxRida = Int16.Parse(lug["maxRida"].ToString());
                            MaxKoht = Int16.Parse(lug["maxKoht"].ToString());
                        }
                    }
                }
                finally
                {
                    connect.Close();
                }
                Plaan(MaxKoht, MaxRida, 200, 100, 10, 10);
            }
            else if (kasutaja_nimi.SaalID == 2)
            {
                Label_method(saal_txt, 25F, 300, 15, 160, 40, "Teine Saal", Color.Maroon, Color.White);
            }
            else if(kasutaja_nimi.SaalID == 3)
            {
                Label_method(saal_txt, 25F, 300, 15, 160, 40, "Kolme Saal", Color.Maroon, Color.White);
            }
            
        }

        public void Plaan(int kohad, int read, int x, int y, int a, int b) //250, 70, 50, 50
        {
            PictureBox koht_rida = new PictureBox();
            TableLayoutPanel tlp = new TableLayoutPanel();
            int counter = 0;
            tlp.AutoSize = true;
            tlp.Location = new Point(x, y);
            kohad = kohad / read;
            tlp.ColumnCount = kohad;
            tlp.RowCount = read;
            tlp.BackColor = Color.Maroon;
            for (int i = 0; i < read; i++)
            {
                for (int j = 0; j < kohad; j++)
                {
                    counter++;
                    koht_rida = new PictureBox
                    {
                        Image = Image.FromFile(@"..\..\Piltid\sõit.png"),
                        Size = new Size(a,b),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    tlp.Controls.Add(koht_rida, j, i);
                    koht_rida.Click += Koht_rida_Click;
                }
            }
            Controls.Add(tlp);
        }
    

        private void Koht_rida_Click(object sender, EventArgs e)
        {
            PictureBox klik = sender as PictureBox;
            klik.Image = Image.FromFile(@"..\..\Piltid\sõit_ei.png");
        }

        
        private void Label_method(Label label, float font, int x, int y, int a, int b, string tekst, Color varv, Color font_varv)
        {
            label = new Label();
            label.Font = new Font("Monotype Corsiva", font, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(186)));
            label.Location = new Point(x,y);
            label.Size = new Size(a, b);
            label.Text = tekst;
            label.BackColor = varv;
            label.ForeColor = font_varv;
            Controls.Add(label);

        }

    }
}
