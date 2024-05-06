using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKhamNhaKhoa.Entity
{
    public class Medicine
    {
        private string medicineID;
        private string medicineName;
        private float cost;
        private string unit;


        public string MedicineID { get { return medicineID; } set { medicineID = value; } }
        public string MedicineName { get { return medicineName; } set {medicineName = value; } }
        public float Cost { get { return cost; } set { cost = value; } }
        public string Unit { get { return unit; } set { unit = value; } }

        public Medicine(string medicineID, string medicineName, float cost, string unit)
        {
            this.medicineID = medicineID;
            this.medicineName = medicineName;
            this.cost = cost;
            this.unit = unit;
        }
    }
}
