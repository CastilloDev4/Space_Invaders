namespace Space_Invaders
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            SpaceShip = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            invaderTimer = new System.Windows.Forms.Timer(components);
            enemyShootingTimer = new System.Windows.Forms.Timer(components);
            enemyBulletMoveTimer = new System.Windows.Forms.Timer(components);
            bulletTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)SpaceShip).BeginInit();
            SuspendLayout();
            // 
            // SpaceShip
            // 
            SpaceShip.Image = Properties.Resources.StarLink;
            SpaceShip.Location = new Point(539, 605);
            SpaceShip.Name = "SpaceShip";
            SpaceShip.Size = new Size(199, 137);
            SpaceShip.SizeMode = PictureBoxSizeMode.Zoom;
            SpaceShip.TabIndex = 0;
            SpaceShip.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 1;
            timer1.Tick += timer1_Tick;
            // 
            // invaderTimer
            // 
            invaderTimer.Tick += invaderTimer_Tick;
            // 
            // bulletTimer
            // 
            bulletTimer.Tick += bulletTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1348, 780);
            Controls.Add(SpaceShip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Space Invaders";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)SpaceShip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox SpaceShip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer invaderTimer;
        private System.Windows.Forms.Timer enemyShootingTimer;
        private System.Windows.Forms.Timer enemyBulletMoveTimer;
        private System.Windows.Forms.Timer bulletTimer;
    }
}