using QuanLyPhongKhamNhaKhoa.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKhamNhaKhoa.Dao
{
    internal class MedicineDao
    {
        SQLConnectionData mydb = new SQLConnectionData();


        public DataTable getMedicine(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        
        private Random random = new Random();

        public string taoMaMedicine()
        {
            const string chars = "0123456789";
            string result;
            do
            {
                string randomPart = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                result = $"MEDI{randomPart}";
            } while (existMedicine(result));
            return result;
        }
        public bool existMedicine(string id)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Medicine WHERE medicineID = @medicineID", mydb.getConnection);
                command.Parameters.Add("@medicineID", SqlDbType.VarChar).Value = id;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    mydb.closeConnection();
                    return true;
                }
                mydb.closeConnection();
                return false;
            }
            catch
            {
                return true;
            }
        }

        
        public bool updateMedicine(Medicine medicine)
        {
            SqlCommand command = new SqlCommand("UPDATE Medicine SET medicineName=@medicineName, cost=@cost, unit=@unit " +
                "WHERE medicineID=@medicineID", mydb.getConnection);
            command.Parameters.Add("@medicineID", SqlDbType.VarChar).Value = medicine.MedicineID;
            command.Parameters.Add("@medicineName", SqlDbType.NVarChar).Value = medicine.MedicineName;
            command.Parameters.Add("@unit", SqlDbType.NVarChar).Value = medicine.Unit;
            command.Parameters.Add("@cost", SqlDbType.Float).Value = medicine.Cost;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool insertMedicine(Medicine medicine)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Medicine (medicineID, medicineName, cost, unit)" +
                " VALUES (@medicineID,@medicineName, @cost, @unit)", mydb.getConnection);
            command.Parameters.Add("@medicineID", SqlDbType.VarChar).Value = medicine.MedicineID;
            command.Parameters.Add("@medicineName", SqlDbType.NVarChar).Value = medicine.MedicineName;

            command.Parameters.Add("@cost", SqlDbType.Float).Value = medicine.Cost;
            command.Parameters.Add("@unit", SqlDbType.NVarChar).Value = medicine.Unit;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
