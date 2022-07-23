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
    public partial class AREA : Form
    {
        public AREA()
        {
            InitializeComponent();
        }
       
        
        private void Refresh()
        {
            AREA_CLASS Area = new AREA_CLASS();
            dataGridView1.DataSource = Area.Get_Are();
        }


        private void LiscarCargo()
        {
            APLICANTES_CLASS OBJSEDE = new APLICANTES_CLASS();
            cbxcargo.DataSource = OBJSEDE.ListarCargo();
            cbxcargo.DisplayMember = "Nombre_cargo";
            cbxcargo.ValueMember = "CargoId";
        }

        private void AREA_Load(object sender, EventArgs e)
        {
            LiscarCargo();
            Refresh();
            txtid.Text = "";
            txtnomb.Text = "";
            txtid.Enabled = false;
            txtnomb.Enabled = false;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtnomb.Enabled = true;

            txtid.Text = "";
            txtnomb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtnomb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AREA_CLASS Area = new AREA_CLASS();

            try
            {

                Area.Add_Ar(int.Parse(txtid.Text), txtnomb.Text, Convert.ToInt32(cbxcargo.SelectedValue));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txtnomb.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AREA_CLASS Area = new AREA_CLASS();

            try
            {

                Area.Update_Ar(int.Parse(txtid.Text), txtnomb.Text, Convert.ToInt32(cbxcargo.SelectedValue));
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
            AREA_CLASS Area = new AREA_CLASS();

            try
            {
                Area.Delete_Ar(int.Parse(txtid.Text));
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
