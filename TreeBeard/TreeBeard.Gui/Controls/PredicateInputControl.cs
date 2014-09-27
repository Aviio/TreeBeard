using System;
using System.Windows.Forms;
using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class PredicateInputControl : UserControl
    {
        public PredicateInputControl()
        {
            InitializeComponent();
        }

        public Func<IEvent, bool> GetPredicate()
        {
            try
            {
                return txtPredicate.Text.GetFunc<IEvent, bool>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
