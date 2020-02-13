using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ASP.NET_Shipov;

namespace ASP.NET_Shipov.Models
{
    public class EmpSettings
    {
        private SqlConnection sqlConnection;

        public EmpSettings()
        {


            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=WPFPROJECT_Shipov;
                                        Integrated Security=True;
                                        Pooling=True";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public List<ASP.NET_Shipov.Models.Employeers> GetList()
        {
            List<Employeers> list = new List<Employeers>();

            string sql = @"SELECT * FROM People";

            using (SqlCommand comment = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = comment.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(
                            new Employeers()
                            {
                                ID = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Salary = Convert.ToInt32(reader["Salary"]),
                                //DepName = reader["DepName"].ToString()
                            });
                    }
                }
            }
            return list;

        }

        public ASP.NET_Shipov.Models.Employeers GetEmpById(int Id)
        {
            string sql = $@"SELECT * FROM People WHERE Id={Id}";
            Employeers temp = new Employeers();
            using (SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        temp = new Employeers()
                        {
                            Name = reader["Name"].ToString(),
                            Salary = Convert.ToInt32(reader["Salary"]),
                            //DepName = reader["Email"].ToString()
                        };
                    }
                }

            }
            return temp;

        }

        public bool AddEmployeers(ASP.NET_Shipov.Models.Employeers employee)
        {
            try
            {
                string sqlAdd = $@" INSERT INTO People(FIO, Birthday, Email, Phone)
                               VALUES(N'{employee.Name}',
                                      N'{employee.Salary}',
                                      //N'{employee.DepName}')";

                using (var com = new SqlCommand(sqlAdd, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}