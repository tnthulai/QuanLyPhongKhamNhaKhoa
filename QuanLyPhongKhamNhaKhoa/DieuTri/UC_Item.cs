using QuanLyPhongKhamNhaKhoa.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa.User_Control
{
    public partial class UC_Item : UserControl
    {
        public UC_Item(string id, string serviceName, float cost, string unit)
        {
            InitializeComponent();
            ServiceId = id;
            ServiceName = serviceName;
            ServiceCost = cost;
            ServiceUnit = unit;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
        }

        public event EventHandler CheckBoxCheckedChanged;

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxCheckedChanged != null)
            {
                CheckBoxCheckedChanged(this, EventArgs.Empty);
            }
        }

        public string ServiceId { get; set; }

        public string ServiceName
        {
            get { return nameService.Text; }
            set { nameService.Text = value; }
        }

        public float ServiceCost
        {
            get { return float.Parse(cost.Text.Split('/')[0]); }
            set { cost.Text = value.ToString("0.##") + "/" + ServiceUnit; }
        }

        public string ServiceUnit
        {
            get { return cost.Text.Split('/')[1]; }
            set { cost.Text = ServiceCost.ToString("0.##") + "/" + value; }
        }
       

    }
}
