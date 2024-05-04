namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    partial class UC_ItemDichVu
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
            this.nameService = new System.Windows.Forms.Label();
            this.cost = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameService
            // 
            this.nameService.AutoSize = true;
            this.nameService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameService.ForeColor = System.Drawing.Color.White;
            this.nameService.Location = new System.Drawing.Point(29, 11);
            this.nameService.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameService.Name = "nameService";
            this.nameService.Size = new System.Drawing.Size(90, 15);
            this.nameService.TabIndex = 0;
            this.nameService.Text = "nameService";
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost.ForeColor = System.Drawing.Color.White;
            this.cost.Location = new System.Drawing.Point(196, 11);
            this.cost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(61, 15);
            this.cost.TabIndex = 1;
            this.cost.Text = "cost/unit";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(11, 14);
            this.checkBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(15, 14);
            this.checkBox.TabIndex = 2;
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // UC_ItemDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.nameService);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_ItemDichVu";
            this.Size = new System.Drawing.Size(349, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.CheckBox checkBox;
        public System.Windows.Forms.Label cost;
        public System.Windows.Forms.Label nameService;
    }
}
