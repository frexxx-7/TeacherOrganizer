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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeacherOrganizer.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            new Autorization().Show();
            this.Close();
        }
        private void loadInfoEducation()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM education_teacher";
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
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            if (
                NameTextBox.Text.Length == 0 || SurnameTextBox.Text.Length == 0 || PatronymicTextBox.Text.Length == 0 ||
                PhoneNumberTextBox.Text.Length == 0 || HomePhoneTextBox.Text.Length == 0 || AddressTextBox.Text.Length == 0 ||
                PassportTextBox.Text.Length == 0 
                )
            {
                MessageBox.Show("Данные введены некорректно");
            }else
            if (PasswordTextBox.Text != RepeatPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                DB db = new DB();

                MySqlCommand command = new MySqlCommand("insert into teachers " +
                    "(name, patronymic, surname, home_number, phone_number, address, passport, password, id_education)" +
                    "values (@name, @patronymic, @surname, @home_number, @phone_number, @address, @passport, @password, @id_education)" +
                    "" +
                    "", db.getConnection());

                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameTextBox.Text;
                command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = PatronymicTextBox.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = SurnameTextBox.Text;
                command.Parameters.Add("@home_number", MySqlDbType.VarChar).Value = HomePhoneTextBox.Text;
                command.Parameters.Add("@phone_number", MySqlDbType.VarChar).Value = PhoneNumberTextBox.Text;
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = AddressTextBox.Text;
                command.Parameters.Add("@passport", MySqlDbType.VarChar).Value = PassportTextBox.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PasswordTextBox.Text;
                command.Parameters.Add("@id_education", MySqlDbType.Int32).Value = Convert.ToInt32((EducationComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт создан!");
                    Autorization auth = new Autorization();
                    auth.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка создания аккаунта");
                }

                db.closeConnection();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            loadInfoEducation();
        }
    }
}
