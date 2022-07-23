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
    public partial class TABLA_EVALUACION : Form
    {
        public TABLA_EVALUACION()
        {
            InitializeComponent();
        }



        private void Refresh()
        {
            TABLA_EVALUACION_CLASS Empleados = new TABLA_EVALUACION_CLASS();
            dataGridView1.DataSource = Empleados.Get_Evalu();
        }


        private void TABLA_EVALUACION_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
