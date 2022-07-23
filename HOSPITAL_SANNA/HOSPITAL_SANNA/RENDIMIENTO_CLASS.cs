using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    class RENDIMIENTO_CLASS
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

        public List<Rendimiento> Get_Rend()
        {
            List<Rendimiento> Rend = new List<Rendimiento>();

            string query = "select RendimientoID,Cant_faltas,Cant_observaciones,Cant_objetivoscumplidos,Cant_horascumplidas,Opinion_empleado from Rendimiento";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Rendimiento Ren = new Rendimiento();
                        Ren.RendimientoID = reader.GetInt32(0);
                        Ren.Cant_faltas = reader.GetInt32(1);
                        Ren.Cant_Observ = reader.GetInt32(2);
                        Ren.Cant_Obj_cumplid = reader.GetInt32(3);
                        Ren.Cant_hor_cumplid = reader.GetInt32(4);
                        Ren.Opinion = reader.GetString(5);
                        Rend.Add(Ren);
                    }
                    reader.Close();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }

            return Rend;
        }



        public Rendimiento Get_Req(int Id)
        {

            string query = "select RendimientoID,Cant_faltas,Cant_observaciones,Cant_objetivoscumplidos,Cant_horascumplidas,Opinion_empleado from Rendimiento" +
                " where RendimientoID=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Rendimiento Ren = new Rendimiento();
                    Ren.RendimientoID = reader.GetInt32(0);
                    Ren.Cant_faltas = reader.GetInt32(1);
                    Ren.Cant_Observ = reader.GetInt32(2);
                    Ren.Cant_Obj_cumplid = reader.GetInt32(3);
                    Ren.Cant_hor_cumplid = reader.GetInt32(4);
                    Ren.Opinion = reader.GetString(5);
                    reader.Close();

                    connection.Close();

                    return Ren;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la bd " + ex.Message);
                }
            }
        }


        public void Add_Ren(int Id, int cfalt, int cobser, int cobjc, int chorc, string Opinion)
        {
            string query = "insert into Rendimiento(RendimientoID,Cant_faltas,Cant_observaciones,Cant_objetivoscumplidos,Cant_horascumplidas,Opinion_empleado) values" +
                "(@id,@cfaltas,@cobs,@cobjcumpl,@chcumpl,@opin) ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@cfaltas", cfalt);
                command.Parameters.AddWithValue("@cobs", cobser);
                command.Parameters.AddWithValue("@cobjcumpl", cobjc);
                command.Parameters.AddWithValue("@chcumpl", chorc);
                command.Parameters.AddWithValue("@opin", Opinion);

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




        public void Delete_Ren(int Id)
        {
            string query = "delete from Rendimiento" +
                " where RendimientoID=@id ";

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



        public class Rendimiento
        {
            public int RendimientoID { get; set; }
            public int Cant_faltas { get; set; }
            public int Cant_Observ { get; set; }
            public int Cant_Obj_cumplid { get; set; }
            public int Cant_hor_cumplid { get; set; }
            public string Opinion { get; set; }
        }


    }
}
