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
    public partial class AddSpeciality : Form
    {
        private string idSpeciality = null;
        public AddSpeciality(string idSpeciality)
        {
            InitializeComponent();
            this.idSpeciality = idSpeciality;
        }
        private void loadSpecialitytInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM speciality WHERE id = '{idSpeciality}'";
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
            if (idSpeciality == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into speciality (name) values(@name)", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Специальность добавлена");
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
                MySqlCommand command = new MySqlCommand($"update speciality set name=@name where id = {idSpeciality}", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Специальность изменена");
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

        private void AddSpeciality_Load(object sender, EventArgs e)
        {
            if (idSpeciality != null)
            {
                label1.Text = "Редактировать специальность";
                loadSpecialitytInfo();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить специальность";
            }
        }
    }
}
