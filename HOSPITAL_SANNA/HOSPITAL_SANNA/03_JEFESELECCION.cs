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
    public partial class _03_JEFESELECCION : Form
    {
        public _03_JEFESELECCION()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rEGISTROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            APLICANTES frmap = new APLICANTES();
            frmap.Show();
            frmap.BringToFront();
            frmap.WindowState = FormWindowState.Normal;
        }

        private void eVALUACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TABLA_EVALUACION frmap = new TABLA_EVALUACION();
            frmap.Show();
            frmap.BringToFront();
            frmap.WindowState = FormWindowState.Normal;
        }

        private void aSISTENCIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ASISTENCIA frmap = new ASISTENCIA();
            frmap.Show();
            frmap.BringToFront();
            frmap.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
