using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class TABLA_EVALUACION_CLASS
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




        public List<Evaluacion> Get_Evalu()
        {
            List<Evaluacion> Evalu = new List<Evaluacion>();

            string query = "select EvaluaciónID,Fechaevaluacion,AplicantesID, Pregunta1,Pregunta2,Pregunta3,Pregunta4,Pregunta5,Puntajetotal from Evaluación";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Evaluacion Eva = new Evaluacion();
                        Eva.EvaluacionID = reader.GetInt32(0);
                        Eva.Fecha = reader.GetDateTime(1);
                        Eva.EmpleadoID = reader.GetInt32(2);
                        Eva.Pregunta1 = reader.GetString(3);
                        Eva.Pregunta2 = reader.GetString(4);
                        Eva.Pregunta3 = reader.GetString(5);
                        Eva.Pregunta4 = reader.GetString(6);
                        Eva.Pregunta5 = reader.GetString(7);
                        Eva.Puntaje = reader.GetInt32(8);
                        

                        Evalu.Add(Eva);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Evalu;
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
