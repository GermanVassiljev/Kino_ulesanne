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
            Label_method(saal_txt, 25F, 300,15, 200,40,"Esimene Saal", Color.Maroon,Color.White);
        }

        public void Plaan(int kohad, int read, int x, int y, int a, int b) //250, 70, 50, 50
        {
            PictureBox koht_rida = new PictureBox();
            TableLayoutPanel tlp = new TableLayoutPanel();
            int counter = 0;
            tlp.AutoSize = true;
            tlp.Location = new Point(x, y);
            tlp.ColumnCount = kohad;
            tlp.RowCount = read;
            tlp.BackColor = Color.Maroon;
            for (int i = 0; i < kohad; i++)
            {
                for (int j = 0; j < read; j++)
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
