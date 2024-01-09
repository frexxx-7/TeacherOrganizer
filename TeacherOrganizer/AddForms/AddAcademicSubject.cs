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
    public partial class AddAcademicSubject : Form
    {
        private string idAcademicSubject = null;
        public AddAcademicSubject(string idAcademicSubject)
        {
            InitializeComponent();
            this.idAcademicSubject = idAcademicSubject;
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadAcademicSubjectInfo()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM academic_subject WHERE id = '{idAcademicSubject}'";
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
            if (idAcademicSubject == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into academic_subject (name) values(@name)", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Академический предмет добавлен");
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
                MySqlCommand command = new MySqlCommand($"update academic_subject set name=@name where id = {idAcademicSubject}", db.getConnection());
                command.Parameters.AddWithValue("@name", nameTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Академический предмет изменен");
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

        private void AddAcademicSubject_Load(object sender, EventArgs e)
        {

            if (idAcademicSubject != null)
            {
                label1.Text = "Редактировать академический предмет";
                loadAcademicSubjectInfo();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить академический предмет";
            }

        }
    }
}
