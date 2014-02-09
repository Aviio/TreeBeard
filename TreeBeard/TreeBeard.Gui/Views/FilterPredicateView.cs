using System;
using System.Drawing;
using System.Windows.Forms;
using TreeBeard.Events;
using TreeBeard.ExtensionMethods;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Views
{
    public partial class FilterPredicateView : UserControl
    {
        public FilterPredicateView()
        {
            InitializeComponent();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            lblResult.BackColor = SystemColors.Control;
            lblResult.Text = "...";

            IEvent value = GetEvent();
            Func<IEvent, bool> predicate = GetPredicate();
            if (predicate == null)
            {
                return;
            }
            if (predicate(value))
            {
                lblResult.BackColor = Color.Green;
                lblResult.Text = "TRUE";
            }
            else
            {
                lblResult.BackColor = Color.Red;
                lblResult.Text = "FALSE";
            }
        }

        private IEvent GetEvent()
        {
            return new Event(txtType.Text, txtId.Text, txtMessage.Text, dtpTimeStamp.Value);
        }

        private Func<IEvent, bool> GetPredicate()
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
