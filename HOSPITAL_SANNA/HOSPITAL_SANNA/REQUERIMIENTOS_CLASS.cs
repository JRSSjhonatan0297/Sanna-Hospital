using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace HOSPITAL_SANNA
{
    class REQUERIMIENTOS_CLASS
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

        public List<Requerimientos> Get_Requ()
        {
            List<Requerimientos> Requer = new List<Requerimientos>();

            string query = "select RequerimientoID,Descripcion from Requerimiento";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Requerimientos Req = new Requerimientos();
                        Req.RequerimientoID = reader.GetInt32(0);
                        Req.Descripcion = reader.GetString(1);
                        Requer.Add(Req);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Requer;
        }




        public Requerimientos Get_Req(int Id)
        {

            string query = "select id,descripcion from Requerimiento" +
                " where RequerimientoID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Requerimientos Req = new Requerimientos();
                    Req.RequerimientoID = reader.GetInt32(0);
                    Req.Descripcion = reader.GetString(1);
                    reader.Close();

                    connection.Close();

                    return Req;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Req(int Id,string Desc)
        {
            string query = "insert into Requerimiento(RequerimientoID, Descripcion) values" +
                "(@id, @desc) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@desc", Desc);

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



        public void Update_Req(int Id, string Desc)
        {
            string query = "update Requerimiento set Descripcion=@desc" +
                " where RequerimientoID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@desc", Desc);
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


        public void Delete_Req(int Id)
        {
            string query = "delete from Requerimiento" +
                " where RequerimientoID=@id ";

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



        public class Requerimientos
        {
            public int RequerimientoID { get; set; }
            public string Descripcion { get; set; }
        }

    }
}
