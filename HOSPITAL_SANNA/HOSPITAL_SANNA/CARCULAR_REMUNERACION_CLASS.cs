using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class CARCULAR_REMUNERACION_CLASS
    {

        private string connectionString
           = "Data Source=localhost;Initial Catalog=BD_SANNA;" +
           "User=sa;Password=1234";

        public bool Ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }



        public List<Remuneraciones> Get_Remu()
        {
            List<Remuneraciones> Remu = new List<Remuneraciones>();

            string query = "select RemuneracionesID,EmpleadoID,Numasistencias,Sueldo from Remuneraciones";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Remuneraciones Rem = new Remuneraciones();
                        Rem.RemuneracionesID = reader.GetInt32(0);
                        Rem.EmpleadoID = reader.GetInt32(1);
                        Rem.Sueldo = reader.GetDouble(3);
                        Rem.Cant_Asist = reader.GetInt32(2);
                        Remu.Add(Rem);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
            return Remu;
        }







         public double Get_Suel(int Id)
        {
            string query = "select Sueldo-((select cant_faltas from Rendimiento where RendimientoID =(select RendimientoID from Empleado"+
                " where EmpleadoID =@id))*30)from Empleado where EmpleadoID =@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    double Rem_suel;
                    Rem_suel = reader.GetDouble(0);
                    reader.Close();
                    connection.Close();
                    return Rem_suel;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }

             }

            }



         public int Get_Asis(int Id)
        {
            string query = "select COUNT(*) from Asistencia where EmpleadoID =@id";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int Rem_Asist;
                    Rem_Asist = reader.GetInt32(0);
                    reader.Close();
                    connection.Close();
                    return Rem_Asist;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }

             }

            }





         public void Add_Rem(int Id, int idemp, double Sueldo, int asist)
        {
            string query = "insert into Remuneraciones(RemuneracionesID,EmpleadoID,Numasistencias,Sueldo) values" +
                "(@id,@idemp,@Sueldo,@asist) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@idemp", idemp);
                command.Parameters.AddWithValue("@Sueldo", Sueldo);
                command.Parameters.AddWithValue("@asist", asist);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

        }




        public class Remuneraciones
        {
            public int RemuneracionesID { get; set; }
            public int EmpleadoID { get; set; }
            public double Sueldo { get; set; }
            public int Cant_Asist { get; set; }
        }


    }
}
