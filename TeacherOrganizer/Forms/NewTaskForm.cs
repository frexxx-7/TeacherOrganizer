using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeacherOrganizer.Classes;

namespace TeacherOrganizer.Forms
{
    public partial class NewTaskForm : Form
    {
        private DateTime _currentDate;
        private Task _task;
        public static Main.delegateRefreshMethod _delegateRefreshMethod;

        public NewTaskForm(DateTime currentDate,
            Task task)
        {
            InitializeComponent();
            _currentDate = currentDate;
            _task = task;
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_task == null)
            {
                saveTask();
            }
            else
            {
                updateTask();
            }
            _delegateRefreshMethod(_currentDate.Year, _currentDate.Month);
            Close();
        }
        private void saveTask()
        {
            var task = new Task()
            {
                title = TitleTextBox.Text,
                endDate = EndDateDateTimePicker.Value,
                description = DescriptionTextBox.Text,
                isCompleted = false,
            };

            TasksDbFunc.AddTask(task);
        }
        private void updateTask()
        {
            _task.title = TitleTextBox.Text;
            _task.endDate = EndDateDateTimePicker.Value;
            _task.description = DescriptionTextBox.Text;

            if (_task.id == 0)
            {
                _task.id = TasksDbFunc.GetNextTaskID();
                TasksDbFunc.AddTask(_task);
            }
            if (isCompletedCheckBox.Checked)
            {
                _task.isCompleted = isCompletedCheckBox.Checked;
            }
            TasksDbFunc.UpdateTask(_task);
        }

        private void NewTaskForm_Load(object sender, EventArgs e)
        {
            EndDateDateTimePicker.Value = _currentDate;
            if (_task != null)
            {
                TitleTextBox.Text = _task.title;
                DescriptionTextBox.Text = _task.description;
                EndDateDateTimePicker.Value = _task.endDate;
                isCompletedCheckBox.Checked = _task.isCompleted;
            }
        }
    }
}
