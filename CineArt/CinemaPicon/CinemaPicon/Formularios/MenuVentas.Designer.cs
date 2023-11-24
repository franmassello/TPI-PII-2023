﻿namespace CinemaPicon {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditarPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNuevoPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEliminarPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCerrarPrincipal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFiltrar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cbxFecha = new System.Windows.Forms.CheckBox();
            this.txtSinopsis = new System.Windows.Forms.TextBox();
            this.lblCodigoPeli = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblSinopsis = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTitutloPeli = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dtpFechaEstreno = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lblFechaEstreno = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnMinimizarse = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnSalirse = new Bunifu.Framework.UI.BunifuImageButton();
            this.cboIdioma = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirse)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnEditarPrincipal);
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
            // btnEditarPrincipal
            // 
            this.btnEditarPrincipal.Activecolor = System.Drawing.Color.White;
            this.btnEditarPrincipal.BackColor = System.Drawing.Color.White;
            this.btnEditarPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditarPrincipal.BorderRadius = 0;
            this.btnEditarPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnEditarPrincipal.ButtonText = "EDITAR";
            this.btnEditarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarPrincipal.DisabledColor = System.Drawing.Color.Gray;
            this.btnEditarPrincipal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditarPrincipal.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEditarPrincipal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEditarPrincipal.Iconimage")));
            this.btnEditarPrincipal.Iconimage_right = null;
            this.btnEditarPrincipal.Iconimage_right_Selected = null;
            this.btnEditarPrincipal.Iconimage_Selected = null;
            this.btnEditarPrincipal.IconMarginLeft = 0;
            this.btnEditarPrincipal.IconMarginRight = 0;
            this.btnEditarPrincipal.IconRightVisible = true;
            this.btnEditarPrincipal.IconRightZoom = 0D;
            this.btnEditarPrincipal.IconVisible = true;
            this.btnEditarPrincipal.IconZoom = 60D;
            this.btnEditarPrincipal.IsTab = false;
            this.btnEditarPrincipal.Location = new System.Drawing.Point(23, 415);
            this.btnEditarPrincipal.Name = "btnEditarPrincipal";
            this.btnEditarPrincipal.Normalcolor = System.Drawing.Color.White;
            this.btnEditarPrincipal.OnHovercolor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEditarPrincipal.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEditarPrincipal.selected = false;
            this.btnEditarPrincipal.Size = new System.Drawing.Size(200, 50);
            this.btnEditarPrincipal.TabIndex = 1;
            this.btnEditarPrincipal.Text = "EDITAR";
            this.btnEditarPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEditarPrincipal.Textcolor = System.Drawing.Color.DimGray;
            this.btnEditarPrincipal.TextFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPrincipal.Click += new System.EventHandler(this.BtnEditarPrincipal_Click);
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(276, 253);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(973, 443);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboIdioma);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.cbxFecha);
            this.groupBox1.Controls.Add(this.txtSinopsis);
            this.groupBox1.Controls.Add(this.lblCodigoPeli);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblSinopsis);
            this.groupBox1.Controls.Add(this.lblTitutloPeli);
            this.groupBox1.Controls.Add(this.dtpFechaEstreno);
            this.groupBox1.Controls.Add(this.lblFechaEstreno);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(276, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 196);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiltrar.BorderRadius = 0;
            this.btnFiltrar.ButtonText = "FILTRAR";
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.DisabledColor = System.Drawing.Color.Gray;
            this.btnFiltrar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFiltrar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.Iconimage")));
            this.btnFiltrar.Iconimage_right = null;
            this.btnFiltrar.Iconimage_right_Selected = null;
            this.btnFiltrar.Iconimage_Selected = null;
            this.btnFiltrar.IconMarginLeft = 0;
            this.btnFiltrar.IconMarginRight = 0;
            this.btnFiltrar.IconRightVisible = true;
            this.btnFiltrar.IconRightZoom = 0D;
            this.btnFiltrar.IconVisible = true;
            this.btnFiltrar.IconZoom = 60D;
            this.btnFiltrar.IsTab = false;
            this.btnFiltrar.Location = new System.Drawing.Point(816, 50);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnFiltrar.OnHovercolor = System.Drawing.Color.GreenYellow;
            this.btnFiltrar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFiltrar.selected = false;
            this.btnFiltrar.Size = new System.Drawing.Size(117, 64);
            this.btnFiltrar.TabIndex = 13;
            this.btnFiltrar.Text = "FILTRAR";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFiltrar.Textcolor = System.Drawing.Color.DimGray;
            this.btnFiltrar.TextFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // cbxFecha
            // 
            this.cbxFecha.AutoSize = true;
            this.cbxFecha.Location = new System.Drawing.Point(816, 23);
            this.cbxFecha.Name = "cbxFecha";
            this.cbxFecha.Size = new System.Drawing.Size(111, 20);
            this.cbxFecha.TabIndex = 8;
            this.cbxFecha.Text = "Filtrar por Fecha";
            this.cbxFecha.UseVisualStyleBackColor = true;
            this.cbxFecha.CheckStateChanged += new System.EventHandler(this.cbxFecha_CheckStateChanged);
            // 
            // txtSinopsis
            // 
            this.txtSinopsis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtSinopsis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSinopsis.ForeColor = System.Drawing.Color.DimGray;
            this.txtSinopsis.Location = new System.Drawing.Point(602, 88);
            this.txtSinopsis.Name = "txtSinopsis";
            this.txtSinopsis.Size = new System.Drawing.Size(162, 21);
            this.txtSinopsis.TabIndex = 7;
            // 
            // lblCodigoPeli
            // 
            this.lblCodigoPeli.AutoSize = true;
            this.lblCodigoPeli.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoPeli.ForeColor = System.Drawing.Color.DimGray;
            this.lblCodigoPeli.Location = new System.Drawing.Point(15, 34);
            this.lblCodigoPeli.Name = "lblCodigoPeli";
            this.lblCodigoPeli.Size = new System.Drawing.Size(160, 21);
            this.lblCodigoPeli.TabIndex = 62;
            this.lblCodigoPeli.Text = "Código de factura:";
            this.lblCodigoPeli.Click += new System.EventHandler(this.lblCodigoPeli_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Location = new System.Drawing.Point(226, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(162, 21);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // lblSinopsis
            // 
            this.lblSinopsis.AutoSize = true;
            this.lblSinopsis.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinopsis.ForeColor = System.Drawing.Color.DimGray;
            this.lblSinopsis.Location = new System.Drawing.Point(482, 86);
            this.lblSinopsis.Name = "lblSinopsis";
            this.lblSinopsis.Size = new System.Drawing.Size(62, 21);
            this.lblSinopsis.TabIndex = 64;
            this.lblSinopsis.Text = "Monto";
            this.lblSinopsis.Click += new System.EventHandler(this.lblSinopsis_Click);
            // 
            // lblTitutloPeli
            // 
            this.lblTitutloPeli.AutoSize = true;
            this.lblTitutloPeli.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitutloPeli.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitutloPeli.Location = new System.Drawing.Point(32, 88);
            this.lblTitutloPeli.Name = "lblTitutloPeli";
            this.lblTitutloPeli.Size = new System.Drawing.Size(135, 21);
            this.lblTitutloPeli.TabIndex = 63;
            this.lblTitutloPeli.Text = "Forma de pago:";
            // 
            // dtpFechaEstreno
            // 
            this.dtpFechaEstreno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.dtpFechaEstreno.BorderRadius = 0;
            this.dtpFechaEstreno.ForeColor = System.Drawing.Color.DimGray;
            this.dtpFechaEstreno.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFechaEstreno.FormatCustom = null;
            this.dtpFechaEstreno.Location = new System.Drawing.Point(634, 22);
            this.dtpFechaEstreno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFechaEstreno.Name = "dtpFechaEstreno";
            this.dtpFechaEstreno.Size = new System.Drawing.Size(162, 21);
            this.dtpFechaEstreno.TabIndex = 9;
            this.dtpFechaEstreno.Value = new System.DateTime(2019, 11, 14, 0, 0, 0, 0);
            // 
            // lblFechaEstreno
            // 
            this.lblFechaEstreno.AutoSize = true;
            this.lblFechaEstreno.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEstreno.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaEstreno.Location = new System.Drawing.Point(478, 22);
            this.lblFechaEstreno.Name = "lblFechaEstreno";
            this.lblFechaEstreno.Size = new System.Drawing.Size(140, 21);
            this.lblFechaEstreno.TabIndex = 60;
            this.lblFechaEstreno.Text = "Fecha de venta:";
            this.lblFechaEstreno.Click += new System.EventHandler(this.lblFechaEstreno_Click);
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
            // cboIdioma
            // 
            this.cboIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.cboIdioma.ForeColor = System.Drawing.Color.DimGray;
            this.cboIdioma.FormattingEnabled = true;
            this.cboIdioma.Location = new System.Drawing.Point(226, 90);
            this.cboIdioma.Name = "cboIdioma";
            this.cboIdioma.Size = new System.Drawing.Size(162, 24);
            this.cboIdioma.TabIndex = 65;
            // 
            // MenuVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnMinimizarse);
            this.Controls.Add(this.btnSalirse);
            this.Controls.Add(this.groupBox1);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizarse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalirse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnEditarPrincipal;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevoPrincipal;
        private Bunifu.Framework.UI.BunifuFlatButton btnEliminarPrincipal;
        private Bunifu.Framework.UI.BunifuFlatButton btnCerrarPrincipal;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimizarse;
        private Bunifu.Framework.UI.BunifuImageButton btnSalirse;
        private System.Windows.Forms.TextBox txtSinopsis;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCodigoPeli;
        private System.Windows.Forms.TextBox txtCodigo;
        private Bunifu.Framework.UI.BunifuCustomLabel lblSinopsis;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTitutloPeli;
        private Bunifu.Framework.UI.BunifuDatepicker dtpFechaEstreno;
        private Bunifu.Framework.UI.BunifuCustomLabel lblFechaEstreno;
        private System.Windows.Forms.CheckBox cbxFecha;
        private Bunifu.Framework.UI.BunifuFlatButton btnFiltrar;
        private System.Windows.Forms.ComboBox cboIdioma;
    }
}