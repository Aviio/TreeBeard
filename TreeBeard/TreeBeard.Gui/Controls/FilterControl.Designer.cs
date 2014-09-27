namespace TreeBeard.Gui.Controls
{
    partial class FilterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl3 = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(512, 6);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(17, 13);
            this.lbl3.TabIndex = 9;
            this.lbl3.Text = "] }";
            // 
            // txtArgs
            // 
            this.txtArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArgs.Location = new System.Drawing.Point(288, 3);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(218, 20);
            this.txtArgs.TabIndex = 8;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(163, 6);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(119, 13);
            this.lbl2.TabIndex = 7;
            this.lbl2.Text = "\", predicate : \"\", args : [";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(57, 3);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 20);
            this.txtType.TabIndex = 6;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(3, 6);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(48, 13);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "{ type : \"";
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txtArgs);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lbl1);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(532, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lbl1;
    }
}
