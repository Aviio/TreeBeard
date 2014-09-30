using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class EventInputControl : UserControl
    {
        public EventInputControl()
        {
            InitializeComponent();
        }

        public Event GetEvent()
        {
            Event ev = new Event(txtType.Text, txtAlias.Text, dtpTimeStamp.Value);

            try
            {
                var dynamicValues = JsonConvert.DeserializeObject<Dictionary<string, object>>(txtDynamic.Text);
                if (dynamicValues != null)
                {
                    foreach (var v in dynamicValues)
                    {
                        ev.SetMember(v.Key, v.Value);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ev;
        }
    }
}
