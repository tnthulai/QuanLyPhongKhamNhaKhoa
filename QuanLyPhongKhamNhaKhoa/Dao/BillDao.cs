using QuanLyPhongKhamNhaKhoa.Entity;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace QuanLyPhongKhamNhaKhoa.Dao
{
    internal class BillDao
    {
        SQLConnectionData mydb = new SQLConnectionData();
        private Random random = new Random();
        public DataTable getBill(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteAppointment(Bill bill)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Bill WHERE billID=@billID", mydb.getConnection);
            command.Parameters.Add("@billID", SqlDbType.VarChar).Value = bill.BillID;
            
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

        public bool updateBill(Bill bill)
        {
            SqlCommand command = new SqlCommand("UPDATE Bill SET treatmentID=@treatmentID, " +
                "totalCost=@totalCost, exportBillDate=@exportBillDate " +
                "WHERE billID=@billID", mydb.getConnection);
            command.Parameters.Add("@billID", SqlDbType.VarChar).Value = bill.BillID;
            command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = bill.TreatmentID;
            command.Parameters.Add("@totalCost", SqlDbType.Float).Value = bill.TotalCost;
            command.Parameters.Add("@exportBillDate", SqlDbType.DateTime).Value = DateTime.Now;

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
        public double CalculateMonthlyRevenue(int month, int year)
        {
            double totalRevenue = 0;
            try
            {
                string query = "SELECT SUM(totalCost) AS TotalRevenue FROM Bill WHERE MONTH(exportBillDate) = @Month AND YEAR(exportBillDate) = @Year";
                using (SqlCommand command = new SqlCommand(query, mydb.getConnection))
                {
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);
                    mydb.openConnection();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalRevenue = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating monthly revenue: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }
            return totalRevenue;
        }
        public double CalculateDailyRevenue(DateTime date)
        {
            double totalRevenue = 0;
            try
            {
                string query = "SELECT SUM(totalCost) AS TotalRevenue FROM Bill WHERE CONVERT(date, exportBillDate) = @Date";
                using (SqlCommand command = new SqlCommand(query, mydb.getConnection))
                {
                    command.Parameters.AddWithValue("@Date", date.Date);
                    mydb.openConnection();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalRevenue = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception tại đây nếu cần
                Console.WriteLine("Error calculating daily revenue: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }
            return totalRevenue;
        }
        public double CalculateYearlyRevenue(int year)
        {
            double totalRevenue = 0;
            try
            {
                string query = "SELECT SUM(totalCost) AS TotalRevenue FROM Bill WHERE YEAR(exportBillDate) = @Year";
                using (SqlCommand command = new SqlCommand(query, mydb.getConnection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    mydb.openConnection();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalRevenue = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý exception tại đây nếu cần
                Console.WriteLine("Error calculating yearly revenue: " + ex.Message);
            }
            finally
            {
                mydb.closeConnection();
            }
            return totalRevenue;
        }
        public string taoMaBill()
        {
            const string chars = "0123456789";
            string result;
            do
            {
                string randomPart = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                result = $"BILL{randomPart}";
            } while (existBill(result));
            return result;
        }
        public bool existBill(string id)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Bill WHERE billID = @billID", mydb.getConnection);
                command.Parameters.Add("@billID", SqlDbType.VarChar).Value = id;
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
        public bool insertBill(Bill bill)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Bill (billID, treatmentID, totalCost, exportBillDate)" +
                " VALUES (@billID, @treatmentID, @totalCost, @exportBillDate)", mydb.getConnection);
            command.Parameters.Add("@billID", SqlDbType.VarChar).Value = bill.BillID;
            command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = bill.TreatmentID;
            command.Parameters.Add("@totalCost", SqlDbType.Float).Value = bill.TotalCost;
            command.Parameters.Add("@exportBillDate", SqlDbType.DateTime).Value = DateTime.Now;

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
    }
}
