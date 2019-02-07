namespace TheGoodPicture
{
    partial class frmGoodPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoodPicture));
            this.tsOilPaint = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblFilter = new System.Windows.Forms.ToolStripLabel();
            this.cbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbIntensity = new System.Windows.Forms.ToolStripTextBox();
            this.btnRaiseIntensity = new System.Windows.Forms.ToolStripButton();
            this.btnLowerIntensity = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pictureDemo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOilPaintTool = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOilPaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDemo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsOilPaint
            // 
            this.tsOilPaint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.lblFilter,
            this.cbFilter,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.tbIntensity,
            this.btnRaiseIntensity,
            this.btnLowerIntensity,
            this.toolStripSeparator3});
            this.tsOilPaint.Location = new System.Drawing.Point(0, 24);
            this.tsOilPaint.Name = "tsOilPaint";
            this.tsOilPaint.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsOilPaint.Size = new System.Drawing.Size(800, 25);
            this.tsOilPaint.TabIndex = 2;
            this.tsOilPaint.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblFilter
            // 
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(92, 22);
            this.lblFilter.Text = "Neighbor Pixels:";
            // 
            // cbFilter
            // 
            this.cbFilter.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9",
            "11",
            "13",
            "15"});
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(75, 25);
            this.cbFilter.Text = "3";
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel1.Text = "Intensity";
            // 
            // tbIntensity
            // 
            this.tbIntensity.Name = "tbIntensity";
            this.tbIntensity.Size = new System.Drawing.Size(50, 25);
            this.tbIntensity.Text = "25";
            // 
            // btnRaiseIntensity
            // 
            this.btnRaiseIntensity.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRaiseIntensity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRaiseIntensity.Image = ((System.Drawing.Image)(resources.GetObject("btnRaiseIntensity.Image")));
            this.btnRaiseIntensity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRaiseIntensity.Name = "btnRaiseIntensity";
            this.btnRaiseIntensity.Size = new System.Drawing.Size(23, 22);
            this.btnRaiseIntensity.Text = "+";
            this.btnRaiseIntensity.Click += new System.EventHandler(this.btnRaiseIntensity_Click);
            // 
            // btnLowerIntensity
            // 
            this.btnLowerIntensity.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnLowerIntensity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLowerIntensity.Image = ((System.Drawing.Image)(resources.GetObject("btnLowerIntensity.Image")));
            this.btnLowerIntensity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLowerIntensity.Name = "btnLowerIntensity";
            this.btnLowerIntensity.Size = new System.Drawing.Size(23, 22);
            this.btnLowerIntensity.Text = "-";
            this.btnLowerIntensity.Click += new System.EventHandler(this.btnLowerIntensity_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // pictureDemo
            // 
            this.pictureDemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureDemo.Location = new System.Drawing.Point(0, 49);
            this.pictureDemo.Name = "pictureDemo";
            this.pictureDemo.Size = new System.Drawing.Size(800, 401);
            this.pictureDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureDemo.TabIndex = 3;
            this.pictureDemo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOilPaintTool});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuOilPaintTool
            // 
            this.menuOilPaintTool.Checked = true;
            this.menuOilPaintTool.CheckOnClick = true;
            this.menuOilPaintTool.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuOilPaintTool.Name = "menuOilPaintTool";
            this.menuOilPaintTool.Size = new System.Drawing.Size(180, 22);
            this.menuOilPaintTool.Text = "Oil Paint Processor..";
            this.menuOilPaintTool.CheckedChanged += new System.EventHandler(this.menuOilPaintTool_CheckedChanged);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad,
            this.btnSave,
            this.btnReset,
            this.toolStripSeparator4,
            this.btnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnLoad
            // 
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(180, 22);
            this.btnLoad.Text = "Load..";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 22);
            this.btnSave.Text = "Save...";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel2.Text = "OIL PAINTER";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 22);
            this.btnReset.Text = "Reset Image";
            this.btnReset.Click += new System.EventHandler(this.tbReset_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 22);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmGoodPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureDemo);
            this.Controls.Add(this.tsOilPaint);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGoodPicture";
            this.Text = "The Good Picture";
            this.tsOilPaint.ResumeLayout(false);
            this.tsOilPaint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureDemo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsOilPaint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblFilter;
        private System.Windows.Forms.ToolStripComboBox cbFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbIntensity;
        private System.Windows.Forms.ToolStripButton btnRaiseIntensity;
        private System.Windows.Forms.ToolStripButton btnLowerIntensity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.PictureBox pictureDemo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuOilPaintTool;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLoad;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

