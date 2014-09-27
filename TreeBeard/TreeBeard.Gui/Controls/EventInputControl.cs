using System.Windows.Forms;
using TreeBeard.Events;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class EventInputControl : UserControl
    {
        public EventInputControl()
        {
            InitializeComponent();
        }

        public IEvent GetEvent()
        {
            return new Event(txtType.Text, txtId.Text, txtMessage.Text, dtpTimeStamp.Value);
        }
    }
}
