using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKhamNhaKhoa.Entity;

namespace QuanLyPhongKhamNhaKhoa.Dao
{
    class TreatmentDao
    {
        SQLConnectionData mydb = new SQLConnectionData();
        private Random random = new Random();

        public bool insertMedicineTreatment(Medicine_Treatment medicine_Treatment)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Medicine_Treatment (treatmentID, medicineID, amount)" +
                " VALUES (@treatmentID, @medicineID, @amount)", mydb.getConnection);
            command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = medicine_Treatment.TreatmentID;
            command.Parameters.Add("@medicineID", SqlDbType.VarChar).Value = medicine_Treatment.MedicineID;
            command.Parameters.Add("@amount", SqlDbType.Int).Value = medicine_Treatment.Amount;

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
        public bool insertServiceTreatment(Service_Treatment service_Treatment)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Service_Treatment (treatmentID, serviceID, amount)" +
                " VALUES (@treatmentID, @serviceID, @amount)", mydb.getConnection);
            command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = service_Treatment.TreatmentID;
            command.Parameters.Add("@serviceID", SqlDbType.VarChar).Value = service_Treatment.ServiceID;
            command.Parameters.Add("@amount", SqlDbType.Int).Value = service_Treatment.Amount;

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

        public bool insertTreatment(Treatment treatment)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Treatment (treatmentID, patientsID, userID, startDate, endDate, treatmentDetail, advice)" +
                " VALUES (@treatmentID, @patientsID, @userID, @startDate, @endDate, @treatmentDetail, @advice)", mydb.getConnection);
            command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = treatment.TreatmentID;
            command.Parameters.Add("@patientsID", SqlDbType.VarChar).Value = treatment.PatientsID;
            command.Parameters.Add("@userID", SqlDbType.VarChar).Value = treatment.UserID;
            command.Parameters.Add("@startDate", SqlDbType.DateTime).Value = treatment.StartDate;
            command.Parameters.Add("@endDate", SqlDbType.DateTime).Value = treatment.EndDate;
            command.Parameters.Add("@treatmentDetail", SqlDbType.NVarChar).Value = treatment.TreatmentDetail;
            command.Parameters.Add("@advice", SqlDbType.NVarChar).Value = treatment.Advice;

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

        public string taoMaStreatment()
        {
            const string chars = "0123456789";
            string result;
            do
            {
                string randomPart = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
                result = $"TREA{randomPart}";

            } while (existTreatment(result));
            return result;
        }

        public bool existTreatment(string id)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Treatment WHERE treatmentID = @treatmentID", mydb.getConnection);
                command.Parameters.Add("@treatmentID", SqlDbType.VarChar).Value = id;
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
    }
}
