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
    public partial class CARCULAR_REMUNERACION : Form
    {
        public CARCULAR_REMUNERACION()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            CARCULAR_REMUNERACION_CLASS Remuneracion = new CARCULAR_REMUNERACION_CLASS();
            dataGridView1.DataSource = Remuneracion.Get_Remu();
        }



        private void CARCULAR_REMUNERACION_Load(object sender, EventArgs e)
        {

            Refresh();

            txtid.Text = "";
            txtidemp.Text = "";
            txtasistencias.Text = "";
            txtsueldo.Text = "";


            txtid.Enabled = true;
            txtidemp.Enabled = false;
            txtasistencias.Enabled = false;
            txtsueldo.Enabled = false;
            txtsueldo.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtidemp.Enabled = true;
            txtasistencias.Enabled = false;
            txtsueldo.Enabled = false;
            txtsueldo.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

              CARCULAR_REMUNERACION_CLASS Remuneracion = new CARCULAR_REMUNERACION_CLASS();

            try
            {

                Remuneracion.Add_Rem(int.Parse(txtid.Text), int.Parse(txtidemp.Text), Convert.ToDouble(txtsueldo.Text), int.Parse(txtasistencias.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }


            Refresh();

            txtid.Text = "";
            txtidemp.Text = "";
            txtasistencias.Text = "";
            txtsueldo.Text = "";


            txtid.Enabled = true;
            txtidemp.Enabled = false;
            txtasistencias.Enabled = false;
            txtsueldo.Enabled = false;
            txtsueldo.Enabled = false;
   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CARCULAR_REMUNERACION_CLASS Remuneracion = new CARCULAR_REMUNERACION_CLASS();

            txtasistencias.Text=Remuneracion.Get_Asis(int.Parse(txtidemp.Text)).ToString();
            txtsueldo.Text = Remuneracion.Get_Suel(int.Parse(txtidemp.Text)).ToString();
            
            
            txtid.Enabled = true;
            txtidemp.Enabled = false;
            txtasistencias.Enabled = false;
            txtsueldo.Enabled = false;
            txtsueldo.Enabled = false;
        }
    }
}
