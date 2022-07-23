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
    public partial class _02_JEFEAREA : Form
    {
        public _02_JEFEAREA()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void _02_JEFEAREA_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            REQUERIMIENTOS frmr = new REQUERIMIENTOS();

          
            frmr.ShowDialog();
            frmr.BringToFront();
            frmr.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OBSERVACIONES frmobs = new OBSERVACIONES();
            frmobs.Show();
            frmobs.BringToFront();
            frmobs.WindowState = FormWindowState.Normal;
        }

        private void rENDIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RENDIMIENTO frmobs = new RENDIMIENTO();
            frmobs.Show();
            frmobs.BringToFront();
            frmobs.WindowState = FormWindowState.Normal;
        }
    }
}
