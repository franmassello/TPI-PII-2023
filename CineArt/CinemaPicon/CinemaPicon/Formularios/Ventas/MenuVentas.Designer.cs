namespace CinemaPicon {
    partial class MenuVentas {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuVentas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNuevoPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEliminarPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCerrarPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMinimizarse = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnSalirse = new Bunifu.Framework.UI.BunifuImageButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirse)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnNuevoPrincipal);
            this.panel1.Controls.Add(this.btnEliminarPrincipal);
            this.panel1.Controls.Add(this.btnCerrarPrincipal);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 720);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // btnNuevoPrincipal
            // 
            this.btnNuevoPrincipal.Activecolor = System.Drawing.Color.White;
            this.btnNuevoPrincipal.BackColor = System.Drawing.Color.White;
            this.btnNuevoPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevoPrincipal.BorderRadius = 0;
            this.btnNuevoPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnNuevoPrincipal.ButtonText = "NUEVO";
            this.btnNuevoPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPrincipal.DisabledColor = System.Drawing.Color.Gray;
            this.btnNuevoPrincipal.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevoPrincipal.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNuevoPrincipal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNuevoPrincipal.Iconimage")));
            this.btnNuevoPrincipal.Iconimage_right = null;
            this.btnNuevoPrincipal.Iconimage_right_Selected = null;
            this.btnNuevoPrincipal.Iconimage_Selected = null;
            this.btnNuevoPrincipal.IconMarginLeft = 0;
            this.btnNuevoPrincipal.IconMarginRight = 0;
            this.btnNuevoPrincipal.IconRightVisible = true;
            this.btnNuevoPrincipal.IconRightZoom = 0D;
            this.btnNuevoPrincipal.IconVisible = true;
            this.btnNuevoPrincipal.IconZoom = 65D;
            this.btnNuevoPrincipal.IsTab = false;
            this.btnNuevoPrincipal.Location = new System.Drawing.Point(23, 337);
            this.btnNuevoPrincipal.Name = "btnNuevoPrincipal";
            this.btnNuevoPrincipal.Normalcolor = System.Drawing.Color.White;
            this.btnNuevoPrincipal.OnHovercolor = System.Drawing.SystemColors.MenuHighlight;
            this.btnNuevoPrincipal.OnHoverTextColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevoPrincipal.selected = false;
            this.btnNuevoPrincipal.Size = new System.Drawing.Size(200, 50);
            this.btnNuevoPrincipal.TabIndex = 0;
            this.btnNuevoPrincipal.Text = "NUEVO";
            this.btnNuevoPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevoPrincipal.Textcolor = System.Drawing.Color.DimGray;
            this.btnNuevoPrincipal.TextFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPrincipal.Click += new System.EventHandler(this.BtnNuevoPrincipal_Click);
            // 
            // btnEliminarPrincipal
            // 
            this.btnEliminarPrincipal.Activecolor = System.Drawing.Color.White;
            this.btnEliminarPrincipal.BackColor = System.Drawing.Color.White;
            this.btnEliminarPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarPrincipal.BorderRadius = 0;
            this.btnEliminarPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnEliminarPrincipal.ButtonText = "ELIMINAR";
            this.btnEliminarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarPrincipal.DisabledColor = System.Drawing.Color.Gray;
            this.btnEliminarPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEliminarPrincipal.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEliminarPrincipal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEliminarPrincipal.Iconimage")));
            this.btnEliminarPrincipal.Iconimage_right = null;
            this.btnEliminarPrincipal.Iconimage_right_Selected = null;
            this.btnEliminarPrincipal.Iconimage_Selected = null;
            this.btnEliminarPrincipal.IconMarginLeft = 0;
            this.btnEliminarPrincipal.IconMarginRight = 0;
            this.btnEliminarPrincipal.IconRightVisible = true;
            this.btnEliminarPrincipal.IconRightZoom = 0D;
            this.btnEliminarPrincipal.IconVisible = true;
            this.btnEliminarPrincipal.IconZoom = 70D;
            this.btnEliminarPrincipal.IsTab = false;
            this.btnEliminarPrincipal.Location = new System.Drawing.Point(23, 492);
            this.btnEliminarPrincipal.Name = "btnEliminarPrincipal";
            this.btnEliminarPrincipal.Normalcolor = System.Drawing.Color.White;
            this.btnEliminarPrincipal.OnHovercolor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEliminarPrincipal.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEliminarPrincipal.selected = false;
            this.btnEliminarPrincipal.Size = new System.Drawing.Size(200, 50);
            this.btnEliminarPrincipal.TabIndex = 2;
            this.btnEliminarPrincipal.Text = "ELIMINAR";
            this.btnEliminarPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEliminarPrincipal.Textcolor = System.Drawing.Color.DimGray;
            this.btnEliminarPrincipal.TextFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPrincipal.Click += new System.EventHandler(this.BtnEliminarPrincipal_Click);
            // 
            // btnCerrarPrincipal
            // 
            this.btnCerrarPrincipal.Activecolor = System.Drawing.Color.White;
            this.btnCerrarPrincipal.BackColor = System.Drawing.Color.White;
            this.btnCerrarPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrarPrincipal.BorderRadius = 0;
            this.btnCerrarPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnCerrarPrincipal.ButtonText = "CERRAR SESIÓN";
            this.btnCerrarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarPrincipal.DisabledColor = System.Drawing.Color.Gray;
            this.btnCerrarPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarPrincipal.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCerrarPrincipal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCerrarPrincipal.Iconimage")));
            this.btnCerrarPrincipal.Iconimage_right = null;
            this.btnCerrarPrincipal.Iconimage_right_Selected = null;
            this.btnCerrarPrincipal.Iconimage_Selected = null;
            this.btnCerrarPrincipal.IconMarginLeft = 0;
            this.btnCerrarPrincipal.IconMarginRight = 0;
            this.btnCerrarPrincipal.IconRightVisible = true;
            this.btnCerrarPrincipal.IconRightZoom = 0D;
            this.btnCerrarPrincipal.IconVisible = true;
            this.btnCerrarPrincipal.IconZoom = 70D;
            this.btnCerrarPrincipal.IsTab = false;
            this.btnCerrarPrincipal.Location = new System.Drawing.Point(23, 641);
            this.btnCerrarPrincipal.Name = "btnCerrarPrincipal";
            this.btnCerrarPrincipal.Normalcolor = System.Drawing.Color.White;
            this.btnCerrarPrincipal.OnHovercolor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCerrarPrincipal.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCerrarPrincipal.selected = false;
            this.btnCerrarPrincipal.Size = new System.Drawing.Size(200, 45);
            this.btnCerrarPrincipal.TabIndex = 4;
            this.btnCerrarPrincipal.Text = "CERRAR SESIÓN";
            this.btnCerrarPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCerrarPrincipal.Textcolor = System.Drawing.Color.DimGray;
            this.btnCerrarPrincipal.TextFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPrincipal.Click += new System.EventHandler(this.BtnCerrarPrincipal_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 196);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(276, 253);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(973, 443);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnMinimizarse
            // 
            this.btnMinimizarse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnMinimizarse.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizarse.Image")));
            this.btnMinimizarse.ImageActive = null;
            this.btnMinimizarse.Location = new System.Drawing.Point(1188, 2);
            this.btnMinimizarse.Name = "btnMinimizarse";
            this.btnMinimizarse.Size = new System.Drawing.Size(40, 33);
            this.btnMinimizarse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizarse.TabIndex = 30;
            this.btnMinimizarse.TabStop = false;
            this.btnMinimizarse.Zoom = 10;
            this.btnMinimizarse.Click += new System.EventHandler(this.BtnMinimizarse_Click);
            // 
            // btnSalirse
            // 
            this.btnSalirse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSalirse.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirse.Image")));
            this.btnSalirse.ImageActive = null;
            this.btnSalirse.Location = new System.Drawing.Point(1234, 2);
            this.btnSalirse.Name = "btnSalirse";
            this.btnSalirse.Size = new System.Drawing.Size(36, 33);
            this.btnSalirse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalirse.TabIndex = 29;
            this.btnSalirse.TabStop = false;
            this.btnSalirse.Zoom = 10;
            this.btnSalirse.Click += new System.EventHandler(this.BtnSalirse_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(542, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(429, 64);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "GESTION VENTAS";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MenuVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnMinimizarse);
            this.Controls.Add(this.btnSalirse);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Principal_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevoPrincipal;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminarPrincipal;
        private Bunifu.Framework.UI.BunifuFlatButton btnCerrarPrincipal;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizarse;
        private Bunifu.Framework.UI.BunifuImageButton btnSalirse;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}