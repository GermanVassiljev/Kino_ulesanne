namespace Kino_ulesanne
{
    partial class Seans
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seans));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.esindus_lbl = new System.Windows.Forms.Label();
            this.saal_lbl = new System.Windows.Forms.Label();
            this.aeg_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(677, 460);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "Telli";
            // 
            // calendar
            // 
            this.calendar.CalendarDimensions = new System.Drawing.Size(1, 3);
            this.calendar.Dock = System.Windows.Forms.DockStyle.Right;
            this.calendar.Location = new System.Drawing.Point(520, 0);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 3;
            this.calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // esindus_lbl
            // 
            this.esindus_lbl.AutoSize = true;
            this.esindus_lbl.BackColor = System.Drawing.Color.Maroon;
            this.esindus_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.esindus_lbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.esindus_lbl.Location = new System.Drawing.Point(14, 91);
            this.esindus_lbl.Name = "esindus_lbl";
            this.esindus_lbl.Size = new System.Drawing.Size(144, 45);
            this.esindus_lbl.TabIndex = 4;
            this.esindus_lbl.Text = "Esindus:";
            // 
            // saal_lbl
            // 
            this.saal_lbl.AutoSize = true;
            this.saal_lbl.BackColor = System.Drawing.Color.Maroon;
            this.saal_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.saal_lbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.saal_lbl.Location = new System.Drawing.Point(14, 220);
            this.saal_lbl.Name = "saal_lbl";
            this.saal_lbl.Size = new System.Drawing.Size(102, 45);
            this.saal_lbl.TabIndex = 5;
            this.saal_lbl.Text = "Saal: ";
            // 
            // aeg_lbl
            // 
            this.aeg_lbl.AutoSize = true;
            this.aeg_lbl.BackColor = System.Drawing.Color.Maroon;
            this.aeg_lbl.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.aeg_lbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.aeg_lbl.Location = new System.Drawing.Point(16, 153);
            this.aeg_lbl.Name = "aeg_lbl";
            this.aeg_lbl.Size = new System.Drawing.Size(94, 45);
            this.aeg_lbl.TabIndex = 6;
            this.aeg_lbl.Text = "Aeg: ";
            // 
            // Seans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 460);
            this.Controls.Add(this.aeg_lbl);
            this.Controls.Add(this.saal_lbl);
            this.Controls.Add(this.esindus_lbl);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Seans";
            this.Text = "Seans";
            this.Load += new System.EventHandler(this.Seans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Label esindus_lbl;
        private System.Windows.Forms.Label saal_lbl;
        private System.Windows.Forms.Label aeg_lbl;
    }
}