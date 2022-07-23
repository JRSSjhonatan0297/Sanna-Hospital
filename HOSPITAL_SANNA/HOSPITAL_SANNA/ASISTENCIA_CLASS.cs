using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class ASISTENCIA_CLASS
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





        public List<Asistencia> Get_Asist()
        {
            List<Asistencia> Obser = new List<Asistencia>();

            string query = "select ObservacionID,Descripcion,Fecha,EmpleadoID from Observacion";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Asistencia Asis = new Asistencia();
                        Asis.AsistenciaID = reader.GetInt32(0);
                        Asis.EmpleadoID = reader.GetInt32(1);
                        Asis.Fecha = reader.GetDateTime(2);
                        Asis.Opinion = reader.GetString(3);
                        Obser.Add(Asis);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Obser;
        }




        public Asistencia Get_Asi(int Id)
        {

            string query = "select AsistenciaID,Descripcion,Fecha,EmpleadoID from Asistencia" +
                " where AsistenciaID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {


                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Asistencia Asis = new Asistencia();
                    Asis.AsistenciaID = reader.GetInt32(0);
                    Asis.EmpleadoID = reader.GetInt32(1);
                    Asis.Fecha = reader.GetDateTime(2);
                    Asis.Opinion = reader.GetString(3);
                    reader.Close();

                    connection.Close();

                    return Asis;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Asi(int Id, string Desc, DateTime fecha, int idempl)
        {

            string query = "insert into Observacion(ObservacionID,Descripcion,Fecha,EmpleadoID) values" +
                "(@id, @desc,@fecha,@idemp)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@desc", Desc);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@idemp", idempl);

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



        public void Update_Asi(int Id, string Desc, DateTime fecha, int idempl)
        {


            string query = "update Asistencia set Descripcion=@desc,Fecha=@fecha,EmpleadoID=@idemp" +
                " where AsistenciaID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@desc", Desc);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@idemp", idempl);

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


        public void Delete_Asi(int Id)
        {
            string query = "delete from Asistencia" +
                " where AsistenciaID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

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


        public class Asistencia
        {
            public int AsistenciaID { get; set; }
            public int EmpleadoID { get; set; }
            public string Opinion { get; set; }
            public DateTime Fecha { get; set; }
        }


    }
}
