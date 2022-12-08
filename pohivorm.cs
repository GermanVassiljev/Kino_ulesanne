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
    public partial class Teater : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\TARpv21_Vassiljev\Kino_ulesanne\teaterBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader lugeja;
        public Teater()
        {
            InitializeComponent();
            //label1 = new Label();
            //silt_method(label1, 144, 9, 290, 57, 36F, "Monotype Corsiva", "Germani teater");
            //Controls.Add(label1);
        }

        private void esindus_btn_Click(object sender, EventArgs e)
        {
            Esindus esi = new Esindus();
            this.Visible = false;
            esi.Visible = true;
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            this.Visible = false;
            reg.Visible = true;
        }

        private void sisse_btn_Click(object sender, EventArgs e)
        {
            Sissepaas paas = new Sissepaas();
            this.Visible = false;
            paas.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Teater_VisibleChanged(object sender, EventArgs e)
        {
            label2.Text = "Tere "+kasutaja_nimi.nimi+"!";
        }


        //private void silt_method(Label silt, int x, int y, int a, int b, float font, string font_tekst, string tekst, Color varv)
        //{
        //    silt.AutoSize = true;
        //    silt.Font = new Font(font_tekst, font, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        //    silt.Location = new Point(x, y);
        //    silt.Size = new Size(a, b);
        //    silt.Text = tekst;
        //    silt.TextAlign = ContentAlignment.MiddleCenter;
        //    silt.BackColor = Color.varv;
        //}
    }
}
