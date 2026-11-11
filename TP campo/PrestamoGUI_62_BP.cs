using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BE_62_BP;
using BLL_62_BP;
using SEG_62_BP;
using SEG_62_BP.Observer;
using TP_campo;

namespace TP_campo_62_BP
{
    public partial class PrestamoGUI_62_BP : LocalizableForm_62_BP
    {
        private LectorBLL_62_BP _lectorBLL_62_BP = new LectorBLL_62_BP();
        private PrestamoBLL_62_BP _prestamoBLL_62_BP = new PrestamoBLL_62_BP();
        private MultaBLL_62_BP _multaBLL_62_BP = new MultaBLL_62_BP();
        private LibroBLL_62_BP _libroBLL_62_BP = new LibroBLL_62_BP();
        private DetallePrestamoBLL_62_BP _detallePrestamoBLL_62_BP = new DetallePrestamoBLL_62_BP();
        private SolicitudInsatisfechaBLL_62_BP _solicitudInsatisfechaBLL_62_BP = new SolicitudInsatisfechaBLL_62_BP();

        private const int LIMITE_PRESTAMOS = 5;
        private bool dniValidado_62_BP = false;
        private LectorBE_62_BP _lectorActual_62_BP;

        public PrestamoGUI_62_BP()
        {
            InitializeComponent();
            buttonValidar.Click += buttonValidar_Click;
            buttonBuscarLibros.Click += buttonBuscarLibros_Click;
            buttonAgregarLibro.Click += buttonAgregarLibro_Click;
            buttonRegistrarPrestamo.Click += buttonRegistrarPrestamo_Click;
            ConfigurarDataGridViewLibrosFiltrados();
            ConfigurardataGridViewLibrosSeleccion();
            DeshabilitarFiltros();
        }

        private void DeshabilitarFiltros()
        {
            textBoxTitulo.ReadOnly = true;
            textBoxAutor.ReadOnly = true;
            textBoxGenero.ReadOnly = true;
            textBoxISBN.ReadOnly = true;
            buttonBuscarLibros.Enabled = false;
            dataGridViewLibrosFiltrados.Enabled = false;
            buttonAgregarLibro.Enabled = false;
        }

        private void HabilitarFiltros()
        {
            textBoxTitulo.ReadOnly = false;
            textBoxAutor.ReadOnly = false;
            textBoxGenero.ReadOnly = false;
            textBoxISBN.ReadOnly = false;
            buttonBuscarLibros.Enabled = true;
            dataGridViewLibrosFiltrados.Enabled = true;
            buttonAgregarLibro.Enabled = true;
        }

        private void ConfigurarDataGridViewLibrosFiltrados()
        {
            dataGridViewLibrosFiltrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibrosFiltrados.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn1", "ID");
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn1"].Width = 40;
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn2", "Titulo");
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn2"].Width = 120;
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn3", "Autor");
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn3"].Width = 100;
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn4", "Genero");
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn5", "ISBN");
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn5"].Width = 110;
            dataGridViewLibrosFiltrados.Columns.Add("dataGridViewTextBoxColumn6", "Vol.");
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn6"].Width = 40;
            dataGridViewLibrosFiltrados.Columns["dataGridViewTextBoxColumn6"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        }

        private void ConfigurardataGridViewLibrosSeleccion()
        {
            dataGridViewLibrosSeleccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibrosSeleccion.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewLibrosSeleccion.Columns.Add("colId", "ID");
            dataGridViewLibrosSeleccion.Columns["colId"].Width = 40;
            dataGridViewLibrosSeleccion.Columns.Add("colTitulo", "Título");
            dataGridViewLibrosSeleccion.Columns["colTitulo"].Width = 120;
            dataGridViewLibrosSeleccion.Columns.Add("colAutor", "Autor");
            dataGridViewLibrosSeleccion.Columns["colAutor"].Width = 100;
            dataGridViewLibrosSeleccion.Columns.Add("colGenero", "Género");
            dataGridViewLibrosSeleccion.Columns.Add("colIsbn", "ISBN");
            dataGridViewLibrosSeleccion.Columns["colIsbn"].Width = 110;
            dataGridViewLibrosSeleccion.Columns.Add("colVol", "Vol.");
            dataGridViewLibrosSeleccion.Columns["colVol"].Width = 40;
            dataGridViewLibrosSeleccion.Columns["colVol"].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
        }

        private void buttonAgregarLibro_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrosFiltrados.SelectedRows.Count == 0)
            {
                MostrarMensaje_62_BP("msg_sin_seleccion", "Seleccione un libro de la lista para agregar.");
                return;
            }

            DataGridViewRow filaSeleccionada = dataGridViewLibrosFiltrados.SelectedRows[0];

            // Verificar si el libro ya está en la lista de seleccionados
            int idLibro = Convert.ToInt32(filaSeleccionada.Cells["dataGridViewTextBoxColumn1"].Value);
            bool yaExiste = false;
            foreach (DataGridViewRow fila in dataGridViewLibrosSeleccion.Rows)
            {
                if (fila.Cells["colId"].Value != null && Convert.ToInt32(fila.Cells["colId"].Value) == idLibro)
                {
                    yaExiste = true;
                    break;
                }
            }

            if (yaExiste)
            {
                MostrarMensaje_62_BP("msg_libro_ya_agregado", "Este libro ya se encuentra en la lista de seleccionados.");
                return;
            }

            // Validar que agregar este libro no supere el límite de 5
            string dni = textBoxDNI.Text.Trim();
            int prestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(dni);
            int librosSeleccionados = ContarLibrosSeleccionados();
            int totalDespues = prestamosActivos + librosSeleccionados + 1;

            if (totalDespues > LIMITE_PRESTAMOS)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_limite_superado",
                    "No se puede agregar este libro. El lector ya tiene {0} libros prestados y selecciono {1} mas. El maximo es {2}.",
                    prestamosActivos, librosSeleccionados, LIMITE_PRESTAMOS));
                return;
            }

            int indice = dataGridViewLibrosSeleccion.Rows.Add();
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colId"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn1"].Value;
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colTitulo"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn2"].Value;
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colAutor"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn3"].Value;
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colGenero"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn4"].Value;
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colIsbn"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn5"].Value;
            dataGridViewLibrosSeleccion.Rows[indice].Cells["colVol"].Value = filaSeleccionada.Cells["dataGridViewTextBoxColumn6"].Value;
            ActualizarBotonRegistrarPrestamo();
        }

        private void buttonRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            string dni = textBoxDNI.Text.Trim();

            if (dataGridViewLibrosSeleccion.Rows.Count == 0)
            {
                MostrarMensaje_62_BP("msg_sin_libros", "No hay libros seleccionados para el prestamo.");
                return;
            }

            int prestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(dni);
            int librosSeleccionados = ContarLibrosSeleccionados();
            int totalDespues = prestamosActivos + librosSeleccionados;

            if (totalDespues > LIMITE_PRESTAMOS)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_limite_superado",
                    "No se puede registrar el prestamo. El lector ya tiene {0} libros prestados y selecciono {1} mas. El maximo es {2}.",
                    prestamosActivos, librosSeleccionados, LIMITE_PRESTAMOS));
                return;
            }

            try
            {
                PrestamoBE_62_BP prestamo = new PrestamoBE_62_BP
                {
                    dni_lector_62_BP = dni,
                    fecha_prestamo_62_BP = DateTime.Now,
                    fecha_limite_62_BP = DateTime.Now.AddDays(7),
                    finalizado_62_BP = false
                };

                int idPrestamo = _prestamoBLL_62_BP.AgregarPrestamo_62_BP(prestamo);

                if (idPrestamo <= 0)
                {
                    throw new Exception("No se pudo crear el prestamo.");
                }

                foreach (DataGridViewRow fila in dataGridViewLibrosSeleccion.Rows)
                {
                    if (fila.IsNewRow) continue;

                    int idLibro = Convert.ToInt32(fila.Cells["colId"].Value);

                    DetallePrestamoBE_62_BP detalle = new DetallePrestamoBE_62_BP
                    {
                        id_libro_62_BP = idLibro,
                        id_prestamo_62_BP = idPrestamo,
                        devuelto_62_BP = false,
                        perdido_62_BP = false
                    };

                    bool agregado = _detallePrestamoBLL_62_BP.AgregarDetallePrestamo_62_BP(detalle);

                    if (!agregado)
                    {
                        throw new Exception("No se pudo agregar el libro al detalle del prestamo.");
                    }
                }

                _prestamoBLL_62_BP.MarcarLibrosPrestados_62_BP(idPrestamo);

                GuardarComprobantePrestamo_62_BP(idPrestamo, prestamo);

                MostrarMensaje_62_BP("msg_prestamo_exitoso", "Prestamo registrado con exito.");

                dataGridViewLibrosSeleccion.Rows.Clear();
                dataGridViewLibrosFiltrados.Rows.Clear();
                textBoxDNI.Clear();
                textBoxTitulo.Clear();
                textBoxAutor.Clear();
                textBoxGenero.Clear();
                textBoxISBN.Clear();
                textBoxDNI.ReadOnly = false;
                dniValidado_62_BP = false;
                _lectorActual_62_BP = null;
                DeshabilitarFiltros();
                ActualizarBotonRegistrarPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_error_prestamo", "Error al registrar el prestamo: {0}", ex.Message));
            }
        }

        private void ActualizarBotonRegistrarPrestamo()
        {
            if (string.IsNullOrWhiteSpace(textBoxDNI.Text.Trim()) || !dniValidado_62_BP)
            {
                buttonRegistrarPrestamo.Enabled = false;
                return;
            }

            int librosSeleccionados = ContarLibrosSeleccionados();
            int prestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(textBoxDNI.Text.Trim());

            int totalDespues = prestamosActivos + librosSeleccionados;

            if (librosSeleccionados == 0 || totalDespues > LIMITE_PRESTAMOS)
            {
                buttonRegistrarPrestamo.Enabled = false;
                return;
            }

            buttonRegistrarPrestamo.Enabled = true;
        }

        private int ContarLibrosSeleccionados()
        {
            return dataGridViewLibrosSeleccion.Rows.Cast<DataGridViewRow>()
                .Count(fila => !fila.IsNewRow);
        }


        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);
            this.Text = Texto_62_BP("titulo_prestamo", "Prestamos");
            labelDNI.Text = Texto_62_BP("lbl_dni_lector", "DNI Lector");
            buttonValidar.Text = Texto_62_BP("btn_validar", "Validar");
            labelTitulo.Text = Texto_62_BP("lbl_titulo", "Titulo");
            labelAutor.Text = Texto_62_BP("lbl_autor", "Autor");
            labelGenero.Text = Texto_62_BP("lbl_genero", "Genero");
            label1.Text = Texto_62_BP("lbl_isbn", "ISBN");
            buttonBuscarLibros.Text = Texto_62_BP("btn_buscar_libros", "Buscar Libros");
        }

        // -------------------------------------------------------------------------
        // Filtrar libros por titulo, autor, genero e ISBN (LIKE)
        // -------------------------------------------------------------------------

        private void buttonBuscarLibros_Click(object sender, EventArgs e)
        {
            string titulo = textBoxTitulo.Text.Trim();
            string autor = textBoxAutor.Text.Trim();
            string genero = textBoxGenero.Text.Trim();
            string isbn = textBoxISBN.Text.Trim();

            // Si todos los campos estan vacios, mostrar todos los libros
            if (string.IsNullOrWhiteSpace(titulo) && string.IsNullOrWhiteSpace(autor)
                && string.IsNullOrWhiteSpace(genero) && string.IsNullOrWhiteSpace(isbn))
            {
                List<LibroBE_62_BP> todosLosLibros = _libroBLL_62_BP.BuscarTodosLosLibros_62_BP(false);
                LlenarDataGridViewLibrosFiltrados(todosLosLibros);
                return;
            }

            // Con filtros se traen todos los resultados para poder determinar si
            // el libro solicitado está agotado y luego quitar los ejemplares prestados.
            List<LibroBE_62_BP> librosCoincidentes = _libroBLL_62_BP.BuscarLibrosConFiltros_62_BP(
                titulo, autor, genero, isbn);

            bool mismoISBN = librosCoincidentes.Count > 0
                && librosCoincidentes.All(libro => libro.isbn_62_BP == librosCoincidentes[0].isbn_62_BP);
            bool todosPrestados = librosCoincidentes.Count > 0
                && librosCoincidentes.All(libro => libro.prestado_62_BP);

            if (librosCoincidentes.Count == 0)
            {
                DialogResult confirmarAlta = MessageBox.Show(
                    Texto_62_BP(
                        "msg_confirmar_libro_no_registrado",
                        "No existe un libro para esos filtros. ¿Desea agregarlo?"),
                    Texto_62_BP("titulo_confirmacion", "Confirmacion"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmarAlta != DialogResult.Yes)
                {
                    LlenarDataGridViewLibrosFiltrados(new List<LibroBE_62_BP>());
                    return;
                }

                LibroGUI_62_BP libroForm = new LibroGUI_62_BP(
                    titulo,
                    autor,
                    isbn,
                    genero,
                    true,
                    textBoxDNI.Text.Trim());
                libroForm.StartPosition = FormStartPosition.CenterParent;

                if (libroForm.ShowDialog(this) != DialogResult.OK)
                {
                    LlenarDataGridViewLibrosFiltrados(new List<LibroBE_62_BP>());
                    return;
                }

                librosCoincidentes = new List<LibroBE_62_BP>();
            }
            else if (mismoISBN && todosPrestados)
            {
                LibroBE_62_BP libroSolicitado = librosCoincidentes[0];

                SolicitudInsatisfechaBE_62_BP solicitud = new SolicitudInsatisfechaBE_62_BP
                {
                    id_libro_62_BP = libroSolicitado.id_libro_62_BP,
                    dni_lector_62_BP = textBoxDNI.Text.Trim(),
                    fecha_62_BP = DateTime.Now
                };

                _solicitudInsatisfechaBLL_62_BP.AgregarSolicitudInsatisfecha_62_BP(solicitud);
                librosCoincidentes = _libroBLL_62_BP.BuscarLibrosAlternativos_62_BP(libroSolicitado);

                MostrarMensaje_62_BP(
                    "msg_libro_no_disponible",
                    "Todos los ejemplares del libro solicitado están prestados. Se muestran alternativas disponibles.");
            }
            else
            {
                librosCoincidentes = librosCoincidentes
                    .Where(libro => !libro.prestado_62_BP)
                    .ToList();
            }

            LlenarDataGridViewLibrosFiltrados(librosCoincidentes);
        }

        private void LlenarDataGridViewLibrosFiltrados(List<LibroBE_62_BP> libros)
        {
            dataGridViewLibrosFiltrados.Rows.Clear();

            if (libros == null || libros.Count == 0)
            {
                return;
            }

            foreach (LibroBE_62_BP libro in libros)
            {
                int indice = dataGridViewLibrosFiltrados.Rows.Add();
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn1"].Value = libro.id_libro_62_BP;
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn2"].Value = libro.titulo_62_BP;
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn3"].Value = libro.autor_62_BP;
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn4"].Value = libro.genero_62_BP;
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn5"].Value = libro.isbn_62_BP;
                dataGridViewLibrosFiltrados.Rows[indice].Cells["dataGridViewTextBoxColumn6"].Value = libro.numero_volumen_62_BP;
            }
        }

        private void buttonValidar_Click(object sender, EventArgs e)
        {
            string dni = textBoxDNI.Text.Trim();

            ResultadoValidacionLector_62_BP resultado = ValidarLectorParaPrestamo_62_BP(dni);

            if (string.IsNullOrWhiteSpace(dni))
            {
                MostrarMensaje_62_BP("msg_error_dni_vacio", "Debe ingresar un DNI.");
                return;
            }

            if (!resultado.LectorRegistrado)
            {
                if (resultado.MotivoBloqueo == "Registro de lector cancelado.")
                {
                    MostrarMensaje_62_BP("msg_registro_cancelado", "Registro de lector cancelado.");
                }
                else
                {
                    MostrarMensaje_62_BP("msg_lector_no_registrado", resultado.MotivoBloqueo);
                }
                DeshabilitarFiltros();
                return;
            }

            if (!resultado.PuedeSolicitarPrestamo)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_restriccion_prestamo", "{0}", resultado.MotivoBloqueo));

                if (resultado.TieneDeudaPendiente)
                {
                    MultaGUI_62_BP multaForm = new MultaGUI_62_BP(dni);
                    multaForm.MdiParent = MdiParent;
                    multaForm.Show();
                }

                // El lector no puede solicitar un prestamo; permitir ingresar otro DNI.
                dniValidado_62_BP = false;
                textBoxDNI.ReadOnly = false;
                DeshabilitarFiltros();
                ActualizarBotonRegistrarPrestamo();
                return;
            }

            MessageBox.Show(TextoFormato_62_BP("msg_validacion_exitosa",
                "Lector: {0} {1}\nPrestamos activos: {2}\nDeuda pendiente: No\nPuede solicitar prestamo.",
                    resultado.Lector.nombre_62_BP,
                    resultado.Lector.apellido_62_BP,
                    resultado.PrestamosActivos));

            // Bloquear el DNI y habilitar los filtros
            _lectorActual_62_BP = resultado.Lector;
            dniValidado_62_BP = true;
            textBoxDNI.ReadOnly = true;
            HabilitarFiltros();
        }

        private void GuardarComprobantePrestamo_62_BP(int idPrestamo, PrestamoBE_62_BP prestamo)
        {
            SaveFileDialog dialogo = new SaveFileDialog
            {
                Filter = Texto_62_BP("dialog_filtro_xml", "Archivo XML (*.xml)|*.xml"),
                Title = Texto_62_BP("dialog_guardar_comprobante", "Guardar comprobante de préstamo"),
                FileName = string.Format("ComprobanteN_{0}.xml", idPrestamo),
                AddExtension = true,
                DefaultExt = "xml"
            };

            if (dialogo.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            XElement comprobante = new XElement("ComprobantePrestamo",
                new XElement("Lector",
                    new XElement("Nombre", _lectorActual_62_BP == null ? string.Empty : _lectorActual_62_BP.nombre_62_BP),
                    new XElement("Apellido", _lectorActual_62_BP == null ? string.Empty : _lectorActual_62_BP.apellido_62_BP),
                    new XElement("DNI", prestamo.dni_lector_62_BP)),
                new XElement("NumeroPrestamo", idPrestamo),
                new XElement("Ejemplares",
                    dataGridViewLibrosSeleccion.Rows
                        .Cast<DataGridViewRow>()
                        .Where(fila => !fila.IsNewRow)
                        .Select(fila => new XElement("Libro",
                            new XElement("Titulo", Convert.ToString(fila.Cells["colTitulo"].Value)),
                            new XElement("Autor", Convert.ToString(fila.Cells["colAutor"].Value)),
                            new XElement("ISBN", Convert.ToString(fila.Cells["colIsbn"].Value)),
                            new XElement("Volumen", Convert.ToString(fila.Cells["colVol"].Value))))),
                new XElement("FechaLimiteDevolucion", prestamo.fecha_limite_62_BP.ToString("yyyy-MM-dd")));

            comprobante.Save(dialogo.FileName);
        }

        // -------------------------------------------------------------------------
        // Clase de resultado: encapsula el estado del lector y las restricciones
        // -------------------------------------------------------------------------

        public class ResultadoValidacionLector_62_BP
        {
            public bool LectorRegistrado { get; set; }
            public LectorBE_62_BP Lector { get; set; }
            public int PrestamosActivos { get; set; }
            public bool TieneDeudaPendiente { get; set; }
            public bool PuedeSolicitarPrestamo { get; set; }
            public string MotivoBloqueo { get; set; }
        }

        // -------------------------------------------------------------------------
        // Funcion principal: valida el DNI y retorna el estado completo del lector
        // -------------------------------------------------------------------------

        public ResultadoValidacionLector_62_BP ValidarLectorParaPrestamo_62_BP(string dni)
        {
            ResultadoValidacionLector_62_BP resultado = new ResultadoValidacionLector_62_BP
            {
                LectorRegistrado = false,
                PuedeSolicitarPrestamo = false,
                MotivoBloqueo = string.Empty
            };

            if (string.IsNullOrWhiteSpace(dni))
            {
                resultado.MotivoBloqueo = Texto_62_BP("msg_error_dni_vacio", "Debe ingresar un DNI.");
                return resultado;
            }

            // Buscar lector por DNI
            LectorBE_62_BP lector = _lectorBLL_62_BP.BuscarLector_62_BP(dni: dni);

            if (lector == null)
            {
                // Lector no registrado: abrir formulario de alta
                resultado.LectorRegistrado = false;
                resultado.PuedeSolicitarPrestamo = false;
                resultado.MotivoBloqueo = Texto_62_BP("msg_lector_no_registrado", "El lector no esta registrado en el sistema.");

                AgregarLectorGUI_62_BP agregarForm = new AgregarLectorGUI_62_BP(dni);
                agregarForm.Text = Texto_62_BP("titulo_agregar_lector", "Alta de Lector");
                agregarForm.StartPosition = FormStartPosition.CenterParent;

                if (agregarForm.ShowDialog(this) == DialogResult.OK)
                {
                    // Registro exitoso: buscar nuevamente al lector
                    LectorBE_62_BP lectorNuevo = _lectorBLL_62_BP.BuscarLector_62_BP(dni: dni);
                    if (lectorNuevo != null)
                    {
                        resultado.LectorRegistrado = true;
                        resultado.Lector = lectorNuevo;
                        resultado.PrestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(dni);

                        List<MultaBE_62_BP> multasNuevas = _multaBLL_62_BP.ObtenerMultas_62_BP(dni);
                        resultado.TieneDeudaPendiente = multasNuevas != null && multasNuevas.Any(m => !m.pagada_62_BP);

                        if (resultado.TieneDeudaPendiente)
                        {
                            resultado.PuedeSolicitarPrestamo = false;
                            resultado.MotivoBloqueo = "El lector posee deuda pendiente. Debe cancelarla antes de solicitar un nuevo prestamo.";
                        }
                        else if (resultado.PrestamosActivos >= LIMITE_PRESTAMOS)
                        {
                            resultado.PuedeSolicitarPrestamo = false;
                            resultado.MotivoBloqueo = TextoFormato_62_BP("msg_limite_prestamos", "El lector alcanzó el maximo de {0} libros prestados. Debe efectuar una devolucion antes de solicitar un nuevo prestamo.", LIMITE_PRESTAMOS);
                        }
                        else
                        {
                            resultado.PuedeSolicitarPrestamo = true;
                            resultado.MotivoBloqueo = string.Empty;
                        }
                    }
                }
                else
                {
                    // El usuario cancelo el alta: mantener estado de no registrado
                    resultado.MotivoBloqueo = Texto_62_BP("msg_registro_cancelado", "Registro de lector cancelado.");
                }
                return resultado;
            }

            // Lector registrado: obtener estado actual
            resultado.LectorRegistrado = true;
            resultado.Lector = lector;
            resultado.PrestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(dni);

            // Verificar deuda pendiente
            List<MultaBE_62_BP> multasRegistradas = _multaBLL_62_BP.ObtenerMultas_62_BP(dni);
            resultado.TieneDeudaPendiente = multasRegistradas != null && multasRegistradas.Any(m => !m.pagada_62_BP);

            // Verificar restriccion de deuda pendiente
            if (resultado.TieneDeudaPendiente)
            {
                resultado.PuedeSolicitarPrestamo = false;
                resultado.MotivoBloqueo = Texto_62_BP("msg_deuda_pendiente", "El lector posee deuda pendiente. Debe cancelarla antes de solicitar un nuevo prestamo.");
                return resultado;
            }

            // Verificar restriccion de limite de libros prestados
            if (resultado.PrestamosActivos >= LIMITE_PRESTAMOS)
            {
                resultado.PuedeSolicitarPrestamo = false;
                resultado.MotivoBloqueo = TextoFormato_62_BP("msg_limite_prestamos", "El lector alcanzó el maximo de {0} libros prestados. Debe efectuar una devolucion antes de solicitar un nuevo prestamo.", LIMITE_PRESTAMOS);
                return resultado;
            }

            // Todas las restricciones pasaron
            resultado.PuedeSolicitarPrestamo = true;
            return resultado;
        }

        // -------------------------------------------------------------------------
        // Funcion auxiliar: registra un nuevo lector con sus datos completos
        // -------------------------------------------------------------------------

        public int RegistrarLectorNuevo_62_BP(string dni, string nombre, string apellido, DateTime fechaNacimiento)
        {
            try
            {
                LectorBE_62_BP lector = new LectorBE_62_BP
                {
                    dni_62_BP = dni,
                    nombre_62_BP = nombre,
                    apellido_62_BP = apellido,
                    fecha_nacimiento_62_BP = fechaNacimiento
                };

                return _lectorBLL_62_BP.AgregarLector_62_BP(lector);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el lector: " + ex.Message);
            }
        }

        // -------------------------------------------------------------------------
        // Funcion auxiliar: obtiene solo el estado del lector (sin validacion de DNI)
        // -------------------------------------------------------------------------

        public EstadoLector_62_BP ObtenerEstadoLector_62_BP(string dni)
        {
            LectorBE_62_BP lector = _lectorBLL_62_BP.BuscarLector_62_BP(dni: dni);

            if (lector == null)
            {
                return null;
            }

            int prestamosActivos = _prestamoBLL_62_BP.ContarPrestamosActivos_62_BP(dni);

            List<MultaBE_62_BP> multas = _multaBLL_62_BP.ObtenerMultas_62_BP(dni);
            bool tieneDeudaPendiente = multas != null && multas.Any(m => !m.pagada_62_BP);

            return new EstadoLector_62_BP
            {
                Dni = lector.dni_62_BP,
                Nombre = lector.nombre_62_BP,
                Apellido = lector.apellido_62_BP,
                FechaNacimiento = lector.fecha_nacimiento_62_BP,
                PrestamosActivos = prestamosActivos,
                TieneDeudaPendiente = tieneDeudaPendiente,
                PuedePrestar = !tieneDeudaPendiente && prestamosActivos < LIMITE_PRESTAMOS
            };
        }

        // -------------------------------------------------------------------------
        // Clase de estado simplificado para mostrar en la interfaz
        // -------------------------------------------------------------------------

        public class EstadoLector_62_BP
        {
            public string Dni { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
            public int PrestamosActivos { get; set; }
            public bool TieneDeudaPendiente { get; set; }
            public bool PuedePrestar { get; set; }
        }

        private void buttonValidar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
