using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using SEG_62_BP;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class MultaGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly MultaBLL_62_BP _multaBLL_62_BP = new MultaBLL_62_BP();

        public MultaGUI_62_BP()
        {
            InitializeComponent();
            buttonBuscarMultas.Click += buttonBuscarMultas_Click;
            buttonPagarMulta.Click += buttonPagarMulta_Click;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            ConfigurarDataGridViewMultas();
        }

        public MultaGUI_62_BP(int idPrestamo)
            : this()
        {
            textBoxNumPrestamo.Text = idPrestamo.ToString();
        }

        public MultaGUI_62_BP(string dni)
            : this()
        {
            textBoxDNI.Text = dni;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConfigurarDataGridViewMultas()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.Columns.Add("colIdMulta", "Num. Multa");
            dataGridView1.Columns.Add("colIdPrestamo", "Num. Préstamo");
            dataGridView1.Columns.Add("colDni", "DNI Lector");
            dataGridView1.Columns.Add("colMonto", "Monto");
            dataGridView1.Columns.Add("colPagada", "Pagada");
            dataGridView1.Columns.Add("colMotivo", "Motivo");
            ActualizarBotonPagarMulta();
        }

        private void buttonBuscarMultas_Click(object sender, EventArgs e)
        {
            int? idMulta = ObtenerIdOpcional(textBoxNumeroMulta.Text, Texto_62_BP("campo_multa", "multa"));
            if (textBoxNumeroMulta.Text.Trim().Length > 0 && !idMulta.HasValue)
            {
                return;
            }

            int? idPrestamo = ObtenerIdOpcional(textBoxNumPrestamo.Text, Texto_62_BP("campo_prestamo", "préstamo"));
            if (textBoxNumPrestamo.Text.Trim().Length > 0 && !idPrestamo.HasValue)
            {
                return;
            }

            try
            {
                List<MultaBE_62_BP> multas = _multaBLL_62_BP.BuscarMultas_62_BP(
                    idMulta,
                    idPrestamo,
                    textBoxDNI.Text.Trim());

                dataGridView1.Rows.Clear();
                buttonPagarMulta.Enabled = false;
                foreach (MultaBE_62_BP multa in multas)
                {
                    int indice = dataGridView1.Rows.Add();
                    DataGridViewRow fila = dataGridView1.Rows[indice];
                    fila.Cells["colIdMulta"].Value = multa.id_multa_62_BP;
                    fila.Cells["colIdPrestamo"].Value = multa.id_prestamo_62_BP;
                    fila.Cells["colDni"].Value = multa.dni_lector_62_BP;
                    fila.Cells["colMonto"].Value = multa.monto_62_BP;
                    fila.Cells["colPagada"].Value = multa.pagada_62_BP
                        ? Texto_62_BP("estado_si", "Sí")
                        : Texto_62_BP("estado_no", "No");
                    fila.Cells["colMotivo"].Value = multa.motivo_62_BP;
                }
                ActualizarBotonPagarMulta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_multa_busqueda_error", "No se pudieron buscar las multas: {0}", ex.Message));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonPagarMulta();
        }

        private void ActualizarBotonPagarMulta()
        {
            buttonPagarMulta.Enabled = false;

            if (!SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(22))
            {
                return;
            }

            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }

            object pagada = dataGridView1.SelectedRows[0].Cells["colPagada"].Value;
            buttonPagarMulta.Enabled = string.Equals(
                Convert.ToString(pagada), Texto_62_BP("estado_no", "No"), StringComparison.OrdinalIgnoreCase);
        }

        private void buttonPagarMulta_Click(object sender, EventArgs e)
        {
            if (!SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(22))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            if (dataGridView1.SelectedRows.Count != 1 || !buttonPagarMulta.Enabled)
            {
                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];
            MultaBE_62_BP multa = new MultaBE_62_BP
            {
                id_multa_62_BP = Convert.ToInt32(fila.Cells["colIdMulta"].Value),
                id_prestamo_62_BP = Convert.ToInt32(fila.Cells["colIdPrestamo"].Value),
                monto_62_BP = Convert.ToInt32(fila.Cells["colMonto"].Value),
                pagada_62_BP = true,
                motivo_62_BP = Convert.ToString(fila.Cells["colMotivo"].Value)
            };

            try
            {
                if (_multaBLL_62_BP.ModificarMulta_62_BP(multa) <= 0)
                {
                    throw new Exception(Texto_62_BP("msg_multa_actualizacion_error", "No se pudo actualizar el estado de la multa."));
                }

                MessageBox.Show(Texto_62_BP("msg_multa_pagada", "Multa pagada correctamente."));
                textBoxNumeroMulta.Clear();
                textBoxNumPrestamo.Clear();
                textBoxDNI.Clear();
                dataGridView1.Rows.Clear();
                buttonPagarMulta.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_multa_pago_error", "No se pudo pagar la multa: {0}", ex.Message));
            }
        }

        private int? ObtenerIdOpcional(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            int id;
            if (!int.TryParse(texto.Trim(), out id) || id <= 0)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_numero_entero_positivo", "El número de {0} debe ser un número entero positivo.", nombreCampo));
                return null;
            }

            return id;
        }
    }
}
