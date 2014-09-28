﻿using System;
using System.Drawing;
using System.Windows.Forms;
using TreeBeard.Events;

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

            Event value = uclEventInput.GetEvent();
            Func<Event, bool> predicate = uclPredicateInput.GetPredicate();
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
    }
}
