using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace HOSPITAL_SANNA
{
    class CARGO_CLASS
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




        public List<Cargo> Get_Carg()
        {
            List<Cargo> Carg = new List<Cargo>();

            string query = "select CargoID,Nombre_cargo from Cargo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Cargo Cg = new Cargo();
                        Cg.CargoID = reader.GetInt32(0);
                        Cg.Nombre_cargo = reader.GetString(1);
                        Carg.Add(Cg);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Carg;
        }



        public Cargo Get_Cg(int Id)
        {

            string query = "select CargoID,Nombre_cargo from Cargo" +
                " where CargoID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Cargo Cg = new Cargo();
                    Cg.CargoID = reader.GetInt32(0);
                    Cg.Nombre_cargo = reader.GetString(1);
                    reader.Close();

                    connection.Close();

                    return Cg;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Cg(int Id, string Nombre)
        {


            string query = "insert into Cargo(CargoID,Nombre_cargo) values" +
                "(@id, @nombre) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@nombre", Nombre);

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



        public void Update_Cg(int Id, string Nombre)
        {

            string query = "update Cargo set Nombre_cargo=@nombre" +
                " where CargoID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", Nombre);
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


        public void Delete_Cg(int Id)
        {
            string query = "delete from Cargo" +
                " where CargoID=@id ";

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



        public class Cargo
        {
            public int CargoID { get; set; }
            public string Nombre_cargo { get; set; }
        }

    }
}
