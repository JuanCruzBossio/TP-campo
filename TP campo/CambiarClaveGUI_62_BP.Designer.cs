namespace TP_campo
{
    partial class CambiarClaveGUI_62_BP
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
            this.labelContrasenaActual = new System.Windows.Forms.Label();
            this.labelContrasenaNueva = new System.Windows.Forms.Label();
            this.labelRepetirContrasenaNueva = new System.Windows.Forms.Label();
            this.textBoxContrasenaActual = new System.Windows.Forms.TextBox();
            this.textBoxContrasenaNueva = new System.Windows.Forms.TextBox();
            this.textBoxRepetirContrasenaNueva = new System.Windows.Forms.TextBox();
            this.buttonCambiarContrasena = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelContrasenaActual
            // 
            this.labelContrasenaActual.AutoSize = true;
            this.labelContrasenaActual.Location = new System.Drawing.Point(73, 52);
            this.labelContrasenaActual.Name = "labelContrasenaActual";
            this.labelContrasenaActual.Size = new System.Drawing.Size(94, 13);
            this.labelContrasenaActual.TabIndex = 0;
            this.labelContrasenaActual.Text = "Contraseña Actual";
            // 
            // labelContrasenaNueva
            // 
            this.labelContrasenaNueva.AutoSize = true;
            this.labelContrasenaNueva.Location = new System.Drawing.Point(73, 95);
            this.labelContrasenaNueva.Name = "labelContrasenaNueva";
            this.labelContrasenaNueva.Size = new System.Drawing.Size(96, 13);
            this.labelContrasenaNueva.TabIndex = 1;
            this.labelContrasenaNueva.Text = "Contraseña Nueva";
            // 
            // labelRepetirContrasenaNueva
            // 
            this.labelRepetirContrasenaNueva.AutoSize = true;
            this.labelRepetirContrasenaNueva.Location = new System.Drawing.Point(71, 132);
            this.labelRepetirContrasenaNueva.Name = "labelRepetirContrasenaNueva";
            this.labelRepetirContrasenaNueva.Size = new System.Drawing.Size(133, 13);
            this.labelRepetirContrasenaNueva.TabIndex = 2;
            this.labelRepetirContrasenaNueva.Text = "Repetir Contraseña Nueva";
            // 
            // textBoxContrasenaActual
            // 
            this.textBoxContrasenaActual.Location = new System.Drawing.Point(244, 49);
            this.textBoxContrasenaActual.Name = "textBoxContrasenaActual";
            this.textBoxContrasenaActual.Size = new System.Drawing.Size(219, 20);
            this.textBoxContrasenaActual.TabIndex = 3;
            // 
            // textBoxContrasenaNueva
            // 
            this.textBoxContrasenaNueva.Location = new System.Drawing.Point(244, 92);
            this.textBoxContrasenaNueva.Name = "textBoxContrasenaNueva";
            this.textBoxContrasenaNueva.Size = new System.Drawing.Size(219, 20);
            this.textBoxContrasenaNueva.TabIndex = 4;
            // 
            // textBoxRepetirContrasenaNueva
            // 
            this.textBoxRepetirContrasenaNueva.Location = new System.Drawing.Point(244, 129);
            this.textBoxRepetirContrasenaNueva.Name = "textBoxRepetirContrasenaNueva";
            this.textBoxRepetirContrasenaNueva.Size = new System.Drawing.Size(219, 20);
            this.textBoxRepetirContrasenaNueva.TabIndex = 5;
            // 
            // buttonCambiarContrasena
            // 
            this.buttonCambiarContrasena.Location = new System.Drawing.Point(244, 186);
            this.buttonCambiarContrasena.Name = "buttonCambiarContrasena";
            this.buttonCambiarContrasena.Size = new System.Drawing.Size(111, 50);
            this.buttonCambiarContrasena.TabIndex = 9;
            this.buttonCambiarContrasena.Text = "Cambiar Contraseña";
            this.buttonCambiarContrasena.UseVisualStyleBackColor = true;
            this.buttonCambiarContrasena.Click += new System.EventHandler(this.buttonCambiarContrasena_Click);
            // 
            // CambiarClaveGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 248);
            this.Controls.Add(this.buttonCambiarContrasena);
            this.Controls.Add(this.textBoxRepetirContrasenaNueva);
            this.Controls.Add(this.textBoxContrasenaNueva);
            this.Controls.Add(this.textBoxContrasenaActual);
            this.Controls.Add(this.labelRepetirContrasenaNueva);
            this.Controls.Add(this.labelContrasenaNueva);
            this.Controls.Add(this.labelContrasenaActual);
            this.Name = "CambiarClaveGUI_62_BP";
            this.Text = "CambiarClaveGUI_62_BP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContrasenaActual;
        private System.Windows.Forms.Label labelContrasenaNueva;
        private System.Windows.Forms.Label labelRepetirContrasenaNueva;
        private System.Windows.Forms.TextBox textBoxContrasenaActual;
        private System.Windows.Forms.TextBox textBoxContrasenaNueva;
        private System.Windows.Forms.TextBox textBoxRepetirContrasenaNueva;
        private System.Windows.Forms.Button buttonCambiarContrasena;
    }
}