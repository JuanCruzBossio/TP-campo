namespace TP_campo
{
    partial class CambiarIdiomaGUI_62_BP
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
            this.lbl_idioma = new System.Windows.Forms.Label();
            this.lbl_idioma_actual = new System.Windows.Forms.Label();
            this.txt_idioma_actual = new System.Windows.Forms.TextBox();
            this.cmb_idioma = new System.Windows.Forms.ComboBox();
            this.btn_cambiar_idioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_idioma
            // 
            this.lbl_idioma.AutoSize = true;
            this.lbl_idioma.Location = new System.Drawing.Point(21, 65);
            this.lbl_idioma.Name = "lbl_idioma";
            this.lbl_idioma.Size = new System.Drawing.Size(41, 13);
            this.lbl_idioma.TabIndex = 0;
            this.lbl_idioma.Text = "Idioma:";
            // 
            // lbl_idioma_actual
            // 
            this.lbl_idioma_actual.AutoSize = true;
            this.lbl_idioma_actual.Location = new System.Drawing.Point(21, 29);
            this.lbl_idioma_actual.Name = "lbl_idioma_actual";
            this.lbl_idioma_actual.Size = new System.Drawing.Size(74, 13);
            this.lbl_idioma_actual.TabIndex = 1;
            this.lbl_idioma_actual.Text = "Idioma Actual:";
            // 
            // txt_idioma_actual
            // 
            this.txt_idioma_actual.Location = new System.Drawing.Point(109, 26);
            this.txt_idioma_actual.Name = "txt_idioma_actual";
            this.txt_idioma_actual.Size = new System.Drawing.Size(121, 20);
            this.txt_idioma_actual.TabIndex = 2;
            // 
            // cmb_idioma
            // 
            this.cmb_idioma.FormattingEnabled = true;
            this.cmb_idioma.Location = new System.Drawing.Point(109, 62);
            this.cmb_idioma.Name = "cmb_idioma";
            this.cmb_idioma.Size = new System.Drawing.Size(121, 21);
            this.cmb_idioma.TabIndex = 3;
            // 
            // btn_cambiar_idioma
            // 
            this.btn_cambiar_idioma.Location = new System.Drawing.Point(71, 114);
            this.btn_cambiar_idioma.Name = "btn_cambiar_idioma";
            this.btn_cambiar_idioma.Size = new System.Drawing.Size(111, 23);
            this.btn_cambiar_idioma.TabIndex = 4;
            this.btn_cambiar_idioma.Text = "Cambiar Idioma";
            this.btn_cambiar_idioma.UseVisualStyleBackColor = true;
            this.btn_cambiar_idioma.Click += new System.EventHandler(this.btn_cambiar_idioma_Click_1);
            // 
            // CambiarIdiomaGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 155);
            this.Controls.Add(this.btn_cambiar_idioma);
            this.Controls.Add(this.cmb_idioma);
            this.Controls.Add(this.txt_idioma_actual);
            this.Controls.Add(this.lbl_idioma_actual);
            this.Controls.Add(this.lbl_idioma);
            this.Name = "CambiarIdiomaGUI_62_BP";
            this.Text = "Cambiar Idioma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_idioma;
        private System.Windows.Forms.Label lbl_idioma_actual;
        private System.Windows.Forms.TextBox txt_idioma_actual;
        private System.Windows.Forms.ComboBox cmb_idioma;
        private System.Windows.Forms.Button btn_cambiar_idioma;
    }
}