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

namespace TeacherOrganizer
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            new Registration().Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT id, CONCAT(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic) as FIOTeacher, password FROM teachers WHERE CONCAT(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic) = @fio AND password = @uP", db.getConnection());

            command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = FIOTextBox.Text;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = PasswordTextBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                Main.idTeacher = table.Rows[0]["id"].ToString();
                Main main = new Main();
                this.Hide();
                main.Show();
                MessageBox.Show("Добро пожаловать");
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
