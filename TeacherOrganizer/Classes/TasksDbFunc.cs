﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TeacherOrganizer.Forms;

namespace TeacherOrganizer.Classes
{
    internal class TasksDbFunc
    {
        public static List<Task> GetTask(DateTime date)
        {
            DB db = new DB();
            MySqlCommand mySqlCommand = new MySqlCommand($"SELECT * FROM tasks WHERE endDate = @Date and idTeacher = {Main.idTeacher}", db.getConnection());
            db.openConnection();
            mySqlCommand.Parameters.AddWithValue("@Date", date.ToString("yyyy-MM-dd"));
            var tasks = new List<Task>();
            var reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var task = new Task();

                task.id = int.Parse(reader["id"].ToString());
                task.title = reader["title"].ToString();
                task.description = reader["description"].ToString();
                task.endDate = Convert.ToDateTime(reader["endDate"].ToString());
                task.isCompleted = Convert.ToBoolean(reader["isComplete"]);
                if (reader["idTeacher"].ToString() != "")
                    task.idTeacher = int.Parse(reader["idTeacher"].ToString());
                tasks.Add(task);
            }
            db.closeConnection();
            return tasks;
        }
        public static void AddTask(Task task)
        {
            DB db = new DB();
            MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO Tasks (title, description, endDate, IsComplete, idTeacher) " +
                    $"VALUES (@title, @description, @endDate, 0, {Main.idTeacher})", db.getConnection());
            db.openConnection();
            mySqlCommand.Parameters.AddWithValue("@title", task.title);
            mySqlCommand.Parameters.AddWithValue("@description", task.description);
            mySqlCommand.Parameters.AddWithValue("@endDate", task.endDate.ToString("yyyy-MM-dd"));
            mySqlCommand.ExecuteNonQuery();
            db.closeConnection();
        }
        public static void UpdateTask(Task task)
        {
            DB db = new DB();
            MySqlCommand mySqlCommand;
            db.openConnection();
            if (task.isCompleted)
            {
                mySqlCommand = new MySqlCommand("UPDATE Tasks SET title = @title, description = @description, " +
                    "endDate = @endDate, IsComplete = 1 WHERE id = @id", db.getConnection());
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
            db.closeConnection();
        }
        public static void ExecuteQuery(string query)
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection());
            mySqlCommand.ExecuteNonQuery();
            db.closeConnection();
        }
        public static int GetNextTaskID()
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'teacherorganizer' AND TABLE_NAME = 'Tasks'", db.getConnection());
            return Convert.ToInt32(mySqlCommand.ExecuteScalar());
            db.closeConnection();
        }
    }
}
