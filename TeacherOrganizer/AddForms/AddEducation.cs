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
    public partial class AddEducation : Form
    {
        private string idEducation;
        public AddEducation(string idEducation)
        {
            InitializeComponent();
            this.idEducation= idEducation;
        }
        private void loadEducationInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM education_teacher WHERE id = '{idEducation}'";
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
            if (idEducation == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into education_teacher (name) values(@name)", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Образование добавлено");
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
                MySqlCommand command = new MySqlCommand($"update education_teacher set name=@name where id = {idEducation}", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Образование изменено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEducation_Load(object sender, EventArgs e)
        {
            if (idEducation != null)
            {
                label1.Text = "Редактировать образование";
                loadEducationInfo();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить образование";
            }
        }
    }
}
