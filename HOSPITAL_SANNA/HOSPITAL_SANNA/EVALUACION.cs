using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOSPITAL_SANNA
{
    public partial class EVALUACION : Form
    {
        public EVALUACION()
        {
            InitializeComponent();
             
        }
        int nota = 0;



        private void EVALUACION_Load(object sender, EventArgs e)
        {
           
        }



        private void button3_Click(object sender, EventArgs e)
        {



            EVALUACION_CLASS Evaluacion =new EVALUACION_CLASS();
            APLICANTES_CLASS Aplicantes = new APLICANTES_CLASS();
            PERSONAL_CLASS Empleados = new PERSONAL_CLASS();
            DateTime Fecha = DateTime.Now;


            int nota=0,nota1=0,nota2=0,nota3=0,nota4=0,nota5=0;
            
            if(rbtn11.Checked==true){nota1 = nota1 + 1;};
            if(rbtn12.Checked==true){nota1 = nota1 + 2;};
            if(rbtn13.Checked==true){nota1 = nota1 + 3;};
            if(rbtn14.Checked==true){nota1 = nota1 + 4;};

            if(rbtn21.Checked==true){nota2 = nota2 + 1;};
            if(rbtn22.Checked==true){nota2 = nota2 + 2;};
            if(rbtn23.Checked==true){nota2 = nota2 + 3;};
            if(rbtn24.Checked==true){nota2 = nota2 + 4;};

            if(rbtn31.Checked==true){nota3 = nota3 + 1;};
            if(rbtn32.Checked==true){nota3 = nota3 + 2;};
            if(rbtn33.Checked==true){nota3 = nota3 + 3;};
            if(rbtn34.Checked==true){nota3 = nota3 + 4;};

            if(rbtn41.Checked==true){nota4 = nota4 + 2;};
            if(rbtn42.Checked==true){nota4 = nota4 + 4;};

            if(rbtn51.Checked==true){nota5 = nota5 + 2;};
            if(rbtn52.Checked==true){nota5 = nota5 + 4;};

           
            nota=nota1+nota2+nota3+nota4+nota5;

           


            /////////////////////empleado/////////////////////////////////
            int EmpleadoID;
            double Sueldo=930.00;
            int RendimientoID=1;
            //////////////////////////////////////////////////////
            

            /////////////////////postulante/////////////////////////////////
               string Nombre;
               string Apellido;
               string Nume_tel;
               string Correo;
               string Dni;
               string Direccion;
               int SedeID;
               int CargoID;
               string A_pass;
            //////////////////////////////////////////////////////

            /////////////////////EVALUACION/////////////////////////////////
            int EvaluacionID=Evaluacion.id_idev();
            //////////////////////////////////////////////////////

           
            EmpleadoID=Evaluacion.id_idemp();

            Nombre=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Nombre;
            Apellido=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Apellido;
            Nume_tel=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Nume_tel;
            Correo=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Correo;
            Dni=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Dni;
            Direccion=Aplicantes.Get_Apl(int.Parse(txtid.Text)).Direccion;
            SedeID=Aplicantes.Get_Apl(int.Parse(txtid.Text)).SedeID;
            CargoID=Aplicantes.Get_Apl(int.Parse(txtid.Text)).CargoID;
            A_pass=Aplicantes.Get_Apl(int.Parse(txtid.Text)).A_pass;


            if(nota>=15){

                Empleados.Add_Emp(
                     EmpleadoID,
                     Nombre,
                    Apellido,
                    Nume_tel,
                    Correo,
                    Dni,
                    Direccion,
                    Sueldo,
                    RendimientoID,
                    SedeID,
                    CargoID,
                    A_pass
                    );

                MessageBox.Show("Usted a aprobado la evaluación, Bienvenido a Hospital Sanna");

            }
            else
            {
                MessageBox.Show("Usted a desaprobado la evaluación, gracias por postualar a Hospital Sanna");
            }

           

            MessageBox.Show("fecha."+ Fecha);

            Evaluacion.Add_Eva(EvaluacionID,
                Convert.ToInt32(txtid.Text),
                nota1.ToString(),
                nota2.ToString(),
                nota3.ToString(),
                nota4.ToString(),
                nota5.ToString(),
                nota,
                Fecha
                );

    }
}
}