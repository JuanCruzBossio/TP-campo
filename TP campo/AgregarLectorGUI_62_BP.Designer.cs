namespace TP_campo
{
    partial class AgregarLectorGUI_62_BP
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lbl_dni;
        private System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label lbl_fechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtp_fechaNacimiento;
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
            this.lbl_dni = new System.Windows.Forms.Label();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.lbl_fechaNacimiento = new System.Windows.Forms.Label();
            this.dtp_fechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btn_crear = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lbl_dni
            this.lbl_dni.AutoSize = true;
            this.lbl_dni.Location = new System.Drawing.Point(30, 30);
            this.lbl_dni.Name = "lbl_dni";
            this.lbl_dni.Size = new System.Drawing.Size(38, 13);
            this.lbl_dni.TabIndex = 0;
            this.lbl_dni.Text = "DNI:";

            // txt_dni
            this.txt_dni.Location = new System.Drawing.Point(30, 50);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.ReadOnly = true;
            this.txt_dni.Size = new System.Drawing.Size(200, 20);
            this.txt_dni.TabIndex = 1;

            // lbl_nombre
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(30, 90);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 2;
            this.lbl_nombre.Text = "Nombre:";

            // txt_nombre
            this.txt_nombre.Location = new System.Drawing.Point(30, 110);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(200, 20);
            this.txt_nombre.TabIndex = 3;

            // lbl_apellido
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(30, 150);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_apellido.TabIndex = 4;
            this.lbl_apellido.Text = "Apellido:";

            // txt_apellido
            this.txt_apellido.Location = new System.Drawing.Point(30, 170);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(200, 20);
            this.txt_apellido.TabIndex = 5;

            // lbl_fechaNacimiento
            this.lbl_fechaNacimiento.AutoSize = true;
            this.lbl_fechaNacimiento.Location = new System.Drawing.Point(30, 210);
            this.lbl_fechaNacimiento.Name = "lbl_fechaNacimiento";
            this.lbl_fechaNacimiento.Size = new System.Drawing.Size(90, 13);
            this.lbl_fechaNacimiento.TabIndex = 6;
            this.lbl_fechaNacimiento.Text = "Fecha de Nacimiento:";

            // dtp_fechaNacimiento
            this.dtp_fechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaNacimiento.Location = new System.Drawing.Point(30, 230);
            this.dtp_fechaNacimiento.MaxDate = System.DateTime.Today;
            this.dtp_fechaNacimiento.Name = "dtp_fechaNacimiento";
            this.dtp_fechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtp_fechaNacimiento.TabIndex = 7;

            // btn_crear
            this.btn_crear.Location = new System.Drawing.Point(30, 280);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(100, 30);
            this.btn_crear.TabIndex = 8;
            this.btn_crear.Text = "Crear";
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);

            // btn_cancelar
            this.btn_cancelar.Location = new System.Drawing.Point(150, 280);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(100, 30);
            this.btn_cancelar.TabIndex = 9;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);

            // AgregarLectorGUI_62_BP
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 340);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_crear);
            this.Controls.Add(this.dtp_fechaNacimiento);
            this.Controls.Add(this.lbl_fechaNacimiento);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.lbl_dni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarLectorGUI_62_BP";
            this.Text = "AgregarLectorGUI_62_BP";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}