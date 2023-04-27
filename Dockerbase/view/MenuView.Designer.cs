namespace DockerBase.view
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            MenuFormLoader = new Panel();
            DatabaseList = new Panel();
            UserPanel = new Panel();
            pictureBox1 = new PictureBox();
            usernameTitle = new Label();
            UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // MenuFormLoader
            // 
            MenuFormLoader.BackColor = Color.White;
            MenuFormLoader.Location = new Point(191, 12);
            MenuFormLoader.Name = "MenuFormLoader";
            MenuFormLoader.Size = new Size(1002, 710);
            MenuFormLoader.TabIndex = 1;
            // 
            // DatabaseList
            // 
            DatabaseList.BackColor = Color.White;
            DatabaseList.Location = new Point(12, 191);
            DatabaseList.Name = "DatabaseList";
            DatabaseList.Size = new Size(173, 531);
            DatabaseList.TabIndex = 2;
            // 
            // UserPanel
            // 
            UserPanel.BackColor = Color.White;
            UserPanel.Controls.Add(usernameTitle);
            UserPanel.Controls.Add(pictureBox1);
            UserPanel.Location = new Point(12, 12);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(173, 173);
            UserPanel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(33, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 110);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // username
            // 
            usernameTitle.AutoSize = true;
            usernameTitle.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            usernameTitle.ForeColor = Color.FromArgb(237, 92, 62);
            usernameTitle.Location = new Point(33, 140);
            usernameTitle.Name = "username";
            usernameTitle.Size = new Size(110, 18);
            usernameTitle.TabIndex = 1;
            usernameTitle.Text = "----Username---";
            usernameTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MenuView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 734);
            Controls.Add(UserPanel);
            Controls.Add(DatabaseList);
            Controls.Add(MenuFormLoader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MenuView";
            Text = "MenuScene";
            UserPanel.ResumeLayout(false);
            UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuFormLoader;
        private Panel DatabaseList;
        private Panel UserPanel;
        private PictureBox pictureBox1;
        private Label usernameTitle;
    }
}