namespace TP_campo_62_BP
{
    partial class Bitacora_62_BP
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
            this.dgv_bitacora = new System.Windows.Forms.DataGridView();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_modulo = new System.Windows.Forms.Label();
            this.lbl_fecha_ini = new System.Windows.Forms.Label();
            this.lbl_evento = new System.Windows.Forms.Label();
            this.lbl_fecha_fin = new System.Windows.Forms.Label();
            this.lbl_criticidad = new System.Windows.Forms.Label();
            this.txt_login = new System.Windows.Forms.TextBox();
            this.txt_modulo = new System.Windows.Forms.TextBox();
            this.txt_evento = new System.Windows.Forms.TextBox();
            this.txt_criticidad = new System.Windows.Forms.TextBox();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.btn_imprimir = new System.Windows.Forms.Button();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.dtp_fecha_ini = new System.Windows.Forms.DateTimePicker();
            this.dtp_fecha_fin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_bitacora
            // 
            this.dgv_bitacora.AllowUserToAddRows = false;
            this.dgv_bitacora.AllowUserToDeleteRows = false;
            this.dgv_bitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bitacora.Location = new System.Drawing.Point(29, 27);
            this.dgv_bitacora.Name = "dgv_bitacora";
            this.dgv_bitacora.ReadOnly = true;
            this.dgv_bitacora.Size = new System.Drawing.Size(746, 268);
            this.dgv_bitacora.TabIndex = 0;
            this.dgv_bitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_bitacora_CellClick);
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(72, 409);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(43, 13);
            this.lbl_login.TabIndex = 1;
            this.lbl_login.Text = "LOGIN:";
            // 
            // lbl_modulo
            // 
            this.lbl_modulo.AutoSize = true;
            this.lbl_modulo.Location = new System.Drawing.Point(61, 457);
            this.lbl_modulo.Name = "lbl_modulo";
            this.lbl_modulo.Size = new System.Drawing.Size(57, 13);
            this.lbl_modulo.TabIndex = 2;
            this.lbl_modulo.Text = "MODULO:";
            // 
            // lbl_fecha_ini
            // 
            this.lbl_fecha_ini.AutoSize = true;
            this.lbl_fecha_ini.Location = new System.Drawing.Point(324, 409);
            this.lbl_fecha_ini.Name = "lbl_fecha_ini";
            this.lbl_fecha_ini.Size = new System.Drawing.Size(62, 13);
            this.lbl_fecha_ini.TabIndex = 3;
            this.lbl_fecha_ini.Text = "FECHA INI:";
            // 
            // lbl_evento
            // 
            this.lbl_evento.AutoSize = true;
            this.lbl_evento.Location = new System.Drawing.Point(338, 457);
            this.lbl_evento.Name = "lbl_evento";
            this.lbl_evento.Size = new System.Drawing.Size(54, 13);
            this.lbl_evento.TabIndex = 4;
            this.lbl_evento.Text = "EVENTO:";
            // 
            // lbl_fecha_fin
            // 
            this.lbl_fecha_fin.AutoSize = true;
            this.lbl_fecha_fin.Location = new System.Drawing.Point(558, 409);
            this.lbl_fecha_fin.Name = "lbl_fecha_fin";
            this.lbl_fecha_fin.Size = new System.Drawing.Size(65, 13);
            this.lbl_fecha_fin.TabIndex = 5;
            this.lbl_fecha_fin.Text = "FECHA FIN:";
            // 
            // lbl_criticidad
            // 
            this.lbl_criticidad.AutoSize = true;
            this.lbl_criticidad.Location = new System.Drawing.Point(552, 457);
            this.lbl_criticidad.Name = "lbl_criticidad";
            this.lbl_criticidad.Size = new System.Drawing.Size(71, 13);
            this.lbl_criticidad.TabIndex = 6;
            this.lbl_criticidad.Text = "CRITICIDAD:";
            // 
            // txt_login
            // 
            this.txt_login.Location = new System.Drawing.Point(124, 406);
            this.txt_login.Name = "txt_login";
            this.txt_login.Size = new System.Drawing.Size(100, 20);
            this.txt_login.TabIndex = 7;
            // 
            // txt_modulo
            // 
            this.txt_modulo.Location = new System.Drawing.Point(124, 454);
            this.txt_modulo.Name = "txt_modulo";
            this.txt_modulo.Size = new System.Drawing.Size(100, 20);
            this.txt_modulo.TabIndex = 10;
            // 
            // txt_evento
            // 
            this.txt_evento.Location = new System.Drawing.Point(392, 454);
            this.txt_evento.Name = "txt_evento";
            this.txt_evento.Size = new System.Drawing.Size(100, 20);
            this.txt_evento.TabIndex = 11;
            // 
            // txt_criticidad
            // 
            this.txt_criticidad.Location = new System.Drawing.Point(629, 454);
            this.txt_criticidad.Name = "txt_criticidad";
            this.txt_criticidad.Size = new System.Drawing.Size(100, 20);
            this.txt_criticidad.TabIndex = 12;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(139, 519);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(123, 35);
            this.btn_limpiar.TabIndex = 13;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Location = new System.Drawing.Point(337, 519);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(122, 35);
            this.btn_aplicar.TabIndex = 14;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            // 
            // btn_imprimir
            // 
            this.btn_imprimir.Location = new System.Drawing.Point(547, 519);
            this.btn_imprimir.Name = "btn_imprimir";
            this.btn_imprimir.Size = new System.Drawing.Size(121, 35);
            this.btn_imprimir.TabIndex = 15;
            this.btn_imprimir.Text = "Imprimir";
            this.btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(215, 335);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(47, 13);
            this.lbl_nombre.TabIndex = 16;
            this.lbl_nombre.Text = "Nombre:";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(412, 335);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(47, 13);
            this.lbl_apellido.TabIndex = 17;
            this.lbl_apellido.Text = "Apellido:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(268, 332);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.ReadOnly = true;
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 18;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(462, 332);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.ReadOnly = true;
            this.txt_apellido.Size = new System.Drawing.Size(100, 20);
            this.txt_apellido.TabIndex = 19;
            // 
            // dtp_fecha_ini
            // 
            this.dtp_fecha_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_ini.Location = new System.Drawing.Point(392, 406);
            this.dtp_fecha_ini.Name = "dtp_fecha_ini";
            this.dtp_fecha_ini.Size = new System.Drawing.Size(100, 20);
            this.dtp_fecha_ini.TabIndex = 20;
            this.dtp_fecha_ini.Value = new System.DateTime(2026, 5, 18, 0, 0, 0, 0);
            // 
            // dtp_fecha_fin
            // 
            this.dtp_fecha_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fecha_fin.Location = new System.Drawing.Point(629, 406);
            this.dtp_fecha_fin.Name = "dtp_fecha_fin";
            this.dtp_fecha_fin.Size = new System.Drawing.Size(100, 20);
            this.dtp_fecha_fin.TabIndex = 21;
            this.dtp_fecha_fin.Value = new System.DateTime(2026, 5, 18, 0, 0, 0, 0);
            // 
            // Bitacora_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 583);
            this.Controls.Add(this.dtp_fecha_fin);
            this.Controls.Add(this.dtp_fecha_ini);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.btn_imprimir);
            this.Controls.Add(this.btn_aplicar);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.txt_criticidad);
            this.Controls.Add(this.txt_evento);
            this.Controls.Add(this.txt_modulo);
            this.Controls.Add(this.txt_login);
            this.Controls.Add(this.lbl_criticidad);
            this.Controls.Add(this.lbl_fecha_fin);
            this.Controls.Add(this.lbl_evento);
            this.Controls.Add(this.lbl_fecha_ini);
            this.Controls.Add(this.lbl_modulo);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.dgv_bitacora);
            this.Name = "Bitacora_62_BP";
            this.Text = "Bitacora_62_BP";
            this.Load += new System.EventHandler(this.Bitacora_62_BP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_bitacora;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_modulo;
        private System.Windows.Forms.Label lbl_fecha_ini;
        private System.Windows.Forms.Label lbl_evento;
        private System.Windows.Forms.Label lbl_fecha_fin;
        private System.Windows.Forms.Label lbl_criticidad;
        private System.Windows.Forms.TextBox txt_login;
        private System.Windows.Forms.TextBox txt_modulo;
        private System.Windows.Forms.TextBox txt_evento;
        private System.Windows.Forms.TextBox txt_criticidad;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.Button btn_imprimir;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.DateTimePicker dtp_fecha_ini;
        private System.Windows.Forms.DateTimePicker dtp_fecha_fin;
    }
}