namespace TreeBeard.Gui.Controls
{
    partial class PredicateInputControl
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
            this.txtPredicate = new System.Windows.Forms.TextBox();
            this.lblPredicate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPredicate
            // 
            this.txtPredicate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPredicate.Location = new System.Drawing.Point(72, 3);
            this.txtPredicate.Name = "txtPredicate";
            this.txtPredicate.Size = new System.Drawing.Size(688, 20);
            this.txtPredicate.TabIndex = 1;
            // 
            // lblPredicate
            // 
            this.lblPredicate.AutoSize = true;
            this.lblPredicate.Location = new System.Drawing.Point(3, 6);
            this.lblPredicate.Name = "lblPredicate";
            this.lblPredicate.Size = new System.Drawing.Size(55, 13);
            this.lblPredicate.TabIndex = 2;
            this.lblPredicate.Text = "Predicate:";
            // 
            // PredicateInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPredicate);
            this.Controls.Add(this.lblPredicate);
            this.Name = "PredicateInputControl";
            this.Size = new System.Drawing.Size(763, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPredicate;
        private System.Windows.Forms.Label lblPredicate;
    }
}
