namespace TP_campo_62_BP
{
    partial class ReporteGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;

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
            this.labelReporte = new System.Windows.Forms.Label();
            this.comboBoxReporte = new System.Windows.Forms.ComboBox();
            this.labelFechaDesde = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.labelFechaHasta = new System.Windows.Forms.Label();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonExportar = new System.Windows.Forms.Button();
            this.dataGridViewReportes = new System.Windows.Forms.DataGridView();
            this.labelResumen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelReporte
            // 
            this.labelReporte.AutoSize = true;
            this.labelReporte.Location = new System.Drawing.Point(22, 24);
            this.labelReporte.Name = "labelReporte";
            this.labelReporte.Size = new System.Drawing.Size(48, 13);
            this.labelReporte.TabIndex = 0;
            this.labelReporte.Text = "Reporte";
            // 
            // comboBoxReporte
            // 
            this.comboBoxReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReporte.FormattingEnabled = true;
            this.comboBoxReporte.Location = new System.Drawing.Point(76, 20);
            this.comboBoxReporte.Name = "comboBoxReporte";
            this.comboBoxReporte.Size = new System.Drawing.Size(244, 21);
            this.comboBoxReporte.TabIndex = 1;
            this.comboBoxReporte.SelectedIndexChanged += new System.EventHandler(this.comboBoxReporte_SelectedIndexChanged);
            // 
            // labelFechaDesde
            // 
            this.labelFechaDesde.AutoSize = true;
            this.labelFechaDesde.Location = new System.Drawing.Point(345, 24);
            this.labelFechaDesde.Name = "labelFechaDesde";
            this.labelFechaDesde.Size = new System.Drawing.Size(69, 13);
            this.labelFechaDesde.TabIndex = 2;
            this.labelFechaDesde.Text = "Fecha desde";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(420, 20);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(110, 20);
            this.dateTimePickerDesde.TabIndex = 3;
            // 
            // labelFechaHasta
            // 
            this.labelFechaHasta.AutoSize = true;
            this.labelFechaHasta.Location = new System.Drawing.Point(550, 24);
            this.labelFechaHasta.Name = "labelFechaHasta";
            this.labelFechaHasta.Size = new System.Drawing.Size(66, 13);
            this.labelFechaHasta.TabIndex = 4;
            this.labelFechaHasta.Text = "Fecha hasta";
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(622, 20);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(110, 20);
            this.dateTimePickerHasta.TabIndex = 5;
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.Location = new System.Drawing.Point(754, 18);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(110, 25);
            this.buttonGenerar.TabIndex = 6;
            this.buttonGenerar.Text = "Generar";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(870, 18);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(110, 25);
            this.buttonLimpiar.TabIndex = 7;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonExportar
            // 
            this.buttonExportar.Enabled = false;
            this.buttonExportar.Location = new System.Drawing.Point(986, 18);
            this.buttonExportar.Name = "buttonExportar";
            this.buttonExportar.Size = new System.Drawing.Size(110, 25);
            this.buttonExportar.TabIndex = 8;
            this.buttonExportar.Text = "Exportar PDF";
            this.buttonExportar.UseVisualStyleBackColor = true;
            this.buttonExportar.Click += new System.EventHandler(this.buttonExportar_Click);
            // 
            // dataGridViewReportes
            // 
            this.dataGridViewReportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReportes.Location = new System.Drawing.Point(25, 72);
            this.dataGridViewReportes.Name = "dataGridViewReportes";
            this.dataGridViewReportes.Size = new System.Drawing.Size(1071, 474);
            this.dataGridViewReportes.TabIndex = 9;
            // 
            // labelResumen
            // 
            this.labelResumen.AutoSize = true;
            this.labelResumen.Location = new System.Drawing.Point(22, 52);
            this.labelResumen.Name = "labelResumen";
            this.labelResumen.Size = new System.Drawing.Size(72, 13);
            this.labelResumen.TabIndex = 10;
            this.labelResumen.Text = "Resultados: 0";
            // 
            // ReporteGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 570);
            this.Controls.Add(this.labelResumen);
            this.Controls.Add(this.dataGridViewReportes);
            this.Controls.Add(this.buttonExportar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonGenerar);
            this.Controls.Add(this.dateTimePickerHasta);
            this.Controls.Add(this.labelFechaHasta);
            this.Controls.Add(this.dateTimePickerDesde);
            this.Controls.Add(this.labelFechaDesde);
            this.Controls.Add(this.comboBoxReporte);
            this.Controls.Add(this.labelReporte);
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "ReporteGUI_62_BP";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.ReporteGUI_62_BP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelReporte;
        private System.Windows.Forms.ComboBox comboBoxReporte;
        private System.Windows.Forms.Label labelFechaDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.Label labelFechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Button buttonGenerar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonExportar;
        private System.Windows.Forms.DataGridView dataGridViewReportes;
        private System.Windows.Forms.Label labelResumen;
    }
}
