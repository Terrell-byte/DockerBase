﻿namespace DockerBase
{
    partial class MenuScene
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
            MenuFormLoader = new Panel();
            panel2 = new Panel();
            UserPanel = new Panel();
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
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(12, 167);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 555);
            panel2.TabIndex = 2;
            // 
            // UserPanel
            // 
            UserPanel.BackColor = Color.White;
            UserPanel.Location = new Point(12, 12);
            UserPanel.Name = "UserPanel";
            UserPanel.Size = new Size(173, 149);
            UserPanel.TabIndex = 3;
            // 
            // MenuScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 734);
            Controls.Add(UserPanel);
            Controls.Add(panel2);
            Controls.Add(MenuFormLoader);
            Name = "MenuScene";
            Text = "MenuScene";
            Load += MenuScene_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel MenuFormLoader;
        private Panel panel2;
        private Panel UserPanel;
    }
}