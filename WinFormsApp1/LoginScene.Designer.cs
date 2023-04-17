namespace DockerBase
{
    partial class LoginScene
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            usernameField = new TextBox();
            passwordField = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = DockerBase.Properties.Resources.logo;
            pictureBox1.Location = new Point(150, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(98, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += loginLogo;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(237, 92, 62);
            label1.Location = new Point(135, 180);
            label1.Name = "label1";
            label1.Size = new Size(128, 42);
            label1.TabIndex = 1;
            label1.Text = "LOG IN";
            label1.Click += loginTitle;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = DockerBase.Properties.Resources.person_circle;
            pictureBox2.Location = new Point(64, 292);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            pictureBox2.Click += usernameIcon;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = DockerBase.Properties.Resources.shield_lock;
            pictureBox3.Location = new Point(64, 385);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            pictureBox3.Click += passwordIcon;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 92, 62);
            panel1.Location = new Point(64, 421);
            panel1.Name = "panel1";
            panel1.Size = new Size(297, 1);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(237, 92, 62);
            panel2.Location = new Point(64, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 1);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // textBox1
            // 
            usernameField.BorderStyle = BorderStyle.None;
            usernameField.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            usernameField.Location = new Point(100, 292);
            usernameField.Name = "textBox1";
            usernameField.Size = new Size(261, 28);
            usernameField.TabIndex = 6;
            usernameField.TextChanged += usernameField_TextChanged;
            // 
            // textBox2
            // 
            passwordField.BorderStyle = BorderStyle.None;
            passwordField.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            passwordField.Location = new Point(100, 385);
            passwordField.Name = "textBox2";
            passwordField.Size = new Size(261, 28);
            passwordField.TabIndex = 7;
            passwordField.TextChanged += passwordField_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(237, 92, 62);
            button1.Font = new Font("Corbel", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(84, 467);
            button1.Name = "button1";
            button1.Size = new Size(231, 69);
            button1.TabIndex = 8;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LoginBtn_Click;
            // 
            // LoginScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(400, 600);
            Controls.Add(button1);
            Controls.Add(passwordField);
            Controls.Add(usernameField);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginScene";
            Text = "Form1";
            Load += LoginScene_load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel1;
        private Panel panel2;
        private TextBox usernameField;
        private TextBox passwordField;
        private Button button1;
    }
}