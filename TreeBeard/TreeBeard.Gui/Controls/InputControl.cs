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
            return (chkUseScript.Checked) ? GetInputFromScript() : GetInputFromDll();
        }

        private IInput GetInputFromScript()
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

        private IInput GetInputFromDll()
        {
            Type type = Type.GetType(txtType.Text + "Input, TreeBeard.Plugins");
            IInput input = Activator.CreateInstance(type) as IInput;
            input.Type = txtType.Text;
            input.Alias = txtAlias.Text;
            input.Initialize(txtArgs.Text.SplitCsv());
            return input;
        }
    }
}
