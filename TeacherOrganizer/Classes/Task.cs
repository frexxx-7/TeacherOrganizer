using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherOrganizer.Classes
{
    internal class Task
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime endDate { get; set; }

        public bool isCompleted { get; set; } 
        public int idTeacher { get; set; }
    }
}
