namespace DockerBase.view
{
    partial class DatabaseTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseTab));
            Tab = new Button();
            SuspendLayout();
            // 
            // Tab
            // 
            Tab.BackColor = SystemColors.ButtonHighlight;
            Tab.BackgroundImageLayout = ImageLayout.Center;
            Tab.Cursor = Cursors.Hand;
            Tab.Dock = DockStyle.Fill;
            Tab.FlatStyle = FlatStyle.Flat;
            Tab.Image = (Image)resources.GetObject("Tab.Image");
            Tab.ImageAlign = ContentAlignment.MiddleLeft;
            Tab.Location = new Point(0, 0);
            Tab.Name = "Tab";
            Tab.Size = new Size(157, 59);
            Tab.TabIndex = 0;
            Tab.Text = "Na";
            Tab.TextImageRelation = TextImageRelation.ImageBeforeText;
            Tab.UseVisualStyleBackColor = false;
            Tab.Click += Tab_Click;
            // 
            // DatabaseTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(157, 59);
            Controls.Add(Tab);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DatabaseTab";
            Text = "DatabaseTab";
            Load += DatabaseTab_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Tab;
    }
}