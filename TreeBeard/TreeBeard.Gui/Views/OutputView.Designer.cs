namespace TreeBeard.Gui.Views
{
    partial class OutputView
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
            this.uclConsole = new TreeBeard.Gui.Controls.ConsoleControl();
            this.btnExecute = new System.Windows.Forms.Button();
            this.gbxOutput = new System.Windows.Forms.GroupBox();
            this.uclOutput = new TreeBeard.Gui.Controls.OutputControl();
            this.gbxEvent = new System.Windows.Forms.GroupBox();
            this.uclEventInput = new TreeBeard.Gui.Controls.EventInputControl();
            this.gbxMain.SuspendLayout();
            this.gbxOutput.SuspendLayout();
            this.gbxEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.uclConsole);
            this.gbxMain.Controls.Add(this.btnExecute);
            this.gbxMain.Controls.Add(this.gbxOutput);
            this.gbxMain.Controls.Add(this.gbxEvent);
            this.gbxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMain.Location = new System.Drawing.Point(0, 0);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.TabIndex = 1;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "Outputs";
            // 
            // uclConsole
            // 
            this.uclConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uclConsole.Location = new System.Drawing.Point(6, 269);
            this.uclConsole.Name = "uclConsole";
            this.uclConsole.Size = new System.Drawing.Size(562, 102);
            this.uclConsole.TabIndex = 4;
            this.uclConsole.Load += new System.EventHandler(this.uclConsole_Load);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(6, 206);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(562, 57);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // gbxOutput
            // 
            this.gbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOutput.Controls.Add(this.uclOutput);
            this.gbxOutput.Location = new System.Drawing.Point(6, 152);
            this.gbxOutput.Name = "gbxOutput";
            this.gbxOutput.Size = new System.Drawing.Size(562, 48);
            this.gbxOutput.TabIndex = 1;
            this.gbxOutput.TabStop = false;
            this.gbxOutput.Text = "Output";
            // 
            // uclOutput
            // 
            this.uclOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclOutput.Location = new System.Drawing.Point(3, 16);
            this.uclOutput.Name = "uclOutput";
            this.uclOutput.Size = new System.Drawing.Size(556, 29);
            this.uclOutput.TabIndex = 0;
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
            // OutputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxMain);
            this.Name = "OutputView";
            this.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.ResumeLayout(false);
            this.gbxOutput.ResumeLayout(false);
            this.gbxEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.GroupBox gbxEvent;
        private Controls.EventInputControl uclEventInput;
        private System.Windows.Forms.GroupBox gbxOutput;
        private Controls.OutputControl uclOutput;
        private System.Windows.Forms.Button btnExecute;
        private Controls.ConsoleControl uclConsole;
    }
}
