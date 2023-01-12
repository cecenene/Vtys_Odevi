namespace deneme1
{
    partial class LoadScreen
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
            this.components = new System.ComponentModel.Container();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Logo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.Myprogress = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.Myprogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.ImageRotate = 0F;
            this.Logo.Location = new System.Drawing.Point(97, 92);
            this.Logo.Name = "Logo";
            this.Logo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Logo.Size = new System.Drawing.Size(64, 64);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // Myprogress
            // 
            this.Myprogress.Controls.Add(this.Logo);
            this.Myprogress.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.Myprogress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Myprogress.ForeColor = System.Drawing.Color.White;
            this.Myprogress.Location = new System.Drawing.Point(372, 122);
            this.Myprogress.Minimum = 0;
            this.Myprogress.Name = "Myprogress";
            this.Myprogress.ProgressColor = System.Drawing.Color.White;
            this.Myprogress.ProgressColor2 = System.Drawing.Color.White;
            this.Myprogress.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Myprogress.Size = new System.Drawing.Size(258, 258);
            this.Myprogress.TabIndex = 1;
            this.Myprogress.Text = "guna2CircleProgressBar1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(390, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Market Satış Programı";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(958, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Myprogress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoadScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.Myprogress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox Logo;
        private Guna.UI2.WinForms.Guna2CircleProgressBar Myprogress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

