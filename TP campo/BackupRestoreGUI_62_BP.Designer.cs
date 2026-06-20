namespace TP_campo
{
    partial class BackupRestoreGUI_62_BP
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
            this.labelRuta = new System.Windows.Forms.Label();
            this.textBoxRuta = new System.Windows.Forms.TextBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.radioButtonBackup = new System.Windows.Forms.RadioButton();
            this.radioButtonRestore = new System.Windows.Forms.RadioButton();
            this.buttonAplicar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRuta
            // 
            this.labelRuta.AutoSize = true;
            this.labelRuta.Location = new System.Drawing.Point(44, 81);
            this.labelRuta.Name = "labelRuta";
            this.labelRuta.Size = new System.Drawing.Size(33, 13);
            this.labelRuta.TabIndex = 0;
            this.labelRuta.Text = "Ruta:";
            // 
            // textBoxRuta
            // 
            this.textBoxRuta.Location = new System.Drawing.Point(104, 76);
            this.textBoxRuta.Name = "textBoxRuta";
            this.textBoxRuta.Size = new System.Drawing.Size(421, 20);
            this.textBoxRuta.TabIndex = 1;
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.Location = new System.Drawing.Point(544, 62);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(104, 46);
            this.buttonSeleccionar.TabIndex = 2;
            this.buttonSeleccionar.Text = "Seleccionar Ruta";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // radioButtonBackup
            // 
            this.radioButtonBackup.AutoSize = true;
            this.radioButtonBackup.Location = new System.Drawing.Point(137, 39);
            this.radioButtonBackup.Name = "radioButtonBackup";
            this.radioButtonBackup.Size = new System.Drawing.Size(62, 17);
            this.radioButtonBackup.TabIndex = 3;
            this.radioButtonBackup.TabStop = true;
            this.radioButtonBackup.Text = "Backup";
            this.radioButtonBackup.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestore
            // 
            this.radioButtonRestore.AutoSize = true;
            this.radioButtonRestore.Location = new System.Drawing.Point(235, 39);
            this.radioButtonRestore.Name = "radioButtonRestore";
            this.radioButtonRestore.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRestore.TabIndex = 4;
            this.radioButtonRestore.TabStop = true;
            this.radioButtonRestore.Text = "Restore";
            this.radioButtonRestore.UseVisualStyleBackColor = true;
            // 
            // buttonAplicar
            // 
            this.buttonAplicar.Location = new System.Drawing.Point(259, 123);
            this.buttonAplicar.Name = "buttonAplicar";
            this.buttonAplicar.Size = new System.Drawing.Size(104, 46);
            this.buttonAplicar.TabIndex = 5;
            this.buttonAplicar.Text = "Aplicar";
            this.buttonAplicar.UseVisualStyleBackColor = true;
            this.buttonAplicar.Click += new System.EventHandler(this.buttonAplicar_Click);
            // 
            // BackupRestoreGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 181);
            this.Controls.Add(this.buttonAplicar);
            this.Controls.Add(this.radioButtonRestore);
            this.Controls.Add(this.radioButtonBackup);
            this.Controls.Add(this.buttonSeleccionar);
            this.Controls.Add(this.textBoxRuta);
            this.Controls.Add(this.labelRuta);
            this.Name = "BackupRestoreGUI_62_BP";
            this.Text = "BackupRestoreGUI_62_BP";
            this.Load += new System.EventHandler(this.BackupRestoreGUI_62_BP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRuta;
        private System.Windows.Forms.TextBox textBoxRuta;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.RadioButton radioButtonBackup;
        private System.Windows.Forms.RadioButton radioButtonRestore;
        private System.Windows.Forms.Button buttonAplicar;
    }
}