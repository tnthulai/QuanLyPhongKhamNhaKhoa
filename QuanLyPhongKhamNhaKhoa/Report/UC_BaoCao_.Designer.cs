namespace QuanLyPhongKhamNhaKhoa.Report
{
    partial class UC_BaoCao_
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.NgayItemToolTip = new System.Windows.Forms.ToolStripMenuItem();
            this.thangItemToolTip = new System.Windows.Forms.ToolStripMenuItem();
            this.NamItemToolTip = new System.Windows.Forms.ToolStripMenuItem();
            this.pkdateTime = new System.Windows.Forms.DateTimePicker();
            this.dataDanhSachHoaDon = new System.Windows.Forms.DataGridView();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lblSLDieuTri = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.uC_BaoCaoTheoNam1 = new QuanLyPhongKhamNhaKhoa.Report.UC_BaoCaoTheoNam();
            this.uC_BaoCaoTheoThang1 = new QuanLyPhongKhamNhaKhoa.User_Control.UC_BaoCaoTheoThang();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDanhSachHoaDon)).BeginInit();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NgayItemToolTip,
            this.thangItemToolTip,
            this.NamItemToolTip});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(13, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1936, 44);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip1";
            // 
            // NgayItemToolTip
            // 
            this.NgayItemToolTip.Checked = true;
            this.NgayItemToolTip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NgayItemToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgayItemToolTip.Name = "NgayItemToolTip";
            this.NgayItemToolTip.Padding = new System.Windows.Forms.Padding(3);
            this.NgayItemToolTip.Size = new System.Drawing.Size(72, 38);
            this.NgayItemToolTip.Text = "Ngày";
            this.NgayItemToolTip.Click += new System.EventHandler(this.NgayItemToolTip_Click);
            // 
            // thangItemToolTip
            // 
            this.thangItemToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thangItemToolTip.Name = "thangItemToolTip";
            this.thangItemToolTip.Padding = new System.Windows.Forms.Padding(3);
            this.thangItemToolTip.Size = new System.Drawing.Size(84, 38);
            this.thangItemToolTip.Text = "Tháng";
            this.thangItemToolTip.Click += new System.EventHandler(this.thangItemToolTip_Click);
            // 
            // NamItemToolTip
            // 
            this.NamItemToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamItemToolTip.Name = "NamItemToolTip";
            this.NamItemToolTip.Padding = new System.Windows.Forms.Padding(3);
            this.NamItemToolTip.Size = new System.Drawing.Size(66, 38);
            this.NamItemToolTip.Text = "Năm";
            this.NamItemToolTip.Click += new System.EventHandler(this.NamItemToolTip_Click);
            // 
            // pkdateTime
            // 
            this.pkdateTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkdateTime.CustomFormat = "dddd dd/MM/yyyy";
            this.pkdateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pkdateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pkdateTime.Location = new System.Drawing.Point(1415, 114);
            this.pkdateTime.Name = "pkdateTime";
            this.pkdateTime.Size = new System.Drawing.Size(315, 34);
            this.pkdateTime.TabIndex = 10;
            this.pkdateTime.ValueChanged += new System.EventHandler(this.pkdateTime_ValueChanged);
            // 
            // dataDanhSachHoaDon
            // 
            this.dataDanhSachHoaDon.AllowDrop = true;
            this.dataDanhSachHoaDon.AllowUserToAddRows = false;
            this.dataDanhSachHoaDon.AllowUserToDeleteRows = false;
            this.dataDanhSachHoaDon.AllowUserToResizeColumns = false;
            this.dataDanhSachHoaDon.AllowUserToResizeRows = false;
            this.dataDanhSachHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDanhSachHoaDon.ColumnHeadersHeight = 29;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataDanhSachHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataDanhSachHoaDon.Location = new System.Drawing.Point(716, 154);
            this.dataDanhSachHoaDon.Name = "dataDanhSachHoaDon";
            this.dataDanhSachHoaDon.ReadOnly = true;
            this.dataDanhSachHoaDon.RowHeadersWidth = 5;
            this.dataDanhSachHoaDon.RowTemplate.Height = 24;
            this.dataDanhSachHoaDon.Size = new System.Drawing.Size(1014, 544);
            this.dataDanhSachHoaDon.TabIndex = 9;
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BorderColor = System.Drawing.Color.SteelBlue;
            this.guna2CustomGradientPanel2.BorderRadius = 50;
            this.guna2CustomGradientPanel2.BorderThickness = 3;
            this.guna2CustomGradientPanel2.Controls.Add(this.lblSLDieuTri);
            this.guna2CustomGradientPanel2.Controls.Add(this.lblS);
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.DeepPink;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.Snow;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(206, 450);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(462, 200);
            this.guna2CustomGradientPanel2.TabIndex = 8;
            // 
            // lblSLDieuTri
            // 
            this.lblSLDieuTri.AutoSize = true;
            this.lblSLDieuTri.BackColor = System.Drawing.Color.Transparent;
            this.lblSLDieuTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSLDieuTri.Location = new System.Drawing.Point(58, 109);
            this.lblSLDieuTri.Name = "lblSLDieuTri";
            this.lblSLDieuTri.Size = new System.Drawing.Size(108, 32);
            this.lblSLDieuTri.TabIndex = 0;
            this.lblSLDieuTri.Text = "điều trị";
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.BackColor = System.Drawing.Color.Transparent;
            this.lblS.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblS.Location = new System.Drawing.Point(56, 32);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(357, 38);
            this.lblS.TabIndex = 0;
            this.lblS.Text = "SỐ LƯỢNG ĐIỀU TRỊ";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderColor = System.Drawing.Color.SteelBlue;
            this.guna2CustomGradientPanel1.BorderRadius = 50;
            this.guna2CustomGradientPanel1.BorderThickness = 3;
            this.guna2CustomGradientPanel1.Controls.Add(this.lblDoanhThu);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.DeepPink;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.DeepSkyBlue;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Snow;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(206, 194);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(462, 200);
            this.guna2CustomGradientPanel1.TabIndex = 7;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDoanhThu.Location = new System.Drawing.Point(58, 109);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(188, 32);
            this.lblDoanhThu.TabIndex = 0;
            this.lblDoanhThu.Text = "DOANH THU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(56, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOANH THU NGÀY";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // uC_BaoCaoTheoNam1
            // 
            this.uC_BaoCaoTheoNam1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_BaoCaoTheoNam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_BaoCaoTheoNam1.Location = new System.Drawing.Point(0, 44);
            this.uC_BaoCaoTheoNam1.Name = "uC_BaoCaoTheoNam1";
            this.uC_BaoCaoTheoNam1.Size = new System.Drawing.Size(1936, 768);
            this.uC_BaoCaoTheoNam1.TabIndex = 11;
            // 
            // uC_BaoCaoTheoThang1
            // 
            this.uC_BaoCaoTheoThang1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_BaoCaoTheoThang1.Location = new System.Drawing.Point(0, 44);
            this.uC_BaoCaoTheoThang1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_BaoCaoTheoThang1.Name = "uC_BaoCaoTheoThang1";
            this.uC_BaoCaoTheoThang1.Size = new System.Drawing.Size(1936, 768);
            this.uC_BaoCaoTheoThang1.TabIndex = 12;
            // 
            // UC_BaoCao_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uC_BaoCaoTheoThang1);
            this.Controls.Add(this.uC_BaoCaoTheoNam1);
            this.Controls.Add(this.pkdateTime);
            this.Controls.Add(this.dataDanhSachHoaDon);
            this.Controls.Add(this.guna2CustomGradientPanel2);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "UC_BaoCao_";
            this.Size = new System.Drawing.Size(1936, 812);
            this.Load += new System.EventHandler(this.UC_BaoCao__Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDanhSachHoaDon)).EndInit();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem NgayItemToolTip;
        private System.Windows.Forms.ToolStripMenuItem thangItemToolTip;
        private System.Windows.Forms.ToolStripMenuItem NamItemToolTip;
        private System.Windows.Forms.DateTimePicker pkdateTime;
        private System.Windows.Forms.DataGridView dataDanhSachHoaDon;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private System.Windows.Forms.Label lblSLDieuTri;
        private System.Windows.Forms.Label lblS;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private User_Control.UC_BaoCaoTheoThang uC_BaoCaoTheoThang1;
        private UC_BaoCaoTheoNam uC_BaoCaoTheoNam1;
    }
}
