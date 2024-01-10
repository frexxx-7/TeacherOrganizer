using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using TeacherOrganizer.Classes;
using Microsoft.Office.Interop.Word;

namespace TeacherOrganizer.Forms
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void OutputButton_Click(object sender, EventArgs e)
        {
            List<TeacherOrganizer.Classes.Task> tasks = new List<TeacherOrganizer.Classes.Task>();
            for (DateTime date = StartDateTimePicker.Value; date <= EndDateTimePicker.Value; date = date.AddDays(1))
            {
                tasks.AddRange(TasksDbFunc.GetTask(date));
            }
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document doc = wordApp.Documents.Add();

            foreach (TeacherOrganizer.Classes.Task task in tasks)
            {
                Paragraph para = doc.Content.Paragraphs.Add();
                para.Range.Text = $"{task.id}\n Заголовок:{task.title} \n Описание:{task.description} \n Выволнено:{task.isCompleted} \n \n";
                para.Range.InsertParagraphAfter();
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog1.Title = "Сохранить скопированный документ в";
            saveFileDialog1.ShowDialog();

            string targetPath = saveFileDialog1.FileName;
            doc.SaveAs2(targetPath);
            doc.Close();
            wordApp.Quit();

            Microsoft.Office.Interop.Word.Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            Document wordDocument = wordApplication.Documents.Open(targetPath);
            wordApplication.Visible = true;
        }
    }
}
