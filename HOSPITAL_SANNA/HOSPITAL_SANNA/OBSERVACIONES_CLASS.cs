using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class OBSERVACIONES_CLASS
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

        public List<Observacion> Get_Obser()
        {
            List<Observacion> Obser = new List<Observacion>();

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
                        Observacion Obs = new Observacion();
                        Obs.ObservacionID = reader.GetInt32(0);
                        Obs.Descripcion = reader.GetString(1);
                        Obs.Fecha = reader.GetDateTime(2); 
                        Obs.EmpleadoID = reader.GetInt32(3);
                        Obser.Add(Obs);
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




        public Observacion Get_Obs(int Id)
        {

            string query = "select ObservacionID,Descripcion,Fecha,EmpleadoID from Observacion" +
                " where ObservacionID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Observacion Obs = new Observacion();
                    Obs.ObservacionID = reader.GetInt32(0);
                    Obs.Descripcion = reader.GetString(1);
                    Obs.Fecha = reader.GetDateTime(2); 
                    Obs.EmpleadoID = reader.GetInt32(3);
                    reader.Close();

                    connection.Close();

                    return Obs;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Obs(int Id, string Desc, DateTime fecha, int idempl)
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



        public void Update_Obs(int Id, string Desc, DateTime fecha, int idempl)
        {


            string query = "update Observacion set Descripcion=@desc,Fecha=@fecha,EmpleadoID=@idemp" +
                " where ObservacionID=@id ";

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


        public void Delete_Obs(int Id)
        {
            string query = "delete from Observacion" +
                " where ObservacionID=@id ";

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



        public class Observacion
        {
            public int ObservacionID { get; set; }
            public int EmpleadoID { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            
        }

    }
}
