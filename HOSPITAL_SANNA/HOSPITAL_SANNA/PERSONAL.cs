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
    public partial class PERSONAL : Form
    {
        public PERSONAL()
        {
            InitializeComponent();
        }

        private void LiscarSede()
        {
            PERSONAL_CLASS OBJSEDE = new PERSONAL_CLASS();
            cbxsede.DataSource = OBJSEDE.ListarSede();
            cbxsede.DisplayMember = "Nombre_sede";
            cbxsede.ValueMember = "SedeId";
        }


        private void LiscarCargo()
        {
            PERSONAL_CLASS OBJSEDE = new PERSONAL_CLASS();
            cbxcargo.DataSource = OBJSEDE.ListarCargo();
            cbxcargo.DisplayMember = "Nombre_cargo";
            cbxcargo.ValueMember = "CargoId";
        }

        private void LiscarRendimiento()
        {
            PERSONAL_CLASS OBJSEDE = new PERSONAL_CLASS();
            cbxrendimiento.DataSource = OBJSEDE.ListarRendimiento();
            cbxrendimiento.DisplayMember = "RendimientoID";
            cbxrendimiento.ValueMember = "RendimientoID";
        }


        private void Refresh()
        {
            PERSONAL_CLASS Empleados = new PERSONAL_CLASS();
            dataGridView1.DataSource = Empleados.Get_Emple();
        }






        private void PERSONAL_Load(object sender, EventArgs e)
        {
            LiscarSede();
            LiscarCargo();
            LiscarRendimiento();
            Refresh();


            txtid.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtsueldo.Text = "";
            cbxrendimiento.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";



            txtid.Enabled = false;
            txtnomb.Enabled = false;
            txtap.Enabled = false;
            txtnt.Enabled = false;
            txtce.Enabled = false;
            txtdni.Enabled = false;
            txtdir.Enabled = false;
            txtsueldo.Enabled = false;
            cbxrendimiento.Enabled = false;
            cbxsede.Enabled = false;
            cbxcargo.Enabled = false;



        }



        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtnomb.Enabled = true;
            txtap.Enabled = true;
            txtnt.Enabled = true;
            txtce.Enabled = true;
            txtdni.Enabled = true;
            txtdir.Enabled = true;
            txtsueldo.Enabled = true;
            cbxrendimiento.Enabled = true;
            cbxsede.Enabled = true;
            cbxcargo.Enabled = true;

            txtid.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtsueldo.Text = "";
            cbxrendimiento.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            PERSONAL_CLASS Empleados = new PERSONAL_CLASS();
            string a = "1234";

            try
            {


                Empleados.Add_Emp(
                    Convert.ToInt32(txtid.Text),
                    txtnomb.Text,
                    txtap.Text,
                    txtnt.Text,
                    txtce.Text,
                    txtdni.Text,
                    txtdir.Text,
                    Convert.ToDouble(txtsueldo.Text),
                    Convert.ToInt32(cbxrendimiento.SelectedValue),
                    Convert.ToInt32(cbxsede.SelectedValue),
                    Convert.ToInt32(cbxcargo.SelectedValue),
                    a
                    );
                Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtsueldo.Text = "";
            cbxrendimiento.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";


        }


        private void button2_Click(object sender, EventArgs e)
        {
            PERSONAL_CLASS Empleados = new PERSONAL_CLASS();
            string a = "1234";

            try
            {


                Empleados.Update_Emp(
                    Convert.ToInt32(txtid.Text),
                    txtnomb.Text,
                    txtap.Text,
                    txtnt.Text,
                    txtce.Text,
                    txtdni.Text,
                    txtdir.Text,
                    Convert.ToSingle(txtsueldo.Text),
                    Convert.ToInt32(cbxrendimiento.SelectedValue),
                    Convert.ToInt32(cbxsede.SelectedValue),
                    Convert.ToInt32(cbxcargo.SelectedValue),
                    a
                    );
                Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar: " + ex.Message);
            }

            txtid.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtsueldo.Text = "";
            cbxrendimiento.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";

        }



        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtsueldo.Text = "";
            cbxrendimiento.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";

        }



        private void button5_Click(object sender, EventArgs e)
        {


            PERSONAL_CLASS Empleados = new PERSONAL_CLASS();


            try
            {

                Empleados.Delete_Emp(
                    Convert.ToInt32(txtid.Text));
                Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }



        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (txtid.Enabled == true)
            {
                //Obtienes la fila actual
                var row = (sender as DataGridView).CurrentRow;

                txtid.Text = row.Cells[0].Value.ToString();
                txtnomb.Text = row.Cells[1].Value.ToString();
                txtap.Text = row.Cells[2].Value.ToString();
                txtnt.Text = row.Cells[3].Value.ToString();
                txtce.Text = row.Cells[4].Value.ToString();
                txtdni.Text = row.Cells[5].Value.ToString();
                txtdir.Text = row.Cells[6].Value.ToString();
                txtsueldo.Text = row.Cells[7].Value.ToString();

            }


        }











        private void txtap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtnomb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbxrendimiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

      

       

        
        
    }
}
