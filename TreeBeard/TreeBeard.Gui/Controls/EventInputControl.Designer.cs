namespace TreeBeard.Gui.Controls
{
    partial class EventInputControl
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
            this.components = new System.ComponentModel.Container();
            this.dtpTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.txtDynamic = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblDynamic = new System.Windows.Forms.Label();
            this.lblTimeStamp = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.ttiDynamic = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // dtpTimeStamp
            // 
            this.dtpTimeStamp.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeStamp.Location = new System.Drawing.Point(72, 55);
            this.dtpTimeStamp.Name = "dtpTimeStamp";
            this.dtpTimeStamp.Size = new System.Drawing.Size(150, 20);
            this.dtpTimeStamp.TabIndex = 8;
            // 
            // txtDynamic
            // 
            this.txtDynamic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDynamic.Location = new System.Drawing.Point(72, 81);
            this.txtDynamic.Name = "txtDynamic";
            this.txtDynamic.Size = new System.Drawing.Size(457, 20);
            this.txtDynamic.TabIndex = 10;
            this.ttiDynamic.SetToolTip(this.txtDynamic, "{\"foo\":\"bar\",\"int\":123,\"date\":\"2012-04-23T18:25:43.511Z\"}");
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(72, 29);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(457, 20);
            this.txtId.TabIndex = 6;
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(72, 3);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(457, 20);
            this.txtType.TabIndex = 5;
            // 
            // lblDynamic
            // 
            this.lblDynamic.AutoSize = true;
            this.lblDynamic.Location = new System.Drawing.Point(3, 84);
            this.lblDynamic.Name = "lblDynamic";
            this.lblDynamic.Size = new System.Drawing.Size(51, 13);
            this.lblDynamic.TabIndex = 12;
            this.lblDynamic.Text = "Dynamic:";
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Location = new System.Drawing.Point(3, 59);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(63, 13);
            this.lblTimeStamp.TabIndex = 11;
            this.lblTimeStamp.Text = "TimeStamp:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(3, 32);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 13);
            this.lblId.TabIndex = 9;
            this.lblId.Text = "Id:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(3, 6);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type:";
            // 
            // ttiDynamic
            // 
            this.ttiDynamic.AutomaticDelay = 10;
            this.ttiDynamic.AutoPopDelay = 100000;
            this.ttiDynamic.InitialDelay = 10;
            this.ttiDynamic.ReshowDelay = 2;
            this.ttiDynamic.ShowAlways = true;
            this.ttiDynamic.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttiDynamic.ToolTipTitle = "Example";
            // 
            // EventInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpTimeStamp);
            this.Controls.Add(this.txtDynamic);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.lblDynamic);
            this.Controls.Add(this.lblTimeStamp);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblType);
            this.Name = "EventInputControl";
            this.Size = new System.Drawing.Size(532, 103);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTimeStamp;
        private System.Windows.Forms.TextBox txtDynamic;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblDynamic;
        private System.Windows.Forms.Label lblTimeStamp;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ToolTip ttiDynamic;
    }
}
