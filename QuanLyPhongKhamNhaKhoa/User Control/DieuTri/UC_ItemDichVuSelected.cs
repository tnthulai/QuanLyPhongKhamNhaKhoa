using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.User_Control.DieuTri
{
    public partial class UC_ItemDichVuSelected : UserControl
    {
        public UC_ItemDichVuSelected(string serviceName, float cost, string unit)
        {
            InitializeComponent();
            ServiceName = serviceName;
            ServiceCost = cost;
            Unit = unit;
            float totalCost = float.Parse(numAmount.Value.ToString()) * ServiceCost;
            lblTotalCost.Text = totalCost.ToString("0.##") + "VND";
        }
        public string ServiceName
        {
            get { return nameService.Text; }
            set { nameService.Text = value; }
        }

        public float ServiceCost
        {
            get { return float.Parse(cost.Text.Split('/')[0]); }
            set { cost.Text = value.ToString("0.##") + "/" + Unit; }
        }

        public string Unit
        {
            get { return cost.Text.Split('/')[1]; }
            set { cost.Text = ServiceCost.ToString("0.##") + "/" + value; }
        }


        public event EventHandler TotalCostChanged;
        public void numAmount_ValueChanged(object sender, EventArgs e)
        {
            float totalCost = float.Parse(numAmount.Value.ToString()) * ServiceCost;
            lblTotalCost.Text = totalCost.ToString("0.##") + "VND";

            // Kích hoạt sự kiện TotalCostChanged để thông báo rằng thành tiền đã thay đổi
            TotalCostChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
