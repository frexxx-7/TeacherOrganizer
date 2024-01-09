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

namespace TeacherOrganizer.UserControls
{
    public partial class TaskView : UserControl
    {
        private Task _task;
        public TaskView(Task task)
        {
            InitializeComponent();
            _task = task;
            FillTaskCard(task.title, task.description);
            ContextMenuStrip = CreateMenu();
        }
        private ContextMenuStrip CreateMenu()
        {
            var contextMenuStrip = new ContextMenuStrip();

            var editAppointment = new ToolStripMenuItem();
            editAppointment.Text = "Редактировать";
            editAppointment.Click += EditAppointment_Click;

            var deleteAppointment = new ToolStripMenuItem();
            deleteAppointment.Text = "Удалить";
            deleteAppointment.Click += DeleteAppointment_Click;

            contextMenuStrip.Items.AddRange(new ToolStripItem[] { editAppointment, deleteAppointment });
            return contextMenuStrip;
        }
        private void DeleteAppointment_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данную задачу?", "Внимание!",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from tasks where ID =" + _task.id);
                NewTaskForm._delegateRefreshMethod(_task.endDate.Year, _task.endDate.Month);
            }
        }

        private void EditAppointment_Click(object sender, EventArgs e)
        {
            var editAppointment = new NewTaskForm(_task.endDate, _task);
            editAppointment.ShowDialog();
        }
        private void FillTaskCard(string title, string description)
        {
            TitleLabel.Text = title;
            DescriptionLabel.Text = description;

            if (_task.isCompleted)
            {
                TitleLabel.ForeColor = Color.MediumSpringGreen;
                TitleLabel.Text = TitleLabel.Text;
            }

            var titleHeight = TextRenderer.MeasureText(title, Font, new Size(300, 40), TextFormatFlags.WordBreak).Height;
            var descriprionHeight = TextRenderer.MeasureText(description, Font, new Size(300, 110), TextFormatFlags.WordBreak).Height;

            descriprionHeight = descriprionHeight > 150 ? descriprionHeight +30 : descriprionHeight + 15;
            titleHeight = titleHeight > 20 ? titleHeight + 20 : titleHeight + 10;
            titleHeight = titleHeight > 100 ? titleHeight + 25 : titleHeight;

            Height = titleHeight + descriprionHeight;
        }

        private void DescriptionLabel_MouseMove(object sender, MouseEventArgs e)
        {
            TitleLabel.ForeColor = Color.Fuchsia;
        }

        private void DescriptionLabel_MouseLeave(object sender, EventArgs e)
        {
            TitleLabel.ForeColor = Color.Blue;
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            TitleLabel.ForeColor = Color.Fuchsia;

        }

        private void TitleLabel_MouseLeave(object sender, EventArgs e)
        {
            TitleLabel.ForeColor = Color.Blue;
        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {
            new ShowTask(_task).Show();
        }

        private void DescriptionLabel_Click(object sender, EventArgs e)
        {
            new ShowTask(_task).Show();
        }
    }
}
