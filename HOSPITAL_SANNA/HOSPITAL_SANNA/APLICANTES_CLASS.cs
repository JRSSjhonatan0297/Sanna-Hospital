using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HOSPITAL_SANNA
{
    class APLICANTES_CLASS
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


        


        public List<Aplicantes> Get_Aplic()
        {
            List<Aplicantes> Aplic = new List<Aplicantes>();

            string query = "select AplicantesID, Titulo,Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Objetivos,Experiencia,Grado_instruccion,Habilidades,SedeID,CargoID,Pass from Aplicantes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try{
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Aplicantes Apl = new Aplicantes();


                        Apl.AplicantesID = reader.GetInt32(0);
                        Apl.A_pass = reader.GetString(14);
                        Apl.Titulo = reader.GetString(1);
                        Apl.Nombre = reader.GetString(2);
                        Apl.Apellido = reader.GetString(3);
                        Apl.Nume_tel = reader.GetString(4);
                        Apl.Correo = reader.GetString(5);
                        Apl.Dni = reader.GetString(6);
                        Apl.Direccion = reader.GetString(7);
                        Apl.Objetivos = reader.GetString(8);
                        Apl.Experiencia = reader.GetString(9);
                        Apl.Grado_in = reader.GetString(10);
                        Apl.Habilidades = reader.GetString(11);
                        Apl.SedeID = reader.GetInt32(12);
                        Apl.CargoID = reader.GetInt32(13);
                        Aplic.Add(Apl);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Aplic;
        }




        public Aplicantes Get_Apl(int Id)
        {

            string query = "select AplicantesID, Titulo,Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Objetivos,Experiencia,Grado_instruccion,Habilidades,SedeID,CargoID,Pass from Aplicantes" +
                " where AplicantesID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Aplicantes Apl = new Aplicantes();
                    Apl.AplicantesID = reader.GetInt32(0);
                    Apl.A_pass = reader.GetString(14);
                    Apl.Titulo = reader.GetString(1);
                    Apl.Nombre = reader.GetString(2);
                    Apl.Apellido = reader.GetString(3);
                    Apl.Nume_tel = reader.GetString(4);
                    Apl.Correo = reader.GetString(5);
                    Apl.Dni = reader.GetString(6);
                    Apl.Direccion = reader.GetString(7);
                    Apl.Objetivos = reader.GetString(8);
                    Apl.Experiencia = reader.GetString(9);
                    Apl.Grado_in = reader.GetString(10);
                    Apl.Habilidades = reader.GetString(11);
                    Apl.SedeID = reader.GetInt32(12);
                    Apl.CargoID = reader.GetInt32(13);
                    reader.Close();

                    connection.Close();

                    return Apl;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Apl(
            int AplicantesID,
            string A_pass,
            string Titulo,
            string Nombre,
            string Apellido,
            string Nume_tel,
            string Correo,
            string Dni,
            string Direccion,
            string Objetivos,
            string Experiencia,
            string Grado_in,
            string Habilidades,
            int SedeID,
            int CargoID)
        {
            string query = "insert into Aplicantes(AplicantesID, Titulo,Nombre,Apellido,Numero_telefonico," +
                "Correo_electronico,Dni,Direccion,Objetivos,Experiencia,Grado_instruccion,Habilidades,SedeID,CargoID,Pass" +
                ") values" +
                "(@id, @titulo,@nomb,@ape,@numtel,@corr,@dni,@dirr,@obj,@exp,@grad,@hab,@idsede,@idcargo,@pass) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", AplicantesID);
                command.Parameters.AddWithValue("@titulo", Titulo);
                command.Parameters.AddWithValue("@nomb", Nombre);
                command.Parameters.AddWithValue("@ape", Apellido);
                command.Parameters.AddWithValue("@numtel", Nume_tel);
                command.Parameters.AddWithValue("@corr", Correo);
                command.Parameters.AddWithValue("@dni", Dni);
                command.Parameters.AddWithValue("@dirr", Direccion);
                command.Parameters.AddWithValue("@obj", Objetivos);
                command.Parameters.AddWithValue("@exp", Experiencia);
                command.Parameters.AddWithValue("@grad", Grado_in);
                command.Parameters.AddWithValue("@hab", Habilidades);
                command.Parameters.AddWithValue("@idsede", SedeID);
                command.Parameters.AddWithValue("@idcargo", CargoID);
                command.Parameters.AddWithValue("@pass", A_pass);

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



        public void Update_Apl(
        int AplicantesID,
        string A_pass,
        string Titulo,
        string Nombre,
        string Apellido,
        string Nume_tel,
        string Correo,
        string Dni,
        string Direccion,
        string Objetivos,
        string Experiencia,
        string Grado_in,
        string Habilidades,
        int SedeID,
        int CargoID)
            {
                string query = "update Aplicantes set " +
                    "Titulo=@titulo, " +
                    "Nombre=@nomb, " +
                    "Apellido=@ape, " +
                    "Numero_telefonico=@numtel, " +
                    "Correo_electronico=@corr, " +
                    "Dni=@dni," +
                    "Direccion=@dirr," +
                    "Objetivos=@obj," +
                    "Experiencia=@exp," +
                    "Grado_instruccion=@grad," +
                    "Habilidades=@hab," +
                    "SedeID=@idsede," +
                    "CargoID=@idcargo, " +
                    "Pass=@pass " +
                " where AplicantesID=@id ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", AplicantesID);
                    command.Parameters.AddWithValue("@titulo", Titulo);
                    command.Parameters.AddWithValue("@nomb", Nombre);
                    command.Parameters.AddWithValue("@ape", Apellido);
                    command.Parameters.AddWithValue("@numtel", Nume_tel);
                    command.Parameters.AddWithValue("@corr", Correo);
                    command.Parameters.AddWithValue("@dni", Dni);
                    command.Parameters.AddWithValue("@dirr", Direccion);
                    command.Parameters.AddWithValue("@obj", Objetivos);
                    command.Parameters.AddWithValue("@exp", Experiencia);
                    command.Parameters.AddWithValue("@grad", Grado_in);
                    command.Parameters.AddWithValue("@hab", Habilidades);
                    command.Parameters.AddWithValue("@idsede", SedeID);
                    command.Parameters.AddWithValue("@idcargo", CargoID);
                    command.Parameters.AddWithValue("@pass", A_pass);

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













        public void Delete_Apl(int Id)
        {
            string query = "delete from Aplicantes"
                +
                " where AplicantesID=@id ";

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



        public class Aplicantes
        {
            public int AplicantesID { get; set; }
            public string Titulo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nume_tel { get; set; }
            public string Correo { get; set; }
            public string Dni { get; set; }
            public string Direccion { get; set; }
            public string Objetivos { get; set; }
            public string Experiencia { get; set; }
            public string Grado_in { get; set; }
            public string Habilidades { get; set; }
            public int SedeID { get; set; }
            public int CargoID { get; set; }
            public string A_pass { get; set; }
        }




    }
}
