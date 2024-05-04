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
            this.pBExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).BeginInit();
            this.SuspendLayout();
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost.Location = new System.Drawing.Point(2, 28);
            this.cost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(49, 13);
            this.cost.TabIndex = 3;
            this.cost.Text = "cost/unit";
            // 
            // nameService
            // 
            this.nameService.AutoSize = true;
            this.nameService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameService.Location = new System.Drawing.Point(2, 13);
            this.nameService.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameService.Name = "nameService";
            this.nameService.Size = new System.Drawing.Size(79, 15);
            this.nameService.TabIndex = 2;
            this.nameService.Text = "nameService";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(241, 17);
            this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(62, 15);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "thanhTien";
            this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // numAmount
            // 
            this.numAmount.Location = new System.Drawing.Point(135, 13);
            this.numAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(52, 20);
            this.numAmount.TabIndex = 5;
            this.numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAmount.ValueChanged += new System.EventHandler(this.numAmount_ValueChanged);
            // 
            // pBExit
            // 
            this.pBExit.Image = global::QuanLyPhongKhamNhaKhoa.Properties.Resources.x;
            this.pBExit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pBExit.Location = new System.Drawing.Point(388, 16);
            this.pBExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBExit.Name = "pBExit";
            this.pBExit.Size = new System.Drawing.Size(15, 16);
            this.pBExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBExit.TabIndex = 6;
            this.pBExit.TabStop = false;
            // 
            // UC_ItemDichVuSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pBExit);
            this.Controls.Add(this.numAmount);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.nameService);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_ItemDichVuSelected";
            this.Size = new System.Drawing.Size(423, 48);
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Label nameService;
        public System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.PictureBox pBExit;
    }
}
