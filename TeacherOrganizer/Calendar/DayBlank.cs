using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeacherOrganizer.Classes;
using TeacherOrganizer.Forms;

namespace TeacherOrganizer.Calendar
{
    public partial class DayBlank : UserControl
    {
        private DateTime _currentDate;
        private Color _backColor;
        private List<Task> _tasks;
        public DayBlank()
        {
            InitializeComponent();
        }
        public void Refresh(Color backColor, int day, DateTime date, Color foreColor)
        {
            BackColor = _backColor = backColor;
            dayNumber.Text = day.ToString();
            _currentDate = date;
            if (_currentDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                BackColor = Color.FromArgb(222, 255, 159, 67);

            dayNumber.ForeColor = foreColor;
            _tasks = TasksDbFunc.GetTask(date);

            int tasksCount = _tasks.Count;
            int completedCount = _tasks.Where(x => x.isCompleted).Count();
            int activeCount = tasksCount - completedCount;

            CompletedAppointmentsLabel.Text = completedCount < 10 ? '0' + completedCount.ToString() : completedCount.ToString();
            ActiveAppointmentsLabel.Text = activeCount < 10 ? '0' + activeCount.ToString() : activeCount.ToString();

            CompletedAppointmentPanel.Visible = completedCount > 0;
            ActiveAppointmentPanel.Visible = activeCount > 0;
        }

        private void DayBlank_MouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                AddAppointmentButton.Visible = false;
                BackColor = _backColor;
            }
        }

        private void DayBlank_MouseEnter(object sender, EventArgs e)
        {
            AddAppointmentButton.Visible = true;
            BackColor = Color.FromArgb(123, _backColor);
        }

        private void DayBlankControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (_tasks.Count > 0)
            {
                Main.tvp.FillView(_tasks);
            }
        }

        private void DayBlank_Load_1(object sender, EventArgs e)
        {
            new List<Control> { dayNumber , AddAppointmentButton, ActiveAppointmentsLabel,ActiveAppointmentPanel,
            CompletedAppointmentsLabel,CompletedAppointmentPanel, this}.ForEach(x =>
            {
                x.MouseClick += DayBlankControl_MouseClick;
                x.MouseEnter += DayBlank_MouseEnter;
                x.MouseLeave += DayBlank_MouseLeave;
            });
        }

        private void AddAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointmentButton.Visible = false;
            BackColor = _backColor;
            new NewTaskForm(_currentDate, null).ShowDialog();
        }
    }
}
