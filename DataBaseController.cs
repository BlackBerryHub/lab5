using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class DataBaseController
    {
        private SqlConnection connect = null;

        public void OpenConnection(string connectionString)
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }

        public void InsertDocuments(int IdEquipment, int IdProcedure)
        {
            string sql = string.Format("INSERT INTO Documents VALUES(@ID_Equipment, @ID_Procedure)");
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@ID_Equipment", IdEquipment);
                cmd.Parameters.AddWithValue("@ID_Procedure", IdProcedure);

                cmd.ExecuteNonQuery();
            }
        }

        public void InsertNaprav(int IdPacients, int IdProcedure)
        {
            string sql = string.Format("INSERT INTO Naprav VALUES(@ID_Pacients, @ID_Procedure)");
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@ID_Pacients", IdPacients);
                cmd.Parameters.AddWithValue("@ID_Procedure", IdProcedure);
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertEquipments(string nameEquipments, string Appointments)
        {
            string sql = string.Format("INSERT INTO Equipments VALUES(@nameEquipments, @Appointments)");
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@nameEquipments", nameEquipments);
                cmd.Parameters.AddWithValue("@Appointments", Appointments);
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertPacients(string Name, string LastName)
        {
            string sql = string.Format("INSERT INTO Pacients VALUES(@Name, @LastName)");
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@LastName", LastName);
                cmd.ExecuteNonQuery();
            }
        }
        public void InsertProcedure(string Name, int Cost)
        {
            string sql = string.Format("INSERT INTO Procedure VALUES(@Name, @Cost)");
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Cost", Cost);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetDataDocuments()
        {
            DataTable doc = new DataTable();
            string sql = "SELECT * FROM Documents";
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                doc.Load(dr);
                dr.Close();
            }
            return doc;
        }
        public DataTable GetDataNaprav()
        {
            DataTable nap = new DataTable();
            string sql = "SELECT * FROM Naprav";
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                nap.Load(dr);
                dr.Close();
            }
            return nap;
        }
        public DataTable GetDataEquipments()
        {
            DataTable equip = new DataTable();
            string sql = "SELECT * FROM Equipments";
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                equip.Load(dr);
                dr.Close();
            }
            return equip;
        }
        public DataTable GetDataPacients()
        {
            DataTable pacients = new DataTable();
            string sql = "SELECT * FROM Pacients";
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                pacients.Load(dr);
                dr.Close();
            }
            return pacients;
        }
        public DataTable GetDataProcedure()
        {
            DataTable proc = new DataTable();
            string sql = "SELECT * FROM \"Procedure\"";
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                proc.Load(dr);
                dr.Close();
            }
            return proc;
        }

        public void DeleteDocuments(int ID_Documents)
        {
            string sql = string.Format("DELETE FROM Documents WHERE ID_Documents = '{0}'", ID_Documents);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Запис не існує", ex);
                    throw error;
                }
            }
        }
        public void DeleteEquipments(int ID_Equipment)
        {
            string sql = string.Format("DELETE FROM Equipments WHERE ID_Equipment = '{0}'", ID_Equipment);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Запис не існує", ex);
                    throw error;
                }
            }
        }
        public void DeleteNaprav(int ID_Naprav)
        {
            string sql = string.Format("DELETE FROM Naprav WHERE ID_Naprav = '{0}'", ID_Naprav);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Запис не існує", ex);
                    throw error;
                }
            }
        }
        public void DeletePacients(int ID_Pacients)
        {
            string sql = string.Format("DELETE FROM Pacients WHERE ID_Pacients = '{0}'", ID_Pacients);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Запис не існує", ex);
                    throw error;
                }
            }
        }
        public void DeleteProcedure(int ID_Procedure)
        {
            string sql = string.Format("DELETE FROM Procedure WHERE ID_Procedure = '{0}'", ID_Procedure);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Запис не існує", ex);
                    throw error;
                }
            }
        }
        public void UpdateDocuments(int ID_Documents, int ID_Equipment, int ID_Procedure)
        {
            string sql = string.Format("UPDATE Documents SET ID_Equipment = '{0}', ID_Procedure = '{1}' WHERE ID_Documents = '{2}'", 
                ID_Equipment, ID_Procedure, ID_Documents);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateEquipments(int ID_Equipment, string nameEquipment, string Appointments)
        {
            string sql = string.Format("UPDATE Equipments SET nameEquipment = '{0}', Appointments = '{1}' WHERE ID_Equipment = '{2}'",
                nameEquipment, Appointments, ID_Equipment);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateNaprav(int ID_Naprav, int ID_Pacients, int ID_Procedure)
        {
            string sql = string.Format("UPDATE Naprav SET ID_Pacients = '{0}', ID_Procedure = '{1}' WHERE ID_Naprav = '{2}'",
                ID_Pacients, ID_Procedure, ID_Naprav);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePacients(int ID_Pacients, string Name, string LastName)
        {
            string sql = string.Format("UPDATE Pacients SET Name = '{0}', LastName = '{1}' WHERE ID_Pacinents = '{2}'",
                Name, LastName, ID_Pacients);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateProcedure(int ID_Procedure, string Name, int Cost)
        {
            string sql = string.Format("UPDATE Procedure SET Name = '{0}', Cost = '{1}' WHERE ID_Procedure = '{2}'",
                Name, Cost, ID_Procedure);
            using (SqlCommand cmd = new SqlCommand(sql, this.connect))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
