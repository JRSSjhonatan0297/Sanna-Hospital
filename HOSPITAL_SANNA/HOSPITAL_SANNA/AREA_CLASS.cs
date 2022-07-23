using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace HOSPITAL_SANNA
{
    class AREA_CLASS
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

        public List<Area> Get_Are()
        {
            List<Area> Are = new List<Area>();

            string query = "select AreaID,Nombre_area,CargoID from Area";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Area Ar = new Area();
                        Ar.AreaID = reader.GetInt32(0);
                        Ar.Nombre_area = reader.GetString(1);
                        Ar.CargoID = reader.GetInt32(2);
                        Are.Add(Ar);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Are;
        }




        public DataTable ListarCargo()
        {
            DataTable Tabla = new DataTable();
            string query = "select CargoId,Nombre_cargo from Cargo";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Tabla.Load(reader);
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
            return Tabla;
        }




        public Area Get_Ar(int Id)
        {

            string query = "select AreaID,Nombre_area,CargoID from Area" +
                " where AreaID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Area Ar = new Area();
                    Ar.AreaID = reader.GetInt32(0);
                    Ar.Nombre_area = reader.GetString(1);
                    Ar.CargoID = reader.GetInt32(2);
                    reader.Close();

                    connection.Close();

                    return Ar;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Ar(int Id, string Nombre, int CargoID)
        {
            string query = "insert into Area(AreaID, Nombre_area,CargoID) values" +
                "(@id, @nombre,@idcar) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@idcar", CargoID);

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



        public void Update_Ar(int Id, string Nombre, int CargoID)
        {
            string query = "update Area set Nombre_area=@nombre ,CargoID=@idcar " +
                " where AreaID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@nombre", Nombre);
                command.Parameters.AddWithValue("@idcar", CargoID);

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


        public void Delete_Ar(int Id)
        {
            string query = "delete from Area" +
                " where AreaID=@id ";

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



        public class Area
        {
            public int AreaID { get; set; }
            public string Nombre_area { get; set; }
            public int CargoID { get; set; }

        }

    }
}
