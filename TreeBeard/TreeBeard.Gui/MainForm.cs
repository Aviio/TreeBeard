using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeBeard.Gui.Views;

namespace TreeBeard.Gui
{
    public partial class MainForm : Form
    {
        UserControl _control;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnFilterPredicate_Click(object sender, EventArgs e)
        { 
            DisplayView<FilterPredicateView>(btnFilterPredicate);
        }

        private void DisplayView<T>(ToolStripButton sender)
            where T : UserControl, new()
        {
            bool viewChanged = false;
            foreach (ToolStripItem item in tspMain.Items)
            {
                ToolStripButton button = item as ToolStripButton;
                if (button != null)
                {
                    viewChanged = (button == sender && !button.Checked);
                    button.Checked = (button == sender);
                }
            }
            if (viewChanged)
            {
                // dispose of old control
                if (_control != null)
                {
                    pnlMain.Controls.Remove(_control);
                }

                // create new control
                _control = new T();
                pnlMain.Controls.Add(_control);
                _control.Dock = DockStyle.Fill;
            }
        }
    }
}
