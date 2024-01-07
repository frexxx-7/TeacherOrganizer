using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TeacherOrganizer.Classes
{
    internal class TasksDbFunc
    {
        private readonly static DB db = new DB();
        public static List<Task> GetTask(DateTime date)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM Tasks WHERE endDate = @Date", db.getConnection());
            mySqlCommand.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
            var appointments = new List<Task>();
            db.openConnection();
            mySqlCommand = new MySqlCommand();
            var reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var appointment = new Task();

                appointment.id = int.Parse(reader["id"].ToString());
                appointment.title = reader["title"].ToString();
                appointment.description = reader["description"].ToString();
                appointment.endDate = Convert.ToDateTime(reader["endDate"].ToString());
                appointment.isCompleted = Convert.ToBoolean(reader["isCompleted"]);
                appointment.idTeacher = int.Parse(reader["idTeacher"].ToString());
                appointments.Add(appointment);
            }
            return appointments;
        }
        public static void AddTask(Task task)
        {
            MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO Tasks (title, description, endDate, IsCompleted) " +
                    "VALUES (@title, @description, @endDate, 0)", db.getConnection());
            db.openConnection();
            mySqlCommand.Parameters.AddWithValue("@title", task.title);
            mySqlCommand.Parameters.AddWithValue("@description", task.description);
            mySqlCommand.Parameters.AddWithValue("@endDate", task.endDate.ToString("yyyy-MM-dd"));
            mySqlCommand.ExecuteNonQuery();
        }
        public static void UpdateTask(Task task)
        {
            MySqlCommand mySqlCommand;
            db.openConnection();
            if (task.isCompleted)
            {
                mySqlCommand = new MySqlCommand("UPDATE Tasks SET title = @title, description = @description, " +
                    "endDate = @endDate, IsCompleted = 1 WHERE id = @id", db.getConnection());
            }
            else
            {
                mySqlCommand = new MySqlCommand("UPDATE Tasks SET title = @title, description = @description, " +
                    "endDate = @endDate WHERE id = @id", db.getConnection());
            }
            mySqlCommand.Parameters.AddWithValue("@title", task.title);
            mySqlCommand.Parameters.AddWithValue("@description", task.description);
            mySqlCommand.Parameters.AddWithValue("@endDate", task.endDate.ToString("yyyy-MM-dd"));
            mySqlCommand.Parameters.AddWithValue("@id", task.id);
            mySqlCommand.ExecuteNonQuery();
        }
        public static void ExecuteQuery(string query)
        {
            db.openConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection());
            mySqlCommand.ExecuteNonQuery();
        }
        public static int GetNextTaskID()
        {
            db.openConnection();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'teacherorganizer' AND TABLE_NAME = 'Tasks'", db.getConnection());
                return Convert.ToInt32(mySqlCommand.ExecuteScalar());
        }
    }
}
