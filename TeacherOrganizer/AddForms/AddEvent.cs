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
using TeacherOrganizer.Classes;
using TeacherOrganizer.Forms;

namespace TeacherOrganizer.AddForms
{
    public partial class AddEvent : Form
    {
        private string idEvent;
        public AddEvent(string idEvent)
        {
            InitializeComponent();
            this.idEvent = idEvent;
        }
        private void loadEventInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM events WHERE id = '{idEvent}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                nameTextBox.Text = reader["name"].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idEvent == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into events (name) values(@name)", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Мероприятие добавлено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update events set name=@name where id = {idEvent}", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Мероприятие изменено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEvent_Load(object sender, EventArgs e)
        {
            if (idEvent != null)
            {
                label1.Text = "Редактировать мероприятие";
                loadEventInfo();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить мероприятие";
            }
        }
    }
}
