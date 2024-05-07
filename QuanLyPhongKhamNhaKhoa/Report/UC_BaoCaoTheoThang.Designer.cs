namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    partial class UC_BaoCaoTheoThang
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDoanhThuThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.cbNam = new System.Windows.Forms.ComboBox();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDoanhThuThang
            // 
            this.chartDoanhThuThang.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chartDoanhThuThang.BorderlineColor = System.Drawing.SystemColors.HotTrack;
            this.chartDoanhThuThang.BorderlineWidth = 4;
            this.chartDoanhThuThang.BorderSkin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.chartDoanhThuThang.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            this.chartDoanhThuThang.BorderSkin.BorderColor = System.Drawing.Color.IndianRed;
            this.chartDoanhThuThang.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartDoanhThuThang.BorderSkin.BorderWidth = 5;
            this.chartDoanhThuThang.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThuThang.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDoanhThuThang.Legends.Add(legend1);
            this.chartDoanhThuThang.Location = new System.Drawing.Point(24, 106);
            this.chartDoanhThuThang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartDoanhThuThang.Name = "chartDoanhThuThang";
            this.chartDoanhThuThang.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu";
            this.chartDoanhThuThang.Series.Add(series1);
            this.chartDoanhThuThang.Size = new System.Drawing.Size(1653, 630);
            this.chartDoanhThuThang.TabIndex = 0;
            this.chartDoanhThuThang.Text = "chart1";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(263, 0);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(195, 29);
            this.lblTongDoanhThu.TabIndex = 2;
            this.lblTongDoanhThu.Text = "Tổng doanh thu";
            // 
            // cbThang
            // 
            this.cbThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Location = new System.Drawing.Point(220, 40);
            this.cbThang.Margin = new System.Windows.Forms.Padding(4);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(176, 28);
            this.cbThang.TabIndex = 3;
            this.cbThang.SelectedValueChanged += new System.EventHandler(this.cbThang_SelectedValueChanged);
            // 
            // cbNam
            // 
            this.cbNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNam.FormattingEnabled = true;
            this.cbNam.Location = new System.Drawing.Point(24, 40);
            this.cbNam.Margin = new System.Windows.Forms.Padding(4);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(176, 28);
            this.cbNam.TabIndex = 3;
            this.cbNam.SelectedValueChanged += new System.EventHandler(this.cbNam_SelectedValueChanged_1);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblTongDoanhThu);
            this.guna2Panel1.Location = new System.Drawing.Point(1202, 40);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(458, 44);
            this.guna2Panel1.TabIndex = 4;
            // 
            // UC_BaoCaoTheoThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.cbThang);
            this.Controls.Add(this.chartDoanhThuThang);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_BaoCaoTheoThang";
            this.Size = new System.Drawing.Size(1936, 768);
            this.Load += new System.EventHandler(this.UC_BaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThuThang)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThuThang;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.ComboBox cbNam;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
