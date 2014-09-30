using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBeard.Extensions;
using TreeBeard.Inputs;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        public IInput GetInput()
        {
            try
            {
                List<string> fullArgs = new List<string> { txtType.Text, txtAlias.Text };
                string[] args = txtArgs.Text.SplitCsv();
                if (args != null)
                {
                    fullArgs.AddRange(args);
                }

                ConfigurationInput input = new ConfigurationInput();
                input.Initialize(fullArgs.ToArray());

                return input;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
