using System;
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

            IEvent value = uclEventInput.GetEvent();
            IOutput output = uclOutput.GetOutput();
            if (output != null)
            {
                output.Execute(value);
            }
        }

        private void uclConsole_Load(object sender, EventArgs e)
        {

        }
    }
}
