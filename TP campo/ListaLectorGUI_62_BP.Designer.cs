namespace TP_campo
{
    partial class ListaLectorGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelFiltroDNI;
        private System.Windows.Forms.TextBox textBoxFiltroDNI;
        private System.Windows.Forms.Label labelFiltroNombre;
        private System.Windows.Forms.TextBox textBoxFiltroNombre;
        private System.Windows.Forms.Label labelFiltroApellido;
        private System.Windows.Forms.TextBox textBoxFiltroApellido;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonAgregarLector;
        private System.Windows.Forms.DataGridView dataGridViewLectores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaNacimiento;
        private System.Windows.Forms.GroupBox groupBoxEdicion;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label labelFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacimiento;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.labelFiltroDNI = new System.Windows.Forms.Label();
            this.textBoxFiltroDNI = new System.Windows.Forms.TextBox();
            this.labelFiltroNombre = new System.Windows.Forms.Label();
            this.textBoxFiltroNombre = new System.Windows.Forms.TextBox();
            this.labelFiltroApellido = new System.Windows.Forms.Label();
            this.textBoxFiltroApellido = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonAgregarLector = new System.Windows.Forms.Button();
            this.dataGridViewLectores = new System.Windows.Forms.DataGridView();
            this.colDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEdicion = new System.Windows.Forms.GroupBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelApellido = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.labelFechaNacimiento = new System.Windows.Forms.Label();
            this.dateTimePickerFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectores)).BeginInit();
            this.groupBoxEdicion.SuspendLayout();
            this.SuspendLayout();
            //
            // groupBoxFiltros
            //
            this.groupBoxFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltros.Controls.Add(this.labelFiltroDNI);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroDNI);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroNombre);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroNombre);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroApellido);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroApellido);
            this.groupBoxFiltros.Controls.Add(this.buttonBuscar);
            this.groupBoxFiltros.Controls.Add(this.buttonLimpiar);
            this.groupBoxFiltros.Controls.Add(this.buttonAgregarLector);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(856, 92);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            //
            // filtros
            //
            this.labelFiltroDNI.AutoSize = true;
            this.labelFiltroDNI.Location = new System.Drawing.Point(18, 28);
            this.labelFiltroDNI.Name = "labelFiltroDNI";
            this.labelFiltroDNI.Text = "DNI:";
            this.textBoxFiltroDNI.Location = new System.Drawing.Point(60, 25);
            this.textBoxFiltroDNI.Name = "textBoxFiltroDNI";
            this.textBoxFiltroDNI.Size = new System.Drawing.Size(160, 20);
            this.labelFiltroNombre.AutoSize = true;
            this.labelFiltroNombre.Location = new System.Drawing.Point(240, 28);
            this.labelFiltroNombre.Name = "labelFiltroNombre";
            this.labelFiltroNombre.Text = "Nombre:";
            this.textBoxFiltroNombre.Location = new System.Drawing.Point(300, 25);
            this.textBoxFiltroNombre.Name = "textBoxFiltroNombre";
            this.textBoxFiltroNombre.Size = new System.Drawing.Size(160, 20);
            this.labelFiltroApellido.AutoSize = true;
            this.labelFiltroApellido.Location = new System.Drawing.Point(480, 28);
            this.labelFiltroApellido.Name = "labelFiltroApellido";
            this.labelFiltroApellido.Text = "Apellido:";
            this.textBoxFiltroApellido.Location = new System.Drawing.Point(540, 25);
            this.textBoxFiltroApellido.Name = "textBoxFiltroApellido";
            this.textBoxFiltroApellido.Size = new System.Drawing.Size(160, 20);
            this.buttonBuscar.Location = new System.Drawing.Point(60, 58);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 23);
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Location = new System.Drawing.Point(170, 58);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(100, 23);
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonAgregarLector.Location = new System.Drawing.Point(280, 58);
            this.buttonAgregarLector.Name = "buttonAgregarLector";
            this.buttonAgregarLector.Size = new System.Drawing.Size(120, 23);
            this.buttonAgregarLector.Text = "Agregar lector";
            this.buttonAgregarLector.UseVisualStyleBackColor = true;
            //
            // dataGridViewLectores
            //
            this.dataGridViewLectores.AllowUserToAddRows = false;
            this.dataGridViewLectores.AllowUserToDeleteRows = false;
            this.dataGridViewLectores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLectores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLectores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colDNI, this.colNombre, this.colApellido, this.colFechaNacimiento });
            this.dataGridViewLectores.Location = new System.Drawing.Point(12, 116);
            this.dataGridViewLectores.MultiSelect = false;
            this.dataGridViewLectores.Name = "dataGridViewLectores";
            this.dataGridViewLectores.ReadOnly = true;
            this.dataGridViewLectores.RowHeadersVisible = false;
            this.dataGridViewLectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLectores.Size = new System.Drawing.Size(856, 250);
            this.dataGridViewLectores.TabIndex = 1;
            this.colDNI.HeaderText = "DNI";
            this.colDNI.Name = "colDNI";
            this.colDNI.ReadOnly = true;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colApellido.HeaderText = "Apellido";
            this.colApellido.Name = "colApellido";
            this.colApellido.ReadOnly = true;
            this.colFechaNacimiento.HeaderText = "Fecha de nacimiento";
            this.colFechaNacimiento.Name = "colFechaNacimiento";
            this.colFechaNacimiento.ReadOnly = true;
            //
            // groupBoxEdicion
            //
            this.groupBoxEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdicion.Controls.Add(this.labelDNI);
            this.groupBoxEdicion.Controls.Add(this.textBoxDNI);
            this.groupBoxEdicion.Controls.Add(this.labelNombre);
            this.groupBoxEdicion.Controls.Add(this.textBoxNombre);
            this.groupBoxEdicion.Controls.Add(this.labelApellido);
            this.groupBoxEdicion.Controls.Add(this.textBoxApellido);
            this.groupBoxEdicion.Controls.Add(this.labelFechaNacimiento);
            this.groupBoxEdicion.Controls.Add(this.dateTimePickerFechaNacimiento);
            this.groupBoxEdicion.Location = new System.Drawing.Point(12, 378);
            this.groupBoxEdicion.Name = "groupBoxEdicion";
            this.groupBoxEdicion.Size = new System.Drawing.Size(856, 118);
            this.groupBoxEdicion.TabIndex = 2;
            this.groupBoxEdicion.TabStop = false;
            this.groupBoxEdicion.Text = "Edición del lector seleccionado";
            //
            // edición
            //
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(18, 30);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Text = "DNI:";
            this.textBoxDNI.Location = new System.Drawing.Point(80, 27);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.ReadOnly = true;
            this.textBoxDNI.Size = new System.Drawing.Size(170, 20);
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(280, 30);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Text = "Nombre:";
            this.textBoxNombre.Location = new System.Drawing.Point(345, 27);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(180, 20);
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(550, 30);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Text = "Apellido:";
            this.textBoxApellido.Location = new System.Drawing.Point(615, 27);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(180, 20);
            this.labelFechaNacimiento.AutoSize = true;
            this.labelFechaNacimiento.Location = new System.Drawing.Point(18, 75);
            this.labelFechaNacimiento.Name = "labelFechaNacimiento";
            this.labelFechaNacimiento.Text = "Fecha de nacimiento:";
            this.dateTimePickerFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaNacimiento.Location = new System.Drawing.Point(140, 72);
            this.dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            this.dateTimePickerFechaNacimiento.ShowCheckBox = true;
            this.dateTimePickerFechaNacimiento.Size = new System.Drawing.Size(150, 20);
            //
            // botones
            //
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditar.Location = new System.Drawing.Point(12, 511);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(110, 28);
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGuardar.Location = new System.Drawing.Point(132, 511);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(110, 28);
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.Location = new System.Drawing.Point(252, 511);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(110, 28);
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            //
            // ListaLectorGUI_62_BP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 554);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.groupBoxEdicion);
            this.Controls.Add(this.dataGridViewLectores);
            this.Controls.Add(this.groupBoxFiltros);
            this.MinimumSize = new System.Drawing.Size(760, 590);
            this.Name = "ListaLectorGUI_62_BP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de lectores";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectores)).EndInit();
            this.groupBoxEdicion.ResumeLayout(false);
            this.groupBoxEdicion.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
