namespace TreeBeard.Gui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tspMain = new System.Windows.Forms.ToolStrip();
            this.btnFilterPredicate = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnInput = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.btnOutput = new System.Windows.Forms.ToolStripButton();
            this.tspMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspMain
            // 
            this.tspMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilterPredicate,
            this.btnInput,
            this.btnFilter,
            this.btnOutput});
            this.tspMain.Location = new System.Drawing.Point(0, 0);
            this.tspMain.Name = "tspMain";
            this.tspMain.Size = new System.Drawing.Size(735, 25);
            this.tspMain.TabIndex = 0;
            // 
            // btnFilterPredicate
            // 
            this.btnFilterPredicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFilterPredicate.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterPredicate.Image")));
            this.btnFilterPredicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilterPredicate.Name = "btnFilterPredicate";
            this.btnFilterPredicate.Size = new System.Drawing.Size(94, 22);
            this.btnFilterPredicate.Text = "Filter Predicates";
            this.btnFilterPredicate.Click += new System.EventHandler(this.btnFilterPredicate_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Location = new System.Drawing.Point(12, 28);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(711, 395);
            this.pnlMain.TabIndex = 1;
            // 
            // btnInput
            // 
            this.btnInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInput.Image = ((System.Drawing.Image)(resources.GetObject("btnInput.Image")));
            this.btnInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(44, 22);
            this.btnInput.Text = "Inputs";
            this.btnInput.ToolTipText = "Inputs";
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(42, 22);
            this.btnFilter.Text = "Filters";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(54, 22);
            this.btnOutput.Text = "Outputs";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 435);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tspMain);
            this.Name = "MainForm";
            this.Text = "TreeBeard";
            this.tspMain.ResumeLayout(false);
            this.tspMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspMain;
        private System.Windows.Forms.ToolStripButton btnFilterPredicate;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripButton btnInput;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripButton btnOutput;
    }
}

