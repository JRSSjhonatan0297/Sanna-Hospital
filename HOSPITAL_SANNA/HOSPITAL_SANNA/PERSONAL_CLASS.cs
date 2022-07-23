using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace HOSPITAL_SANNA
{
    class PERSONAL_CLASS
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



        public DataTable ListarSede()
        {

            DataTable Tabla = new DataTable();
            string query = "select SedeId,Nombre_sede from Sede";
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




        public DataTable ListarRendimiento()
        {
            DataTable Tabla = new DataTable();
            string query = "select RendimientoID from Rendimiento";
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




        public List<Empleados> Get_Emple()
        {
            List<Empleados> Emple = new List<Empleados>();

            string query = "select EmpleadoID, Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Sueldo,RendimientoID,SedeID,CargoID,Pass from Empleado";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Empleados Emp = new Empleados();
                        Emp.EmpleadoID = reader.GetInt32(0);
                        Emp.Pass = reader.GetString(11);
                        Emp.Nombre = reader.GetString(1);
                        Emp.Apellido = reader.GetString(2);
                        Emp.Nume_tel = reader.GetString(3);
                        Emp.Correo = reader.GetString(4);
                        Emp.Dni = reader.GetString(5);
                        Emp.Direccion = reader.GetString(6);
                        Emp.Sueldo = reader.GetDouble(7);
                        Emp.RendimientoID = reader.GetInt32(8);
                        Emp.SedeID = reader.GetInt32(9);
                        Emp.CargoID = reader.GetInt32(10);
                        Emple.Add(Emp);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Emple;
        }



        public Empleados Get_Emp(int Id)
        {

            string query = "select EmpleadoID, Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Sueldo,RendimientoID,SedeID,CargoID,Pass from Empleado "+
                " where EmpleadoID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Empleados Emp = new Empleados();
                    Emp.EmpleadoID = reader.GetInt32(0);
                    Emp.Pass = reader.GetString(11);
                    Emp.Nombre = reader.GetString(1);
                    Emp.Apellido = reader.GetString(2);
                    Emp.Nume_tel = reader.GetString(3);
                    Emp.Correo = reader.GetString(4);
                    Emp.Dni = reader.GetString(5);
                    Emp.Direccion = reader.GetString(6);
                    Emp.Sueldo = reader.GetDouble(7);
                    Emp.RendimientoID = reader.GetInt32(8);
                    Emp.SedeID = reader.GetInt32(9);
                    Emp.CargoID = reader.GetInt32(10);
                    reader.Close();

                    connection.Close();

                    return Emp;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }



        public void Add_Emp(
            int EmpleadoID,
            string Nombre,
            string Apellido, 
            string Nume_tel, 
            string Correo,
            string Dni, 
            string Direccion,
            double Sueldo,
            int RendimientoID, 
            int SedeID, 
            int CargoID,
            string Pass)
        {
            string query = "insert into Empleado(EmpleadoID,Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Sueldo,RendimientoID,SedeID,CargoID,Pass" +
                ") values" +
                "(@id,@nomb,@ape,@numtel,@corr,@dni,@dirr,@suel,@idrend,@idsede,@idcargo,@pass) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", EmpleadoID);
                command.Parameters.AddWithValue("@nomb", Nombre);
                command.Parameters.AddWithValue("@ape", Apellido);
                command.Parameters.AddWithValue("@numtel", Nume_tel);
                command.Parameters.AddWithValue("@corr", Correo);
                command.Parameters.AddWithValue("@dni", Dni);
                command.Parameters.AddWithValue("@dirr", Direccion);
                command.Parameters.AddWithValue("@suel", Sueldo);
                command.Parameters.AddWithValue("@idrend", RendimientoID);
                command.Parameters.AddWithValue("@idsede", SedeID);
                command.Parameters.AddWithValue("@idcargo", CargoID);
                command.Parameters.AddWithValue("@pass", Pass);

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




        public void Update_Emp(
        int EmpleadoID,
            string Nombre,
            string Apellido,
            string Nume_tel,
            string Correo,
            string Dni,
            string Direccion,
            double Sueldo,
            int RendimientoID,
            int SedeID,
            int CargoID,
            string Pass)
        {
            string query = "update Empleado set " +
                "Nombre=@nomb, " +
                "Apellido=@ape, " +
                "Numero_telefonico=@numtel, " +
                "Correo_electronico=@corr, " +
                "Dni=@dni," +
                "Direccion=@dirr," +
                "Sueldo=@suel," +
                "RendimientoID=@idrend," +
                "SedeID=@idsede," +
                "CargoID=@idcargo, " +
                "Pass=@pass " +
            " where EmpleadoID=@id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", EmpleadoID);
                command.Parameters.AddWithValue("@nomb", Nombre);
                command.Parameters.AddWithValue("@ape", Apellido);
                command.Parameters.AddWithValue("@numtel", Nume_tel);
                command.Parameters.AddWithValue("@corr", Correo);
                command.Parameters.AddWithValue("@dni", Dni);
                command.Parameters.AddWithValue("@dirr", Direccion);
                command.Parameters.AddWithValue("@suel", Sueldo);
                command.Parameters.AddWithValue("@idrend", RendimientoID);
                command.Parameters.AddWithValue("@idsede", SedeID);
                command.Parameters.AddWithValue("@idcargo", CargoID);
                command.Parameters.AddWithValue("@pass", Pass);

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




        public void Delete_Emp(int Id)
        {
            string query = "delete from Empleado"
                +
                " where EmpleadoID=@id ";

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



        public class Empleados
        {
            public int EmpleadoID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nume_tel { get; set; }
            public string Correo { get; set; }
            public string Dni { get; set; }
            public string Direccion { get; set; }
            public double Sueldo { get; set; }
            public int RendimientoID { get; set; }
            public int SedeID { get; set; }
            public int CargoID { get; set; }
            public string Pass { get; set; }
        }





    }
}
