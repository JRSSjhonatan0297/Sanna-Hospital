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
    public partial class OBSERVACIONES : Form
    {
        public OBSERVACIONES()
        {
            InitializeComponent();
        }
        


        private void Refresh()
        {
            OBSERVACIONES_CLASS Observacion = new OBSERVACIONES_CLASS();
            dataGridView1.DataSource = Observacion.Get_Obser();
        }



        private void OBSERVACIONES_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtdesc.Text = "";
            txtempleado.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OBSERVACIONES_CLASS Observacion = new OBSERVACIONES_CLASS();

            
            try
            {
                Observacion.Add_Obs(int.Parse(txtid.Text), txtdesc.Text, dtpfecha.Value, int.Parse(txtempleado.Text));
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
            OBSERVACIONES_CLASS Observacion = new OBSERVACIONES_CLASS();

            try
            {
                Observacion.Update_Obs(int.Parse(txtid.Text), txtdesc.Text, dtpfecha.Value, int.Parse(txtempleado.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar: " + ex.Message);
            }

            txtid.Enabled = true;
            txtdesc.Enabled = true;
            txtempleado.Enabled = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {

            OBSERVACIONES_CLASS Observacion = new OBSERVACIONES_CLASS();

            try
            {
                Observacion.Delete_Obs(int.Parse(txtid.Text));
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (txtid.Enabled == true)
            {
                //Obtienes la fila actual
                var row = (sender as DataGridView).CurrentRow;

                txtid.Text = row.Cells[0].Value.ToString();
                txtempleado.Text = row.Cells[1].Value.ToString();
                txtdesc.Text = row.Cells[2].Value.ToString();
            }

        }
    }
}
