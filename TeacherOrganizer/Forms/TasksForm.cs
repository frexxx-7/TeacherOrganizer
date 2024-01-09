using MySql.Data.MySqlClient;
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
    public partial class TasksForm : Form
    {
        private List<Task> _tasks = new List<Task>();
        public TasksForm()
        {
            InitializeComponent();
        }
        
        private void loadTasks()
        {
            DB db = new DB();

            tasksDataGridView.Rows.Clear();

            string query = $"select tasks.id, tasks.title, tasks.description, tasks.endDate, tasks.isComplete from tasks " +
                $"where idTeacher = {Main.idTeacher}";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    var task = new Task();

                    task.id = int.Parse(reader["id"].ToString());
                    task.title = reader["title"].ToString();
                    task.description = reader["description"].ToString();
                    task.endDate = Convert.ToDateTime(reader["endDate"].ToString());
                    task.isCompleted = Convert.ToBoolean(reader["isComplete"]);
                   
                    _tasks.Add(task);

                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    tasksDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ntff =  new NewTaskForm(DateTime.Now, null);
            ntff.FormClosed += Ntff_FormClosed;
            ntff.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ntff = new NewTaskForm(DateTime.Now, _tasks.Where(x=>x.id == Convert.ToInt32(tasksDataGridView[0, tasksDataGridView.SelectedCells[0].RowIndex].Value)).First());
            ntff.FormClosed += Ntff_FormClosed;
            ntff.ShowDialog();
        }

        private void Ntff_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadTasks();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            loadTasks();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadTasks();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данную задачу?", "Внимание!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from tasks where ID =" + _tasks.Where(x => x.id == Convert.ToInt32(tasksDataGridView[0, tasksDataGridView.SelectedCells[0].RowIndex].Value)).First().id);
                NewTaskForm._delegateRefreshMethod(_tasks.Where(x => x.id == Convert.ToInt32(tasksDataGridView[0, tasksDataGridView.SelectedCells[0].RowIndex].Value)).First().endDate.Year, _tasks.Where(x => x.id == Convert.ToInt32(tasksDataGridView[0, tasksDataGridView.SelectedCells[0].RowIndex].Value)).First().endDate.Month);
                loadTasks();
            }
        }
    }
}
