using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using BLL;
using BLL_62_BP;
using SEG.Permisos_62_BP;
using SEG_62_BP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_campo_62_BP
{

    public partial class UsuarioGUI_62_BP : LocalizableForm_62_BP
    {
        public UsuarioGUI_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();
        private RolBLL_62_BP _rolBLL_62_BP = new RolBLL_62_BP();
        private List<Usuario_62_BP> _listaUsuarios_62_BP = new List<Usuario_62_BP>();
        private List<Usuario_62_BP> _listaFiltrada_62_BP = new List<Usuario_62_BP>();
        private List<Rol_62_BP> _listaRol_62_BP = new List<Rol_62_BP>();

        //Modos Posibles:
        // 0 - Inicial - Mensaje: ""
        // 1 - Consulta - Mensaje: "Modo Consulta"
        // 2 - Crear  - Mensaje: "Modo Crear"
        // 3 - Desbloquear  - Mensaje: "Modo Desbloquear"
        // 4 - Modificar  - Mensaje: "Modo Modificar"
        // 5 - Activar/Desactivar  - Mensaje: "Modo Activar/Desactivar"
        private int modoActual_62_BP = 0;
        private bool hayUsuarioSeleccionado_62_BP = false;

        //Eventos
        private void UsuarioGUI_62_BP_Load(object sender, EventArgs e)
        {
            RellenarComboBoxRol();
            radioButtonActivos.Checked = true;
            RellenarGrilla_62_BP();
            CambiarModo_62_BP(0);
            hayUsuarioSeleccionado_62_BP = false;
            buttonCrear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(1);
            buttonDesbloquear.Enabled = false;
            buttonModificar.Enabled = false;
            buttonActivar.Enabled = false;
            dataGridViewUsuarios.Columns["Contrasena_62_BP"].Visible = false;
            dataGridViewUsuarios.ReadOnly = true;
        }

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LlenarCampos_62_BP((Usuario_62_BP)dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem);
                hayUsuarioSeleccionado_62_BP = true;
                buttonDesbloquear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(2);
                buttonModificar.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(3);
                buttonActivar.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(4);
            }
        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioButtonActivos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_62_BP();
        }

        private void radioButtonTodos_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGrilla_62_BP();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo_62_BP(0);
        }

        private void buttonHabilitarConsulta_Click(object sender, EventArgs e)
        {
            CambiarModo_62_BP(1);
        }
        private void buttonCrear_Click(object sender, EventArgs e)
        {
            CambiarModo_62_BP(2);
        }
        private void buttonDesbloquear_Click(object sender, EventArgs e)
        {
            if (hayUsuarioSeleccionado_62_BP)
            {
                CambiarModo_62_BP(3);
            }
            else
            {
                MostrarMensaje_62_BP("msg_usuario_debe_seleccionar", "Debe seleccionar un usuario.");
            }
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (hayUsuarioSeleccionado_62_BP)
            {
                CambiarModo_62_BP(4);
            }
            else
            {
                MostrarMensaje_62_BP("msg_usuario_debe_seleccionar", "Debe seleccionar un usuario.");
            }
        }
        private void buttonActivar_Click(object sender, EventArgs e)
        {
            if (hayUsuarioSeleccionado_62_BP)
            {
                CambiarModo_62_BP(5);
            }
            else
            {
                MostrarMensaje_62_BP("msg_usuario_debe_seleccionar", "Debe seleccionar un usuario.");
            }
        }
        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            bool operacionExitosa = false;

            switch (modoActual_62_BP)
            {
                case 1:
                    filtrarUsuarios_62_BP();
                    return;

                case 2:
                    operacionExitosa = crearUsuario_62_BP();
                    break;

                case 3:
                    operacionExitosa = desbloquearUsuario_62_BP();
                    break;

                case 4:
                    operacionExitosa = modificarUsuario_62_BP();
                    break;

                case 5:
                    operacionExitosa = activarUsuario_62_BP();
                    break;
            }

            if (operacionExitosa)
            {
                RellenarGrilla_62_BP();
                CambiarModo_62_BP(0);
            }
        }

        //Funciones:
        private void RellenarComboBoxRol()
        {
            _listaRol_62_BP = _rolBLL_62_BP.BuscarRoles_62_BP();
            comboBoxRol.DataSource = _listaRol_62_BP;
            comboBoxRol.DisplayMember = "Nombre_62_BP";
            comboBoxRol.ValueMember = "Id_62_BP";
            comboBoxRol.SelectedIndex = -1;
        }
        private void setButtons(bool valor)
        {
            buttonAplicar.Enabled = valor;
            buttonCancelar.Enabled = valor;
        }
        private void setTextBoxs(bool valor)
        {
            textBoxDNI.Enabled = valor;
            textBoxApellidos.Enabled = valor;
            textBoxNombres.Enabled = valor;
            textBoxEmail.Enabled = valor;
            comboBoxRol.Enabled = valor;
            textBoxLogin.Enabled = valor;
            checkBoxBloqueado.Enabled = valor;
            checkBoxActivo.Enabled = valor;
        }
        private void RellenarGrilla_62_BP()
        {
            _listaUsuarios_62_BP = _usuarioBLL_62_BP.TraerTodosUsuarios_62_BP();
            _listaFiltrada_62_BP = _listaUsuarios_62_BP;
            labelCantidadUsuarios.Text = "Cantidad de Usuarios: " + _listaUsuarios_62_BP.Count();
            ActualizarGrilla_62_BP();
        }
        private void ActualizarGrilla_62_BP()
        {
            List<Usuario_62_BP> listaMostrar = _listaFiltrada_62_BP;

            if (radioButtonActivos.Checked)
            {
                listaMostrar = listaMostrar
                    .Where(u => u.Activo_62_BP)
                    .ToList();
            }

            dataGridViewUsuarios.DataSource = null;
            dataGridViewUsuarios.DataSource = listaMostrar;
            dataGridViewUsuarios.Columns["Contrasena_62_BP"].Visible = false;
            dataGridViewUsuarios.ReadOnly = true;
            ActualizarIdioma_62_BP(SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP);
        }
        private void LlenarCampos_62_BP(Usuario_62_BP usuario)
        {
            if (usuario != null)
            {
                textBoxDNI.Text = usuario.Dni_62_BP;
                textBoxApellidos.Text = usuario.Apellido_62_BP;
                textBoxNombres.Text = usuario.Nombre_62_BP;

                comboBoxRol.SelectedValue = usuario.IdRol_62_BP;

                textBoxEmail.Text = usuario.Email_62_BP;
                textBoxLogin.Text = usuario.Login_62_BP;

                checkBoxBloqueado.Checked = usuario.Bloqueo_62_BP;
                checkBoxActivo.Checked = usuario.Activo_62_BP;
            }
        }
        private Usuario_62_BP ValidarUsuario_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxDNI.Text) || !int.TryParse(textBoxDNI.Text, out int dni) ||
                dni <= 0 || string.IsNullOrWhiteSpace(textBoxApellidos.Text) ||
                string.IsNullOrWhiteSpace(textBoxNombres.Text) || comboBoxRol.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MostrarMensaje_62_BP("msg_faltan_datos_obligatorios", "Faltan completar datos obligatorios.");
                return null;
            }

            try
            {
                return new Usuario_62_BP
                {
                    Dni_62_BP = textBoxDNI.Text,
                    Apellido_62_BP = textBoxApellidos.Text,
                    Nombre_62_BP = textBoxNombres.Text,
                    IdRol_62_BP = (int)comboBoxRol.SelectedValue,
                    Email_62_BP = textBoxEmail.Text,
                    Login_62_BP = textBoxLogin.Text,
                    Bloqueo_62_BP = checkBoxBloqueado.Checked,
                    Activo_62_BP = checkBoxActivo.Checked
                };
            }
            catch
            {
                MostrarMensaje_62_BP("msg_usuario_formato_datos", "Error en el formato de los datos (verifique Bloqueado/Activo).");
                return null;
            }
        }

        public bool crearUsuario_62_BP()
        {
            try
            {
                Usuario_62_BP nuevoUsuario = ValidarUsuario_62_BP();

                if (nuevoUsuario != null)
                {
                    int resultado = _usuarioBLL_62_BP.Alta_62_BP(nuevoUsuario);

                    if (resultado > 0)
                    {
                        MostrarMensaje_62_BP("msg_usuario_creado", "Usuario creado con exito.");
                        return true;
                    }
                    else
                    {
                        MostrarMensaje_62_BP("msg_usuario_alta_error", "No se pudo realizar el alta.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_usuario_crear_error_detalle", "Ocurrio un error al intentar crear el usuario: {0}", ex.Message));
            }
            return false;
        }
        private bool desbloquearUsuario_62_BP()
        {
            try
            {
                if (!hayUsuarioSeleccionado_62_BP)
                {
                    MostrarMensaje_62_BP("msg_usuario_debe_seleccionar_desbloquear", "Debe seleccionar un usuario a desbloquear.");
                    return false;
                }

                if (!checkBoxBloqueado.Checked)
                {
                    MostrarMensaje_62_BP("msg_usuario_no_bloqueado", "El usuario seleccionado no se encuentra bloqueado.");
                    return false;
                }
                Usuario_62_BP usuarioADesbloquear = ValidarUsuario_62_BP();

                int filas = _usuarioBLL_62_BP.Desbloquear_62_BP(usuarioADesbloquear);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_usuario_desbloqueado", "Usuario desbloqueado con exito.");
                    return true;
                }
                else
                {
                    MostrarMensaje_62_BP("msg_usuario_desbloqueo_error", "No se pudo realizar el desbloqueo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_usuario_desbloquear_error_detalle", "Ocurrio un error al intentar desbloquear el usuario: {0}", ex.Message));
            }
            return false;
        }

        private void LimpiarCampos_62_BP()
        {
            textBoxDNI.Enabled = true;
            checkBoxActivo.Enabled = true;
            checkBoxBloqueado.Enabled = true;
            textBoxDNI.Clear();
            textBoxApellidos.Clear();
            textBoxNombres.Clear();
            comboBoxRol.SelectedIndex = -1;
            textBoxEmail.Clear();
            textBoxLogin.Clear();
            checkBoxBloqueado.Checked = false;
            checkBoxActivo.Checked = true;
            textBoxDNI.Focus();
            hayUsuarioSeleccionado_62_BP = false;
        }

        private bool activarUsuario_62_BP()
        {
            try
            {
                if (!hayUsuarioSeleccionado_62_BP)
                {
                    MostrarMensaje_62_BP("msg_usuario_debe_seleccionar", "Debe seleccionar un usuario.");
                    return false;
                }

                Usuario_62_BP usuario = new Usuario_62_BP();
                usuario.Dni_62_BP = textBoxDNI.Text;
                usuario.Login_62_BP = textBoxLogin.Text;

                int filas = 0;
                string accionRealizada = "";

                if (checkBoxActivo.Checked)
                {
                    filas = _usuarioBLL_62_BP.Desactivar_62_BP(usuario);
                    accionRealizada = Texto_62_BP("estado_usuario_desactivado", "Desactivado");
                }
                else
                {
                    filas = _usuarioBLL_62_BP.Activar_62_BP(usuario);
                    accionRealizada = Texto_62_BP("estado_usuario_activado", "Activado");
                }

                if (filas > 0)
                {
                    MessageBox.Show(TextoFormato_62_BP("msg_usuario_accion_exito", "Usuario {0} con exito.", accionRealizada));
                    return true;
                }
                else
                {
                    MessageBox.Show(TextoFormato_62_BP("msg_usuario_accion_error", "No se pudo completar la accion: {0}.", accionRealizada));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_usuario_activar_error_detalle", "Ocurrio un error al intentar Activar/Desactivar el usuario: {0}", ex.Message));
            }
            return false;
        }
        private bool modificarUsuario_62_BP()
        {
            try
            {
                if (!hayUsuarioSeleccionado_62_BP)
                {
                    MostrarMensaje_62_BP("msg_usuario_debe_seleccionar", "Debe seleccionar un usuario.");
                    return false;
                }

                Usuario_62_BP usuarioAModificar = ValidarUsuario_62_BP();

                if (usuarioAModificar != null)
                {
                    int filas = _usuarioBLL_62_BP.Modificar_62_BP(usuarioAModificar);

                    if (filas > 0)
                    {
                        MostrarMensaje_62_BP("msg_usuario_modificado", "Usuario modificado con exito.");
                        return true;
                    }
                    else
                    {
                        MostrarMensaje_62_BP("msg_usuario_modificar_error", "No se pudo realizar la modificacion.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_modificar_error_detalle", "Error al intentar modificar: {0}", ex.Message));
            }
            return false;
        }

        private void CambiarModo_62_BP(int modo)
        {
            modoActual_62_BP = modo;
            buttonCrear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(1);
            buttonDesbloquear.Enabled = false;
            buttonModificar.Enabled = false;
            buttonActivar.Enabled = false;
            switch (modo)
            {
                case 1:
                    LimpiarCampos_62_BP();
                    setButtons(true);
                    setTextBoxs(true);
                    checkBoxBloqueado.Enabled = false;
                    checkBoxActivo.Enabled = false;
                    textBoxMensaje.Text = "Modo Consulta";
                    break;
                case 2:
                    LimpiarCampos_62_BP();
                    setButtons(true);
                    setTextBoxs(true);
                    buttonCrear.Enabled = false;
                    checkBoxBloqueado.Enabled = false;
                    textBoxMensaje.Text = "Modo Crear";
                    break;
                case 3:
                    setButtons(true);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "Modo Desbloquear";
                    break;
                case 4:
                    setButtons(true);
                    setTextBoxs(true);
                    textBoxDNI.Enabled = false;
                    checkBoxBloqueado.Enabled = false;
                    textBoxMensaje.Text = "Modo Modificar";
                    break;
                case 5:
                    setButtons(true);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "Modo Activar/Desactivar";
                    break;
                case 0:
                    LimpiarCampos_62_BP();
                    RellenarGrilla_62_BP();
                    setButtons(false);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "";
                    break;
                default:
                    LimpiarCampos_62_BP();
                    RellenarGrilla_62_BP();
                    setButtons(false);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "";
                    break;
            }
            buttonCancelar.Enabled = true;
        }
        private void filtrarUsuarios_62_BP()
        {
            _listaFiltrada_62_BP = _listaUsuarios_62_BP.Where(
               u =>
               (string.IsNullOrEmpty(textBoxDNI.Text) || u.Dni_62_BP.Contains(textBoxDNI.Text)) &&
               (string.IsNullOrEmpty(textBoxApellidos.Text) || u.Apellido_62_BP.Contains(textBoxApellidos.Text)) &&
               (string.IsNullOrEmpty(textBoxNombres.Text) || u.Nombre_62_BP.Contains(textBoxNombres.Text)) &&
               (comboBoxRol.SelectedIndex == -1 || u.IdRol_62_BP == (int)comboBoxRol.SelectedValue) &&
               (string.IsNullOrEmpty(textBoxEmail.Text) || u.Email_62_BP.Contains(textBoxEmail.Text)) &&
               (string.IsNullOrEmpty(textBoxLogin.Text) || u.Login_62_BP.Contains(textBoxLogin.Text))
            ).ToList();

            if (_listaFiltrada_62_BP.Count > 0)
            {
                ActualizarGrilla_62_BP();
            }
            else
            {
                MostrarMensaje_62_BP("msg_usuario_sin_resultados", "No hay Usuarios que cumplan con los filtros");
            }
        }
    }
}
