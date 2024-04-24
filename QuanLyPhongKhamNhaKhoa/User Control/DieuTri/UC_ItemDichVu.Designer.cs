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
            this.nameService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameService.Location = new System.Drawing.Point(39, 17);
            this.nameService.Name = "nameService";
            this.nameService.Size = new System.Drawing.Size(106, 20);
            this.nameService.TabIndex = 0;
            this.nameService.Text = "nameService";
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost.Location = new System.Drawing.Point(255, 17);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(73, 20);
            this.cost.TabIndex = 1;
            this.cost.Text = "cost/unit";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(15, 17);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(18, 17);
            this.checkBox.TabIndex = 2;
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // UC_ItemDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.nameService);
            this.Name = "UC_ItemDichVu";
            this.Size = new System.Drawing.Size(440, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameService;
        private System.Windows.Forms.Label cost;
        public System.Windows.Forms.CheckBox checkBox;
    }
}
