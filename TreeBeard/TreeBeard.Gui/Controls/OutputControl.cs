using System;
using System.Collections.Generic;
using System.Reflection;
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
            return (chkUseScript.Checked) ? GetOutputFromScript() : GetOutputFromDll();
        }

        private IOutput GetOutputFromScript()
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

        private IOutput GetOutputFromDll()
        {
            Type type = Type.GetType(txtType.Text + "Output, TreeBeard.Plugins");
            IOutput output = Activator.CreateInstance(type) as IOutput;
            output.Initialize(txtArgs.Text.SplitCsv());
            return output;
        }
    }
}
