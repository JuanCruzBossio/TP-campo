using System;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class LibroGUI_62_BP : LocalizableForm_62_BP
    {
        private LibroBLL_62_BP _libroBLL_62_BP = new LibroBLL_62_BP();
        private SolicitudInsatisfechaBLL_62_BP _solicitudInsatisfechaBLL_62_BP = new SolicitudInsatisfechaBLL_62_BP();
        private bool _prestadoInicial_62_BP;
        private string _dniLector_62_BP;

        public int IdLibroRegistrado_62_BP { get; private set; }

        public LibroGUI_62_BP()
        {
            InitializeComponent();
        }

        public LibroGUI_62_BP(
            string titulo,
            string autor,
            string isbn,
            string genero,
            bool prestado,
            string dniLector) : this()
        {
            txt_titulo.Text = titulo;
            txt_autor.Text = autor;
            txt_isbn.Text = isbn;
            txt_genero.Text = genero;
            _prestadoInicial_62_BP = prestado;
            _dniLector_62_BP = dniLector;
        }

        protected override void TraducirFormulario_62_BP(SEG_62_BP.Observer.Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            Text = Texto_62_BP("titulo_solicitud_libro", "Solicitud de libro");
            lbl_titulo.Text = Texto_62_BP("lbl_titulo", "Titulo:");
            lbl_autor.Text = Texto_62_BP("lbl_autor", "Autor:");
            lbl_isbn.Text = Texto_62_BP("lbl_isbn", "ISBN:");
            lbl_genero.Text = Texto_62_BP("lbl_genero", "Genero:");
            lbl_numeroVolumen.Text = Texto_62_BP("lbl_numero_volumen", "Numero de volumen:");
            btn_crear.Text = Texto_62_BP("btn_solicitar_libro", "Solicitar");
            btn_cancelar.Text = Texto_62_BP("btn_cancelar", "Cancelar");
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            string titulo = txt_titulo.Text.Trim();
            string autor = txt_autor.Text.Trim();
            string isbn = txt_isbn.Text.Trim();
            string genero = txt_genero.Text.Trim();
            int numeroVolumen = Convert.ToInt32(nud_numeroVolumen.Value);

            if (string.IsNullOrWhiteSpace(titulo))
            {
                MostrarMensaje_62_BP("msg_error_titulo_vacio", "El titulo no puede estar vacio.");
                txt_titulo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(autor))
            {
                MostrarMensaje_62_BP("msg_error_autor_vacio", "El autor no puede estar vacio.");
                txt_autor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(isbn))
            {
                MostrarMensaje_62_BP("msg_error_isbn_vacio", "El ISBN no puede estar vacio.");
                txt_isbn.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(genero))
            {
                MostrarMensaje_62_BP("msg_error_genero_vacio", "El genero no puede estar vacio.");
                txt_genero.Focus();
                return;
            }

            try
            {
                LibroBE_62_BP nuevoLibro = new LibroBE_62_BP
                {
                    titulo_62_BP = titulo,
                    autor_62_BP = autor,
                    isbn_62_BP = isbn,
                    genero_62_BP = genero,
                    numero_volumen_62_BP = numeroVolumen,
                    prestado_62_BP = _prestadoInicial_62_BP
                };

                int idLibro = _libroBLL_62_BP.AgregarLibro_62_BP(nuevoLibro);

                if (idLibro > 0)
                {
                    IdLibroRegistrado_62_BP = idLibro;

                    SolicitudInsatisfechaBE_62_BP solicitud = new SolicitudInsatisfechaBE_62_BP
                    {
                        id_libro_62_BP = idLibro,
                        dni_lector_62_BP = _dniLector_62_BP,
                        fecha_62_BP = DateTime.Now
                    };

                    if (_solicitudInsatisfechaBLL_62_BP.AgregarSolicitudInsatisfecha_62_BP(solicitud) <= 0)
                    {
                        throw new Exception("No se pudo registrar la solicitud del libro.");
                    }

                    MostrarMensaje_62_BP("msg_exito_solicitud_libro", "Solicitud de libro registrada con exito.");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MostrarMensaje_62_BP("msg_error_registro_libro", "No se pudo registrar el libro. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_error_registro_libro_detalle",
                    "Error al registrar el libro: {0}",
                    ex.Message));
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
