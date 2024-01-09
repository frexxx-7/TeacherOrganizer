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
    public partial class AcademicSubject : Form
    {
        public AcademicSubject()
        {
            InitializeComponent();
        }
        private void loadAcademicSubject()
        {
            DB db = new DB();

            academicSubjectDataGridView.Rows.Clear();

            string query = $"select academic_subject.id, academic_subject.name from academic_subject ";

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
                    academicSubjectDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var aas = new AddAcademicSubject(null);
            aas.FormClosed += aas_FormClosed;
            aas.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var aas = new AddAcademicSubject(academicSubjectDataGridView[0, academicSubjectDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            aas.FormClosed += aas_FormClosed;
            aas.ShowDialog();
        }
        private void aas_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadAcademicSubject();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данный академический предмет?", "Внимание!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from academic_subject where ID =" + academicSubjectDataGridView[0, academicSubjectDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadAcademicSubject();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadAcademicSubject();
        }

        private void AcademicSubject_Load(object sender, EventArgs e)
        {
            loadAcademicSubject();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
