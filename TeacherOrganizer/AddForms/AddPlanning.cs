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
    public partial class AddPlanning : Form
    {
        private string idPlanning;
        public AddPlanning(string idPlanning)
        {
            InitializeComponent();
            this.idPlanning = idPlanning;
        }
        private void loadInfoPlanning()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM planning WHERE id = '{idPlanning}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < eventComboBox.Items.Count; i++)
                {
                    if (reader["idEvent"].ToString() != "")
                    {
                        if (Convert.ToInt32((eventComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idEvent"]))
                        {
                            eventComboBox.SelectedIndex = i;
                        }
                    }
                }
                
                planExecutionDateDateTimePicker.Text = reader["plan_execution_date"].ToString();
                actualExecutionDateTimePicker.Text = reader["actual_execution_date"].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoEvent()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM events";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                eventComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idPlanning == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into planning (idEvent, plan_execution_date, actual_execution_date, idTeacher) values(@idEvent, @plan_execution_date, @actual_execution_date, @idTeacher)", db.getConnection());
                command.Parameters.AddWithValue("@idEvent", (eventComboBox.SelectedItem as ComboBoxItem).Value);
                command.Parameters.AddWithValue("@plan_execution_date", planExecutionDateDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@actual_execution_date", actualExecutionDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@idTeacher", Main.idTeacher);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Планирование добавлено");
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
                MySqlCommand command = new MySqlCommand($"update planning set idEvent=@idEvent, plan_execution_date=@plan_execution_date, actual_execution_date=@actual_execution_date, idTeacher=@idTeacher where id = {idPlanning}", db.getConnection());
                command.Parameters.AddWithValue("@idEvent", (eventComboBox.SelectedItem as ComboBoxItem).Value);
                command.Parameters.AddWithValue("@plan_execution_date", planExecutionDateDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@actual_execution_date", actualExecutionDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@idTeacher", Main.idTeacher);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Планирование добавлено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddPlanning_Load(object sender, EventArgs e)
        {
            loadInfoEvent();

            if (idPlanning != null)
            {
                label1.Text = "Редактировать планирование";
                loadInfoPlanning();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить планирование";
            }
        }
    }
}
