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
    public partial class REQUERIMIENTOS : Form
    {
        public REQUERIMIENTOS()
        {
            InitializeComponent();

        }


        private void Refresh()
        {
            REQUERIMIENTOS_CLASS Requerimientos = new REQUERIMIENTOS_CLASS();
            dataGridView1.DataSource = Requerimientos.Get_Requ();
        }



        private void REQUERIMIENTOS_Load(object sender, EventArgs e)
        {
            Refresh();
            txtid.Text = "";
            txtdesc.Text = "";
            txtid.Enabled = false;
            txtdesc.Enabled = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            txtdesc.Enabled = true;
            txtid.Text = "";
            txtdesc.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            REQUERIMIENTOS_CLASS Requerimientos = new REQUERIMIENTOS_CLASS();
                try
                {
                    Requerimientos.Update_Req(int.Parse(txtid.Text), txtdesc.Text);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al actualizar: " + ex.Message);
                }

                txtid.Enabled = true;
                txtdesc.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            REQUERIMIENTOS_CLASS Requerimientos = new REQUERIMIENTOS_CLASS();

            try
                {
                   
                    Requerimientos.Add_Req(int.Parse(txtid.Text), txtdesc.Text);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
                }

            txtid.Text = "";
            txtdesc.Text = "";

            }

        private void button4_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtdesc.Text = "";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (txtid.Enabled == true)
            {
                //Obtienes la fila actual
                var row = (sender as DataGridView).CurrentRow;

                txtid.Text = row.Cells[0].Value.ToString();
                txtdesc.Text = row.Cells[1].Value.ToString();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            REQUERIMIENTOS_CLASS Requerimientos = new REQUERIMIENTOS_CLASS();
            try
            {
                Requerimientos.Delete_Req(int.Parse(txtid.Text));
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar: " + ex.Message);
            }

            txtid.Enabled = true;
            txtdesc.Enabled = true;
        }
 
    }
}
