namespace TP_campo
{
    partial class ManejoPrestamosGUI_62_BP
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
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.textBoxNumeroPrestamo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBuscarPrestamos = new System.Windows.Forms.Button();
            this.dataGridViewPrestamosFiltrados = new System.Windows.Forms.DataGridView();
            this.dataGridViewDetallePrestamo = new System.Windows.Forms.DataGridView();
            this.buttonSeleccionarPrestamo = new System.Windows.Forms.Button();
            this.buttonDevolverPrestamo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamosFiltrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallePrestamo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(120, 23);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(163, 20);
            this.textBoxDNI.TabIndex = 4;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(43, 26);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(59, 13);
            this.labelDNI.TabIndex = 3;
            this.labelDNI.Text = "DNI Lector";
            // 
            // textBoxNumeroPrestamo
            // 
            this.textBoxNumeroPrestamo.Location = new System.Drawing.Point(120, 68);
            this.textBoxNumeroPrestamo.Name = "textBoxNumeroPrestamo";
            this.textBoxNumeroPrestamo.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumeroPrestamo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Num Prestamo";
            // 
            // buttonBuscarPrestamos
            // 
            this.buttonBuscarPrestamos.Location = new System.Drawing.Point(120, 113);
            this.buttonBuscarPrestamos.Name = "buttonBuscarPrestamos";
            this.buttonBuscarPrestamos.Size = new System.Drawing.Size(162, 23);
            this.buttonBuscarPrestamos.TabIndex = 14;
            this.buttonBuscarPrestamos.Text = "Buscar Prestamos";
            this.buttonBuscarPrestamos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPrestamosFiltrados
            // 
            this.dataGridViewPrestamosFiltrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrestamosFiltrados.Location = new System.Drawing.Point(9, 142);
            this.dataGridViewPrestamosFiltrados.Name = "dataGridViewPrestamosFiltrados";
            this.dataGridViewPrestamosFiltrados.Size = new System.Drawing.Size(779, 143);
            this.dataGridViewPrestamosFiltrados.TabIndex = 15;
            // 
            // dataGridViewDetallePrestamo
            // 
            this.dataGridViewDetallePrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetallePrestamo.Location = new System.Drawing.Point(9, 320);
            this.dataGridViewDetallePrestamo.Name = "dataGridViewDetallePrestamo";
            this.dataGridViewDetallePrestamo.Size = new System.Drawing.Size(779, 143);
            this.dataGridViewDetallePrestamo.TabIndex = 16;
            // 
            // buttonSeleccionarPrestamo
            // 
            this.buttonSeleccionarPrestamo.Location = new System.Drawing.Point(120, 291);
            this.buttonSeleccionarPrestamo.Name = "buttonSeleccionarPrestamo";
            this.buttonSeleccionarPrestamo.Size = new System.Drawing.Size(162, 23);
            this.buttonSeleccionarPrestamo.TabIndex = 17;
            this.buttonSeleccionarPrestamo.Text = "Seleccionar  Prestamo";
            this.buttonSeleccionarPrestamo.UseVisualStyleBackColor = true;
            // 
            // buttonDevolverPrestamo
            // 
            this.buttonDevolverPrestamo.Enabled = false;
            this.buttonDevolverPrestamo.Location = new System.Drawing.Point(120, 479);
            this.buttonDevolverPrestamo.Name = "buttonDevolverPrestamo";
            this.buttonDevolverPrestamo.Size = new System.Drawing.Size(162, 23);
            this.buttonDevolverPrestamo.TabIndex = 18;
            this.buttonDevolverPrestamo.Text = "Devolver Prestamo";
            this.buttonDevolverPrestamo.UseVisualStyleBackColor = true;
            // 
            // ManejoPrestamosGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.buttonSeleccionarPrestamo);
            this.Controls.Add(this.buttonDevolverPrestamo);
            this.Controls.Add(this.dataGridViewDetallePrestamo);
            this.Controls.Add(this.dataGridViewPrestamosFiltrados);
            this.Controls.Add(this.buttonBuscarPrestamos);
            this.Controls.Add(this.textBoxNumeroPrestamo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Name = "ManejoPrestamosGUI_62_BP";
            this.Text = "ManejoPrestamosGUI_62_BP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrestamosFiltrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetallePrestamo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox textBoxNumeroPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBuscarPrestamos;
        private System.Windows.Forms.DataGridView dataGridViewPrestamosFiltrados;
        private System.Windows.Forms.DataGridView dataGridViewDetallePrestamo;
        private System.Windows.Forms.Button buttonSeleccionarPrestamo;
        private System.Windows.Forms.Button buttonDevolverPrestamo;
    }
}
