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
    public partial class ASISTENCIA : Form
    {
        public ASISTENCIA()
        {
            InitializeComponent();
        }

        private void ASISTENCIA_Load(object sender, EventArgs e)
        {
            Refresh();
            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
            txtid.Enabled = false;
            txtdesc.Enabled = false;
            txtempleado.Enabled = false;

            dtpfecha.Format = DateTimePickerFormat.Custom;
            dtpfecha.CustomFormat = "yyyy/MM/dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtdesc.Enabled = true;
            txtempleado.Enabled = true;
            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ASISTENCIA_CLASS Asistencia = new ASISTENCIA_CLASS();


            try
            {
                Asistencia.Add_Asi(int.Parse(txtid.Text), txtdesc.Text, dtpfecha.Value, int.Parse(txtempleado.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ASISTENCIA_CLASS Asistencia = new ASISTENCIA_CLASS();


            try
            {
                Asistencia.Update_Asi(int.Parse(txtid.Text), txtdesc.Text, dtpfecha.Value, int.Parse(txtempleado.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ASISTENCIA_CLASS Asistencia = new ASISTENCIA_CLASS();

            try
            {
                Asistencia.Delete_Asi(int.Parse(txtid.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }

            txtid.Enabled = true;
            txtdesc.Enabled = true;
            txtempleado.Enabled = true;
        }
    }
}
