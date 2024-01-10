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
    public partial class Profile : Form
    {
        private bool isEdit = false;
        public Profile()
        {
            InitializeComponent();
        }
        private void loadInfoEducation()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM education_teacher";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                EducationComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoProfile()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM teachers WHERE id = '{Main.idTeacher}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                SurnameTextBox.Text = reader["surname"].ToString();
                NameTextBox.Text = reader["name"].ToString();
                PatronymicTextBox.Text = reader["patronymic"].ToString();
                PhoneNumberTextBox.Text = reader["phone_number"].ToString();
                HomePhoneTextBox.Text = reader["home_number"].ToString();
                AddressTextBox.Text = reader["address"].ToString();
                PassportTextBox.Text = reader["passport"].ToString();
                for (int i = 0; i < EducationComboBox.Items.Count; i++)
                {
                    if (reader["id_education"].ToString() != "")
                    {
                        if (Convert.ToInt32((EducationComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["id_education"]))
                        {
                            EducationComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Main.mainForm.Close();
            new Autorization().Show();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadInfoEducation();
            loadInfoProfile();
            SurnameTextBox.Enabled = false;
            NameTextBox.Enabled = false;
            PatronymicTextBox.Enabled = false;
            PhoneNumberTextBox.Enabled= false;
            HomePhoneTextBox.Enabled= false;
            AddressTextBox.Enabled = false;
            PassportTextBox.Enabled = false;
            EducationComboBox.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                DB db = new DB();
                EditButton.Text = "Редактировать";
                isEdit = !isEdit;
                SurnameTextBox.Enabled = false;
                NameTextBox.Enabled = false;
                PatronymicTextBox.Enabled = false;
                PhoneNumberTextBox.Enabled = false;
                HomePhoneTextBox.Enabled = false;
                AddressTextBox.Enabled = false;
                PassportTextBox.Enabled = false;
                EducationComboBox.Enabled = false;

                MySqlCommand command = new MySqlCommand($"update teachers set name=@name, patronymic=@patronymic, surname=@surname, home_number=@home_number, " +
                    $"phone_number=@phone_number, address=@address, passport=@passport, id_education=@id_education " +
                    $"where id = {Main.idTeacher}", db.getConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBox.Text;
                command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = PatronymicTextBox.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBox.Text;
                command.Parameters.Add("@home_number", MySqlDbType.VarChar).Value = HomePhoneTextBox.Text;
                command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = PhoneNumberTextBox.Text;
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = AddressTextBox.Text;
                command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = PassportTextBox.Text;
                command.Parameters.Add("@id_education", MySqlDbType.Int32).Value = Convert.ToInt32((EducationComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Профиль изменен");

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                EditButton.Text = "Сохранить";
                isEdit = !isEdit;
                SurnameTextBox.Enabled = true;
                NameTextBox.Enabled = true;
                PatronymicTextBox.Enabled = true;
                PhoneNumberTextBox.Enabled = true;
                HomePhoneTextBox.Enabled = true;
                AddressTextBox.Enabled = true;
                PassportTextBox.Enabled = true;
                EducationComboBox.Enabled = true;
            }
        }
    }
}
