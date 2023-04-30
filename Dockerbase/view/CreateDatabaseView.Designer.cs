namespace DockerBase.view
{
    partial class CreateDatabaseView
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
            nameField = new TextBox();
            titleLabel = new Label();
            nameLabel = new Label();
            typeLabel = new Label();
            containerType = new ComboBox();
            createDatabaseButton = new Button();
            SuspendLayout();
            // 
            // nameText
            // 
            nameField.Location = new Point(41, 136);
            nameField.Name = "nameText";
            nameField.Size = new Size(224, 23);
            nameField.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Corbel", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.FromArgb(237, 92, 62);
            titleLabel.Location = new Point(21, 30);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(268, 42);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Create Database";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            nameLabel.ForeColor = Color.FromArgb(237, 92, 62);
            nameLabel.Location = new Point(41, 115);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(48, 18);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Font = new Font("Corbel", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            typeLabel.ForeColor = Color.FromArgb(237, 92, 62);
            typeLabel.Location = new Point(41, 198);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(40, 18);
            typeLabel.TabIndex = 3;
            typeLabel.Text = "Type";
            // 
            // containerType
            // 
            containerType.FormattingEnabled = true;
            containerType.Location = new Point(41, 219);
            containerType.Name = "containerType";
            containerType.Size = new Size(224, 23);
            containerType.TabIndex = 4;
            containerType.SelectedIndexChanged += containerType_SelectedIndexChanged;
            // 
            // createDatabaseButton
            // 
            createDatabaseButton.BackColor = Color.FromArgb(237, 92, 62);
            createDatabaseButton.ForeColor = Color.White;
            createDatabaseButton.Location = new Point(41, 287);
            createDatabaseButton.Name = "createDatabaseButton";
            createDatabaseButton.Size = new Size(224, 37);
            createDatabaseButton.TabIndex = 5;
            createDatabaseButton.Text = "New";
            createDatabaseButton.UseVisualStyleBackColor = false;
            createDatabaseButton.Click += createDatabaseButton_Click;
            // 
            // CreateDB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 372);
            Controls.Add(createDatabaseButton);
            Controls.Add(containerType);
            Controls.Add(typeLabel);
            Controls.Add(nameLabel);
            Controls.Add(titleLabel);
            Controls.Add(nameField);
            Name = "CreateDB";
            Text = "CreateDB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label nameLabel;
        private Label typeLabel;
        private TextBox nameField;
        private ComboBox containerType;
        private Button createDatabaseButton;
    }
}