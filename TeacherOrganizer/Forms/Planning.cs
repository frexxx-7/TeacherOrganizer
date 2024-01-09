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
    public partial class Planning : Form
    {
        public Planning()
        {
            InitializeComponent();
        }
        private void loadPlanninig()
        {
            DB db = new DB();

            planningDataGridView.Rows.Clear();

            string query = $"select planning.id, events.name, planning.plan_execution_date, planning.actual_execution_date from planning " +
                $"inner join events on events.id = planning.idEvent " +
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
                    planningDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ap = new AddPlanning(null);
            ap.FormClosed += ap_FormClosed;
            ap.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ap = new AddPlanning(planningDataGridView[0, planningDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ap.FormClosed += ap_FormClosed;
            ap.ShowDialog();
        }
        private void ap_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadPlanninig();
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данное планирование?", "Внимание!",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from planning where ID =" + planningDataGridView[0, planningDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadPlanninig();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadPlanninig();
        }

        private void Planning_Load(object sender, EventArgs e)
        {
            loadPlanninig();
        }
    }
}
