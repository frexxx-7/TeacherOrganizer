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
    public partial class ShowTask : Form
    {
        private Task _task;
        public ShowTask(Task task)
        {
            InitializeComponent();
            this._task = task;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            new NewTaskForm(_task.endDate, _task).Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowTask_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = _task.title;
            DescriptionLabel.Text = _task.description;
            ResultLabel.Text = _task.isCompleted ? "Выполнено" : "Не выполнено";
        }
    }
}
