namespace TP_campo
{
    partial class SolicitudInsatisfechaGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxNumeroSolicitud;
        private System.Windows.Forms.Label labelNumeroSolicitud;
        private System.Windows.Forms.TextBox textBoxNumeroLibro;
        private System.Windows.Forms.Label labelNumeroLibro;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Button buttonBuscarSolicitudes;
        private System.Windows.Forms.DataGridView dataGridViewSolicitudes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTituloLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAutorLibro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDniSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaSolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAceptada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompletada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCompletada;
        private System.Windows.Forms.Button buttonAceptarSolicitud;
        private System.Windows.Forms.Button buttonCompletarSolicitud;

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
            this.textBoxNumeroSolicitud = new System.Windows.Forms.TextBox();
            this.labelNumeroSolicitud = new System.Windows.Forms.Label();
            this.textBoxNumeroLibro = new System.Windows.Forms.TextBox();
            this.labelNumeroLibro = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.buttonBuscarSolicitudes = new System.Windows.Forms.Button();
            this.dataGridViewSolicitudes = new System.Windows.Forms.DataGridView();
            this.colIdSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTituloLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAutorLibro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDniSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAceptada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompletada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCompletada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAceptarSolicitud = new System.Windows.Forms.Button();
            this.buttonCompletarSolicitud = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).BeginInit();
            this.SuspendLayout();
            //
            // textBoxNumeroSolicitud
            //
            this.textBoxNumeroSolicitud.Location = new System.Drawing.Point(125, 12);
            this.textBoxNumeroSolicitud.Name = "textBoxNumeroSolicitud";
            this.textBoxNumeroSolicitud.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumeroSolicitud.TabIndex = 1;
            //
            // labelNumeroSolicitud
            //
            this.labelNumeroSolicitud.AutoSize = true;
            this.labelNumeroSolicitud.Location = new System.Drawing.Point(25, 15);
            this.labelNumeroSolicitud.Name = "labelNumeroSolicitud";
            this.labelNumeroSolicitud.Size = new System.Drawing.Size(75, 13);
            this.labelNumeroSolicitud.TabIndex = 0;
            this.labelNumeroSolicitud.Text = "Num. Solicitud";
            //
            // textBoxNumeroLibro
            //
            this.textBoxNumeroLibro.Location = new System.Drawing.Point(125, 49);
            this.textBoxNumeroLibro.Name = "textBoxNumeroLibro";
            this.textBoxNumeroLibro.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumeroLibro.TabIndex = 3;
            //
            // labelNumeroLibro
            //
            this.labelNumeroLibro.AutoSize = true;
            this.labelNumeroLibro.Location = new System.Drawing.Point(25, 52);
            this.labelNumeroLibro.Name = "labelNumeroLibro";
            this.labelNumeroLibro.Size = new System.Drawing.Size(58, 13);
            this.labelNumeroLibro.TabIndex = 2;
            this.labelNumeroLibro.Text = "Num. Libro";
            //
            // textBoxDNI
            //
            this.textBoxDNI.Location = new System.Drawing.Point(125, 86);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(163, 20);
            this.textBoxDNI.TabIndex = 5;
            //
            // labelDNI
            //
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(25, 89);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(76, 13);
            this.labelDNI.TabIndex = 4;
            this.labelDNI.Text = "DNI Solicitante";
            //
            // buttonBuscarSolicitudes
            //
            this.buttonBuscarSolicitudes.Location = new System.Drawing.Point(125, 116);
            this.buttonBuscarSolicitudes.Name = "buttonBuscarSolicitudes";
            this.buttonBuscarSolicitudes.Size = new System.Drawing.Size(163, 23);
            this.buttonBuscarSolicitudes.TabIndex = 6;
            this.buttonBuscarSolicitudes.Text = "Buscar solicitudes";
            this.buttonBuscarSolicitudes.UseVisualStyleBackColor = true;
            //
            // dataGridViewSolicitudes
            //
            this.dataGridViewSolicitudes.AllowUserToAddRows = false;
            this.dataGridViewSolicitudes.AllowUserToDeleteRows = false;
            this.dataGridViewSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolicitudes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdSolicitud,
            this.colIdLibro,
            this.colTituloLibro,
            this.colAutorLibro,
            this.colDniSolicitante,
            this.colFechaSolicitud,
            this.colAceptada,
            this.colCompletada,
            this.colFechaCompletada});
            this.dataGridViewSolicitudes.Location = new System.Drawing.Point(25, 169);
            this.dataGridViewSolicitudes.MultiSelect = false;
            this.dataGridViewSolicitudes.Name = "dataGridViewSolicitudes";
            this.dataGridViewSolicitudes.ReadOnly = true;
            this.dataGridViewSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSolicitudes.Size = new System.Drawing.Size(775, 150);
            this.dataGridViewSolicitudes.TabIndex = 7;
            //
            // colIdSolicitud
            //
            this.colIdSolicitud.HeaderText = "Num. Solicitud";
            this.colIdSolicitud.Name = "colIdSolicitud";
            this.colIdSolicitud.ReadOnly = true;
            //
            // colIdLibro
            //
            this.colIdLibro.HeaderText = "Num. Libro";
            this.colIdLibro.Name = "colIdLibro";
            this.colIdLibro.ReadOnly = true;
            //
            // colTituloLibro
            //
            this.colTituloLibro.HeaderText = "Título";
            this.colTituloLibro.Name = "colTituloLibro";
            this.colTituloLibro.ReadOnly = true;
            //
            // colAutorLibro
            //
            this.colAutorLibro.HeaderText = "Autor";
            this.colAutorLibro.Name = "colAutorLibro";
            this.colAutorLibro.ReadOnly = true;
            //
            // colDniSolicitante
            //
            this.colDniSolicitante.HeaderText = "DNI Solicitante";
            this.colDniSolicitante.Name = "colDniSolicitante";
            this.colDniSolicitante.ReadOnly = true;
            //
            // colFechaSolicitud
            //
            this.colFechaSolicitud.HeaderText = "Fecha";
            this.colFechaSolicitud.Name = "colFechaSolicitud";
            this.colFechaSolicitud.ReadOnly = true;
            //
            // colAceptada
            //
            this.colAceptada.HeaderText = "Aceptada";
            this.colAceptada.Name = "colAceptada";
            this.colAceptada.ReadOnly = true;
            //
            // colCompletada
            //
            this.colCompletada.HeaderText = "Completada";
            this.colCompletada.Name = "colCompletada";
            this.colCompletada.ReadOnly = true;
            //
            // colFechaCompletada
            //
            this.colFechaCompletada.HeaderText = "Fecha completada";
            this.colFechaCompletada.Name = "colFechaCompletada";
            this.colFechaCompletada.ReadOnly = true;
            //
            // buttonAceptarSolicitud
            //
            this.buttonAceptarSolicitud.Enabled = false;
            this.buttonAceptarSolicitud.Location = new System.Drawing.Point(125, 327);
            this.buttonAceptarSolicitud.Name = "buttonAceptarSolicitud";
            this.buttonAceptarSolicitud.Size = new System.Drawing.Size(163, 23);
            this.buttonAceptarSolicitud.TabIndex = 8;
            this.buttonAceptarSolicitud.Text = "Aceptar solicitud";
            this.buttonAceptarSolicitud.UseVisualStyleBackColor = true;
            //
            // buttonCompletarSolicitud
            //
            this.buttonCompletarSolicitud.Enabled = false;
            this.buttonCompletarSolicitud.Location = new System.Drawing.Point(305, 327);
            this.buttonCompletarSolicitud.Name = "buttonCompletarSolicitud";
            this.buttonCompletarSolicitud.Size = new System.Drawing.Size(163, 23);
            this.buttonCompletarSolicitud.TabIndex = 9;
            this.buttonCompletarSolicitud.Text = "Completar solicitud";
            this.buttonCompletarSolicitud.UseVisualStyleBackColor = true;
            //
            // SolicitudInsatisfechaGUI_62_BP
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 362);
            this.Controls.Add(this.buttonCompletarSolicitud);
            this.Controls.Add(this.buttonAceptarSolicitud);
            this.Controls.Add(this.dataGridViewSolicitudes);
            this.Controls.Add(this.buttonBuscarSolicitudes);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.textBoxNumeroLibro);
            this.Controls.Add(this.labelNumeroLibro);
            this.Controls.Add(this.textBoxNumeroSolicitud);
            this.Controls.Add(this.labelNumeroSolicitud);
            this.Name = "SolicitudInsatisfechaGUI_62_BP";
            this.Text = "Manejo de solicitudes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolicitudes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
