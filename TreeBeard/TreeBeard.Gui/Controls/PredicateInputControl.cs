using System;
using System.Windows.Forms;
using TreeBeard.Extensions;

namespace TreeBeard.Gui.Controls
{
    public partial class PredicateInputControl : UserControl
    {
        public PredicateInputControl()
        {
            InitializeComponent();
        }

        public Func<Event, bool> GetPredicate()
        {
            try
            {
                return txtPredicate.Text.GetFunc<Event, bool>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
