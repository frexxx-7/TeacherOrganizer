using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherOrganizer.Forms;

namespace TeacherOrganizer.Classes
{
    internal class Singleton
    {
        private static Singleton _instance;
        private Main _main;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }
        public Main Main
        {
            get
            {
                if (_main == null || _main.IsDisposed)
                    _main = new Main();
                return _main;
            }
        }
    }
}
