using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using SEG_62_BP;
using SEG_62_BP.Observer;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class ListaMultaGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly MultaBLL_62_BP _multaBLL_62_BP = new MultaBLL_62_BP();
        private bool _editando_62_BP;

        public ListaMultaGUI_62_BP()
        {
            InitializeComponent();

            buttonBuscar.Click += buttonBuscar_Click;
            buttonLimpiar.Click += buttonLimpiar_Click;
            buttonEditar.Click += buttonEditar_Click;
            buttonGuardar.Click += buttonGuardar_Click;
            buttonCancelar.Click += buttonCancelar_Click;
            dataGridViewMultas.SelectionChanged += dataGridViewMultas_SelectionChanged;

            ConfigurarModoEdicion_62_BP(false);
            LimpiarCamposEdicion_62_BP();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarEstados_62_BP();
            ActualizarBotonEditar_62_BP();
            BuscarMultasDesdeBLL_62_BP();
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            Text = Texto_62_BP("titulo_listado_multas", "Listado de multas");
            groupBoxFiltros.Text = Texto_62_BP("grupo_filtros", "Filtros");
            groupBoxEdicion.Text = Texto_62_BP("grupo_edicion_multa", "Edicion de la multa seleccionada");
            labelFiltroIdMulta.Text = Texto_62_BP("lbl_id_multa", "ID Multa:");
            labelFiltroIdPrestamo.Text = Texto_62_BP("lbl_id_prestamo", "ID Prestamo:");
            labelFiltroDNI.Text = Texto_62_BP("lbl_dni", "DNI:");
            labelFiltroEstado.Text = Texto_62_BP("lbl_estado", "Estado:");
            labelIdMulta.Text = Texto_62_BP("lbl_id_multa", "ID Multa:");
            labelIdPrestamo.Text = Texto_62_BP("lbl_id_prestamo", "ID Prestamo:");
            labelDNI.Text = Texto_62_BP("lbl_dni", "DNI:");
            labelMonto.Text = Texto_62_BP("lbl_monto", "Monto:");
            labelEstado.Text = Texto_62_BP("lbl_estado", "Estado:");
            labelMotivo.Text = Texto_62_BP("lbl_motivo", "Motivo:");
            buttonBuscar.Text = Texto_62_BP("btn_buscar", "Buscar");
            buttonLimpiar.Text = Texto_62_BP("btn_limpiar", "Limpiar");
            buttonEditar.Text = Texto_62_BP("btn_editar", "Editar");
            buttonGuardar.Text = Texto_62_BP("btn_guardar", "Guardar");
            buttonCancelar.Text = Texto_62_BP("btn_cancelar", "Cancelar");

            colIdMulta.HeaderText = Texto_62_BP("col_id_multa", "ID Multa");
            colIdPrestamo.HeaderText = Texto_62_BP("col_id_prestamo", "ID Prestamo");
            colDNI.HeaderText = Texto_62_BP("col_dni", "DNI");
            colMonto.HeaderText = Texto_62_BP("col_monto", "Monto");
            colEstado.HeaderText = Texto_62_BP("col_estado", "Estado");
            colMotivo.HeaderText = Texto_62_BP("col_motivo", "Motivo");

            CargarEstados_62_BP();
            ActualizarTextosGrilla_62_BP();
        }

        private void CargarEstados_62_BP()
        {
            int indiceSeleccionado = comboBoxFiltroEstado.SelectedIndex;
            comboBoxFiltroEstado.Items.Clear();
            comboBoxFiltroEstado.Items.Add(Texto_62_BP("estado_todos", "Todos"));
            comboBoxFiltroEstado.Items.Add(Texto_62_BP("estado_pendiente", "Pendiente"));
            comboBoxFiltroEstado.Items.Add(Texto_62_BP("estado_pagada", "Pagada"));
            comboBoxFiltroEstado.SelectedIndex = indiceSeleccionado >= 0 && indiceSeleccionado < 3
                ? indiceSeleccionado
                : 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BuscarMultasDesdeBLL_62_BP();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxFiltroIdMulta.Clear();
            textBoxFiltroIdPrestamo.Clear();
            textBoxFiltroDNI.Clear();
            comboBoxFiltroEstado.SelectedIndex = 0;
            BuscarMultasDesdeBLL_62_BP();
        }

        private void BuscarMultasDesdeBLL_62_BP()
        {
            int? idMulta;
            int? idPrestamo;
            if (!ObtenerFiltroEntero_62_BP(textBoxFiltroIdMulta, "msg_id_multa_invalido", "El ID de multa debe ser un numero entero positivo.", out idMulta) ||
                !ObtenerFiltroEntero_62_BP(textBoxFiltroIdPrestamo, "msg_numero_prestamo_invalido", "El numero de prestamo debe ser un numero entero positivo.", out idPrestamo))
            {
                return;
            }

            bool? pagada = null;
            if (comboBoxFiltroEstado.SelectedIndex == 1)
            {
                pagada = false;
            }
            else if (comboBoxFiltroEstado.SelectedIndex == 2)
            {
                pagada = true;
            }

            try
            {
                List<MultaBE_62_BP> multas = _multaBLL_62_BP.BuscarMultas_62_BP(
                    idMulta,
                    idPrestamo,
                    textBoxFiltroDNI.Text.Trim(),
                    pagada);

                LlenarGrilla_62_BP(multas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_multas_busqueda_error",
                    "No se pudieron obtener las multas: {0}",
                    ex.Message));
            }
        }

        private bool ObtenerFiltroEntero_62_BP(
            TextBox textBox,
            string claveMensaje,
            string mensajePredeterminado,
            out int? valor)
        {
            valor = null;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                return true;
            }

            int numero;
            if (!int.TryParse(textBox.Text.Trim(), out numero) || numero <= 0)
            {
                MostrarMensaje_62_BP(claveMensaje, mensajePredeterminado);
                textBox.Focus();
                return false;
            }

            valor = numero;
            return true;
        }

        private void LlenarGrilla_62_BP(IEnumerable<MultaBE_62_BP> multas)
        {
            dataGridViewMultas.Rows.Clear();

            if (multas != null)
            {
                foreach (MultaBE_62_BP multa in multas)
                {
                    int indice = dataGridViewMultas.Rows.Add();
                    DataGridViewRow fila = dataGridViewMultas.Rows[indice];
                    fila.Tag = multa;
                    fila.Cells[colIdMulta.Name].Value = multa.id_multa_62_BP;
                    fila.Cells[colIdPrestamo.Name].Value = multa.id_prestamo_62_BP;
                    fila.Cells[colDNI.Name].Value = multa.dni_lector_62_BP;
                    fila.Cells[colMonto.Name].Value = multa.monto_62_BP;
                    fila.Cells[colEstado.Name].Value = TextoEstado_62_BP(multa.pagada_62_BP);
                    fila.Cells[colMotivo.Name].Value = multa.motivo_62_BP;
                }
            }

            dataGridViewMultas.ClearSelection();
            LimpiarCamposEdicion_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private void ActualizarTextosGrilla_62_BP()
        {
            foreach (DataGridViewRow fila in dataGridViewMultas.Rows)
            {
                MultaBE_62_BP multa = fila.Tag as MultaBE_62_BP;
                if (multa != null)
                {
                    fila.Cells[colEstado.Name].Value = TextoEstado_62_BP(multa.pagada_62_BP);
                }
            }

            MultaBE_62_BP seleccionada = ObtenerMultaSeleccionada_62_BP();
            if (seleccionada != null)
            {
                textBoxEstado.Text = TextoEstado_62_BP(seleccionada.pagada_62_BP);
            }
        }

        private string TextoEstado_62_BP(bool pagada)
        {
            return pagada
                ? Texto_62_BP("estado_pagada", "Pagada")
                : Texto_62_BP("estado_pendiente", "Pendiente");
        }

        private void dataGridViewMultas_SelectionChanged(object sender, EventArgs e)
        {
            if (_editando_62_BP)
            {
                return;
            }

            CargarMultaSeleccionada_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private MultaBE_62_BP ObtenerMultaSeleccionada_62_BP()
        {
            if (dataGridViewMultas.SelectedRows.Count != 1)
            {
                return null;
            }

            return dataGridViewMultas.SelectedRows[0].Tag as MultaBE_62_BP;
        }

        private void CargarMultaSeleccionada_62_BP()
        {
            MultaBE_62_BP multa = ObtenerMultaSeleccionada_62_BP();
            if (multa == null)
            {
                LimpiarCamposEdicion_62_BP();
                return;
            }

            textBoxIdMulta.Text = multa.id_multa_62_BP.ToString();
            textBoxIdPrestamo.Text = multa.id_prestamo_62_BP.ToString();
            textBoxDNI.Text = multa.dni_lector_62_BP;
            numericUpDownMonto.Value = Math.Min(numericUpDownMonto.Maximum, Math.Max(numericUpDownMonto.Minimum, multa.monto_62_BP));
            textBoxEstado.Text = TextoEstado_62_BP(multa.pagada_62_BP);
            textBoxMotivo.Text = multa.motivo_62_BP;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!TienePermisoModificar_62_BP())
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            if (ObtenerMultaSeleccionada_62_BP() == null)
            {
                return;
            }

            ConfigurarModoEdicion_62_BP(true);
            numericUpDownMonto.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!TienePermisoModificar_62_BP())
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            MultaBE_62_BP multa = ObtenerMultaSeleccionada_62_BP();
            if (multa == null || !ValidarCampos_62_BP())
            {
                return;
            }

            MultaBE_62_BP multaModificada = new MultaBE_62_BP
            {
                id_multa_62_BP = multa.id_multa_62_BP,
                id_prestamo_62_BP = multa.id_prestamo_62_BP,
                dni_lector_62_BP = multa.dni_lector_62_BP,
                monto_62_BP = Convert.ToInt32(numericUpDownMonto.Value),
                pagada_62_BP = multa.pagada_62_BP,
                motivo_62_BP = textBoxMotivo.Text.Trim()
            };

            try
            {
                if (_multaBLL_62_BP.ModificarMulta_62_BP(multaModificada) <= 0)
                {
                    throw new Exception(Texto_62_BP(
                        "msg_listado_multas_modificacion_sin_cambios",
                        "No se pudo actualizar la multa seleccionada."));
                }

                ConfigurarModoEdicion_62_BP(false);
                BuscarMultasDesdeBLL_62_BP();
                MostrarMensaje_62_BP(
                    "msg_listado_multas_modificacion_exitosa",
                    "Multa modificada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_multas_modificacion_error",
                    "No se pudo modificar la multa: {0}",
                    ex.Message));
            }
        }

        private bool ValidarCampos_62_BP()
        {
            if (numericUpDownMonto.Value <= 0)
            {
                MostrarMensaje_62_BP("msg_monto_multa_invalido", "El monto debe ser mayor que cero.");
                numericUpDownMonto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxMotivo.Text))
            {
                MostrarMensaje_62_BP("msg_motivo_multa_vacio", "El motivo no puede estar vacio.");
                textBoxMotivo.Focus();
                return false;
            }

            return true;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CargarMultaSeleccionada_62_BP();
            ConfigurarModoEdicion_62_BP(false);
        }

        private void ConfigurarModoEdicion_62_BP(bool editando)
        {
            _editando_62_BP = editando;
            numericUpDownMonto.Enabled = editando;
            textBoxMotivo.ReadOnly = !editando;
            groupBoxFiltros.Enabled = !editando;
            dataGridViewMultas.Enabled = !editando;
            buttonGuardar.Enabled = editando;
            buttonCancelar.Enabled = editando;
            ActualizarBotonEditar_62_BP();
        }

        private void ActualizarBotonEditar_62_BP()
        {
            buttonEditar.Enabled = !_editando_62_BP
                && TienePermisoModificar_62_BP()
                && dataGridViewMultas.SelectedRows.Count == 1;
        }

        private bool TienePermisoModificar_62_BP()
        {
            return SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(28);
        }

        private void LimpiarCamposEdicion_62_BP()
        {
            textBoxIdMulta.Clear();
            textBoxIdPrestamo.Clear();
            textBoxDNI.Clear();
            numericUpDownMonto.Value = numericUpDownMonto.Minimum;
            textBoxEstado.Clear();
            textBoxMotivo.Clear();
        }
    }
}
