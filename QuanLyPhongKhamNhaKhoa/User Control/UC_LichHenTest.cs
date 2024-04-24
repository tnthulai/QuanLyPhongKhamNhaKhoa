﻿using QuanLyPhongKhamNhaKhoa.Dao;
using QuanLyPhongKhamNhaKhoa.Entity;
using QuanLyPhongKhamNhaKhoa.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public partial class UC_LichHenTest : UserControl
    {
        AppointmentDao app = new AppointmentDao();

        private TableLayoutPanel tableLayoutPanel;
        private Label[] timeLabels;
        private Label[] dayLabels;
        private Panel[,] schedulePanels;
        private DateTime currentDate = DateTime.Today;
        private const int RowHeight = 60; // Chiều cao cho mỗi dòng

        private static UC_LichHenTest _instance;
        //Contants cons = new Contants();
        public static UC_LichHenTest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_LichHenTest();
                return _instance;
            }
        }

        private void UC_LichHenTest_Load(object sender, EventArgs e)
        {
            InitializeCalendar();
        }
        public UC_LichHenTest()
        {
            InitializeComponent();
        }

        private void hienThiLichHen()
        {
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + 1);
            DateTime endDate = startDate.AddDays(6);

            SqlCommand command = new SqlCommand("SELECT fullName, startTime, endTime, appointmentDate FROM Appointment a  join Patients p on a.patientsID = p.patientsID WHERE userID=@userID AND appointmentDate BETWEEN @startDate AND @endDate");
            command.Parameters.Add("@userID", SqlDbType.VarChar).Value = "DENT5705";
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDate;

            DataTable table = app.getAppointment(command);

            foreach (DataRow row in table.Rows)
            {
                TimeSpan startTime = (TimeSpan)row["startTime"];
                TimeSpan endTime = (TimeSpan)row["endTime"];
                DateTime appointmentDate = (DateTime)row["appointmentDate"];

                int startHour = startTime.Hours;
                int endHour = endTime.Hours;

                int dayIndex = (int)appointmentDate.DayOfWeek - 1; // 0 for Monday, 1 for Tuesday, etc.
                if (dayIndex == -1) dayIndex = 6; // Adjust for Sunday

                for (int hour = startHour; hour < endHour; hour++)
                {
                    // Kiểm tra xem hour có nằm trong khoảng 8 đến 16 không
                    if (hour >= 8 && hour <= 16)
                    {
                        schedulePanels[dayIndex, hour - 8].BackColor = Color.LightBlue;
                        
                    }
                }
            }
        }

        private void InitializeCalendar()
        {
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.AutoScroll = true;

            // Thiết lập cột cho TableLayoutPanel
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // Cột cho thời gian
            for (int i = 0; i < 7; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / 7));
            }

            // Thiết lập dòng cho TableLayoutPanel
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // Dòng cố định cho thứ
            for (int i = 0; i < 10; i++) // 9 dòng cho khoảng thời gian từ 8h đến 16h
            {

                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Dòng cho thời gian
            }

            // Thêm thời gian vào TableLayoutPanel
            timeLabels = new Label[10];
            for (int hour = 7; hour <= 16; hour++)
            {
                Label timeLabel = new Label
                {
                    Text = $"{hour}:00",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    ForeColor = Color.Blue
                };
                tableLayoutPanel.Controls.Add(timeLabel, 0, hour - 7);
                timeLabels[hour - 7] = timeLabel;
            }

            // Thêm các ngày vào TableLayoutPanel
            dayLabels = new Label[7];
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            for (int i = 0; i < 7; i++)
            {
                string dayName = startDate.AddDays(i).ToString("ddd d/M");
                dayLabels[i] = new Label
                {
                    Text = dayName,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                tableLayoutPanel.Controls.Add(dayLabels[i], i + 1, 0);
            }

            // Thêm các Panel cho việc lên lịch
            schedulePanels = new Panel[7, 9];
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(j !=4 )
                    {
                        schedulePanels[i, j] = new Panel
                        {
                            BorderStyle = BorderStyle.FixedSingle,
                            Dock = DockStyle.Fill
                        };
                        tableLayoutPanel.Controls.Add(schedulePanels[i, j], i + 1, j + 1);
                    }
                    
                }
            }

            // Thêm TableLayoutPanel vào Panel đã thiết kế
            Panel panel = this.Controls["panelDate"] as Panel;
            if (panel != null)
            {
                panel.Controls.Add(tableLayoutPanel);
            }

            UpdateCalendar();

        }
        private void UpdateCalendar()
        {
            DateTime now = DateTime.Now;

            for (int i = 0; i < 7; i++)
            {
                DateTime day = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday + i);
                string dayName = day.ToString("ddd d");
                dayLabels[i].Text = dayName;

                // Tô màu cho ngày hiện tại
                if (day.Date == DateTime.Today)
                {
                    dayLabels[i].BackColor = Color.LightGray;
                }
                else
                {
                    dayLabels[i].BackColor = Color.Transparent;
                }

                // Reset màu của các ô trong lịch
                for (int hour = 8; hour <= 16; hour++)
                {
                    if (hour != 12)
                    {
                        schedulePanels[i, hour - 8].BackColor = Color.Transparent;
                    }
                    
                }
            }

            tableLayoutPanel.Controls.Remove(dayLabels[0]);
            tableLayoutPanel.Controls.Add(dayLabels[0], 1, 0);
            tableLayoutPanel.Controls.SetChildIndex(dayLabels[0], 8);

            Label monthYearLabel = tableLayoutPanel.Controls[0] as Label;
            if (monthYearLabel != null)
            {
                monthYearLabel.Text = currentDate.ToString("MMMM yyyy");
            }

            for (int hour = 8; hour <= 16; hour++)
            {
                Label timeLabel = timeLabels[hour - 8];

                // Tô màu cho thời gian hiện tại của ngày hiện tại
                if (currentDate.Date == DateTime.Today && now.Hour == hour)
                {
                    timeLabel.BackColor = Color.LightGreen;
                }
                else
                {
                    timeLabel.BackColor = Color.Transparent;
                }
            }

            hienThiLichHen();
        }
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            currentDate = dtpkDate.Value;
            UpdateCalendar();
        }

    }
}
