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
            dataGridView1 = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(305, 392);
            dataGridView1.Margin = new Padding(10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(662, 260);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Gray;
            flowLayoutPanel1.Location = new Point(19, 392);
            flowLayoutPanel1.Margin = new Padding(10);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(266, 260);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Gray;
            flowLayoutPanel2.Location = new Point(19, 204);
            flowLayoutPanel2.Margin = new Padding(10);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(266, 168);
            flowLayoutPanel2.TabIndex = 2;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Gray;
            flowLayoutPanel3.Location = new Point(305, 19);
            flowLayoutPanel3.Margin = new Padding(10);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(662, 353);
            flowLayoutPanel3.TabIndex = 3;
            flowLayoutPanel3.Paint += flowLayoutPanel3_Paint;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.Gray;
            flowLayoutPanel4.Location = new Point(19, 19);
            flowLayoutPanel4.Margin = new Padding(10);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(266, 165);
            flowLayoutPanel4.TabIndex = 3;
            flowLayoutPanel4.Paint += flowLayoutPanel4_Paint;
            // 
            // ContentView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel4);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dataGridView1);
            Name = "ContentView";
            Size = new Size(986, 671);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
    }
}