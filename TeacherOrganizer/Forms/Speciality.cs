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
    public partial class Speciality : Form
    {
        public Speciality()
        {
            InitializeComponent();
        }
        private void loadSpeciality()
        {
            DB db = new DB();

            specialityDataGridView.Rows.Clear();

            string query = $"select speciality.id, speciality.name from speciality ";

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
                    specialityDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var @as = new AddSpeciality(null);
            @as.FormClosed += as_FormClosed;
            @as.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var @as = new AddSpeciality(specialityDataGridView[0, specialityDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            @as.FormClosed += as_FormClosed;
            @as.ShowDialog();
        }
        private void as_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadSpeciality();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данную специальность?", "Внимание!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from speciality where ID =" + specialityDataGridView[0, specialityDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadSpeciality();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadSpeciality();
        }

        private void Speciality_Load(object sender, EventArgs e)
        {
            loadSpeciality();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
