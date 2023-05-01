namespace DockerBase.view
{
    partial class ContentView
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
            previewTables = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            recentEntries = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)previewTables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recentEntries).BeginInit();
            SuspendLayout();
            // 
            // previewTables
            // 
            previewTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            previewTables.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            previewTables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            previewTables.Location = new Point(305, 417);
            previewTables.Margin = new Padding(10);
            previewTables.Name = "previewTables";
            previewTables.ReadOnly = true;
            previewTables.RowTemplate.Height = 25;
            previewTables.Size = new Size(662, 235);
            previewTables.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Gray;
            flowLayoutPanel2.Location = new Point(19, 223);
            flowLayoutPanel2.Margin = new Padding(10);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(266, 149);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Gray;
            flowLayoutPanel3.Location = new Point(305, 46);
            flowLayoutPanel3.Margin = new Padding(10);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(662, 326);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.Gray;
            flowLayoutPanel4.Location = new Point(19, 46);
            flowLayoutPanel4.Margin = new Padding(10);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(266, 138);
            flowLayoutPanel4.TabIndex = 3;
            // 
            // recentEntries
            // 
            recentEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            recentEntries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            recentEntries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recentEntries.Location = new Point(19, 417);
            recentEntries.Margin = new Padding(10);
            recentEntries.Name = "recentEntries";
            recentEntries.RowTemplate.Height = 25;
            recentEntries.Size = new Size(266, 235);
            recentEntries.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(237, 92, 62);
            label1.Location = new Point(19, 382);
            label1.Name = "label1";
            label1.Size = new Size(162, 29);
            label1.TabIndex = 5;
            label1.Text = "Recent Entries";
            // 
            // ContentView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(recentEntries);
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(previewTables);
            Name = "ContentView";
            Size = new Size(986, 671);
            ((System.ComponentModel.ISupportInitialize)previewTables).EndInit();
            ((System.ComponentModel.ISupportInitialize)recentEntries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView previewTables;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
        private DataGridView recentEntries;
        private Label label1;
    }
}