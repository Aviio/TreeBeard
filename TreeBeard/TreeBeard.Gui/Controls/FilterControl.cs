using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBeard.ExtensionMethods;
using TreeBeard.Filters;
using TreeBeard.Interfaces;

namespace TreeBeard.Gui.Controls
{
    public partial class FilterControl : UserControl
    {
        public FilterControl()
        {
            InitializeComponent();
        }

        public IFilter GetFilter()
        {
            try
            {
                List<string> fullArgs = new List<string> { txtType.Text, "" };
                string[] args = txtArgs.Text.SplitCsv();
                if (args != null)
                {
                    fullArgs.AddRange(args);
                }

                ConfigurationFilter filter = new ConfigurationFilter();
                filter.Initialize(fullArgs.ToArray());

                return filter;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
