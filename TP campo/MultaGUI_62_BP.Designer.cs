namespace TP_campo
{
    partial class MultaGUI_62_BP
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
            this.textBoxNumeroMulta = new System.Windows.Forms.TextBox();
            this.labelNumMulta = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.buttonBuscarMultas = new System.Windows.Forms.Button();
            this.textBoxNumPrestamo = new System.Windows.Forms.TextBox();
            this.labelNumeroPrestamo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonPagarMulta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNumeroMulta
            // 
            this.textBoxNumeroMulta.Location = new System.Drawing.Point(110, 50);
            this.textBoxNumeroMulta.Name = "textBoxNumeroMulta";
            this.textBoxNumeroMulta.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumeroMulta.TabIndex = 10;
            // 
            // labelNumMulta
            // 
            this.labelNumMulta.AutoSize = true;
            this.labelNumMulta.Location = new System.Drawing.Point(33, 53);
            this.labelNumMulta.Name = "labelNumMulta";
            this.labelNumMulta.Size = new System.Drawing.Size(58, 13);
            this.labelNumMulta.TabIndex = 9;
            this.labelNumMulta.Text = "Num Multa";
            this.labelNumMulta.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(109, 87);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(163, 20);
            this.textBoxDNI.TabIndex = 8;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(32, 90);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(59, 13);
            this.labelDNI.TabIndex = 7;
            this.labelDNI.Text = "DNI Lector";
            // 
            // buttonBuscarMultas
            // 
            this.buttonBuscarMultas.Location = new System.Drawing.Point(110, 116);
            this.buttonBuscarMultas.Name = "buttonBuscarMultas";
            this.buttonBuscarMultas.Size = new System.Drawing.Size(162, 23);
            this.buttonBuscarMultas.TabIndex = 15;
            this.buttonBuscarMultas.Text = "Buscar Multas";
            this.buttonBuscarMultas.UseVisualStyleBackColor = true;
            // 
            // textBoxNumPrestamo
            // 
            this.textBoxNumPrestamo.Location = new System.Drawing.Point(109, 12);
            this.textBoxNumPrestamo.Name = "textBoxNumPrestamo";
            this.textBoxNumPrestamo.Size = new System.Drawing.Size(163, 20);
            this.textBoxNumPrestamo.TabIndex = 17;
            // 
            // labelNumeroPrestamo
            // 
            this.labelNumeroPrestamo.AutoSize = true;
            this.labelNumeroPrestamo.Location = new System.Drawing.Point(32, 15);
            this.labelNumeroPrestamo.Name = "labelNumeroPrestamo";
            this.labelNumeroPrestamo.Size = new System.Drawing.Size(76, 13);
            this.labelNumeroPrestamo.TabIndex = 16;
            this.labelNumeroPrestamo.Text = "Num Prestamo";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 150);
            this.dataGridView1.TabIndex = 18;
            // 
            // buttonPagarMulta
            // 
            this.buttonPagarMulta.Enabled = false;
            this.buttonPagarMulta.Location = new System.Drawing.Point(109, 327);
            this.buttonPagarMulta.Name = "buttonPagarMulta";
            this.buttonPagarMulta.Size = new System.Drawing.Size(162, 23);
            this.buttonPagarMulta.TabIndex = 19;
            this.buttonPagarMulta.Text = "Pagar Multa";
            this.buttonPagarMulta.UseVisualStyleBackColor = true;
            // 
            // MultaGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 362);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonPagarMulta);
            this.Controls.Add(this.textBoxNumPrestamo);
            this.Controls.Add(this.labelNumeroPrestamo);
            this.Controls.Add(this.buttonBuscarMultas);
            this.Controls.Add(this.textBoxNumeroMulta);
            this.Controls.Add(this.labelNumMulta);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.labelDNI);
            this.Name = "MultaGUI_62_BP";
            this.Text = "MultaGUI_62_BP";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNumeroMulta;
        private System.Windows.Forms.Label labelNumMulta;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Button buttonBuscarMultas;
        private System.Windows.Forms.TextBox textBoxNumPrestamo;
        private System.Windows.Forms.Label labelNumeroPrestamo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonPagarMulta;
    }
}
