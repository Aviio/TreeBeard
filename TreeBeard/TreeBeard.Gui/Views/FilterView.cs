﻿using System;
using System.Windows.Forms;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Views
{
    public partial class FilterView : UserControl
    {
        public FilterView()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            uclConsole.Clear();

            Event value = uclEventInput.GetEvent();
            IFilter filter = uclFilter.GetFilter();
            if (filter != null)
            {
                Event result = filter.Execute(value);
                if (result == null)
                {
                    Console.WriteLine("Event dropped");
                }
                else
                {
                    Console.WriteLine(result.AsString());
                }
            }
        }
    }
}
