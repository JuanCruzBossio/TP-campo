namespace TP_campo
{
    partial class LibroHistoricoGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelIdLibro;
        private System.Windows.Forms.TextBox textBoxIdLibro;
        private System.Windows.Forms.Label labelEstadoPrestamo;
        private System.Windows.Forms.ComboBox comboBoxEstadoPrestamo;
        private System.Windows.Forms.Label labelEstadoVersion;
        private System.Windows.Forms.ComboBox comboBoxEstadoVersion;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonRecuperarEstado;
        private System.Windows.Forms.DataGridView dataGridViewHistoricos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaActualizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.labelIdLibro = new System.Windows.Forms.Label();
            this.textBoxIdLibro = new System.Windows.Forms.TextBox();
            this.labelEstadoPrestamo = new System.Windows.Forms.Label();
            this.comboBoxEstadoPrestamo = new System.Windows.Forms.ComboBox();
            this.labelEstadoVersion = new System.Windows.Forms.Label();
            this.comboBoxEstadoVersion = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonRecuperarEstado = new System.Windows.Forms.Button();
            this.dataGridViewHistoricos = new System.Windows.Forms.DataGridView();
            this.colFechaActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdHistorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricos)).BeginInit();
            this.SuspendLayout();
            //
            // groupBoxFiltros
            //
            this.groupBoxFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltros.Controls.Add(this.labelIdLibro);
            this.groupBoxFiltros.Controls.Add(this.textBoxIdLibro);
            this.groupBoxFiltros.Controls.Add(this.labelEstadoPrestamo);
            this.groupBoxFiltros.Controls.Add(this.comboBoxEstadoPrestamo);
            this.groupBoxFiltros.Controls.Add(this.labelEstadoVersion);
            this.groupBoxFiltros.Controls.Add(this.comboBoxEstadoVersion);
            this.groupBoxFiltros.Controls.Add(this.buttonBuscar);
            this.groupBoxFiltros.Controls.Add(this.buttonLimpiar);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(1056, 88);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            //
            // filter controls
            //
            this.labelIdLibro.AutoSize = true;
            this.labelIdLibro.Location = new System.Drawing.Point(18, 28);
            this.labelIdLibro.Name = "labelIdLibro";
            this.labelIdLibro.Text = "ID Libro:";
            this.textBoxIdLibro.Location = new System.Drawing.Point(80, 25);
            this.textBoxIdLibro.Name = "textBoxIdLibro";
            this.textBoxIdLibro.Size = new System.Drawing.Size(110, 20);
            this.labelEstadoPrestamo.AutoSize = true;
            this.labelEstadoPrestamo.Location = new System.Drawing.Point(215, 28);
            this.labelEstadoPrestamo.Name = "labelEstadoPrestamo";
            this.labelEstadoPrestamo.Text = "Estado del libro:";
            this.comboBoxEstadoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoPrestamo.FormattingEnabled = true;
            this.comboBoxEstadoPrestamo.Location = new System.Drawing.Point(315, 25);
            this.comboBoxEstadoPrestamo.Name = "comboBoxEstadoPrestamo";
            this.comboBoxEstadoPrestamo.Size = new System.Drawing.Size(145, 21);
            this.labelEstadoVersion.AutoSize = true;
            this.labelEstadoVersion.Location = new System.Drawing.Point(485, 28);
            this.labelEstadoVersion.Name = "labelEstadoVersion";
            this.labelEstadoVersion.Text = "Estado de version:";
            this.comboBoxEstadoVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoVersion.FormattingEnabled = true;
            this.comboBoxEstadoVersion.Location = new System.Drawing.Point(600, 25);
            this.comboBoxEstadoVersion.Name = "comboBoxEstadoVersion";
            this.comboBoxEstadoVersion.Size = new System.Drawing.Size(145, 21);
            this.buttonBuscar.Location = new System.Drawing.Point(80, 55);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 23);
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Location = new System.Drawing.Point(190, 55);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(100, 23);
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            //
            // dataGridViewHistoricos
            //
            this.dataGridViewHistoricos.AllowUserToAddRows = false;
            this.dataGridViewHistoricos.AllowUserToDeleteRows = false;
            this.dataGridViewHistoricos.AllowUserToOrderColumns = true;
            this.dataGridViewHistoricos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistoricos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistoricos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoricos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colFechaActualizacion, this.colIdHistorico, this.colIdLibro, this.colTitulo, this.colAutor, this.colISBN, this.colGenero, this.colVolumen, this.colPrestado, this.colActual });
            this.dataGridViewHistoricos.Location = new System.Drawing.Point(12, 112);
            this.dataGridViewHistoricos.MultiSelect = false;
            this.dataGridViewHistoricos.Name = "dataGridViewHistoricos";
            this.dataGridViewHistoricos.ReadOnly = true;
            this.dataGridViewHistoricos.RowHeadersVisible = false;
            this.dataGridViewHistoricos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistoricos.Size = new System.Drawing.Size(1056, 386);
            this.dataGridViewHistoricos.TabIndex = 1;
            this.colFechaActualizacion.HeaderText = "Fecha de actualizacion";
            this.colFechaActualizacion.Name = "colFechaActualizacion";
            this.colFechaActualizacion.ReadOnly = true;
            this.colFechaActualizacion.FillWeight = 120F;
            this.colIdHistorico.HeaderText = "ID Historico";
            this.colIdHistorico.Name = "colIdHistorico";
            this.colIdHistorico.ReadOnly = true;
            this.colIdHistorico.FillWeight = 60F;
            this.colIdLibro.HeaderText = "ID Libro";
            this.colIdLibro.Name = "colIdLibro";
            this.colIdLibro.ReadOnly = true;
            this.colIdLibro.FillWeight = 55F;
            this.colTitulo.HeaderText = "Titulo";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.ReadOnly = true;
            this.colTitulo.FillWeight = 115F;
            this.colAutor.HeaderText = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.ReadOnly = true;
            this.colISBN.HeaderText = "ISBN";
            this.colISBN.Name = "colISBN";
            this.colISBN.ReadOnly = true;
            this.colISBN.FillWeight = 80F;
            this.colGenero.HeaderText = "Genero";
            this.colGenero.Name = "colGenero";
            this.colGenero.ReadOnly = true;
            this.colGenero.FillWeight = 75F;
            this.colVolumen.HeaderText = "Volumen";
            this.colVolumen.Name = "colVolumen";
            this.colVolumen.ReadOnly = true;
            this.colVolumen.FillWeight = 55F;
            this.colPrestado.HeaderText = "Estado";
            this.colPrestado.Name = "colPrestado";
            this.colPrestado.ReadOnly = true;
            this.colPrestado.FillWeight = 70F;
            this.colActual.HeaderText = "Version";
            this.colActual.Name = "colActual";
            this.colActual.ReadOnly = true;
            this.colActual.FillWeight = 65F;
            //
            // buttonRecuperarEstado
            //
            this.buttonRecuperarEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRecuperarEstado.Location = new System.Drawing.Point(12, 510);
            this.buttonRecuperarEstado.Name = "buttonRecuperarEstado";
            this.buttonRecuperarEstado.Size = new System.Drawing.Size(140, 28);
            this.buttonRecuperarEstado.TabIndex = 2;
            this.buttonRecuperarEstado.Text = "Recuperar estado";
            this.buttonRecuperarEstado.UseVisualStyleBackColor = true;
            //
            // LibroHistoricoGUI_62_BP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 550);
            this.Controls.Add(this.buttonRecuperarEstado);
            this.Controls.Add(this.dataGridViewHistoricos);
            this.Controls.Add(this.groupBoxFiltros);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "LibroHistoricoGUI_62_BP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de libros";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoricos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
