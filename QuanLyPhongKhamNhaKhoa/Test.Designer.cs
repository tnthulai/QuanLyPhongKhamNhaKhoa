namespace QuanLyPhongKhamNhaKhoa
{
    partial class Test
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uC_DieuTri_New1 = new QuanLyPhongKhamNhaKhoa.User_Control.UC_DieuTri_New();
            this.SuspendLayout();
            // 
            // uC_DieuTri_New1
            // 
            this.uC_DieuTri_New1.BackColor = System.Drawing.Color.White;
            this.uC_DieuTri_New1.Location = new System.Drawing.Point(1, 2);
            this.uC_DieuTri_New1.Margin = new System.Windows.Forms.Padding(2);
            this.uC_DieuTri_New1.Name = "uC_DieuTri_New1";
            this.uC_DieuTri_New1.Size = new System.Drawing.Size(1286, 665);
            this.uC_DieuTri_New1.TabIndex = 0;
            this.uC_DieuTri_New1.Load += new System.EventHandler(this.uC_DieuTri_New1_Load);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 664);
            this.Controls.Add(this.uC_DieuTri_New1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Control.UC_DieuTri_New uC_DieuTri_New1;
    }
}