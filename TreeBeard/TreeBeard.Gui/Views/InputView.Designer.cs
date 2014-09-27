namespace TreeBeard.Gui.Views
{
    partial class InputView
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
            this.gbxInput = new System.Windows.Forms.GroupBox();
            this.uclInput = new TreeBeard.Gui.Controls.InputControl();
            this.uclConsole = new TreeBeard.Gui.Controls.ConsoleControl();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.gbxMain.SuspendLayout();
            this.gbxInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.btnStop);
            this.gbxMain.Controls.Add(this.uclConsole);
            this.gbxMain.Controls.Add(this.btnStart);
            this.gbxMain.Controls.Add(this.gbxInput);
            this.gbxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMain.Location = new System.Drawing.Point(0, 0);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.TabIndex = 1;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "Inputs";
            this.gbxMain.Resize += new System.EventHandler(this.gbxMain_Resize);
            // 
            // gbxInput
            // 
            this.gbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxInput.Controls.Add(this.uclInput);
            this.gbxInput.Location = new System.Drawing.Point(6, 19);
            this.gbxInput.Name = "gbxInput";
            this.gbxInput.Size = new System.Drawing.Size(562, 48);
            this.gbxInput.TabIndex = 5;
            this.gbxInput.TabStop = false;
            this.gbxInput.Text = "Input";
            // 
            // uclInput
            // 
            this.uclInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uclInput.Location = new System.Drawing.Point(3, 16);
            this.uclInput.Name = "uclInput";
            this.uclInput.Size = new System.Drawing.Size(556, 29);
            this.uclInput.TabIndex = 0;
            // 
            // uclConsole
            // 
            this.uclConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uclConsole.Location = new System.Drawing.Point(6, 136);
            this.uclConsole.Name = "uclConsole";
            this.uclConsole.Size = new System.Drawing.Size(562, 235);
            this.uclConsole.TabIndex = 7;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 73);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(278, 57);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(290, 73);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(278, 57);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // InputView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxMain);
            this.Name = "InputView";
            this.Size = new System.Drawing.Size(574, 377);
            this.gbxMain.ResumeLayout(false);
            this.gbxInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxMain;
        private System.Windows.Forms.GroupBox gbxInput;
        private Controls.InputControl uclInput;
        private System.Windows.Forms.Button btnStop;
        private Controls.ConsoleControl uclConsole;
        private System.Windows.Forms.Button btnStart;
    }
}
