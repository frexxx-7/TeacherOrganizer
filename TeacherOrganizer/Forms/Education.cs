using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherOrganizer.AddForms;
using TeacherOrganizer.Classes;

namespace TeacherOrganizer.Forms
{
    public partial class Education : Form
    {
        public Education()
        {
            InitializeComponent();
        }
        private void loadEducation()
        {
            DB db = new DB();

            educationTeacherDataGridView.Rows.Clear();

            string query = $"select education_teacher.id, education_teacher.name from education_teacher ";

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
                    educationTeacherDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEducation(null);
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEducation(educationTeacherDataGridView[0, educationTeacherDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }
        private void ae_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadEducation();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данное образование?", "Внимание!",
              MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from education_teacher where ID =" + educationTeacherDataGridView[0, educationTeacherDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadEducation();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadEducation();
        }

        private void Education_Load(object sender, EventArgs e)
        {
            loadEducation();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
