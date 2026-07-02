namespace TP_campo
{
    partial class DigitoVerificadorGUI_62_BP
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
            this.labelErrores = new System.Windows.Forms.Label();
            this.dataGridViewErrores = new System.Windows.Forms.DataGridView();
            this.buttonRecalcular = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonBackupRestore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.Location = new System.Drawing.Point(60, 100);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(43, 13);
            this.labelErrores.TabIndex = 2;
            this.labelErrores.Text = "Errores:";
            // 
            // dataGridViewErrores
            // 
            this.dataGridViewErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrores.Location = new System.Drawing.Point(63, 116);
            this.dataGridViewErrores.Name = "dataGridViewErrores";
            this.dataGridViewErrores.Size = new System.Drawing.Size(692, 212);
            this.dataGridViewErrores.TabIndex = 3;
            // 
            // buttonRecalcular
            // 
            this.buttonRecalcular.Location = new System.Drawing.Point(450, 28);
            this.buttonRecalcular.Name = "buttonRecalcular";
            this.buttonRecalcular.Size = new System.Drawing.Size(95, 45);
            this.buttonRecalcular.TabIndex = 5;
            this.buttonRecalcular.Text = "Recalcular Digitos";
            this.buttonRecalcular.UseVisualStyleBackColor = true;
            this.buttonRecalcular.Click += new System.EventHandler(this.buttonRecalcular_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(720, 28);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(95, 45);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonBackupRestore
            // 
            this.buttonBackupRestore.Location = new System.Drawing.Point(610, 28);
            this.buttonBackupRestore.Name = "buttonBackupRestore";
            this.buttonBackupRestore.Size = new System.Drawing.Size(95, 45);
            this.buttonBackupRestore.TabIndex = 7;
            this.buttonBackupRestore.Text = "Backup/Restore";
            this.buttonBackupRestore.UseVisualStyleBackColor = true;
            this.buttonBackupRestore.Click += new System.EventHandler(this.buttonBackupRestore_Click);
            // 
            // DigitoVerificadorGUI_62_BP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 392);
            this.Controls.Add(this.buttonBackupRestore);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonRecalcular);
            this.Controls.Add(this.dataGridViewErrores);
            this.Controls.Add(this.labelErrores);
            this.Name = "DigitoVerificadorGUI_62_BP";
            this.Text = "DigitoVerificador_62_BP";
            this.Load += new System.EventHandler(this.DigitoVerificadorGUI_62_BP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelErrores;
        private System.Windows.Forms.DataGridView dataGridViewErrores;
        private System.Windows.Forms.Button buttonRecalcular;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonBackupRestore;
    }
}