using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using SEG_62_BP.Observer;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class LibroHistoricoGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly LibroHistoricoBLL_62_BP _libroHistoricoBLL_62_BP =
            new LibroHistoricoBLL_62_BP();

        public LibroHistoricoGUI_62_BP()
        {
            InitializeComponent();
            buttonBuscar.Click += buttonBuscar_Click;
            buttonLimpiar.Click += buttonLimpiar_Click;
            buttonRecuperarEstado.Click += buttonRecuperarEstado_Click;
            dataGridViewHistoricos.SelectionChanged += dataGridViewHistoricos_SelectionChanged;

            ActualizarBotonRecuperar_62_BP();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarEstados_62_BP();
            BuscarHistoricosDesdeBLL_62_BP();
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            Text = Texto_62_BP("titulo_historial_libros", "Historial de libros");
            groupBoxFiltros.Text = Texto_62_BP("grupo_filtros", "Filtros");
            labelIdLibro.Text = Texto_62_BP("lbl_id_libro", "ID Libro:");
            labelEstadoPrestamo.Text = Texto_62_BP("lbl_estado_libro", "Estado del libro:");
            labelEstadoVersion.Text = Texto_62_BP("lbl_estado_version", "Estado de version:");
            buttonBuscar.Text = Texto_62_BP("btn_buscar", "Buscar");
            buttonLimpiar.Text = Texto_62_BP("btn_limpiar", "Limpiar");
            buttonRecuperarEstado.Text = Texto_62_BP("btn_recuperar_estado", "Recuperar estado");

            colFechaActualizacion.HeaderText = Texto_62_BP("col_fecha_actualizacion", "Fecha de actualizacion");
            colIdHistorico.HeaderText = Texto_62_BP("col_id_historico", "ID Historico");
            colIdLibro.HeaderText = Texto_62_BP("col_id_libro", "ID Libro");
            colTitulo.HeaderText = Texto_62_BP("col_titulo", "Titulo");
            colAutor.HeaderText = Texto_62_BP("col_autor", "Autor");
            colISBN.HeaderText = Texto_62_BP("col_isbn", "ISBN");
            colGenero.HeaderText = Texto_62_BP("col_genero", "Genero");
            colVolumen.HeaderText = Texto_62_BP("col_volumen", "Volumen");
            colPrestado.HeaderText = Texto_62_BP("col_estado", "Estado");
            colActual.HeaderText = Texto_62_BP("col_version", "Version");

            CargarEstados_62_BP();
            ActualizarTextosGrilla_62_BP();
        }

        private void CargarEstados_62_BP()
        {
            int indicePrestamo = comboBoxEstadoPrestamo.SelectedIndex;
            int indiceVersion = comboBoxEstadoVersion.SelectedIndex;

            comboBoxEstadoPrestamo.Items.Clear();
            comboBoxEstadoPrestamo.Items.Add(Texto_62_BP("estado_todos", "Todos"));
            comboBoxEstadoPrestamo.Items.Add(Texto_62_BP("estado_disponible", "Disponible"));
            comboBoxEstadoPrestamo.Items.Add(Texto_62_BP("estado_prestado", "Prestado"));
            comboBoxEstadoPrestamo.SelectedIndex = indicePrestamo >= 0 && indicePrestamo < 3
                ? indicePrestamo
                : 0;

            comboBoxEstadoVersion.Items.Clear();
            comboBoxEstadoVersion.Items.Add(Texto_62_BP("estado_todos", "Todos"));
            comboBoxEstadoVersion.Items.Add(Texto_62_BP("version_actual", "Actual"));
            comboBoxEstadoVersion.Items.Add(Texto_62_BP("version_historica", "Historica"));
            comboBoxEstadoVersion.SelectedIndex = indiceVersion >= 0 && indiceVersion < 3
                ? indiceVersion
                : 0;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BuscarHistoricosDesdeBLL_62_BP();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdLibro.Clear();
            comboBoxEstadoPrestamo.SelectedIndex = 0;
            comboBoxEstadoVersion.SelectedIndex = 0;
            BuscarHistoricosDesdeBLL_62_BP();
        }

        private void BuscarHistoricosDesdeBLL_62_BP()
        {
            int? idLibro = null;
            if (!string.IsNullOrWhiteSpace(textBoxIdLibro.Text))
            {
                int valorIdLibro;
                if (!int.TryParse(textBoxIdLibro.Text.Trim(), out valorIdLibro) || valorIdLibro <= 0)
                {
                    MostrarMensaje_62_BP(
                        "msg_id_libro_invalido",
                        "El ID del libro debe ser un numero entero positivo.");
                    textBoxIdLibro.Focus();
                    return;
                }

                idLibro = valorIdLibro;
            }

            bool? prestado = null;
            if (comboBoxEstadoPrestamo.SelectedIndex == 1)
            {
                prestado = false;
            }
            else if (comboBoxEstadoPrestamo.SelectedIndex == 2)
            {
                prestado = true;
            }

            bool? actual = null;
            if (comboBoxEstadoVersion.SelectedIndex == 1)
            {
                actual = true;
            }
            else if (comboBoxEstadoVersion.SelectedIndex == 2)
            {
                actual = false;
            }

            try
            {
                List<LibroHistoricoBE_62_BP> historicos =
                    _libroHistoricoBLL_62_BP.BuscarHistoricos_62_BP(idLibro, prestado, actual);

                LlenarGrilla_62_BP(historicos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_historial_libros_busqueda_error",
                    "No se pudo obtener el historial de libros: {0}",
                    ex.Message));
            }
        }

        private void LlenarGrilla_62_BP(IEnumerable<LibroHistoricoBE_62_BP> historicos)
        {
            dataGridViewHistoricos.Rows.Clear();

            if (historicos == null)
            {
                return;
            }

            foreach (LibroHistoricoBE_62_BP historico in historicos)
            {
                int indice = dataGridViewHistoricos.Rows.Add();
                DataGridViewRow fila = dataGridViewHistoricos.Rows[indice];
                fila.Tag = historico;
                fila.Cells[colFechaActualizacion.Name].Value =
                    historico.fecha_actualizacion_62_BP.ToString("dd/MM/yyyy HH:mm:ss.fff");
                fila.Cells[colIdHistorico.Name].Value = historico.id_historico_62_BP;
                fila.Cells[colIdLibro.Name].Value = historico.id_libro_62_BP;
                fila.Cells[colTitulo.Name].Value = historico.titulo_62_BP;
                fila.Cells[colAutor.Name].Value = historico.autor_62_BP;
                fila.Cells[colISBN.Name].Value = historico.isbn_62_BP;
                fila.Cells[colGenero.Name].Value = historico.genero_62_BP;
                fila.Cells[colVolumen.Name].Value = historico.numero_volumen_62_BP;
                fila.Cells[colPrestado.Name].Value = TextoPrestado_62_BP(historico.prestado_62_BP);
                fila.Cells[colActual.Name].Value = TextoVersion_62_BP(historico.actual_62_BP);
            }

            dataGridViewHistoricos.ClearSelection();
            ActualizarBotonRecuperar_62_BP();
        }

        private void dataGridViewHistoricos_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonRecuperar_62_BP();
        }

        private LibroHistoricoBE_62_BP ObtenerHistoricoSeleccionado_62_BP()
        {
            if (dataGridViewHistoricos.SelectedRows.Count != 1)
            {
                return null;
            }

            return dataGridViewHistoricos.SelectedRows[0].Tag as LibroHistoricoBE_62_BP;
        }

        private void ActualizarBotonRecuperar_62_BP()
        {
            LibroHistoricoBE_62_BP historico = ObtenerHistoricoSeleccionado_62_BP();
            buttonRecuperarEstado.Enabled = historico != null && !historico.actual_62_BP;
        }

        private void buttonRecuperarEstado_Click(object sender, EventArgs e)
        {
            LibroHistoricoBE_62_BP historico = ObtenerHistoricoSeleccionado_62_BP();
            if (historico == null)
            {
                return;
            }

            if (historico.actual_62_BP)
            {
                MostrarMensaje_62_BP(
                    "msg_historial_version_ya_actual",
                    "La version seleccionada ya es la version actual.");
                ActualizarBotonRecuperar_62_BP();
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                TextoFormato_62_BP(
                    "msg_historial_confirmar_recuperacion",
                    "¿Desea recuperar la version historica {0} del libro {1}?",
                    historico.id_historico_62_BP,
                    historico.id_libro_62_BP),
                Texto_62_BP("titulo_confirmacion", "Confirmacion"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
            {
                return;
            }

            try
            {
                int idLibro = _libroHistoricoBLL_62_BP.RecuperarEstado_62_BP(
                    historico.id_historico_62_BP);

                BuscarHistoricosDesdeBLL_62_BP();
                MessageBox.Show(
                    TextoFormato_62_BP(
                        "msg_historial_recuperacion_exitosa",
                        "Se recupero correctamente el estado del libro {0}.",
                        idLibro));
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_historial_recuperacion_error",
                    "No se pudo recuperar el estado del libro: {0}",
                    ex.Message));
            }
        }

        private void ActualizarTextosGrilla_62_BP()
        {
            foreach (DataGridViewRow fila in dataGridViewHistoricos.Rows)
            {
                LibroHistoricoBE_62_BP historico = fila.Tag as LibroHistoricoBE_62_BP;
                if (historico == null)
                {
                    continue;
                }

                fila.Cells[colPrestado.Name].Value = TextoPrestado_62_BP(historico.prestado_62_BP);
                fila.Cells[colActual.Name].Value = TextoVersion_62_BP(historico.actual_62_BP);
            }
        }

        private string TextoPrestado_62_BP(bool prestado)
        {
            return prestado
                ? Texto_62_BP("estado_prestado", "Prestado")
                : Texto_62_BP("estado_disponible", "Disponible");
        }

        private string TextoVersion_62_BP(bool actual)
        {
            return actual
                ? Texto_62_BP("version_actual", "Actual")
                : Texto_62_BP("version_historica", "Historica");
        }
    }
}
