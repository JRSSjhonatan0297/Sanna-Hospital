using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class EVALUACION_CLASS
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




                public void Add_Eva(
                    int Id,
                    int Idapli,
                    string pregunta1 ,
                    string pregunta2 ,
                    string pregunta3 ,
                    string pregunta4 ,
                    string pregunta5 ,
                    int total,
                    DateTime fecha)
                {

                    string query = "insert into Evaluación(EvaluaciónID,AplicantesID,Fechaevaluacion,Pregunta1,Pregunta2,Pregunta3,Pregunta4,Pregunta5,Puntajetotal) values" +
                        "(@id, @idaplic,@fecha,@p1,@p2,@p3,@p4,@p5,@pt) ";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@idaplic", Idapli);
                        command.Parameters.AddWithValue("@p1", pregunta1);
                        command.Parameters.AddWithValue("@p2", pregunta2);
                        command.Parameters.AddWithValue("@p3", pregunta3);
                        command.Parameters.AddWithValue("@p4", pregunta4);
                        command.Parameters.AddWithValue("@p5", pregunta5);
                        command.Parameters.AddWithValue("@pt", total);
                        command.Parameters.AddWithValue("@fecha", fecha);

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


        
                public int id_idev()
                {
                    string query = "SELECT TOP 1 EvaluaciónID FROM Evaluación ORDER BY EvaluaciónID DESC";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            reader.Read();
                            int id_idev;
                            id_idev = reader.GetInt32(0);
                            id_idev = id_idev + 1;
                            reader.Close();
                            connection.Close();
                            return id_idev;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hay un error en la bd " + ex.Message);
                        }

                    }
                }



                public int id_idemp()
                {
                    string query = "SELECT TOP 1 EmpleadoID FROM Empleado ORDER BY EmpleadoID DESC";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            reader.Read();
                            int id_idem;
                            id_idem = reader.GetInt32(0);
                            id_idem = id_idem + 1;
                            reader.Close();
                            connection.Close();
                            return id_idem;
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hay un error en la bd " + ex.Message);
                        }

                    }
                }







                public class Evaluacion
                {
                    public int EvaluacionID { get; set; }
                    public int EmpleadoID { get; set; }
                    public string Pregunta1 { get; set; }
                    public string Pregunta2 { get; set; }
                    public string Pregunta3 { get; set; }
                    public string Pregunta4 { get; set; }
                    public string Pregunta5 { get; set; }
                    public int Puntaje { get; set; }
                    public DateTime Fecha { get; set; }
                }




    }
}
