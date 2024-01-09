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
    public partial class Events : Form
    {
        public Events()
        {
            InitializeComponent();
        }
        private void loadEvent()
        {
            DB db = new DB();

            eventsDataGridView.Rows.Clear();

            string query = $"select events.id, events.name from events ";

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
                    eventsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEvent(null);
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEvent(eventsDataGridView[0, eventsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }
        private void ae_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadEvent();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить данное мероприятие?", "Внимание!",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                TasksDbFunc.ExecuteQuery("delete from events where ID =" + eventsDataGridView[0, eventsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
                loadEvent();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadEvent();
        }

        private void Events_Load(object sender, EventArgs e)
        {
            loadEvent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
