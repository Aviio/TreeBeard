using System.Windows.Forms;
using TreeBeard.Events;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class EventInputControl : UserControl
    {
        // TODO need to provide method of entering dynamic content

        public EventInputControl()
        {
            InitializeComponent();
        }

        public Event GetEvent()
        {
            dynamic ev = new Event(txtType.Text, txtId.Text, dtpTimeStamp.Value);
            ev.Message = txtMessage.Text;
            return ev;
        }
    }
}
