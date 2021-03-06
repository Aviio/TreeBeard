﻿namespace TreeBeard.Gui.Views
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
            this.lblResult = new System.Windows.Forms.Label();
            this.btnEvaluate = new System.Windows.Forms.Button();
            this.gbxPredicate = new System.Windows.Forms.GroupBox();
            this.gbxEvent = new System.Windows.Forms.GroupBox();
            this.uclEventInput = new TreeBeard.Gui.Controls.EventInputControl();
            this.uclPredicateInput = new TreeBeard.Gui.Controls.PredicateInputControl();
            this.gbxMain.SuspendLayout();
            this.gbxPredicate.SuspendLayout();
            this.gbxEvent.SuspendLayout();
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
            // gbxPredicate
            // 
            this.gbxPredicate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPredicate.Controls.Add(this.uclPredicateInput);
            this.gbxPredicate.Location = new System.Drawing.Point(6, 152);
            this.gbxPredicate.Name = "gbxPredicate";
            this.gbxPredicate.Size = new System.Drawing.Size(562, 47);
            this.gbxPredicate.TabIndex = 1;
            this.gbxPredicate.TabStop = false;
            this.gbxPredicate.Text = "Predicate";
            // 
            // gbxEvent
            // 
            this.gbxEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxEvent.Controls.Add(this.uclEventInput);
            this.gbxEvent.Location = new System.Drawing.Point(6, 19);
            this.gbxEvent.Name = "gbxEvent";
            this.gbxEvent.Size = new System.Drawing.Size(562, 127);
            this.gbxEvent.TabIndex = 0;
            this.gbxEvent.TabStop = false;
            this.gbxEvent.Text = "Event";
            // 
            // uclEventInput
            // 
            this.uclEventInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclEventInput.Location = new System.Drawing.Point(3, 16);
            this.uclEventInput.Name = "uclEventInput";
            this.uclEventInput.Size = new System.Drawing.Size(556, 108);
            this.uclEventInput.TabIndex = 0;
            // 
            // uclPredicateInput
            // 
            this.uclPredicateInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclPredicateInput.Location = new System.Drawing.Point(3, 16);
            this.uclPredicateInput.Name = "uclPredicateInput";
            this.uclPredicateInput.Size = new System.Drawing.Size(556, 28);
            this.uclPredicateInput.TabIndex = 0;
            // 
            // FilterPredicateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxMain);
            this.Name = "FilterPredicateView";
            this.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.ResumeLayout(false);
            this.gbxPredicate.ResumeLayout(false);
            this.gbxEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.Button btnEvaluate;
        private System.Windows.Forms.GroupBox gbxPredicate;
        private System.Windows.Forms.GroupBox gbxEvent;
        private System.Windows.Forms.Label lblResult;
        private Controls.EventInputControl uclEventInput;
        private Controls.PredicateInputControl uclPredicateInput;
    }
}
