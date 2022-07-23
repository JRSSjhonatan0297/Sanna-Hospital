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
    public partial class SEDE : Form
    {
        public SEDE()
        {
            InitializeComponent();
        }


        private void Refresh()
        {
            SEDE_CLASS Sede = new SEDE_CLASS();
            dataGridView1.DataSource = Sede.Get_Sede();
        }


        private void SEDE_Load(object sender, EventArgs e)
        {
            Refresh();
            txtid.Text = "";
            txtnomb.Text = "";
            txtid.Enabled = false;
            txtnomb.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtnomb.Enabled = true;
            
            txtid.Text = "";
            txtnomb.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SEDE_CLASS Sede = new SEDE_CLASS();

            try
            {

                Sede.Add_Sed(int.Parse(txtid.Text), txtnomb.Text);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txtnomb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtnomb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SEDE_CLASS Sede = new SEDE_CLASS();

            try
            {

                Sede.Update_Sed(int.Parse(txtid.Text), txtnomb.Text);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar: " + ex.Message);
            }

            txtid.Enabled = true;
            txtnomb.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SEDE_CLASS Sede = new SEDE_CLASS();

            try
            {

                Sede.Delete_Sed(int.Parse(txtid.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }

            txtid.Enabled = true;
            txtnomb.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (txtid.Enabled == true)
            {
                //Obtienes la fila actual
                var row = (sender as DataGridView).CurrentRow;

                txtid.Text = row.Cells[0].Value.ToString();
                txtnomb.Text = row.Cells[1].Value.ToString();
            }
        }

    }
}
