using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeacherOrganizer.AddForms;
using TeacherOrganizer.Classes;

namespace TeacherOrganizer.Forms
{
    public partial class Burder : Form
    {
        private List<Task> _tasks = new List<Task>();
        public Burder()
        {
            InitializeComponent();
        }
        
        private void loadBurder()
        {
            DB db = new DB();

            burderDataGridView.Rows.Clear();

            string query = $"select burder.id, groups.name, burder.count_hours, academic_subject.name from burder " +
                $"inner join groups on burder.idGroup = groups.id " +
                $"inner join academic_subject on burder.idAcademicSubject = academic_subject.id " +
                $"where idTeacher = {Main.idTeacher}";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    burderDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ab =  new AddBurder(null);
            ab.FormClosed += ab_FormClosed;
            ab.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ab = new AddBurder(burderDataGridView[0, burderDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ab.FormClosed += ab_FormClosed;
            ab.ShowDialog();
        }

        private void ab_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadBurder();
        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            loadBurder();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadBurder();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данную нагрузку?", "Внимание!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from burder where ID =" + burderDataGridView[0, burderDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadBurder();
            }
        }
    }
}
