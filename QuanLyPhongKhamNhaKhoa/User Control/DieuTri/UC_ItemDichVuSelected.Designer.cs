namespace QuanLyPhongKhamNhaKhoa.User_Control.DieuTri
{
    partial class UC_ItemDichVuSelected
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
            this.cost = new System.Windows.Forms.Label();
            this.nameService = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost.Location = new System.Drawing.Point(3, 34);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(56, 16);
            this.cost.TabIndex = 3;
            this.cost.Text = "cost/unit";
            // 
            // nameService
            // 
            this.nameService.AutoSize = true;
            this.nameService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameService.Location = new System.Drawing.Point(3, 16);
            this.nameService.Name = "nameService";
            this.nameService.Size = new System.Drawing.Size(94, 18);
            this.nameService.TabIndex = 2;
            this.nameService.Text = "nameService";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(326, 16);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(72, 18);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "thanhTien";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(180, 16);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(69, 22);
            this.numAmount.TabIndex = 5;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.ValueChanged += new System.EventHandler(this.numAmount_ValueChanged);
            // 
            // UC_ItemDichVuSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.nameService);
            this.Name = "UC_ItemDichVuSelected";
            this.Size = new System.Drawing.Size(440, 59);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Label nameService;
        public System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.NumericUpDown numAmount;
    }
}
