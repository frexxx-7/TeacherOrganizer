using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherOrganizer.Calendar
{
    public partial class DayBlank : UserControl
    {
        private DateTime _currentDate;
        private Color _backColor;
        public DayBlank()
        {
            InitializeComponent();
        }
        public void Refresh(Color backColor, int day, DateTime date, Color foreColor)
        {
            BackColor = _backColor = backColor;
            dayNumber.Text = day.ToString();
            _currentDate = date;
            if (_currentDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                BackColor = Color.FromArgb(222, 255, 159, 67);

            dayNumber.ForeColor = foreColor;
        }

        private void DayBlank_MouseLeave(object sender, EventArgs e)
        {
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                AddAppointmentButton.Visible = false;
                BackColor = _backColor;
            }
        }

        private void DayBlank_MouseEnter(object sender, EventArgs e)
        {
            AddAppointmentButton.Visible = true;
            BackColor = Color.FromArgb(123, _backColor);
        }

        private void DayBlankControl_MouseClick(object sender, MouseEventArgs e)
        {
            // Next tutorial
            ActiveAppointmentPanel.Visible = true;
            ActiveAppointmentsLabel.Text = (int.Parse(ActiveAppointmentsLabel.Text) + 1).ToString();
        }

        private void DayBlank_Load_1(object sender, EventArgs e)
        {
            new List<Control> { dayNumber , AddAppointmentButton, ActiveAppointmentsLabel,ActiveAppointmentPanel,
            CompletedAppointmentsLabel,CompletedAppointmentPanel, this}.ForEach(x =>
            {
                x.MouseClick += DayBlankControl_MouseClick;
                x.MouseEnter += DayBlank_MouseEnter;
                x.MouseLeave += DayBlank_MouseLeave;
            });
        }
    }
}
