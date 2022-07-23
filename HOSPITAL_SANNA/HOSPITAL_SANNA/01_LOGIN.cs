using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HOSPITAL_SANNA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
             label1.Parent = pictureBox1;
             label1.BackColor = Color.Transparent;
             label2.Parent = pictureBox1;
             label2.BackColor = Color.Transparent;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string us, pass;

            

            us = txtusuario.Text;
            pass = txtpass.Text;
            
            _01C_LOGIN login = new _01C_LOGIN();




            switch (login.Ok(us, pass))
            {
                case 12:
                   this.Hide();
                   _02_JEFEAREA frmja = new _02_JEFEAREA();
                   frmja.Show();
                break;
                
                case 15:
                    this.Hide();
                    _03_JEFESELECCION frmjs = new _03_JEFESELECCION();
                    frmjs.Show();
                break;

                case 18:
                    this.Hide();
                    _04_JEFERRHH frmjrrhh = new _04_JEFERRHH();
                    frmjrrhh.Show();
                break;

                default:
                        if (login.Ok2(us, pass) != null)
                        {
                            EVALUACION EVALUACION = new EVALUACION();
                            EVALUACION.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario no registrado en el sistema");
                        }

                break;
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
