namespace TreeBeard.Gui.Views
{
    partial class FilterPredicateView
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
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.gbxEvent = new System.Windows.Forms.GroupBox();
            this.gbxPredicate = new System.Windows.Forms.GroupBox();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.lblPredicate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblTimeStamp = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtPredicate = new System.Windows.Forms.TextBox();
            this.dtpTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.lblResult = new System.Windows.Forms.Label();
            this.gbxMain.SuspendLayout();
            this.gbxEvent.SuspendLayout();
            this.gbxPredicate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.lblResult);
            this.gbxMain.Controls.Add(this.btnEvaluate);
            this.gbxMain.Controls.Add(this.gbxPredicate);
            this.gbxMain.Controls.Add(this.gbxEvent);
            this.gbxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMain.Location = new System.Drawing.Point(0, 0);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.TabIndex = 0;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "Filter Predicates";
            // 
            // gbxEvent
            // 
            this.gbxEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEvent.Controls.Add(this.dtpTimeStamp);
            this.gbxEvent.Controls.Add(this.txtMessage);
            this.gbxEvent.Controls.Add(this.txtId);
            this.gbxEvent.Controls.Add(this.txtType);
            this.gbxEvent.Controls.Add(this.lblMessage);
            this.gbxEvent.Controls.Add(this.lblTimeStamp);
            this.gbxEvent.Controls.Add(this.lblId);
            this.gbxEvent.Controls.Add(this.lblType);
            this.gbxEvent.Location = new System.Drawing.Point(6, 19);
            this.gbxEvent.Name = "gbxEvent";
            this.gbxEvent.Size = new System.Drawing.Size(562, 127);
            this.gbxEvent.TabIndex = 0;
            this.gbxEvent.TabStop = false;
            this.gbxEvent.Text = "Event";
            // 
            // gbxPredicate
            // 
            this.gbxPredicate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPredicate.Controls.Add(this.txtPredicate);
            this.gbxPredicate.Controls.Add(this.lblPredicate);
            this.gbxPredicate.Location = new System.Drawing.Point(6, 152);
            this.gbxPredicate.Name = "gbxPredicate";
            this.gbxPredicate.Size = new System.Drawing.Size(562, 47);
            this.gbxPredicate.TabIndex = 1;
            this.gbxPredicate.TabStop = false;
            this.gbxPredicate.Text = "Predicate";
            // 
            // btnEvaluate
            // 
            this.btnEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEvaluate.Location = new System.Drawing.Point(6, 205);
            this.btnEvaluate.Name = "btnEvaluate";
            this.btnEvaluate.Size = new System.Drawing.Size(562, 57);
            this.btnEvaluate.TabIndex = 2;
            this.btnEvaluate.Text = "Evaluate";
            this.btnEvaluate.UseVisualStyleBackColor = true;
            this.btnEvaluate.Click += new System.EventHandler(this.btnEvaluate_Click);
            // 
            // lblPredicate
            // 
            this.lblPredicate.AutoSize = true;
            this.lblPredicate.Location = new System.Drawing.Point(6, 22);
            this.lblPredicate.Name = "lblPredicate";
            this.lblPredicate.Size = new System.Drawing.Size(55, 13);
            this.lblPredicate.TabIndex = 0;
            this.lblPredicate.Text = "Predicate:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(6, 48);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "Id:";
            // 
            // lblTimeStamp
            // 
            this.lblTimeStamp.AutoSize = true;
            this.lblTimeStamp.Location = new System.Drawing.Point(6, 77);
            this.lblTimeStamp.Name = "lblTimeStamp";
            this.lblTimeStamp.Size = new System.Drawing.Size(63, 13);
            this.lblTimeStamp.TabIndex = 3;
            this.lblTimeStamp.Text = "TimeStamp:";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(6, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message:";
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(75, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(481, 20);
            this.txtType.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(75, 45);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(481, 20);
            this.txtId.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(75, 97);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(481, 20);
            this.txtMessage.TabIndex = 3;
            // 
            // txtPredicate
            // 
            this.txtPredicate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPredicate.Location = new System.Drawing.Point(75, 19);
            this.txtPredicate.Name = "txtPredicate";
            this.txtPredicate.Size = new System.Drawing.Size(481, 20);
            this.txtPredicate.TabIndex = 0;
            // 
            // dtpTimeStamp
            // 
            this.dtpTimeStamp.Location = new System.Drawing.Point(75, 71);
            this.dtpTimeStamp.Name = "dtpTimeStamp";
            this.dtpTimeStamp.Size = new System.Drawing.Size(200, 20);
            this.dtpTimeStamp.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(15, 274);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(547, 91);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "...";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FilterPredicateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxMain);
            this.Name = "FilterPredicateView";
            this.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.ResumeLayout(false);
            this.gbxEvent.ResumeLayout(false);
            this.gbxEvent.PerformLayout();
            this.gbxPredicate.ResumeLayout(false);
            this.gbxPredicate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.GroupBox gbxPredicate;
        private System.Windows.Forms.TextBox txtPredicate;
        private System.Windows.Forms.Label lblPredicate;
        private System.Windows.Forms.GroupBox gbxEvent;
        private System.Windows.Forms.DateTimePicker dtpTimeStamp;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTimeStamp;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblResult;
    }
}
