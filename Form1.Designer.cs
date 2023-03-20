namespace FoodAssistant;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        search_box = new TextBox();
        SuspendLayout();
        // 
        // search_box
        // 
        search_box.BorderStyle = BorderStyle.None;
        search_box.Cursor = Cursors.IBeam;
        search_box.Location = new Point(245, 98);
        search_box.Margin = new Padding(5, 3, 5, 3);
        search_box.Name = "search_box";
        search_box.Size = new Size(353, 16);
        search_box.TabIndex = 0;
        // 
        // Background
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        ClientSize = new Size(720, 512);
        Controls.Add(search_box);
        FormBorderStyle = FormBorderStyle.None;
        Name = "Form1";
        Text = "Background";
        Load += Form_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox search_box;
}
