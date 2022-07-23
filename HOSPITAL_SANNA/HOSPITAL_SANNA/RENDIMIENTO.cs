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
    public partial class RENDIMIENTO : Form
    {
        public RENDIMIENTO()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            RENDIMIENTO_CLASS Rendimiento = new RENDIMIENTO_CLASS();
            dataGridView1.DataSource = Rendimiento.Get_Rend();
        }


        private void RENDIMIENTO_Load(object sender, EventArgs e)
        {
            Refresh();

            txtid.Text = "";
            
            txtfaltas.Text = "";
            txtobservaciones.Text = "";
            txtobjcump.Text = "";
            txthcump.Text = "";
            txtopinion.Text = "";

            
            txtid.Enabled = true;
            txtfaltas.Enabled = false;
            txtobservaciones.Enabled = false;
            txtobjcump.Enabled = false;
            txthcump.Enabled = false;
            txtopinion.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.Enabled = true;
            
            txtfaltas.Enabled = true;
            txtobservaciones.Enabled = true;
            txtobjcump.Enabled = true;
            txthcump.Enabled = true;
            txtopinion.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RENDIMIENTO_CLASS Rendimiento = new RENDIMIENTO_CLASS();

            try
            {

                Rendimiento.Add_Ren(int.Parse(txtid.Text), int.Parse(txtfaltas.Text), int.Parse(txtobservaciones.Text), int.Parse(txtobjcump.Text), int.Parse(txthcump.Text), txtopinion.Text);
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al guardar: " + ex.Message);
            }

            txtid.Text = "";
            
            txtfaltas.Text = "";
            txtobservaciones.Text = "";
            txtobjcump.Text = "";
            txthcump.Text = "";
            txtopinion.Text = "";


            txtid.Enabled = true;
           
            txtfaltas.Enabled = false;
            txtobservaciones.Enabled = false;
            txtobjcump.Enabled = false;
            txthcump.Enabled = false;
            txtopinion.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            RENDIMIENTO_CLASS Rendimiento = new RENDIMIENTO_CLASS();

            Rendimiento.Get_Req(int.Parse(txtid.Text));
            txtfaltas.Text = Rendimiento.Get_Req(int.Parse(txtid.Text)).Cant_faltas.ToString();
            txtobservaciones.Text = Rendimiento.Get_Req(int.Parse(txtid.Text)).Cant_Observ.ToString();
            txtobjcump.Text = Rendimiento.Get_Req(int.Parse(txtid.Text)).Cant_Obj_cumplid.ToString();
            txthcump.Text = Rendimiento.Get_Req(int.Parse(txtid.Text)).Cant_hor_cumplid.ToString();
            txtopinion.Text = Rendimiento.Get_Req(int.Parse(txtid.Text)).Opinion.ToString();


            txtid.Enabled = true;

            txtfaltas.Enabled = false;
            txtobservaciones.Enabled = false;
            txtobjcump.Enabled = false;
            txthcump.Enabled = false;
            txtopinion.Enabled = false;


        }
    }
}
