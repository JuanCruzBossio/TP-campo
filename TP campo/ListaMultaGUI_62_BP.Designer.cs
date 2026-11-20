namespace TP_campo
{
    partial class ListaMultaGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelFiltroIdMulta;
        private System.Windows.Forms.TextBox textBoxFiltroIdMulta;
        private System.Windows.Forms.Label labelFiltroIdPrestamo;
        private System.Windows.Forms.TextBox textBoxFiltroIdPrestamo;
        private System.Windows.Forms.Label labelFiltroDNI;
        private System.Windows.Forms.TextBox textBoxFiltroDNI;
        private System.Windows.Forms.Label labelFiltroEstado;
        private System.Windows.Forms.ComboBox comboBoxFiltroEstado;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.DataGridView dataGridViewMultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdMulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdPrestamo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.GroupBox groupBoxEdicion;
        private System.Windows.Forms.Label labelIdMulta;
        private System.Windows.Forms.TextBox textBoxIdMulta;
        private System.Windows.Forms.Label labelIdPrestamo;
        private System.Windows.Forms.TextBox textBoxIdPrestamo;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelMonto;
        private System.Windows.Forms.NumericUpDown numericUpDownMonto;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.Label labelMotivo;
        private System.Windows.Forms.TextBox textBoxMotivo;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.labelFiltroIdMulta = new System.Windows.Forms.Label();
            this.textBoxFiltroIdMulta = new System.Windows.Forms.TextBox();
            this.labelFiltroIdPrestamo = new System.Windows.Forms.Label();
            this.textBoxFiltroIdPrestamo = new System.Windows.Forms.TextBox();
            this.labelFiltroDNI = new System.Windows.Forms.Label();
            this.textBoxFiltroDNI = new System.Windows.Forms.TextBox();
            this.labelFiltroEstado = new System.Windows.Forms.Label();
            this.comboBoxFiltroEstado = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dataGridViewMultas = new System.Windows.Forms.DataGridView();
            this.colIdMulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdPrestamo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEdicion = new System.Windows.Forms.GroupBox();
            this.labelIdMulta = new System.Windows.Forms.Label();
            this.textBoxIdMulta = new System.Windows.Forms.TextBox();
            this.labelIdPrestamo = new System.Windows.Forms.Label();
            this.textBoxIdPrestamo = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelMonto = new System.Windows.Forms.Label();
            this.numericUpDownMonto = new System.Windows.Forms.NumericUpDown();
            this.labelEstado = new System.Windows.Forms.Label();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelMotivo = new System.Windows.Forms.Label();
            this.textBoxMotivo = new System.Windows.Forms.TextBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultas)).BeginInit();
            this.groupBoxEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonto)).BeginInit();
            this.SuspendLayout();
            //
            // groupBoxFiltros
            //
            this.groupBoxFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltros.Controls.Add(this.labelFiltroIdMulta);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroIdMulta);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroIdPrestamo);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroIdPrestamo);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroDNI);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroDNI);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroEstado);
            this.groupBoxFiltros.Controls.Add(this.comboBoxFiltroEstado);
            this.groupBoxFiltros.Controls.Add(this.buttonBuscar);
            this.groupBoxFiltros.Controls.Add(this.buttonLimpiar);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(956, 94);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            //
            // filter controls
            //
            this.labelFiltroIdMulta.AutoSize = true;
            this.labelFiltroIdMulta.Location = new System.Drawing.Point(18, 28);
            this.labelFiltroIdMulta.Name = "labelFiltroIdMulta";
            this.labelFiltroIdMulta.Text = "ID Multa:";
            this.textBoxFiltroIdMulta.Location = new System.Drawing.Point(82, 25);
            this.textBoxFiltroIdMulta.Name = "textBoxFiltroIdMulta";
            this.textBoxFiltroIdMulta.Size = new System.Drawing.Size(95, 20);
            this.labelFiltroIdPrestamo.AutoSize = true;
            this.labelFiltroIdPrestamo.Location = new System.Drawing.Point(198, 28);
            this.labelFiltroIdPrestamo.Name = "labelFiltroIdPrestamo";
            this.labelFiltroIdPrestamo.Text = "ID Prestamo:";
            this.textBoxFiltroIdPrestamo.Location = new System.Drawing.Point(280, 25);
            this.textBoxFiltroIdPrestamo.Name = "textBoxFiltroIdPrestamo";
            this.textBoxFiltroIdPrestamo.Size = new System.Drawing.Size(95, 20);
            this.labelFiltroDNI.AutoSize = true;
            this.labelFiltroDNI.Location = new System.Drawing.Point(400, 28);
            this.labelFiltroDNI.Name = "labelFiltroDNI";
            this.labelFiltroDNI.Text = "DNI:";
            this.textBoxFiltroDNI.Location = new System.Drawing.Point(438, 25);
            this.textBoxFiltroDNI.Name = "textBoxFiltroDNI";
            this.textBoxFiltroDNI.Size = new System.Drawing.Size(150, 20);
            this.labelFiltroEstado.AutoSize = true;
            this.labelFiltroEstado.Location = new System.Drawing.Point(612, 28);
            this.labelFiltroEstado.Name = "labelFiltroEstado";
            this.labelFiltroEstado.Text = "Estado:";
            this.comboBoxFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltroEstado.FormattingEnabled = true;
            this.comboBoxFiltroEstado.Location = new System.Drawing.Point(662, 25);
            this.comboBoxFiltroEstado.Name = "comboBoxFiltroEstado";
            this.comboBoxFiltroEstado.Size = new System.Drawing.Size(135, 21);
            this.buttonBuscar.Location = new System.Drawing.Point(82, 59);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 23);
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Location = new System.Drawing.Point(192, 59);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(100, 23);
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            //
            // dataGridViewMultas
            //
            this.dataGridViewMultas.AllowUserToAddRows = false;
            this.dataGridViewMultas.AllowUserToDeleteRows = false;
            this.dataGridViewMultas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMultas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colIdMulta, this.colIdPrestamo, this.colDNI, this.colMonto, this.colEstado, this.colMotivo });
            this.dataGridViewMultas.Location = new System.Drawing.Point(12, 118);
            this.dataGridViewMultas.MultiSelect = false;
            this.dataGridViewMultas.Name = "dataGridViewMultas";
            this.dataGridViewMultas.ReadOnly = true;
            this.dataGridViewMultas.RowHeadersVisible = false;
            this.dataGridViewMultas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMultas.Size = new System.Drawing.Size(956, 245);
            this.dataGridViewMultas.TabIndex = 1;
            this.colIdMulta.HeaderText = "ID Multa";
            this.colIdMulta.Name = "colIdMulta";
            this.colIdMulta.ReadOnly = true;
            this.colIdMulta.FillWeight = 55F;
            this.colIdPrestamo.HeaderText = "ID Prestamo";
            this.colIdPrestamo.Name = "colIdPrestamo";
            this.colIdPrestamo.ReadOnly = true;
            this.colIdPrestamo.FillWeight = 65F;
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            this.colDNI.FillWeight = 80F;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.FillWeight = 70F;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.FillWeight = 65F;
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            this.colMotivo.FillWeight = 180F;
            //
            // groupBoxEdicion
            //
            this.groupBoxEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdicion.Controls.Add(this.labelIdMulta);
            this.groupBoxEdicion.Controls.Add(this.textBoxIdMulta);
            this.groupBoxEdicion.Controls.Add(this.labelIdPrestamo);
            this.groupBoxEdicion.Controls.Add(this.textBoxIdPrestamo);
            this.groupBoxEdicion.Controls.Add(this.labelDNI);
            this.groupBoxEdicion.Controls.Add(this.textBoxDNI);
            this.groupBoxEdicion.Controls.Add(this.labelMonto);
            this.groupBoxEdicion.Controls.Add(this.numericUpDownMonto);
            this.groupBoxEdicion.Controls.Add(this.labelEstado);
            this.groupBoxEdicion.Controls.Add(this.textBoxEstado);
            this.groupBoxEdicion.Controls.Add(this.labelMotivo);
            this.groupBoxEdicion.Controls.Add(this.textBoxMotivo);
            this.groupBoxEdicion.Location = new System.Drawing.Point(12, 375);
            this.groupBoxEdicion.Name = "groupBoxEdicion";
            this.groupBoxEdicion.Size = new System.Drawing.Size(956, 145);
            this.groupBoxEdicion.TabIndex = 2;
            this.groupBoxEdicion.TabStop = false;
            this.groupBoxEdicion.Text = "Edicion de la multa seleccionada";
            //
            // edit controls
            //
            this.labelIdMulta.AutoSize = true;
            this.labelIdMulta.Location = new System.Drawing.Point(18, 30);
            this.labelIdMulta.Name = "labelIdMulta";
            this.labelIdMulta.Text = "ID Multa:";
            this.textBoxIdMulta.Location = new System.Drawing.Point(82, 27);
            this.textBoxIdMulta.Name = "textBoxIdMulta";
            this.textBoxIdMulta.ReadOnly = true;
            this.textBoxIdMulta.Size = new System.Drawing.Size(95, 20);
            this.labelIdPrestamo.AutoSize = true;
            this.labelIdPrestamo.Location = new System.Drawing.Point(198, 30);
            this.labelIdPrestamo.Name = "labelIdPrestamo";
            this.labelIdPrestamo.Text = "ID Prestamo:";
            this.textBoxIdPrestamo.Location = new System.Drawing.Point(280, 27);
            this.textBoxIdPrestamo.Name = "textBoxIdPrestamo";
            this.textBoxIdPrestamo.ReadOnly = true;
            this.textBoxIdPrestamo.Size = new System.Drawing.Size(95, 20);
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(400, 30);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Text = "DNI:";
            this.textBoxDNI.Location = new System.Drawing.Point(438, 27);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.ReadOnly = true;
            this.textBoxDNI.Size = new System.Drawing.Size(140, 20);
            this.labelMonto.AutoSize = true;
            this.labelMonto.Location = new System.Drawing.Point(602, 30);
            this.labelMonto.Name = "labelMonto";
            this.labelMonto.Text = "Monto:";
            this.numericUpDownMonto.Location = new System.Drawing.Point(652, 27);
            this.numericUpDownMonto.Maximum = new decimal(new int[] { 2147483647, 0, 0, 0 });
            this.numericUpDownMonto.Name = "numericUpDownMonto";
            this.numericUpDownMonto.Size = new System.Drawing.Size(125, 20);
            this.numericUpDownMonto.ThousandsSeparator = true;
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(18, 68);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Text = "Estado:";
            this.textBoxEstado.Location = new System.Drawing.Point(82, 65);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.ReadOnly = true;
            this.textBoxEstado.Size = new System.Drawing.Size(120, 20);
            this.labelMotivo.AutoSize = true;
            this.labelMotivo.Location = new System.Drawing.Point(224, 68);
            this.labelMotivo.Name = "labelMotivo";
            this.labelMotivo.Text = "Motivo:";
            this.textBoxMotivo.Location = new System.Drawing.Point(280, 65);
            this.textBoxMotivo.Multiline = true;
            this.textBoxMotivo.Name = "textBoxMotivo";
            this.textBoxMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMotivo.Size = new System.Drawing.Size(610, 60);
            //
            // buttons
            //
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditar.Location = new System.Drawing.Point(12, 535);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(110, 28);
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGuardar.Location = new System.Drawing.Point(132, 535);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(110, 28);
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.Location = new System.Drawing.Point(252, 535);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(110, 28);
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            //
            // ListaMultaGUI_62_BP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 578);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.groupBoxEdicion);
            this.Controls.Add(this.dataGridViewMultas);
            this.Controls.Add(this.groupBoxFiltros);
            this.MinimumSize = new System.Drawing.Size(850, 617);
            this.Name = "ListaMultaGUI_62_BP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de multas";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMultas)).EndInit();
            this.groupBoxEdicion.ResumeLayout(false);
            this.groupBoxEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonto)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
