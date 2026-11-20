namespace TP_campo
{
    partial class ListaLibroGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label labelFiltroTitulo;
        private System.Windows.Forms.TextBox textBoxFiltroTitulo;
        private System.Windows.Forms.Label labelFiltroAutor;
        private System.Windows.Forms.TextBox textBoxFiltroAutor;
        private System.Windows.Forms.Label labelFiltroISBN;
        private System.Windows.Forms.TextBox textBoxFiltroISBN;
        private System.Windows.Forms.Label labelFiltroGenero;
        private System.Windows.Forms.TextBox textBoxFiltroGenero;
        private System.Windows.Forms.Label labelFiltroEstado;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonSolicitarLibro;
        private System.Windows.Forms.DataGridView dataGridViewLibros;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVolumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.GroupBox groupBoxEdicion;
        private System.Windows.Forms.Label labelIdLibro;
        private System.Windows.Forms.TextBox textBoxIdLibro;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.Label labelISBN;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.Label labelGenero;
        private System.Windows.Forms.TextBox textBoxGenero;
        private System.Windows.Forms.Label labelVolumen;
        private System.Windows.Forms.NumericUpDown numericUpDownVolumen;
        private System.Windows.Forms.CheckBox checkBoxPrestado;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.labelFiltroTitulo = new System.Windows.Forms.Label();
            this.textBoxFiltroTitulo = new System.Windows.Forms.TextBox();
            this.labelFiltroAutor = new System.Windows.Forms.Label();
            this.textBoxFiltroAutor = new System.Windows.Forms.TextBox();
            this.labelFiltroISBN = new System.Windows.Forms.Label();
            this.textBoxFiltroISBN = new System.Windows.Forms.TextBox();
            this.labelFiltroGenero = new System.Windows.Forms.Label();
            this.textBoxFiltroGenero = new System.Windows.Forms.TextBox();
            this.labelFiltroEstado = new System.Windows.Forms.Label();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonSolicitarLibro = new System.Windows.Forms.Button();
            this.dataGridViewLibros = new System.Windows.Forms.DataGridView();
            this.colIdLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVolumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEdicion = new System.Windows.Forms.GroupBox();
            this.labelIdLibro = new System.Windows.Forms.Label();
            this.textBoxIdLibro = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelAutor = new System.Windows.Forms.Label();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.labelISBN = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.labelGenero = new System.Windows.Forms.Label();
            this.textBoxGenero = new System.Windows.Forms.TextBox();
            this.labelVolumen = new System.Windows.Forms.Label();
            this.numericUpDownVolumen = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPrestado = new System.Windows.Forms.CheckBox();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).BeginInit();
            this.groupBoxEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolumen)).BeginInit();
            this.SuspendLayout();
            //
            // groupBoxFiltros
            //
            this.groupBoxFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltros.Controls.Add(this.labelFiltroTitulo);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroTitulo);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroAutor);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroAutor);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroISBN);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroISBN);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroGenero);
            this.groupBoxFiltros.Controls.Add(this.textBoxFiltroGenero);
            this.groupBoxFiltros.Controls.Add(this.labelFiltroEstado);
            this.groupBoxFiltros.Controls.Add(this.comboBoxEstado);
            this.groupBoxFiltros.Controls.Add(this.buttonBuscar);
            this.groupBoxFiltros.Controls.Add(this.buttonLimpiar);
            this.groupBoxFiltros.Controls.Add(this.buttonSolicitarLibro);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(1056, 104);
            this.groupBoxFiltros.TabIndex = 0;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros";
            //
            // filtros
            //
            this.labelFiltroTitulo.AutoSize = true;
            this.labelFiltroTitulo.Location = new System.Drawing.Point(18, 28);
            this.labelFiltroTitulo.Name = "labelFiltroTitulo";
            this.labelFiltroTitulo.Text = "Título:";
            this.textBoxFiltroTitulo.Location = new System.Drawing.Point(74, 25);
            this.textBoxFiltroTitulo.Name = "textBoxFiltroTitulo";
            this.textBoxFiltroTitulo.Size = new System.Drawing.Size(170, 20);
            this.labelFiltroAutor.AutoSize = true;
            this.labelFiltroAutor.Location = new System.Drawing.Point(263, 28);
            this.labelFiltroAutor.Name = "labelFiltroAutor";
            this.labelFiltroAutor.Text = "Autor:";
            this.textBoxFiltroAutor.Location = new System.Drawing.Point(310, 25);
            this.textBoxFiltroAutor.Name = "textBoxFiltroAutor";
            this.textBoxFiltroAutor.Size = new System.Drawing.Size(170, 20);
            this.labelFiltroISBN.AutoSize = true;
            this.labelFiltroISBN.Location = new System.Drawing.Point(500, 28);
            this.labelFiltroISBN.Name = "labelFiltroISBN";
            this.labelFiltroISBN.Text = "ISBN:";
            this.textBoxFiltroISBN.Location = new System.Drawing.Point(545, 25);
            this.textBoxFiltroISBN.Name = "textBoxFiltroISBN";
            this.textBoxFiltroISBN.Size = new System.Drawing.Size(170, 20);
            this.labelFiltroGenero.AutoSize = true;
            this.labelFiltroGenero.Location = new System.Drawing.Point(18, 67);
            this.labelFiltroGenero.Name = "labelFiltroGenero";
            this.labelFiltroGenero.Text = "Género:";
            this.textBoxFiltroGenero.Location = new System.Drawing.Point(74, 64);
            this.textBoxFiltroGenero.Name = "textBoxFiltroGenero";
            this.textBoxFiltroGenero.Size = new System.Drawing.Size(170, 20);
            this.labelFiltroEstado.AutoSize = true;
            this.labelFiltroEstado.Location = new System.Drawing.Point(263, 67);
            this.labelFiltroEstado.Name = "labelFiltroEstado";
            this.labelFiltroEstado.Text = "Estado:";
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.Location = new System.Drawing.Point(310, 64);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(170, 21);
            this.buttonBuscar.Location = new System.Drawing.Point(545, 62);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(100, 23);
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Location = new System.Drawing.Point(660, 62);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(100, 23);
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonSolicitarLibro.Location = new System.Drawing.Point(775, 62);
            this.buttonSolicitarLibro.Name = "buttonSolicitarLibro";
            this.buttonSolicitarLibro.Size = new System.Drawing.Size(120, 23);
            this.buttonSolicitarLibro.Text = "Solicitar libro";
            this.buttonSolicitarLibro.UseVisualStyleBackColor = true;
            //
            // dataGridViewLibros
            //
            this.dataGridViewLibros.AllowUserToAddRows = false;
            this.dataGridViewLibros.AllowUserToDeleteRows = false;
            this.dataGridViewLibros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colIdLibro, this.colTitulo, this.colAutor, this.colISBN, this.colGenero, this.colVolumen, this.colEstado });
            this.dataGridViewLibros.Location = new System.Drawing.Point(12, 128);
            this.dataGridViewLibros.MultiSelect = false;
            this.dataGridViewLibros.Name = "dataGridViewLibros";
            this.dataGridViewLibros.ReadOnly = true;
            this.dataGridViewLibros.RowHeadersVisible = false;
            this.dataGridViewLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLibros.Size = new System.Drawing.Size(1056, 270);
            this.dataGridViewLibros.TabIndex = 1;
            this.colIdLibro.HeaderText = "ID Libro";
            this.colIdLibro.Name = "colIdLibro";
            this.colIdLibro.ReadOnly = true;
            this.colTitulo.HeaderText = "Título";
            this.colTitulo.Name = "colTitulo";
            this.colTitulo.ReadOnly = true;
            this.colAutor.HeaderText = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.ReadOnly = true;
            this.colISBN.HeaderText = "ISBN";
            this.colISBN.Name = "colISBN";
            this.colISBN.ReadOnly = true;
            this.colGenero.HeaderText = "Género";
            this.colGenero.Name = "colGenero";
            this.colGenero.ReadOnly = true;
            this.colVolumen.HeaderText = "Volumen";
            this.colVolumen.Name = "colVolumen";
            this.colVolumen.ReadOnly = true;
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            //
            // groupBoxEdicion
            //
            this.groupBoxEdicion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdicion.Controls.Add(this.labelIdLibro);
            this.groupBoxEdicion.Controls.Add(this.textBoxIdLibro);
            this.groupBoxEdicion.Controls.Add(this.labelTitulo);
            this.groupBoxEdicion.Controls.Add(this.textBoxTitulo);
            this.groupBoxEdicion.Controls.Add(this.labelAutor);
            this.groupBoxEdicion.Controls.Add(this.textBoxAutor);
            this.groupBoxEdicion.Controls.Add(this.labelISBN);
            this.groupBoxEdicion.Controls.Add(this.textBoxISBN);
            this.groupBoxEdicion.Controls.Add(this.labelGenero);
            this.groupBoxEdicion.Controls.Add(this.textBoxGenero);
            this.groupBoxEdicion.Controls.Add(this.labelVolumen);
            this.groupBoxEdicion.Controls.Add(this.numericUpDownVolumen);
            this.groupBoxEdicion.Controls.Add(this.checkBoxPrestado);
            this.groupBoxEdicion.Location = new System.Drawing.Point(12, 410);
            this.groupBoxEdicion.Name = "groupBoxEdicion";
            this.groupBoxEdicion.Size = new System.Drawing.Size(1056, 138);
            this.groupBoxEdicion.TabIndex = 2;
            this.groupBoxEdicion.TabStop = false;
            this.groupBoxEdicion.Text = "Edición del libro seleccionado";
            //
            // edición
            //
            this.labelIdLibro.AutoSize = true;
            this.labelIdLibro.Location = new System.Drawing.Point(18, 30);
            this.labelIdLibro.Name = "labelIdLibro";
            this.labelIdLibro.Text = "ID Libro:";
            this.textBoxIdLibro.Location = new System.Drawing.Point(89, 27);
            this.textBoxIdLibro.Name = "textBoxIdLibro";
            this.textBoxIdLibro.ReadOnly = true;
            this.textBoxIdLibro.Size = new System.Drawing.Size(120, 20);
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(230, 30);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Text = "Título:";
            this.textBoxTitulo.Location = new System.Drawing.Point(280, 27);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(230, 20);
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(530, 30);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Text = "Autor:";
            this.textBoxAutor.Location = new System.Drawing.Point(580, 27);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(230, 20);
            this.labelISBN.AutoSize = true;
            this.labelISBN.Location = new System.Drawing.Point(18, 75);
            this.labelISBN.Name = "labelISBN";
            this.labelISBN.Text = "ISBN:";
            this.textBoxISBN.Location = new System.Drawing.Point(89, 72);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(180, 20);
            this.labelGenero.AutoSize = true;
            this.labelGenero.Location = new System.Drawing.Point(290, 75);
            this.labelGenero.Name = "labelGenero";
            this.labelGenero.Text = "Género:";
            this.textBoxGenero.Location = new System.Drawing.Point(350, 72);
            this.textBoxGenero.Name = "textBoxGenero";
            this.textBoxGenero.Size = new System.Drawing.Size(180, 20);
            this.labelVolumen.AutoSize = true;
            this.labelVolumen.Location = new System.Drawing.Point(550, 75);
            this.labelVolumen.Name = "labelVolumen";
            this.labelVolumen.Text = "Número de volumen:";
            this.numericUpDownVolumen.Location = new System.Drawing.Point(670, 72);
            this.numericUpDownVolumen.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numericUpDownVolumen.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numericUpDownVolumen.Name = "numericUpDownVolumen";
            this.numericUpDownVolumen.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownVolumen.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.checkBoxPrestado.AutoSize = true;
            this.checkBoxPrestado.Enabled = false;
            this.checkBoxPrestado.Location = new System.Drawing.Point(790, 74);
            this.checkBoxPrestado.Name = "checkBoxPrestado";
            this.checkBoxPrestado.Text = "Prestado";
            this.checkBoxPrestado.UseVisualStyleBackColor = true;
            //
            // botones
            //
            this.buttonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEditar.Location = new System.Drawing.Point(12, 563);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(110, 28);
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGuardar.Location = new System.Drawing.Point(132, 563);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(110, 28);
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancelar.Location = new System.Drawing.Point(252, 563);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(110, 28);
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            //
            // ListaLibroGUI_62_BP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 606);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.groupBoxEdicion);
            this.Controls.Add(this.dataGridViewLibros);
            this.Controls.Add(this.groupBoxFiltros);
            this.MinimumSize = new System.Drawing.Size(900, 645);
            this.Name = "ListaLibroGUI_62_BP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de libros";
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibros)).EndInit();
            this.groupBoxEdicion.ResumeLayout(false);
            this.groupBoxEdicion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVolumen)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
