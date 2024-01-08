using CodeeloUI.Controls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeacherOrganizer.Classes;

namespace TeacherOrganizer.UserControls
{
    public partial class TaskViewPanel : UserControl
    {
        public TaskViewPanel()
        {
            InitializeComponent();
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                MyDateTimePicker.BackColor = value;
            }

        }
        public void FillView(List<Task> appointments)
        {
            guna2Panel1.Controls.Clear();
            foreach (var item in appointments)
            {
                var task = new TaskView(item);
                task.Dock = DockStyle.Top;
                guna2Panel1.Controls.Add(task);
            }
            MyDateTimePicker.Value = appointments[0].endDate;
        }

    }
}
