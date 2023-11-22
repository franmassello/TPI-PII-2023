namespace CinemaPicon.Formularios
{
    partial class Reporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.Reporte300 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Reporte300
            // 
            this.Reporte300.ActiveViewIndex = -1;
            this.Reporte300.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Reporte300.Cursor = System.Windows.Forms.Cursors.Default;
            this.Reporte300.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reporte300.Location = new System.Drawing.Point(0, 0);
            this.Reporte300.Name = "Reporte300";
            this.Reporte300.Size = new System.Drawing.Size(1264, 681);
            this.Reporte300.TabIndex = 2;
            this.Reporte300.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Reporte300);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reporte_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Reporte300;
    }
}