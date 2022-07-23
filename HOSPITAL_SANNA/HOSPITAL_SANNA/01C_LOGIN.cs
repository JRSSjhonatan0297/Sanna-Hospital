using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class _01C_LOGIN
    {
        private string connectionString
            = "Data Source=localhost;Initial Catalog=BD_SANNA;" +
            "User=sa;Password=1234";

        public int Ok(string us, string pass)
        {
            int aux;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT cargoid from Empleado WHERE dni='" + us + "' AND Pass='" + pass + "'", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                            aux =reader.GetInt32(0);
                            return aux;  
                    }
            }
            catch (Exception ex)
            {
                return 0;  
            }  
    }




        public string Ok2(string us, string pass)
        {
            string aux;

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Dni FROM Aplicantes WHERE Correo_electronico='" + us + "' AND Pass='" + pass + "'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    aux = reader.GetString(0);
                    return aux;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }








    }
}
