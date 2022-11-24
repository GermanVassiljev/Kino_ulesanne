using Kino_ulesanne.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        enum Nimetus {saal1,saal2,saal3,saal4,saal5};
        int Read;
        int Kohad;
        PictureBox pilt_back = new PictureBox();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Saal));

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
            Plaan(2, 2);
        }
        public void Plaan(int kohad, int read)
        {
            Label koht_rida = new Label();
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.ColumnCount = kohad;
            tlp.RowCount = read;
            tlp.BackColor = Color.Maroon;
            for (int i = 0; i < kohad; i++)
            {
                for (int j = 0; j < read; j++)
                {
                    koht_rida = new Label
                    {
                        Text=i.ToString()+j.ToString(),
                        BackColor = Color.Green
                    };
                    tlp.Controls.Add(koht_rida,j,i);
                    koht_rida.Click += new EventHandler(Koht_rida);
                }
            }
            //this.Width = (koht_rida.Width + 10) * kohad;
            //this.Height = (koht_rida.Height + 10) * read;
            Controls.Add(tlp);
            Controls.Add(pilt_back);

        }
        private void Koht_rida(object sender, EventArgs e)
        {
            Label klik = sender as Label;
            klik.BackColor = Color.Red;
        }
    }
}
