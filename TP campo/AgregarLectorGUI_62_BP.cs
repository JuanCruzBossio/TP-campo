using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class AgregarLectorGUI_62_BP : LocalizableForm_62_BP
    {
        private LectorBLL_62_BP _lectorBLL_62_BP = new LectorBLL_62_BP();
        private string _dniPrellenado_62_BP;

        public AgregarLectorGUI_62_BP(string dni)
        {
            _dniPrellenado_62_BP = dni;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!string.IsNullOrWhiteSpace(_dniPrellenado_62_BP))
            {
                txt_dni.Text = _dniPrellenado_62_BP;
                txt_dni.ReadOnly = true;
            }
            else
            {
                txt_dni.ReadOnly = false;
            }

            dtp_fechaNacimiento.MaxDate = DateTime.Today;
        }

        protected override void TraducirFormulario_62_BP(SEG_62_BP.Observer.Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);

            this.Text = Texto_62_BP("titulo_agregar_lector", "Alta de Lector");
            lbl_dni.Text = Texto_62_BP("lbl_dni", "DNI:");
            lbl_nombre.Text = Texto_62_BP("lbl_nombre", "Nombre:");
            lbl_apellido.Text = Texto_62_BP("lbl_apellido", "Apellido:");
            lbl_fechaNacimiento.Text = Texto_62_BP("lbl_fechaNacimiento", "Fecha de Nacimiento:");
            btn_crear.Text = Texto_62_BP("btn_crear", "Crear");
            btn_cancelar.Text = Texto_62_BP("btn_cancelar", "Cancelar");
        }

        private void btn_crear_Click(object sender, EventArgs e)
        {
            string dni = txt_dni.Text.Trim();
            string nombre = txt_nombre.Text.Trim();
            string apellido = txt_apellido.Text.Trim();
            DateTime fechaNacimiento = dtp_fechaNacimiento.Value;

            // Validar DNI: no puede estar vacio y no puede contener letras
            if (string.IsNullOrWhiteSpace(dni))
            {
                MostrarMensaje_62_BP("msg_error_dni_vacio", "El DNI no puede estar vacio.");
                txt_dni.Focus();
                return;
            }

            if (Regex.IsMatch(dni, @"[a-zA-ZáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙäëïöüÄËÏÖÜßñÑ]"))
            {
                MostrarMensaje_62_BP("msg_error_dni_letras", "El DNI no puede contener letras. Solo se permiten numeros.");
                txt_dni.Focus();
                return;
            }

            // Validar Nombre: no puede estar vacio
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje_62_BP("msg_error_nombre_vacio", "El nombre no puede estar vacio.");
                txt_nombre.Focus();
                return;
            }

            // Validar Apellido: no puede estar vacio
            if (string.IsNullOrWhiteSpace(apellido))
            {
                MostrarMensaje_62_BP("msg_error_apellido_vacio", "El apellido no puede estar vacio.");
                txt_apellido.Focus();
                return;
            }

            // Validar Fecha de Nacimiento: no puede ser superior a hoy
            if (fechaNacimiento > DateTime.Today)
            {
                MostrarMensaje_62_BP("msg_error_fecha_superior", "La fecha de nacimiento no puede ser superior a la fecha de hoy.");
                dtp_fechaNacimiento.Focus();
                return;
            }

            // Verificar si ya existe el lector registrado
            LectorBE_62_BP lectorExistente = _lectorBLL_62_BP.BuscarLector_62_BP(dni: dni);
            if (lectorExistente != null)
            {
                MostrarMensaje_62_BP("msg_error_lector_existente", string.Format("Ya existe un lector registrado con el DNI: {0}", dni));
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // Registrar el nuevo lector
            try
            {
                LectorBE_62_BP nuevoLector = new LectorBE_62_BP
                {
                    dni_62_BP = dni,
                    nombre_62_BP = nombre,
                    apellido_62_BP = apellido,
                    fecha_nacimiento_62_BP = fechaNacimiento
                };

                int resultado = _lectorBLL_62_BP.AgregarLector_62_BP(nuevoLector);

                if (resultado > 0)
                {
                    MostrarMensaje_62_BP("msg_exito_registro", "Lector registrado con exito.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MostrarMensaje_62_BP("msg_error_registro", "No se pudo registrar el lector. Intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje_62_BP("msg_error_registro_detalle", "Error al registrar el lector: " + ex.Message);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
