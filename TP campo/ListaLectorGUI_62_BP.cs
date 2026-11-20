using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using SEG_62_BP;
using SEG_62_BP.Observer;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class ListaLectorGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly List<LectorBE_62_BP> _lectores_62_BP = new List<LectorBE_62_BP>();
        private readonly LectorBLL_62_BP _lectorBLL_62_BP = new LectorBLL_62_BP();
        private bool _editando_62_BP;

        public ListaLectorGUI_62_BP()
        {
            InitializeComponent();

            buttonBuscar.Click += buttonBuscar_Click;
            buttonLimpiar.Click += buttonLimpiar_Click;
            buttonAgregarLector.Click += buttonAgregarLector_Click;
            buttonEditar.Click += buttonEditar_Click;
            buttonGuardar.Click += buttonGuardar_Click;
            buttonCancelar.Click += buttonCancelar_Click;
            dataGridViewLectores.SelectionChanged += dataGridViewLectores_SelectionChanged;

            dateTimePickerFechaNacimiento.MaxDate = DateTime.Today;
            ConfigurarModoEdicion_62_BP(false);
            LimpiarCamposEdicion_62_BP();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            buttonAgregarLector.Enabled = TienePermiso_62_BP(19);
            ActualizarBotonEditar_62_BP();
            BuscarLectoresDesdeBLL_62_BP();
        }

        public void CargarLectores_62_BP(IEnumerable<LectorBE_62_BP> lectores)
        {
            _lectores_62_BP.Clear();
            if (lectores != null)
            {
                _lectores_62_BP.AddRange(lectores);
            }

            AplicarFiltros_62_BP();
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            Text = Texto_62_BP("titulo_listado_lectores", "Listado de lectores");
            groupBoxFiltros.Text = Texto_62_BP("grupo_filtros", "Filtros");
            groupBoxEdicion.Text = Texto_62_BP("grupo_edicion_lector", "Edición del lector seleccionado");
            labelFiltroDNI.Text = Texto_62_BP("lbl_dni", "DNI:");
            labelFiltroNombre.Text = Texto_62_BP("lbl_nombre", "Nombre:");
            labelFiltroApellido.Text = Texto_62_BP("lbl_apellido", "Apellido:");
            labelDNI.Text = Texto_62_BP("lbl_dni", "DNI:");
            labelNombre.Text = Texto_62_BP("lbl_nombre", "Nombre:");
            labelApellido.Text = Texto_62_BP("lbl_apellido", "Apellido:");
            labelFechaNacimiento.Text = Texto_62_BP("lbl_fecha_nacimiento", "Fecha de nacimiento:");
            buttonBuscar.Text = Texto_62_BP("btn_buscar", "Buscar");
            buttonLimpiar.Text = Texto_62_BP("btn_limpiar", "Limpiar");
            buttonAgregarLector.Text = Texto_62_BP("btn_agregar_lector", "Agregar lector");
            buttonEditar.Text = Texto_62_BP("btn_editar", "Editar");
            buttonGuardar.Text = Texto_62_BP("btn_guardar", "Guardar");
            buttonCancelar.Text = Texto_62_BP("btn_cancelar", "Cancelar");

            colDNI.HeaderText = Texto_62_BP("col_dni", "DNI");
            colNombre.HeaderText = Texto_62_BP("col_nombre", "Nombre");
            colApellido.HeaderText = Texto_62_BP("col_apellido", "Apellido");
            colFechaNacimiento.HeaderText = Texto_62_BP("col_fecha_nacimiento", "Fecha de nacimiento");

            AplicarFiltros_62_BP();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BuscarLectoresDesdeBLL_62_BP();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxFiltroDNI.Clear();
            textBoxFiltroNombre.Clear();
            textBoxFiltroApellido.Clear();
            BuscarLectoresDesdeBLL_62_BP();
        }

        private void BuscarLectoresDesdeBLL_62_BP()
        {
            try
            {
                List<LectorBE_62_BP> lectores = _lectorBLL_62_BP.BuscarLectores_62_BP(
                    textBoxFiltroDNI.Text.Trim(),
                    textBoxFiltroNombre.Text.Trim(),
                    textBoxFiltroApellido.Text.Trim());

                CargarLectores_62_BP(lectores);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_lectores_busqueda_error",
                    "No se pudieron obtener los lectores: {0}",
                    ex.Message));
            }
        }

        private void buttonAgregarLector_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(19))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            AgregarLectorGUI_62_BP agregarLector = new AgregarLectorGUI_62_BP(
                textBoxFiltroDNI.Text.Trim());

            if (MdiParent != null)
            {
                agregarLector.MdiParent = MdiParent;
            }

            agregarLector.FormClosed += (formulario, argumentos) => BuscarLectoresDesdeBLL_62_BP();
            agregarLector.Show();
        }

        private void AplicarFiltros_62_BP()
        {
            if (dataGridViewLectores == null)
            {
                return;
            }

            IEnumerable<LectorBE_62_BP> resultado = _lectores_62_BP;
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroDNI.Text, lector => lector.dni_62_BP);
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroNombre.Text, lector => lector.nombre_62_BP);
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroApellido.Text, lector => lector.apellido_62_BP);
            LlenarGrilla_62_BP(resultado);
        }

        private IEnumerable<LectorBE_62_BP> FiltrarTexto_62_BP(
            IEnumerable<LectorBE_62_BP> lectores,
            string filtro,
            Func<LectorBE_62_BP, string> selector)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return lectores;
            }

            string valorBuscado = filtro.Trim();
            return lectores.Where(lector =>
                (selector(lector) ?? string.Empty).IndexOf(
                    valorBuscado,
                    StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void LlenarGrilla_62_BP(IEnumerable<LectorBE_62_BP> lectores)
        {
            dataGridViewLectores.Rows.Clear();

            foreach (LectorBE_62_BP lector in lectores)
            {
                int indice = dataGridViewLectores.Rows.Add();
                DataGridViewRow fila = dataGridViewLectores.Rows[indice];
                fila.Tag = lector;
                fila.Cells[colDNI.Name].Value = lector.dni_62_BP;
                fila.Cells[colNombre.Name].Value = lector.nombre_62_BP;
                fila.Cells[colApellido.Name].Value = lector.apellido_62_BP;
                fila.Cells[colFechaNacimiento.Name].Value = lector.fecha_nacimiento_62_BP.HasValue
                    ? lector.fecha_nacimiento_62_BP.Value.ToString("dd/MM/yyyy")
                    : string.Empty;
            }

            dataGridViewLectores.ClearSelection();
            LimpiarCamposEdicion_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private void dataGridViewLectores_SelectionChanged(object sender, EventArgs e)
        {
            if (_editando_62_BP)
            {
                return;
            }

            CargarLectorSeleccionado_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private LectorBE_62_BP ObtenerLectorSeleccionado_62_BP()
        {
            if (dataGridViewLectores.SelectedRows.Count != 1)
            {
                return null;
            }

            return dataGridViewLectores.SelectedRows[0].Tag as LectorBE_62_BP;
        }

        private void CargarLectorSeleccionado_62_BP()
        {
            LectorBE_62_BP lector = ObtenerLectorSeleccionado_62_BP();
            if (lector == null)
            {
                LimpiarCamposEdicion_62_BP();
                return;
            }

            textBoxDNI.Text = lector.dni_62_BP;
            textBoxNombre.Text = lector.nombre_62_BP;
            textBoxApellido.Text = lector.apellido_62_BP;
            dateTimePickerFechaNacimiento.Checked = lector.fecha_nacimiento_62_BP.HasValue;
            dateTimePickerFechaNacimiento.Value = lector.fecha_nacimiento_62_BP.HasValue
                ? lector.fecha_nacimiento_62_BP.Value.Date
                : DateTime.Today;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(27))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            if (ObtenerLectorSeleccionado_62_BP() == null)
            {
                return;
            }

            ConfigurarModoEdicion_62_BP(true);
            textBoxNombre.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(27))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            LectorBE_62_BP lector = ObtenerLectorSeleccionado_62_BP();
            if (lector == null || !ValidarCampos_62_BP())
            {
                return;
            }

            LectorBE_62_BP lectorModificado = new LectorBE_62_BP
            {
                dni_62_BP = lector.dni_62_BP,
                nombre_62_BP = textBoxNombre.Text.Trim(),
                apellido_62_BP = textBoxApellido.Text.Trim(),
                fecha_nacimiento_62_BP = dateTimePickerFechaNacimiento.Value.Date
            };

            try
            {
                if (_lectorBLL_62_BP.ModificarLector_62_BP(lectorModificado) <= 0)
                {
                    throw new Exception(Texto_62_BP(
                        "msg_listado_lectores_modificacion_sin_cambios",
                        "No se pudo actualizar el lector seleccionado."));
                }

                ConfigurarModoEdicion_62_BP(false);
                BuscarLectoresDesdeBLL_62_BP();
                MostrarMensaje_62_BP(
                    "msg_listado_lectores_modificacion_exitosa",
                    "Lector modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_lectores_modificacion_error",
                    "No se pudo modificar el lector: {0}",
                    ex.Message));
            }
        }

        private bool ValidarCampos_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MostrarMensaje_62_BP("msg_error_nombre_vacio", "El nombre no puede estar vacío.");
                textBoxNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxApellido.Text))
            {
                MostrarMensaje_62_BP("msg_error_apellido_vacio", "El apellido no puede estar vacío.");
                textBoxApellido.Focus();
                return false;
            }

            if (!dateTimePickerFechaNacimiento.Checked)
            {
                MostrarMensaje_62_BP("msg_error_fecha_nacimiento_vacia", "Debe ingresar la fecha de nacimiento.");
                return false;
            }

            return true;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CargarLectorSeleccionado_62_BP();
            ConfigurarModoEdicion_62_BP(false);
        }

        private void ConfigurarModoEdicion_62_BP(bool editando)
        {
            _editando_62_BP = editando;
            textBoxDNI.ReadOnly = true;
            textBoxNombre.ReadOnly = !editando;
            textBoxApellido.ReadOnly = !editando;
            dateTimePickerFechaNacimiento.Enabled = editando;
            groupBoxFiltros.Enabled = !editando;
            dataGridViewLectores.Enabled = !editando;
            buttonGuardar.Enabled = editando;
            buttonCancelar.Enabled = editando;
            ActualizarBotonEditar_62_BP();
        }

        private void ActualizarBotonEditar_62_BP()
        {
            buttonEditar.Enabled = !_editando_62_BP
                && TienePermiso_62_BP(27)
                && dataGridViewLectores.SelectedRows.Count == 1;
        }

        private bool TienePermiso_62_BP(int idPatente)
        {
            return SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(idPatente);
        }

        private void LimpiarCamposEdicion_62_BP()
        {
            textBoxDNI.Clear();
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Today;
            dateTimePickerFechaNacimiento.Checked = false;
        }
    }
}
