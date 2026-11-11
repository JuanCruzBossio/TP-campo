namespace TP_campo
{
    partial class LibroGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.TextBox txt_titulo;
        private System.Windows.Forms.Label lbl_autor;
        private System.Windows.Forms.TextBox txt_autor;
        private System.Windows.Forms.Label lbl_isbn;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.Label lbl_genero;
        private System.Windows.Forms.TextBox txt_genero;
        private System.Windows.Forms.Label lbl_numeroVolumen;
        private System.Windows.Forms.NumericUpDown nud_numeroVolumen;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_cancelar;

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
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.lbl_autor = new System.Windows.Forms.Label();
            this.txt_autor = new System.Windows.Forms.TextBox();
            this.lbl_isbn = new System.Windows.Forms.Label();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.lbl_genero = new System.Windows.Forms.Label();
            this.txt_genero = new System.Windows.Forms.TextBox();
            this.lbl_numeroVolumen = new System.Windows.Forms.Label();
            this.nud_numeroVolumen = new System.Windows.Forms.NumericUpDown();
            this.btn_crear = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_numeroVolumen)).BeginInit();
            this.SuspendLayout();
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Location = new System.Drawing.Point(30, 25);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(36, 13);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Titulo:";
            this.txt_titulo.Location = new System.Drawing.Point(30, 45);
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.Size = new System.Drawing.Size(240, 20);
            this.txt_titulo.TabIndex = 1;
            this.lbl_autor.AutoSize = true;
            this.lbl_autor.Location = new System.Drawing.Point(30, 80);
            this.lbl_autor.Name = "lbl_autor";
            this.lbl_autor.Size = new System.Drawing.Size(35, 13);
            this.lbl_autor.TabIndex = 2;
            this.lbl_autor.Text = "Autor:";
            this.txt_autor.Location = new System.Drawing.Point(30, 100);
            this.txt_autor.Name = "txt_autor";
            this.txt_autor.Size = new System.Drawing.Size(240, 20);
            this.txt_autor.TabIndex = 3;
            this.lbl_isbn.AutoSize = true;
            this.lbl_isbn.Location = new System.Drawing.Point(30, 135);
            this.lbl_isbn.Name = "lbl_isbn";
            this.lbl_isbn.Size = new System.Drawing.Size(35, 13);
            this.lbl_isbn.TabIndex = 4;
            this.lbl_isbn.Text = "ISBN:";
            this.txt_isbn.Location = new System.Drawing.Point(30, 155);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(240, 20);
            this.txt_isbn.TabIndex = 5;
            this.lbl_genero.AutoSize = true;
            this.lbl_genero.Location = new System.Drawing.Point(30, 190);
            this.lbl_genero.Name = "lbl_genero";
            this.lbl_genero.Size = new System.Drawing.Size(45, 13);
            this.lbl_genero.TabIndex = 6;
            this.lbl_genero.Text = "Genero:";
            this.txt_genero.Location = new System.Drawing.Point(30, 210);
            this.txt_genero.Name = "txt_genero";
            this.txt_genero.Size = new System.Drawing.Size(240, 20);
            this.txt_genero.TabIndex = 7;
            this.lbl_numeroVolumen.AutoSize = true;
            this.lbl_numeroVolumen.Location = new System.Drawing.Point(30, 245);
            this.lbl_numeroVolumen.Name = "lbl_numeroVolumen";
            this.lbl_numeroVolumen.Size = new System.Drawing.Size(101, 13);
            this.lbl_numeroVolumen.TabIndex = 8;
            this.lbl_numeroVolumen.Text = "Numero de volumen:";
            this.nud_numeroVolumen.Location = new System.Drawing.Point(30, 265);
            this.nud_numeroVolumen.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nud_numeroVolumen.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nud_numeroVolumen.Name = "nud_numeroVolumen";
            this.nud_numeroVolumen.Size = new System.Drawing.Size(240, 20);
            this.nud_numeroVolumen.TabIndex = 9;
            this.nud_numeroVolumen.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.btn_crear.Location = new System.Drawing.Point(30, 315);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(110, 30);
            this.btn_crear.TabIndex = 10;
            this.btn_crear.Text = "Solicitar";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            this.btn_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancelar.Location = new System.Drawing.Point(160, 315);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(110, 30);
            this.btn_cancelar.TabIndex = 11;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            this.AcceptButton = this.btn_crear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancelar;
            this.ClientSize = new System.Drawing.Size(300, 375);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.nud_numeroVolumen);
            this.Controls.Add(this.lbl_numeroVolumen);
            this.Controls.Add(this.txt_genero);
            this.Controls.Add(this.lbl_genero);
            this.Controls.Add(this.txt_isbn);
            this.Controls.Add(this.lbl_isbn);
            this.Controls.Add(this.txt_autor);
            this.Controls.Add(this.lbl_autor);
            this.Controls.Add(this.txt_titulo);
            this.Controls.Add(this.lbl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibroGUI_62_BP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitud de libro";
            ((System.ComponentModel.ISupportInitialize)(this.nud_numeroVolumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
