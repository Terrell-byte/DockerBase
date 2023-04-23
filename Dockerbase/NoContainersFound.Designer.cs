namespace DockerBase
{
    partial class NoContainersFound
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
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(404, 224);
            label1.Name = "label1";
            label1.Size = new Size(186, 18);
            label1.TabIndex = 0;
            label1.Text = "No Containers where found!";
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Cross;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Image = Properties.Resources.person_circle;
            button1.Location = new Point(404, 286);
            button1.Name = "button1";
            button1.Size = new Size(186, 186);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // NoContainersFound
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(986, 671);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NoContainersFound";
            Text = "NoContainersFound";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
    }
}