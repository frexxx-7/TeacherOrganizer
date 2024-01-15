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
    public partial class AddGroups : Form
    {
        private string idGroup;
        public AddGroups(string idGroup)
        {
            InitializeComponent();
            this.idGroup = idGroup;
        }
        private void loadInfoGroup()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM groups WHERE id = '{idGroup}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < specialityComboBox.Items.Count; i++)
                {
                    if (reader["idSpeciality"].ToString() != "")
                    {
                        if (Convert.ToInt32((specialityComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idSpeciality"]))
                        {
                            specialityComboBox.SelectedIndex = i;
                        }
                    }
                }
                
                nameTextBox.Text = reader["name"].ToString();
                dateReceiptDateTimePicker.Value = Convert.ToDateTime(reader["receipt_date"].ToString());
            }
            reader.Close();

            db.closeConnection();
        }

        private void loadSpecialityInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM speciality";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                specialityComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idGroup == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into groups (name, receipt_date, idSpeciality) values(@name, @receipt_date, @idSpeciality)", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                command.Parameters.AddWithValue("@receipt_date", dateReceiptDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@idSpeciality", (specialityComboBox.SelectedItem as ComboBoxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Группа добавлена");
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
                MySqlCommand command = new MySqlCommand($"update groups set name=@name, receipt_date=@receipt_date, idSpeciality=@idSpeciality where id = {idGroup}", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                command.Parameters.AddWithValue("@receipt_date", dateReceiptDateTimePicker.Value.ToString("yyyy.MM.dd"));
                command.Parameters.AddWithValue("@idSpeciality", (specialityComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Группа изменена");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            loadSpecialityInfo();

            if (idGroup != null)
            {
                label1.Text = "Редактировать группу";
                loadInfoGroup();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить группу";
            }
                
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
