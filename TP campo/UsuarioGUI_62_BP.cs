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
using BLL_62_BP;
using SEG_62_BP;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_campo_62_BP
{
    public partial class UsuarioGUI_62_BP : Form
    {
        public UsuarioGUI_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();

        private List<Usuario_62_BP> _listaUsuarios_62_BP = new List<Usuario_62_BP>();
        private List<Usuario_62_BP> _listaFiltrada_62_BP = new List<Usuario_62_BP>();

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
            radioButtonActivos.Checked = true;
            RellenarGrilla_62_BP();
            CambiarModo_62_BP(0);
            hayUsuarioSeleccionado_62_BP = false;
            buttonCrear.Enabled = true;
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
                buttonDesbloquear.Enabled = true;
                buttonModificar.Enabled = true;
                buttonActivar.Enabled = true;
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
                MessageBox.Show("Debe seleccionar un usuario.");
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
                MessageBox.Show("Debe seleccionar un usuario.");
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
                MessageBox.Show("Debe seleccionar un usuario.");
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
            textBoxRol.Enabled = valor;
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
        }
        private void LlenarCampos_62_BP(Usuario_62_BP usuario)
        {
            if (usuario != null)
            {
                textBoxDNI.Text = usuario.Dni_62_BP;
                textBoxApellidos.Text = usuario.Apellido_62_BP;
                textBoxNombres.Text = usuario.Nombre_62_BP;
                textBoxRol.Text = usuario.Rol_62_BP;
                textBoxEmail.Text = usuario.Email_62_BP;
                textBoxLogin.Text = usuario.Login_62_BP;

                checkBoxBloqueado.Checked = usuario.Bloqueo_62_BP;
                checkBoxActivo.Checked = usuario.Activo_62_BP;
            }
        }
        private Usuario_62_BP ValidarUsuario_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxDNI.Text) || string.IsNullOrWhiteSpace(textBoxApellidos.Text) ||
                string.IsNullOrWhiteSpace(textBoxNombres.Text) || string.IsNullOrWhiteSpace(textBoxRol.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxLogin.Text))
            {
                MessageBox.Show("Faltan completar datos obligatorios.");
                return null;
            }

            try
            {
                return new Usuario_62_BP
                {
                    Dni_62_BP = textBoxDNI.Text,
                    Apellido_62_BP = textBoxApellidos.Text,
                    Nombre_62_BP = textBoxNombres.Text,
                    Rol_62_BP = textBoxRol.Text,
                    Email_62_BP = textBoxEmail.Text,
                    Login_62_BP = textBoxLogin.Text,
                    Bloqueo_62_BP = checkBoxBloqueado.Checked,
                    Activo_62_BP = checkBoxActivo.Checked
                };
            }
            catch
            {
                MessageBox.Show("Error en el formato de los datos (verifique Bloqueado/Activo).");
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
                        MessageBox.Show("Usuario creado con éxito.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar el alta.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar crear el usuario: " + ex.Message);
            }
            return false;
        }
        private bool desbloquearUsuario_62_BP()
        {
            try
            {
                if (!hayUsuarioSeleccionado_62_BP)
                {
                    MessageBox.Show("Debe seleccionar un usuario a desbloquear.");
                    return false;
                }

                if (!checkBoxBloqueado.Checked)
                {
                    MessageBox.Show("El usuario seleccionado no se encuentra bloqueado.");
                    return false;
                }
                Usuario_62_BP usuarioADesbloquear = ValidarUsuario_62_BP();

                int filas = _usuarioBLL_62_BP.Desbloquear_62_BP(usuarioADesbloquear);

                if (filas > 0)
                {
                    MessageBox.Show("Usuario desbloqueado con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo realizar el desbloqueo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar desbloquear el usuario: " + ex.Message);
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
            textBoxRol.Clear();
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
                    MessageBox.Show("Debe seleccionar un usuario.");
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
                    accionRealizada = "Desactivado";
                }
                else
                {
                    filas = _usuarioBLL_62_BP.Activar_62_BP(usuario);
                    accionRealizada = "Activado";
                }

                if (filas > 0)
                {
                    MessageBox.Show($"Usuario {accionRealizada} con éxito.");
                    return true;
                }
                else
                {
                    MessageBox.Show($"No se pudo completar la acción: {accionRealizada}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar Activar/Desactivar el usuario: " + ex.Message);
            }
            return false;
        }
        private bool modificarUsuario_62_BP()
        {
            try
            {
                if (!hayUsuarioSeleccionado_62_BP)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return false;
                }

                Usuario_62_BP usuarioAModificar = ValidarUsuario_62_BP();

                if (usuarioAModificar != null)
                {
                    int filas = _usuarioBLL_62_BP.Modificar_62_BP(usuarioAModificar);

                    if (filas > 0)
                    {
                        MessageBox.Show("Usuario modificado con éxito.");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo realizar la modificacion.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar modificar: " + ex.Message);
            }
            return false;
        }

        private void CambiarModo_62_BP(int modo)
        {
            modoActual_62_BP = modo;
            buttonCrear.Enabled = true;
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
               (string.IsNullOrEmpty(textBoxRol.Text) || u.Rol_62_BP.Contains(textBoxRol.Text)) &&
               (string.IsNullOrEmpty(textBoxEmail.Text) || u.Email_62_BP.Contains(textBoxEmail.Text)) &&
               (string.IsNullOrEmpty(textBoxLogin.Text) || u.Login_62_BP.Contains(textBoxLogin.Text))
            ).ToList();

            if (_listaFiltrada_62_BP.Count > 0)
            {
                ActualizarGrilla_62_BP();
            }
            else
            {
                MessageBox.Show("No hay Usuarios que cumplan con los filtros");
            }
        }
    }
}
