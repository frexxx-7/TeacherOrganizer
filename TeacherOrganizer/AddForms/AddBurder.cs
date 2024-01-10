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
    public partial class AddBurder : Form
    {
        private string idBurder = null;
        public AddBurder(string idBurder)
        {
            InitializeComponent();
            this.idBurder = idBurder;
        }
        private void loadInfoBurder()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM burder WHERE id = '{idBurder}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < groupComboBox.Items.Count; i++)
                {
                    if (reader["idGroup"].ToString() != "")
                    {
                        if (Convert.ToInt32((groupComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idGroup"]))
                        {
                            groupComboBox.SelectedIndex = i;
                        }
                    }
                }
                for (int i = 0; i < academicSubjectComboBox.Items.Count; i++)
                {
                    if (reader["idAcademicSubject"].ToString() != "")
                    {
                        if (Convert.ToInt32((academicSubjectComboBox.Items[i] as ComboBoxItem).Value) == Convert.ToInt32(reader["idAcademicSubject"]))
                        {
                            academicSubjectComboBox.SelectedIndex = i;
                        }
                    }
                }
                CountHoursTextBox.Text = reader["count_hours"].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoGroups()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM groups";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                groupComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoAcademicSubject()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM academic_subject";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                academicSubjectComboBox.Items.Add(item);
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
            if (idBurder == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into burder (idGroup, idTeacher, count_hours, idAcademicSubject) values(@idGroup, @idTeacher, @count_hours, @idAcademicSubject)", db.getConnection());
                command.Parameters.AddWithValue("@idGroup", (groupComboBox.SelectedItem as ComboBoxItem).Value);
                command.Parameters.AddWithValue("@idTeacher", Main.idTeacher);
                command.Parameters.AddWithValue("@count_hours", CountHoursTextBox.Text);
                command.Parameters.AddWithValue("@idAcademicSubject", (academicSubjectComboBox.SelectedItem as ComboBoxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Нагрузка добавлена");
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
                MySqlCommand command = new MySqlCommand($"update burder set idGroup=@idGroup, idTeacher=@idTeacher, count_hours=@count_hours, idAcademicSubject=@idAcademicSubject where id = {idBurder}", db.getConnection());
                command.Parameters.AddWithValue("@idGroup", (groupComboBox.SelectedItem as ComboBoxItem).Value);
                command.Parameters.AddWithValue("@idTeacher", Main.idTeacher);
                command.Parameters.AddWithValue("@count_hours", CountHoursTextBox.Text);
                command.Parameters.AddWithValue("@idAcademicSubject", (academicSubjectComboBox.SelectedItem as ComboBoxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Нагрузка изменена");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddBurder_Load(object sender, EventArgs e)
        {
            loadInfoGroups();
            loadInfoAcademicSubject();

            if (idBurder != null)
            {
                label1.Text = "Редактировать нагрузку";
                loadInfoBurder();
                AddButton.Text = "Редактировать";
            }
            else
            {
                label1.Text = "Добавить нагрузку";
            }
        }
    }
}
