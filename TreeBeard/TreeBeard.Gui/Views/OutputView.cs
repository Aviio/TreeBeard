﻿using System;
using System.Windows.Forms;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Views
{
    public partial class OutputView : UserControl
    {
        public OutputView()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            uclConsole.Clear();

            try
            {
                Event value = uclEventInput.GetEvent();
                using (IOutput output = uclOutput.GetOutput())
                {
                    Console.WriteLine("Executing...");
                    if (output != null) output.Execute(value);
                    Console.WriteLine("Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
