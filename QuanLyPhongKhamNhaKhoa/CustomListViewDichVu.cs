using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongKhamNhaKhoa
{
    public class CustomItemCheckedEventArgs : EventArgs
    {
        public ListViewItem Item { get; }
        public bool IsChecked { get; }

        public CustomItemCheckedEventArgs(ListViewItem item, bool isChecked)
        {
            Item = item;
            IsChecked = isChecked;
        }
    }
    public class CustomListViewDichVu : ListView
    {


        public event EventHandler<CustomItemCheckedEventArgs> ItemCheckedChanged;

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            ListViewItem item = (ListViewItem)checkBox.Tag;

            if (checkBox.Checked && ItemCheckedChanged != null)
            {
                ItemCheckedChanged.Invoke(this, new CustomItemCheckedEventArgs(item, true));
            }
            else if (!checkBox.Checked)
            {
                // If the checkbox is unchecked, send an event to remove the corresponding item from lvDichVuDaChon
                ItemCheckedChanged?.Invoke(this, new CustomItemCheckedEventArgs(item, false));
            }

        }

        public void AddControlsToItem(ListViewItem item)
        {
            // Thêm Checkbox
            CheckBox checkBox = new CheckBox();
            checkBox.Size = new Size(15,15);
            checkBox.Tag = item; // Lưu trữ item vào Tag của checkbox
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            this.Controls.Add(checkBox);

            // Thêm NumericUpDown
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = 1000;
            numericUpDown.Value = 0;
            numericUpDown.Size = new Size(80,Size.Height);
            numericUpDown.ValueChanged += (sender, args) =>
            {
                // Xử lý sự kiện khi giá trị của NumericUpDown thay đổi
                // Ví dụ: MessageBox.Show("NumericUpDown value changed: " + numericUpDown.Value.ToString());
            };
            this.Controls.Add(numericUpDown);

            // Đặt vị trí của các control
            Point checkBoxLocation = new Point(item.SubItems[0].Bounds.Left +3 /*+ (item.SubItems[0].Bounds.Width - checkBox.Width) / 2*/, item.Bounds.Top);
            Point numericUpDownLocation = new Point(item.SubItems[4].Bounds.Left , item.Bounds.Top);

            checkBox.Location = checkBoxLocation;
            numericUpDown.Location = numericUpDownLocation;
        }
    }
}
