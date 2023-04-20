namespace DockerBase
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
            button1 = new Button();
            ContainerNameField = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(220, 219);
            button1.Name = "button1";
            button1.Size = new Size(332, 107);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            ContainerNameField.Location = new Point(220, 164);
            ContainerNameField.Name = "Container Name";
            ContainerNameField.Size = new Size(332, 23);
            ContainerNameField.TabIndex = 1;
            // 
            // MenuScene
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ContainerNameField);
            Controls.Add(button1);
            Name = "MenuScene";
            Text = "MenuScene";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox ContainerNameField;
    }
}