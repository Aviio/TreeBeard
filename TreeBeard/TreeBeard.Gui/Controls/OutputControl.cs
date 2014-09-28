using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBeard.Extensions;
using TreeBeard.Interfaces;
using TreeBeard.Outputs;

namespace TreeBeard.Gui.Controls
{
    public partial class OutputControl : UserControl
    {
        public OutputControl()
        {
            InitializeComponent();
        }

        public IOutput GetOutput()
        {
            try
            {
                List<string> fullArgs = new List<string> { txtType.Text };
                string[] args = txtArgs.Text.SplitCsv();
                if (args != null)
                {
                    fullArgs.AddRange(args);
                }

                ConfigurationOutput output = new ConfigurationOutput();
                output.Initialize(fullArgs.ToArray());

                return output;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
