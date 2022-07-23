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
    public partial class APLICANTES : Form

    {
        public APLICANTES()
        {
            InitializeComponent();
        }

        private void LiscarSede()
        {
            APLICANTES_CLASS OBJSEDE = new APLICANTES_CLASS();
            cbxsede.DataSource = OBJSEDE.ListarSede();
            cbxsede.DisplayMember = "Nombre_sede";
            cbxsede.ValueMember = "SedeId";
        }


        private void LiscarCargo()
        {
            APLICANTES_CLASS OBJSEDE = new APLICANTES_CLASS();
            cbxcargo.DataSource = OBJSEDE.ListarCargo();
            cbxcargo.DisplayMember = "Nombre_cargo";
            cbxcargo.ValueMember = "CargoId";
        }

        private void Refresh()
        {
            APLICANTES_CLASS Aplicantes = new APLICANTES_CLASS();
            dataGridView1.DataSource = Aplicantes.Get_Aplic();
        }



        private void APLICANTES_Load(object sender, EventArgs e)
        {
            LiscarSede();
            LiscarCargo();
            Refresh();


            Refresh();
            txtid.Text = "";
            txttitulo.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtobj.Text = "";
            txtep.Text = "";
            cbxgrado.Text = "";
            txthab.Text = "";



            txtid.Enabled = false;
            txttitulo.Enabled = false;
            txtnomb.Enabled = false;
            txtap.Enabled = false;
            txtnt.Enabled = false;
            txtce.Enabled = false;
            txtdni.Enabled = false;
            txtdir.Enabled = false;
            txtobj.Enabled = false;
            txtep.Enabled = false;
            cbxgrado.Enabled = false;
            txthab.Enabled = false;
            cbxsede.Enabled = false;
            cbxcargo.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txttitulo.Enabled = true;
            txtnomb.Enabled = true;
            txtap.Enabled = true;
            txtnt.Enabled = true;
            txtce.Enabled = true;
            txtdni.Enabled = true;
            txtdir.Enabled = true;
            txtobj.Enabled = true;
            txtep.Enabled = true;
            cbxgrado.Enabled = true;
            txthab.Enabled = true;
            cbxsede.Enabled = true;
            cbxcargo.Enabled = true;

            txtid.Text = "";
            txttitulo.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtobj.Text = "";
            txtep.Text = "";
            cbxgrado.Text = "";
            txthab.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txttitulo.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtobj.Text = "";
            txtep.Text = "";
            cbxgrado.Text = "";
            txthab.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            APLICANTES_CLASS Aplicantes = new APLICANTES_CLASS();
            string a = "1234";

            try
            {
                

                Aplicantes.Add_Apl(
                    Convert.ToInt32(txtid.Text),
                    a,
                    txttitulo.Text,
                    txtnomb.Text,
                    txtap.Text,
                    txtnt.Text,
                    txtce.Text,
                    txtdni.Text,
                    txtdir.Text,
                    txtobj.Text,
                    txtep.Text,
                    cbxgrado.SelectedItem.ToString(),
                    txthab.Text,
                    Convert.ToInt32(cbxsede.SelectedValue),
                    Convert.ToInt32(cbxcargo.SelectedValue)
                    );
                Refresh();

                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            txttitulo.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtobj.Text = "";
            txtep.Text = "";
            cbxgrado.Text = "";
            txthab.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (txtid.Enabled == true)
            {
                //Obtienes la fila actual
                var row = (sender as DataGridView).CurrentRow;

                txtid.Text = row.Cells[0].Value.ToString();
                txttitulo.Text = row.Cells[1].Value.ToString();
                txtnomb.Text = row.Cells[2].Value.ToString();
                txtap.Text = row.Cells[3].Value.ToString();
                txtnt.Text = row.Cells[4].Value.ToString();
                txtce.Text = row.Cells[5].Value.ToString();
                txtdni.Text = row.Cells[6].Value.ToString();
                txtdir.Text = row.Cells[7].Value.ToString();
                txtobj.Text = row.Cells[8].Value.ToString();
                txtep.Text = row.Cells[9].Value.ToString();
                txthab.Text = row.Cells[11].Value.ToString();

        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            APLICANTES_CLASS Aplicantes = new APLICANTES_CLASS();
            string a = "1234";

            try
            {

                Aplicantes.Update_Apl(
                    Convert.ToInt32(txtid.Text),
                    a,
                    txttitulo.Text,
                    txtnomb.Text,
                    txtap.Text,
                    txtnt.Text,
                    txtce.Text,
                    txtdni.Text,
                    txtdir.Text,
                    txtobj.Text,
                    txtep.Text,
                    cbxgrado.SelectedItem.ToString(),
                    txthab.Text,
                    Convert.ToInt32(cbxsede.SelectedValue),
                    Convert.ToInt32(cbxcargo.SelectedValue)
                    );
                Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al actualizar: " + ex.Message);
            }

            txtid.Text = "";
            txttitulo.Text = "";
            txtnomb.Text = "";
            txtap.Text = "";
            txtnt.Text = "";
            txtce.Text = "";
            txtdni.Text = "";
            txtdir.Text = "";
            txtobj.Text = "";
            txtep.Text = "";
            cbxgrado.Text = "";
            txthab.Text = "";
            cbxsede.Text = "";
            cbxcargo.Text = "";


        }

        private void button5_Click(object sender, EventArgs e)
        {
            APLICANTES_CLASS Aplicantes = new APLICANTES_CLASS();


            try
            {

                Aplicantes.Delete_Apl(
                    Convert.ToInt32(txtid.Text));
                Refresh();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }

        }
    }
}
