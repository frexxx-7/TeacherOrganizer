namespace TeacherOrganizer.UserControls
{
    partial class TaskViewPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyDateTimePicker = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // MyDateTimePicker
            // 
            this.MyDateTimePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.MyDateTimePicker.Checked = true;
            this.MyDateTimePicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.MyDateTimePicker.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(255)))));
            this.MyDateTimePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MyDateTimePicker.ForeColor = System.Drawing.Color.White;
            this.MyDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.MyDateTimePicker.Location = new System.Drawing.Point(0, 0);
            this.MyDateTimePicker.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.MyDateTimePicker.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.MyDateTimePicker.Name = "MyDateTimePicker";
            this.MyDateTimePicker.Size = new System.Drawing.Size(289, 36);
            this.MyDateTimePicker.TabIndex = 30;
            this.MyDateTimePicker.Value = new System.DateTime(2024, 1, 8, 14, 54, 27, 789);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 36);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(289, 481);
            this.guna2Panel1.TabIndex = 31;
            // 
            // TaskViewPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.MyDateTimePicker);
            this.Name = "TaskViewPanel";
            this.Size = new System.Drawing.Size(289, 517);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DateTimePicker MyDateTimePicker;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
