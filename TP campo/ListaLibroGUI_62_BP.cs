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
    public partial class ListaLibroGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly List<LibroBE_62_BP> _libros_62_BP = new List<LibroBE_62_BP>();
        private readonly LibroBLL_62_BP _libroBLL_62_BP = new LibroBLL_62_BP();
        private bool _editando_62_BP;

        public ListaLibroGUI_62_BP()
        {
            InitializeComponent();
            CargarEstados_62_BP();

            buttonBuscar.Click += buttonBuscar_Click;
            buttonLimpiar.Click += buttonLimpiar_Click;
            buttonSolicitarLibro.Click += buttonSolicitarLibro_Click;
            buttonEditar.Click += buttonEditar_Click;
            buttonGuardar.Click += buttonGuardar_Click;
            buttonCancelar.Click += buttonCancelar_Click;
            dataGridViewLibros.SelectionChanged += dataGridViewLibros_SelectionChanged;

            ConfigurarModoEdicion_62_BP(false);
            LimpiarCamposEdicion_62_BP();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            buttonSolicitarLibro.Enabled = TienePermiso_62_BP(23);
            ActualizarBotonEditar_62_BP();
            BuscarLibrosDesdeBLL_62_BP();
        }

        public void CargarLibros_62_BP(IEnumerable<LibroBE_62_BP> libros)
        {
            _libros_62_BP.Clear();
            if (libros != null)
            {
                _libros_62_BP.AddRange(libros);
            }

            AplicarFiltros_62_BP();
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            Text = Texto_62_BP("titulo_listado_libros", "Listado de libros");
            groupBoxFiltros.Text = Texto_62_BP("grupo_filtros", "Filtros");
            groupBoxEdicion.Text = Texto_62_BP("grupo_edicion_libro", "Edición del libro seleccionado");
            labelFiltroTitulo.Text = Texto_62_BP("lbl_titulo", "Título:");
            labelFiltroAutor.Text = Texto_62_BP("lbl_autor", "Autor:");
            labelFiltroISBN.Text = Texto_62_BP("lbl_isbn", "ISBN:");
            labelFiltroGenero.Text = Texto_62_BP("lbl_genero", "Género:");
            labelFiltroEstado.Text = Texto_62_BP("lbl_estado", "Estado:");
            labelIdLibro.Text = Texto_62_BP("lbl_id_libro", "ID Libro:");
            labelTitulo.Text = Texto_62_BP("lbl_titulo", "Título:");
            labelAutor.Text = Texto_62_BP("lbl_autor", "Autor:");
            labelISBN.Text = Texto_62_BP("lbl_isbn", "ISBN:");
            labelGenero.Text = Texto_62_BP("lbl_genero", "Género:");
            labelVolumen.Text = Texto_62_BP("lbl_numero_volumen", "Número de volumen:");
            checkBoxPrestado.Text = Texto_62_BP("estado_prestado", "Prestado");
            buttonBuscar.Text = Texto_62_BP("btn_buscar", "Buscar");
            buttonLimpiar.Text = Texto_62_BP("btn_limpiar", "Limpiar");
            buttonSolicitarLibro.Text = Texto_62_BP("btn_solicitar_libro", "Solicitar libro");
            buttonEditar.Text = Texto_62_BP("btn_editar", "Editar");
            buttonGuardar.Text = Texto_62_BP("btn_guardar", "Guardar");
            buttonCancelar.Text = Texto_62_BP("btn_cancelar", "Cancelar");

            colIdLibro.HeaderText = Texto_62_BP("col_id_libro", "ID Libro");
            colTitulo.HeaderText = Texto_62_BP("col_titulo", "Título");
            colAutor.HeaderText = Texto_62_BP("col_autor", "Autor");
            colISBN.HeaderText = Texto_62_BP("col_isbn", "ISBN");
            colGenero.HeaderText = Texto_62_BP("col_genero", "Género");
            colVolumen.HeaderText = Texto_62_BP("col_volumen", "Volumen");
            colEstado.HeaderText = Texto_62_BP("col_estado", "Estado");

            int estadoSeleccionado = comboBoxEstado.SelectedIndex;
            CargarEstados_62_BP();
            comboBoxEstado.SelectedIndex = estadoSeleccionado >= 0 ? estadoSeleccionado : 0;
            AplicarFiltros_62_BP();
        }

        private void CargarEstados_62_BP()
        {
            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.Add(Texto_62_BP("estado_todos", "Todos"));
            comboBoxEstado.Items.Add(Texto_62_BP("estado_disponible", "Disponible"));
            comboBoxEstado.Items.Add(Texto_62_BP("estado_prestado", "Prestado"));
            comboBoxEstado.SelectedIndex = 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BuscarLibrosDesdeBLL_62_BP();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxFiltroTitulo.Clear();
            textBoxFiltroAutor.Clear();
            textBoxFiltroISBN.Clear();
            textBoxFiltroGenero.Clear();
            comboBoxEstado.SelectedIndex = 0;
            BuscarLibrosDesdeBLL_62_BP();
        }

        private void BuscarLibrosDesdeBLL_62_BP()
        {
            try
            {
                bool? prestado = null;
                if (comboBoxEstado.SelectedIndex == 1)
                {
                    prestado = false;
                }
                else if (comboBoxEstado.SelectedIndex == 2)
                {
                    prestado = true;
                }

                List<LibroBE_62_BP> libros = _libroBLL_62_BP.BuscarLibrosConFiltros_62_BP(
                    textBoxFiltroTitulo.Text.Trim(),
                    textBoxFiltroAutor.Text.Trim(),
                    textBoxFiltroGenero.Text.Trim(),
                    textBoxFiltroISBN.Text.Trim(),
                    prestado);

                CargarLibros_62_BP(libros);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_libros_busqueda_error",
                    "No se pudieron obtener los libros: {0}",
                    ex.Message));
            }
        }

        private void buttonSolicitarLibro_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(23))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            LibroGUI_62_BP solicitudLibro = new LibroGUI_62_BP(
                textBoxFiltroTitulo.Text.Trim(),
                textBoxFiltroAutor.Text.Trim(),
                textBoxFiltroISBN.Text.Trim(),
                textBoxFiltroGenero.Text.Trim(),
                true,
                null);

            if (MdiParent != null)
            {
                solicitudLibro.MdiParent = MdiParent;
            }

            solicitudLibro.FormClosed += (formulario, argumentos) => BuscarLibrosDesdeBLL_62_BP();
            solicitudLibro.Show();
        }

        private void AplicarFiltros_62_BP()
        {
            if (dataGridViewLibros == null)
            {
                return;
            }

            IEnumerable<LibroBE_62_BP> resultado = _libros_62_BP;
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroTitulo.Text, libro => libro.titulo_62_BP);
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroAutor.Text, libro => libro.autor_62_BP);
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroISBN.Text, libro => libro.isbn_62_BP);
            resultado = FiltrarTexto_62_BP(resultado, textBoxFiltroGenero.Text, libro => libro.genero_62_BP);

            if (comboBoxEstado.SelectedIndex == 1)
            {
                resultado = resultado.Where(libro => !libro.prestado_62_BP);
            }
            else if (comboBoxEstado.SelectedIndex == 2)
            {
                resultado = resultado.Where(libro => libro.prestado_62_BP);
            }

            LlenarGrilla_62_BP(resultado);
        }

        private IEnumerable<LibroBE_62_BP> FiltrarTexto_62_BP(
            IEnumerable<LibroBE_62_BP> libros,
            string filtro,
            Func<LibroBE_62_BP, string> selector)
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return libros;
            }

            string valorBuscado = filtro.Trim();
            return libros.Where(libro =>
                (selector(libro) ?? string.Empty).IndexOf(valorBuscado, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void LlenarGrilla_62_BP(IEnumerable<LibroBE_62_BP> libros)
        {
            dataGridViewLibros.Rows.Clear();

            foreach (LibroBE_62_BP libro in libros)
            {
                int indice = dataGridViewLibros.Rows.Add();
                DataGridViewRow fila = dataGridViewLibros.Rows[indice];
                fila.Tag = libro;
                fila.Cells[colIdLibro.Name].Value = libro.id_libro_62_BP;
                fila.Cells[colTitulo.Name].Value = libro.titulo_62_BP;
                fila.Cells[colAutor.Name].Value = libro.autor_62_BP;
                fila.Cells[colISBN.Name].Value = libro.isbn_62_BP;
                fila.Cells[colGenero.Name].Value = libro.genero_62_BP;
                fila.Cells[colVolumen.Name].Value = libro.numero_volumen_62_BP;
                fila.Cells[colEstado.Name].Value = libro.prestado_62_BP
                    ? Texto_62_BP("estado_prestado", "Prestado")
                    : Texto_62_BP("estado_disponible", "Disponible");
            }

            dataGridViewLibros.ClearSelection();
            LimpiarCamposEdicion_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private void dataGridViewLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (_editando_62_BP)
            {
                return;
            }

            CargarLibroSeleccionado_62_BP();
            ActualizarBotonEditar_62_BP();
        }

        private void CargarLibroSeleccionado_62_BP()
        {
            LibroBE_62_BP libro = ObtenerLibroSeleccionado_62_BP();
            if (libro == null)
            {
                LimpiarCamposEdicion_62_BP();
                return;
            }

            textBoxIdLibro.Text = libro.id_libro_62_BP.ToString();
            textBoxTitulo.Text = libro.titulo_62_BP;
            textBoxAutor.Text = libro.autor_62_BP;
            textBoxISBN.Text = libro.isbn_62_BP;
            textBoxGenero.Text = libro.genero_62_BP;
            decimal volumen = Math.Max(numericUpDownVolumen.Minimum,
                Math.Min(numericUpDownVolumen.Maximum, libro.numero_volumen_62_BP));
            numericUpDownVolumen.Value = volumen;
            checkBoxPrestado.Checked = libro.prestado_62_BP;
        }

        private LibroBE_62_BP ObtenerLibroSeleccionado_62_BP()
        {
            if (dataGridViewLibros.SelectedRows.Count != 1)
            {
                return null;
            }

            return dataGridViewLibros.SelectedRows[0].Tag as LibroBE_62_BP;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(26))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            if (ObtenerLibroSeleccionado_62_BP() == null)
            {
                return;
            }

            ConfigurarModoEdicion_62_BP(true);
            textBoxTitulo.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!TienePermiso_62_BP(26))
            {
                MostrarMensaje_62_BP("msg_sin_permiso", "No tiene permiso para realizar esta accion.");
                return;
            }

            LibroBE_62_BP libro = ObtenerLibroSeleccionado_62_BP();
            if (libro == null || !ValidarCampos_62_BP())
            {
                return;
            }

            LibroBE_62_BP libroModificado = new LibroBE_62_BP
            {
                id_libro_62_BP = libro.id_libro_62_BP,
                titulo_62_BP = textBoxTitulo.Text.Trim(),
                autor_62_BP = textBoxAutor.Text.Trim(),
                isbn_62_BP = textBoxISBN.Text.Trim(),
                genero_62_BP = textBoxGenero.Text.Trim(),
                numero_volumen_62_BP = Convert.ToInt32(numericUpDownVolumen.Value),
                prestado_62_BP = libro.prestado_62_BP
            };

            try
            {
                if (_libroBLL_62_BP.ModificarLibro_62_BP(libroModificado) <= 0)
                {
                    throw new Exception(Texto_62_BP(
                        "msg_listado_libros_modificacion_sin_cambios",
                        "No se pudo actualizar el libro seleccionado."));
                }

                ConfigurarModoEdicion_62_BP(false);
                BuscarLibrosDesdeBLL_62_BP();
                MostrarMensaje_62_BP(
                    "msg_listado_libros_modificacion_exitosa",
                    "Libro modificado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_listado_libros_modificacion_error",
                    "No se pudo modificar el libro: {0}",
                    ex.Message));
            }
        }

        private bool ValidarCampos_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxTitulo.Text))
            {
                MostrarMensaje_62_BP("msg_error_titulo_vacio", "El título no puede estar vacío.");
                textBoxTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxAutor.Text))
            {
                MostrarMensaje_62_BP("msg_error_autor_vacio", "El autor no puede estar vacío.");
                textBoxAutor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxISBN.Text))
            {
                MostrarMensaje_62_BP("msg_error_isbn_vacio", "El ISBN no puede estar vacío.");
                textBoxISBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxGenero.Text))
            {
                MostrarMensaje_62_BP("msg_error_genero_vacio", "El género no puede estar vacío.");
                textBoxGenero.Focus();
                return false;
            }

            return true;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CargarLibroSeleccionado_62_BP();
            ConfigurarModoEdicion_62_BP(false);
        }

        private void ConfigurarModoEdicion_62_BP(bool editando)
        {
            _editando_62_BP = editando;
            textBoxTitulo.ReadOnly = !editando;
            textBoxAutor.ReadOnly = !editando;
            textBoxISBN.ReadOnly = !editando;
            textBoxGenero.ReadOnly = !editando;
            numericUpDownVolumen.Enabled = editando;
            checkBoxPrestado.Enabled = false;
            groupBoxFiltros.Enabled = !editando;
            dataGridViewLibros.Enabled = !editando;
            buttonGuardar.Enabled = editando;
            buttonCancelar.Enabled = editando;
            ActualizarBotonEditar_62_BP();
        }

        private void ActualizarBotonEditar_62_BP()
        {
            buttonEditar.Enabled = !_editando_62_BP
                && TienePermiso_62_BP(26)
                && dataGridViewLibros.SelectedRows.Count == 1;
        }

        private bool TienePermiso_62_BP(int idPatente)
        {
            return SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(idPatente);
        }

        private void LimpiarCamposEdicion_62_BP()
        {
            textBoxIdLibro.Clear();
            textBoxTitulo.Clear();
            textBoxAutor.Clear();
            textBoxISBN.Clear();
            textBoxGenero.Clear();
            numericUpDownVolumen.Value = numericUpDownVolumen.Minimum;
            checkBoxPrestado.Checked = false;
        }
    }
}
