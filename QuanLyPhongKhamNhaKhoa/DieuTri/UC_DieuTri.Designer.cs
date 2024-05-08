namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    partial class UC_DieuTri
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
            this.txtAdvice = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.dateTPEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTPStartDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTreatmentID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblNameNS = new System.Windows.Forms.Label();
            this.lblNameBN = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnDichVuDaChon = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pBThemDichVu = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxLichHen = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pnThuocDaChon = new System.Windows.Forms.FlowLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pBThemThuoc = new System.Windows.Forms.PictureBox();
            this.lblTotalCostMedicine = new System.Windows.Forms.Label();
            this.lblTotalCostService = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.dateTPDate = new System.Windows.Forms.DateTimePicker();
            this.bbtnRefesh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBThemDichVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBThemThuoc)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAdvice
            // 
            this.txtAdvice.Location = new System.Drawing.Point(95, 551);
            this.txtAdvice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdvice.Multiline = true;
            this.txtAdvice.Name = "txtAdvice";
            this.txtAdvice.Size = new System.Drawing.Size(383, 160);
            this.txtAdvice.TabIndex = 92;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(224, 737);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(119, 38);
            this.btnLuu.TabIndex = 107;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXuatHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnXuatHoaDon.Location = new System.Drawing.Point(95, 737);
            this.btnXuatHoaDon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(119, 38);
            this.btnXuatHoaDon.TabIndex = 106;
            this.btnXuatHoaDon.Text = "Xuất hóa đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = false;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(95, 347);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(383, 160);
            this.txtDetail.TabIndex = 93;
            // 
            // dateTPEndDate
            // 
            this.dateTPEndDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPEndDate.CustomFormat = "dd/MM/yyyy";
            this.dateTPEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPEndDate.Location = new System.Drawing.Point(251, 262);
            this.dateTPEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPEndDate.Name = "dateTPEndDate";
            this.dateTPEndDate.Size = new System.Drawing.Size(155, 30);
            this.dateTPEndDate.TabIndex = 105;
            // 
            // dateTPStartDate
            // 
            this.dateTPStartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStartDate.CustomFormat = "dd/MM/yyyy";
            this.dateTPStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPStartDate.Location = new System.Drawing.Point(251, 215);
            this.dateTPStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPStartDate.Name = "dateTPStartDate";
            this.dateTPStartDate.Size = new System.Drawing.Size(155, 30);
            this.dateTPStartDate.TabIndex = 104;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(91, 528);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(108, 20);
            this.label12.TabIndex = 101;
            this.label12.Text = "Lời Khuyên:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(91, 316);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 100;
            this.label11.Text = "Chi Tiết:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(91, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 102;
            this.label10.Text = "Ngày kết thúc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(91, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 99;
            this.label3.Text = "Ngày bắt đầu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(91, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 98;
            this.label5.Text = "Nha sĩ điều trị:";
            // 
            // txtTreatmentID
            // 
            this.txtTreatmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTreatmentID.Location = new System.Drawing.Point(229, 156);
            this.txtTreatmentID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTreatmentID.Multiline = true;
            this.txtTreatmentID.Name = "txtTreatmentID";
            this.txtTreatmentID.Size = new System.Drawing.Size(247, 29);
            this.txtTreatmentID.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(91, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 94;
            this.label4.Text = "Mã Điều Trị:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(91, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Bệnh Nhân:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 91;
            this.label1.Text = "Điều trị";
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // lblNameNS
            // 
            this.lblNameNS.AutoSize = true;
            this.lblNameNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameNS.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNameNS.Location = new System.Drawing.Point(236, 71);
            this.lblNameNS.Name = "lblNameNS";
            this.lblNameNS.Size = new System.Drawing.Size(102, 20);
            this.lblNameNS.TabIndex = 98;
            this.lblNameNS.Text = "lblNameNS";
            // 
            // lblNameBN
            // 
            this.lblNameBN.AutoSize = true;
            this.lblNameBN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameBN.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNameBN.Location = new System.Drawing.Point(236, 113);
            this.lblNameBN.Name = "lblNameBN";
            this.lblNameBN.Size = new System.Drawing.Size(103, 20);
            this.lblNameBN.TabIndex = 98;
            this.lblNameBN.Text = "lblNameBN";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.SteelBlue;
            this.label13.Location = new System.Drawing.Point(779, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 20);
            this.label13.TabIndex = 81;
            this.label13.Text = "DỊCH VỤ ĐIỀU TRỊ";
            // 
            // pnDichVuDaChon
            // 
            this.pnDichVuDaChon.AutoScroll = true;
            this.pnDichVuDaChon.Location = new System.Drawing.Point(608, 174);
            this.pnDichVuDaChon.Margin = new System.Windows.Forms.Padding(0);
            this.pnDichVuDaChon.Name = "pnDichVuDaChon";
            this.pnDichVuDaChon.Size = new System.Drawing.Size(573, 473);
            this.pnDichVuDaChon.TabIndex = 113;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(624, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 22);
            this.label6.TabIndex = 114;
            this.label6.Text = "Dịch vụ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(787, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 22);
            this.label7.TabIndex = 114;
            this.label7.Text = "Số lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(960, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 22);
            this.label8.TabIndex = 114;
            this.label8.Text = "Thành tiền";
            // 
            // pBThemDichVu
            // 
            this.pBThemDichVu.BackColor = System.Drawing.Color.White;
            this.pBThemDichVu.Image = global::QuanLyPhongKhamNhaKhoa.Properties.Resources.add;
            this.pBThemDichVu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBThemDichVu.Location = new System.Drawing.Point(969, 79);
            this.pBThemDichVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBThemDichVu.Name = "pBThemDichVu";
            this.pBThemDichVu.Size = new System.Drawing.Size(29, 30);
            this.pBThemDichVu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBThemDichVu.TabIndex = 115;
            this.pBThemDichVu.TabStop = false;
            this.pBThemDichVu.Click += new System.EventHandler(this.pBThemDichVu_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(1795, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 98;
            this.label9.Text = "Lịch hẹn";
            // 
            // comboBoxLichHen
            // 
            this.comboBoxLichHen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLichHen.FormattingEnabled = true;
            this.comboBoxLichHen.Location = new System.Drawing.Point(1528, 25);
            this.comboBoxLichHen.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLichHen.Name = "comboBoxLichHen";
            this.comboBoxLichHen.Size = new System.Drawing.Size(252, 33);
            this.comboBoxLichHen.TabIndex = 116;
            this.comboBoxLichHen.SelectedValueChanged += new System.EventHandler(this.comboBoxLichHen_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.SteelBlue;
            this.label14.Location = new System.Drawing.Point(1449, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(158, 20);
            this.label14.TabIndex = 81;
            this.label14.Text = "THUỐC ĐIỀU TRỊ";
            // 
            // pnThuocDaChon
            // 
            this.pnThuocDaChon.AutoScroll = true;
            this.pnThuocDaChon.Location = new System.Drawing.Point(1267, 174);
            this.pnThuocDaChon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnThuocDaChon.Name = "pnThuocDaChon";
            this.pnThuocDaChon.Size = new System.Drawing.Size(573, 473);
            this.pnThuocDaChon.TabIndex = 113;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(1283, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 22);
            this.label16.TabIndex = 114;
            this.label16.Text = "Thuốc";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1445, 130);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 22);
            this.label17.TabIndex = 114;
            this.label17.Text = "Số lượng";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1609, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 22);
            this.label18.TabIndex = 114;
            this.label18.Text = "Thành tiền";
            // 
            // pBThemThuoc
            // 
            this.pBThemThuoc.BackColor = System.Drawing.Color.White;
            this.pBThemThuoc.Image = global::QuanLyPhongKhamNhaKhoa.Properties.Resources.add;
            this.pBThemThuoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBThemThuoc.Location = new System.Drawing.Point(1637, 79);
            this.pBThemThuoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pBThemThuoc.Name = "pBThemThuoc";
            this.pBThemThuoc.Size = new System.Drawing.Size(29, 30);
            this.pBThemThuoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBThemThuoc.TabIndex = 115;
            this.pBThemThuoc.TabStop = false;
            this.pBThemThuoc.Click += new System.EventHandler(this.pBThemThuoc_Click);
            // 
            // lblTotalCostMedicine
            // 
            this.lblTotalCostMedicine.AutoSize = true;
            this.lblTotalCostMedicine.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalCostMedicine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCostMedicine.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalCostMedicine.Location = new System.Drawing.Point(1075, 596);
            this.lblTotalCostMedicine.Name = "lblTotalCostMedicine";
            this.lblTotalCostMedicine.Size = new System.Drawing.Size(225, 45);
            this.lblTotalCostMedicine.TabIndex = 83;
            this.lblTotalCostMedicine.Text = "Tổng chi phí thuốc: 0VND";
            this.lblTotalCostMedicine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCostService
            // 
            this.lblTotalCostService.AutoSize = true;
            this.lblTotalCostService.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalCostService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCostService.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalCostService.Location = new System.Drawing.Point(590, 596);
            this.lblTotalCostService.Name = "lblTotalCostService";
            this.lblTotalCostService.Size = new System.Drawing.Size(58, 45);
            this.lblTotalCostService.TabIndex = 83;
            this.lblTotalCostService.Text = "0VND";
            this.lblTotalCostService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCostMedicine, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCostService, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(572, 69);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.544379F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.45562F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1304, 642);
            this.tableLayoutPanel1.TabIndex = 117;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lblTotalCost);
            this.guna2Panel1.Location = new System.Drawing.Point(572, 711);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1303, 50);
            this.guna2Panel1.TabIndex = 118;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalCost.Location = new System.Drawing.Point(3, 14);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(58, 20);
            this.lblTotalCost.TabIndex = 84;
            this.lblTotalCost.Text = "0VND";
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::QuanLyPhongKhamNhaKhoa.Properties.Resources.findicon;
            this.pbSearch.Location = new System.Drawing.Point(445, 158);
            this.pbSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(29, 25);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 119;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // dateTPDate
            // 
            this.dateTPDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPDate.CustomFormat = "dd/MM/yyyy";
            this.dateTPDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPDate.Location = new System.Drawing.Point(1368, 27);
            this.dateTPDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTPDate.Name = "dateTPDate";
            this.dateTPDate.Size = new System.Drawing.Size(153, 30);
            this.dateTPDate.TabIndex = 120;
            this.dateTPDate.ValueChanged += new System.EventHandler(this.dateTPDate_ValueChanged);
            // 
            // bbtnRefesh
            // 
            this.bbtnRefesh.BackColor = System.Drawing.Color.SteelBlue;
            this.bbtnRefesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbtnRefesh.ForeColor = System.Drawing.Color.White;
            this.bbtnRefesh.Location = new System.Drawing.Point(353, 737);
            this.bbtnRefesh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bbtnRefesh.Name = "bbtnRefesh";
            this.bbtnRefesh.Size = new System.Drawing.Size(119, 38);
            this.bbtnRefesh.TabIndex = 121;
            this.bbtnRefesh.Text = "Refesh";
            this.bbtnRefesh.UseVisualStyleBackColor = false;
            this.bbtnRefesh.Click += new System.EventHandler(this.bbtnRefesh_Click);
            // 
            // UC_DieuTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bbtnRefesh);
            this.Controls.Add(this.dateTPDate);
            this.Controls.Add(this.pbSearch);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.comboBoxLichHen);
            this.Controls.Add(this.pBThemThuoc);
            this.Controls.Add(this.pBThemDichVu);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnThuocDaChon);
            this.Controls.Add(this.pnDichVuDaChon);
            this.Controls.Add(this.txtAdvice);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnXuatHoaDon);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.dateTPEndDate);
            this.Controls.Add(this.dateTPStartDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNameBN);
            this.Controls.Add(this.lblNameNS);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTreatmentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_DieuTri";
            this.Size = new System.Drawing.Size(1936, 812);
            this.Load += new System.EventHandler(this.UC_DieuTri_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBThemDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBThemThuoc)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAdvice;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.DateTimePicker dateTPEndDate;
        private System.Windows.Forms.DateTimePicker dateTPStartDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTreatmentID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblNameNS;
        private System.Windows.Forms.Label lblNameBN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel pnDichVuDaChon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pBThemDichVu;
        private System.Windows.Forms.ComboBox comboBoxLichHen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pBThemThuoc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.FlowLayoutPanel pnThuocDaChon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalCostService;
        private System.Windows.Forms.Label lblTotalCostMedicine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.DateTimePicker dateTPDate;
        private System.Windows.Forms.Button bbtnRefesh;
    }
}
