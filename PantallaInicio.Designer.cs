namespace Space_Invaders
{
    partial class PantallaInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaInicio));
            BtnPlay = new Button();
            BtnExit = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // BtnPlay
            // 
            BtnPlay.BackColor = Color.LightGreen;
            BtnPlay.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnPlay.Location = new Point(394, 317);
            BtnPlay.Margin = new Padding(5, 4, 5, 4);
            BtnPlay.Name = "BtnPlay";
            BtnPlay.Size = new Size(271, 61);
            BtnPlay.TabIndex = 0;
            BtnPlay.Text = "PLAY";
            BtnPlay.UseVisualStyleBackColor = false;
            BtnPlay.Click += BtnPlay_Click;
            // 
            // BtnExit
            // 
            BtnExit.BackColor = Color.LightGreen;
            BtnExit.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnExit.Location = new Point(394, 401);
            BtnExit.Margin = new Padding(5, 4, 5, 4);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(271, 61);
            BtnExit.TabIndex = 1;
            BtnExit.Text = "EXIT";
            BtnExit.UseVisualStyleBackColor = false;
            BtnExit.Click += BtnExit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(220, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(637, 249);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.InvaderRosa;
            pictureBox2.Location = new Point(-25, 431);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(223, 156);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.InvaderAzul;
            pictureBox3.Location = new Point(873, 387);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(250, 200);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // PantallaInicio
            // 
            AutoScaleDimensions = new SizeF(14F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1103, 570);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(BtnExit);
            Controls.Add(BtnPlay);
            Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "PantallaInicio";
            Text = "Space Invaders";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnPlay;
        private Button BtnExit;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}