using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TreeBeard.Extensions;
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
            return (chkUseScript.Checked) ? GetFilterFromScript() : GetFilterFromDll();
        }

        private IFilter GetFilterFromScript()
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

        private IFilter GetFilterFromDll()
        {
            Type type = Type.GetType(txtType.Text + "Filter, TreeBeard.Plugins");
            IFilter filter = Activator.CreateInstance(type) as IFilter;
            filter.Predicate = null;
            filter.Initialize(txtArgs.Text.SplitCsv());
            return filter;
        }
    }
}
