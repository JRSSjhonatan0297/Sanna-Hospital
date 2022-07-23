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
    public partial class _04_JEFERRHH : Form
    {
        public _04_JEFERRHH()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _04_JEFERRHH_Load(object sender, EventArgs e)
        {

        }

        private void rEGISTRARPERSONALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PERSONAL frmp = new PERSONAL();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;

        }

        private void cALCULARREMUNERACIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CARCULAR_REMUNERACION frmp = new CARCULAR_REMUNERACION();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;
        }

        private void rvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TABLA_EVALUACION frmp = new TABLA_EVALUACION();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;
        }

        private void aREAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AREA frmp = new AREA();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;
        }

        private void cARGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CARGO frmp = new CARGO();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;
        }

        private void sEDEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SEDE frmp = new SEDE();
            frmp.Show();
            frmp.BringToFront();
            frmp.WindowState = FormWindowState.Normal;
        }
    }
}
