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
    public partial class Groups : Form
    {
        public Groups()
        {
            InitializeComponent();
        }
        private void loadGroups()
        {
            DB db = new DB();

            groupsDataGridView.Rows.Clear();

            string query = $"select groups.id, groups.name, groups.receipt_date, speciality.name from groups " +
                $"inner join speciality on groups.idSpeciality = speciality.id";

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
                    groupsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ag = new AddGroups(null);
            ag.FormClosed += ag_FormClosed;
            ag.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

            var ag = new AddGroups(groupsDataGridView[0, groupsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ag.FormClosed += ag_FormClosed;
            ag.ShowDialog();
        }
        private void ag_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadGroups();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            loadGroups();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadGroups();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данную группу?", "Внимание!",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from groups where ID =" + groupsDataGridView[0, groupsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadGroups();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
