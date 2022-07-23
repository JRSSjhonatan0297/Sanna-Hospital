namespace HOSPITAL_SANNA
{
    partial class _03_JEFESELECCION
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rEGISTROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eVALUACIONESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSISTENCIASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.eVALUACIONESToolStripMenuItem,
            this.aSISTENCIASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rEGISTROToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.toolStripMenuItem1.Text = "APLICANTES";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // rEGISTROToolStripMenuItem
            // 
            this.rEGISTROToolStripMenuItem.Name = "rEGISTROToolStripMenuItem";
            this.rEGISTROToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rEGISTROToolStripMenuItem.Text = "REGISTRO";
            this.rEGISTROToolStripMenuItem.Click += new System.EventHandler(this.rEGISTROToolStripMenuItem_Click);
            // 
            // eVALUACIONESToolStripMenuItem
            // 
            this.eVALUACIONESToolStripMenuItem.Name = "eVALUACIONESToolStripMenuItem";
            this.eVALUACIONESToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.eVALUACIONESToolStripMenuItem.Text = "EVALUACIONES";
            this.eVALUACIONESToolStripMenuItem.Click += new System.EventHandler(this.eVALUACIONESToolStripMenuItem_Click);
            // 
            // aSISTENCIASToolStripMenuItem
            // 
            this.aSISTENCIASToolStripMenuItem.Name = "aSISTENCIASToolStripMenuItem";
            this.aSISTENCIASToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.aSISTENCIASToolStripMenuItem.Text = "ASISTENCIAS";
            this.aSISTENCIASToolStripMenuItem.Click += new System.EventHandler(this.aSISTENCIASToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "JEFE DE SELECCION";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 379);
            this.panel1.TabIndex = 18;
            // 
            // _03_JEFESELECCION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 403);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "_03_JEFESELECCION";
            this.Text = "_03_JEFESELECCION";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rEGISTROToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem eVALUACIONESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSISTENCIASToolStripMenuItem;
    }
}