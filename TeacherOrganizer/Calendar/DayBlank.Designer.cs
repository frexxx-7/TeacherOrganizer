namespace TeacherOrganizer.Calendar
{
    partial class DayBlank
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
            this.ActiveAppointmentPanel = new System.Windows.Forms.Panel();
            this.ActiveAppointmentsLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CompletedAppointmentPanel = new System.Windows.Forms.Panel();
            this.CompletedAppointmentsLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dayNumber = new System.Windows.Forms.Label();
            this.AddAppointmentButton = new System.Windows.Forms.Button();
            this.ActiveAppointmentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CompletedAppointmentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveAppointmentPanel
            // 
            this.ActiveAppointmentPanel.BackColor = System.Drawing.Color.Transparent;
            this.ActiveAppointmentPanel.Controls.Add(this.ActiveAppointmentsLabel);
            this.ActiveAppointmentPanel.Controls.Add(this.pictureBox1);
            this.ActiveAppointmentPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ActiveAppointmentPanel.Location = new System.Drawing.Point(128, 0);
            this.ActiveAppointmentPanel.Name = "ActiveAppointmentPanel";
            this.ActiveAppointmentPanel.Size = new System.Drawing.Size(42, 84);
            this.ActiveAppointmentPanel.TabIndex = 2;
            this.ActiveAppointmentPanel.Visible = false;
            // 
            // ActiveAppointmentsLabel
            // 
            this.ActiveAppointmentsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActiveAppointmentsLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActiveAppointmentsLabel.ForeColor = System.Drawing.Color.Tomato;
            this.ActiveAppointmentsLabel.Location = new System.Drawing.Point(0, 44);
            this.ActiveAppointmentsLabel.Name = "ActiveAppointmentsLabel";
            this.ActiveAppointmentsLabel.Size = new System.Drawing.Size(42, 40);
            this.ActiveAppointmentsLabel.TabIndex = 1;
            this.ActiveAppointmentsLabel.Text = "01";
            this.ActiveAppointmentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CompletedAppointmentPanel
            // 
            this.CompletedAppointmentPanel.BackColor = System.Drawing.Color.Transparent;
            this.CompletedAppointmentPanel.Controls.Add(this.CompletedAppointmentsLabel);
            this.CompletedAppointmentPanel.Controls.Add(this.pictureBox2);
            this.CompletedAppointmentPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CompletedAppointmentPanel.Location = new System.Drawing.Point(86, 0);
            this.CompletedAppointmentPanel.Name = "CompletedAppointmentPanel";
            this.CompletedAppointmentPanel.Size = new System.Drawing.Size(42, 84);
            this.CompletedAppointmentPanel.TabIndex = 3;
            this.CompletedAppointmentPanel.Visible = false;
            // 
            // CompletedAppointmentsLabel
            // 
            this.CompletedAppointmentsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompletedAppointmentsLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompletedAppointmentsLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.CompletedAppointmentsLabel.Location = new System.Drawing.Point(0, 44);
            this.CompletedAppointmentsLabel.Name = "CompletedAppointmentsLabel";
            this.CompletedAppointmentsLabel.Size = new System.Drawing.Size(42, 40);
            this.CompletedAppointmentsLabel.TabIndex = 2;
            this.CompletedAppointmentsLabel.Text = "01";
            this.CompletedAppointmentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // dayNumber
            // 
            this.dayNumber.BackColor = System.Drawing.Color.Transparent;
            this.dayNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dayNumber.Location = new System.Drawing.Point(-2, 0);
            this.dayNumber.Name = "dayNumber";
            this.dayNumber.Size = new System.Drawing.Size(52, 44);
            this.dayNumber.TabIndex = 4;
            this.dayNumber.Text = "01";
            this.dayNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddAppointmentButton
            // 
            this.AddAppointmentButton.BackColor = System.Drawing.Color.Transparent;
            this.AddAppointmentButton.FlatAppearance.BorderSize = 0;
            this.AddAppointmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAppointmentButton.Location = new System.Drawing.Point(0, 71);
            this.AddAppointmentButton.Name = "AddAppointmentButton";
            this.AddAppointmentButton.Size = new System.Drawing.Size(50, 45);
            this.AddAppointmentButton.TabIndex = 5;
            this.AddAppointmentButton.UseVisualStyleBackColor = false;
            this.AddAppointmentButton.Visible = false;
            // 
            // DayBlank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddAppointmentButton);
            this.Controls.Add(this.dayNumber);
            this.Controls.Add(this.CompletedAppointmentPanel);
            this.Controls.Add(this.ActiveAppointmentPanel);
            this.Name = "DayBlank";
            this.Size = new System.Drawing.Size(170, 84);
            this.Load += new System.EventHandler(this.DayBlank_Load_1);
            this.ActiveAppointmentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CompletedAppointmentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ActiveAppointmentPanel;
        private System.Windows.Forms.Label ActiveAppointmentsLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel CompletedAppointmentPanel;
        private System.Windows.Forms.Label CompletedAppointmentsLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label dayNumber;
        private System.Windows.Forms.Button AddAppointmentButton;
    }
}
