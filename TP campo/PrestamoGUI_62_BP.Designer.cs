namespace TP_campo_62_BP
{
    partial class PrestamoGUI_62_BP
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
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.buttonValidar = new System.Windows.Forms.Button();
            this.buttonAgregarLibro = new System.Windows.Forms.Button();
            this.dataGridViewLibrosFiltrados = new System.Windows.Forms.DataGridView();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textBoxAutor = new System.Windows.Forms.TextBox();
            this.labelAutor = new System.Windows.Forms.Label();
            this.textBoxGenero = new System.Windows.Forms.TextBox();
            this.labelGenero = new System.Windows.Forms.Label();
            this.textBoxISBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBuscarLibros = new System.Windows.Forms.Button();
            this.dataGridViewLibrosSeleccionados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrosFiltrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrosSeleccionados)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(91, 22);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(59, 13);
            this.labelDNI.TabIndex = 0;
            this.labelDNI.Text = "DNI Lector";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(168, 19);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(163, 20);
            this.textBoxDNI.TabIndex = 1;
            // 
            // buttonValidar
            // 
            this.buttonValidar.Location = new System.Drawing.Point(337, 19);
            this.buttonValidar.Name = "buttonValidar";
            this.buttonValidar.Size = new System.Drawing.Size(75, 23);
            this.buttonValidar.TabIndex = 2;
            this.buttonValidar.Text = "Validar";
            this.buttonValidar.UseVisualStyleBackColor = true;
            this.buttonValidar.Click += new System.EventHandler(this.buttonValidar_Click_1);
            // 
            // buttonAgregarLibro
            // 
            this.buttonAgregarLibro.Location = new System.Drawing.Point(354, 393);
            this.buttonAgregarLibro.Name = "buttonAgregarLibro";
            this.buttonAgregarLibro.Size = new System.Drawing.Size(122, 23);
            this.buttonAgregarLibro.TabIndex = 3;
            this.buttonAgregarLibro.Text = "Agregar Libro";
            this.buttonAgregarLibro.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLibrosFiltrados
            // 
            this.dataGridViewLibrosFiltrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibrosFiltrados.Location = new System.Drawing.Point(32, 244);
            this.dataGridViewLibrosFiltrados.Name = "dataGridViewLibrosFiltrados";
            this.dataGridViewLibrosFiltrados.Size = new System.Drawing.Size(779, 143);
            this.dataGridViewLibrosFiltrados.TabIndex = 4;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(108, 103);
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(163, 20);
            this.textBoxTitulo.TabIndex = 6;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(29, 106);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(33, 13);
            this.labelTitulo.TabIndex = 5;
            this.labelTitulo.Text = "Titulo";
            // 
            // textBoxAutor
            // 
            this.textBoxAutor.Location = new System.Drawing.Point(107, 129);
            this.textBoxAutor.Name = "textBoxAutor";
            this.textBoxAutor.Size = new System.Drawing.Size(163, 20);
            this.textBoxAutor.TabIndex = 8;
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Location = new System.Drawing.Point(31, 132);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(32, 13);
            this.labelAutor.TabIndex = 7;
            this.labelAutor.Text = "Autor";
            // 
            // textBoxGenero
            // 
            this.textBoxGenero.Location = new System.Drawing.Point(108, 155);
            this.textBoxGenero.Name = "textBoxGenero";
            this.textBoxGenero.Size = new System.Drawing.Size(163, 20);
            this.textBoxGenero.TabIndex = 10;
            // 
            // labelGenero
            // 
            this.labelGenero.AutoSize = true;
            this.labelGenero.Location = new System.Drawing.Point(31, 158);
            this.labelGenero.Name = "labelGenero";
            this.labelGenero.Size = new System.Drawing.Size(42, 13);
            this.labelGenero.TabIndex = 9;
            this.labelGenero.Text = "Genero";
            // 
            // textBoxISBN
            // 
            this.textBoxISBN.Location = new System.Drawing.Point(107, 181);
            this.textBoxISBN.Name = "textBoxISBN";
            this.textBoxISBN.Size = new System.Drawing.Size(163, 20);
            this.textBoxISBN.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ISBN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonBuscarLibros
            // 
            this.buttonBuscarLibros.Location = new System.Drawing.Point(108, 215);
            this.buttonBuscarLibros.Name = "buttonBuscarLibros";
            this.buttonBuscarLibros.Size = new System.Drawing.Size(162, 23);
            this.buttonBuscarLibros.TabIndex = 13;
            this.buttonBuscarLibros.Text = "Buscar Libros";
            this.buttonBuscarLibros.UseVisualStyleBackColor = true;
            //
            // PrestamoGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 632);
            this.Controls.Add(this.buttonBuscarLibros);
            this.Controls.Add(this.textBoxISBN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxGenero);
            this.Controls.Add(this.labelGenero);
            this.Controls.Add(this.textBoxAutor);
            this.Controls.Add(this.labelAutor);
            this.Controls.Add(this.textBoxTitulo);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dataGridViewLibrosFiltrados);
            this.Controls.Add(this.buttonAgregarLibro);
            this.Controls.Add(this.buttonValidar);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Name = "PrestamoGUI_62_BP";
            this.Text = "PrestamoGUI_62_BP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrosFiltrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrosSeleccionados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Button buttonValidar;
        private System.Windows.Forms.Button buttonAgregarLibro;
        private System.Windows.Forms.DataGridView dataGridViewLibrosFiltrados;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textBoxAutor;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.TextBox textBoxGenero;
        private System.Windows.Forms.Label labelGenero;
        private System.Windows.Forms.TextBox textBoxISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBuscarLibros;
        private System.Windows.Forms.DataGridView dataGridViewLibrosSeleccionados;
    }
}