namespace DockerBase.view
{
    partial class NoContainersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoContainersView));
            label1 = new Label();
            addDatabaseButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(326, 232);
            label1.Name = "label1";
            label1.Size = new Size(333, 18);
            label1.TabIndex = 0;
            label1.Text = "ERROR: Could not find any DockerBase containers!";
            // 
            // addDatabaseButton
            // 
            addDatabaseButton.BackgroundImageLayout = ImageLayout.None;
            addDatabaseButton.Cursor = Cursors.Cross;
            addDatabaseButton.FlatAppearance.BorderSize = 0;
            addDatabaseButton.FlatStyle = FlatStyle.Flat;
            addDatabaseButton.Image = (Image)resources.GetObject("addDatabaseButton.Image");
            addDatabaseButton.Location = new Point(399, 253);
            addDatabaseButton.Name = "addDatabaseButton";
            addDatabaseButton.Size = new Size(186, 186);
            addDatabaseButton.TabIndex = 1;
            addDatabaseButton.UseVisualStyleBackColor = true;
            addDatabaseButton.Click += AddDB_Click;
            // 
            // NoContainersFound
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(986, 671);
            Controls.Add(addDatabaseButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NoContainersFound";
            Text = "NoContainersFound";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addDatabaseButton;
    }
}