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
using SEG;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_campo
{
    public partial class UsuarioGUI_62_BP : Form
    {
        public UsuarioGUI_62_BP()
        {
            InitializeComponent();
        }
        private UsuarioBLL_62_BP _usuarioBLL = new UsuarioBLL_62_BP();
        private bool hayUsuarioSeleccionado = false;

        private List<Usuario_62_BP> _listaUsuarios = new List<Usuario_62_BP>();

        //Modos Posibles:
        // 0 - Inicial - Mensaje: ""
        // 1 - Consulta - Mensaje: "Modo Consulta"
        // 2 - Crear  - Mensaje: "Modo Crear"
        // 3 - Desbloquear  - Mensaje: "Modo Desbloquear"
        // 4 - Modificar  - Mensaje: "Modo Modificar"
        // 5 - Activar/Desactivar  - Mensaje: "Modo Activar/Desactivar"
        private int modoActual = 0;
        private void UsuarioGUI_62_BP_Load(object sender, EventArgs e)
        {
            RellenarGrilla();
            CambiarModo(0);
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
            textBoxRol.Enabled = valor;
            textBoxLogin.Enabled = valor;
            checkBoxBloqueado.Enabled = valor;
            checkBoxActivo.Enabled = valor;
        }
        private void RellenarGrilla()
        {
            _listaUsuarios = _usuarioBLL.TraerTodosUsuarios();
            this.dataGridViewUsuarios.DataSource = _listaUsuarios;
        }

        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (modoActual >= 3)
            {
                LlenarCampos((Usuario_62_BP)dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem);
                hayUsuarioSeleccionado = true;
                textBoxDNI.Enabled = false;
            }
        }
        private void LlenarCampos(Usuario_62_BP usuario)
        {
            if (usuario != null)
            {
                textBoxDNI.Text = usuario.Dni;
                textBoxApellidos.Text = usuario.Apellido;
                textBoxNombres.Text = usuario.Nombre;
                textBoxRol.Text = usuario.Rol;
                textBoxEmail.Text = usuario.Email;
                textBoxLogin.Text = usuario.Login;

                checkBoxBloqueado.Checked = usuario.Bloqueo;
                checkBoxActivo.Checked = usuario.Activo;
            }
        }
        private Usuario_62_BP ObtenerUsuarioDeCampos()
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
                    Dni = textBoxDNI.Text,
                    Apellido = textBoxApellidos.Text,
                    Nombre = textBoxNombres.Text,
                    Rol = textBoxRol.Text,
                    Email = textBoxEmail.Text,
                    Login = textBoxLogin.Text,
                    Bloqueo = checkBoxBloqueado.Checked,
                    Activo = checkBoxActivo.Checked
                };
            }
            catch
            {
                MessageBox.Show("Error en el formato de los datos (verifique Bloqueado/Activo).");
                return null;
            }
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            CambiarModo(2);
        }
        public void crearUsuario()
        {
            try
            {
                Usuario_62_BP nuevoUsuario = ObtenerUsuarioDeCampos();

                if (nuevoUsuario != null)
                {
                    int resultado = _usuarioBLL.Alta(nuevoUsuario);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Usuario creado con éxito.");
                        RellenarGrilla();
                        LimpiarCampos();
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
        }
        private void buttonDesbloquear_Click(object sender, EventArgs e)
        {
            CambiarModo(3);
        }
        private void desbloquearUsuario()
        {
            try
            {
                if (!hayUsuarioSeleccionado)
                {
                    MessageBox.Show("Debe seleccionar un usuario a desbloquear.");
                    return;
                }

                if (!checkBoxBloqueado.Checked)
                {
                    MessageBox.Show("El usuario seleccionado no se encuentra bloqueado.");
                    return;
                }
                Usuario_62_BP usuarioADesbloquear = new Usuario_62_BP();
                usuarioADesbloquear.Dni = textBoxDNI.Text;
                usuarioADesbloquear.Login = textBoxLogin.Text;

                int filas = _usuarioBLL.Desbloquear(usuarioADesbloquear);

                if (filas > 0)
                {
                    MessageBox.Show("Usuario desbloqueado con éxito.");
                    RellenarGrilla();
                    LimpiarCampos();
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
        }

        private void LimpiarCampos()
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
            hayUsuarioSeleccionado = false;
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo(0);
        }

        private void buttonActivar_Click(object sender, EventArgs e)
        {
            CambiarModo(5);
        }
        private void activarUsuario()
        {
            try
            {
                if (!hayUsuarioSeleccionado)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                Usuario_62_BP usuario = new Usuario_62_BP();
                usuario.Dni = textBoxDNI.Text;
                usuario.Login = textBoxLogin.Text;

                int filas = 0;
                string accionRealizada = "";

                if (checkBoxActivo.Checked)
                {
                    filas = _usuarioBLL.Desactivar(usuario);
                    accionRealizada = "Desactivado";
                }
                else
                {
                    filas = _usuarioBLL.Activar(usuario);
                    accionRealizada = "Activado";
                }

                if (filas > 0)
                {
                    MessageBox.Show($"Usuario {accionRealizada} con éxito.");
                    RellenarGrilla();
                    LimpiarCampos();
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
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            CambiarModo(4);
        }
        private void modificarUsuario()
        {
           try
            {
                if (!hayUsuarioSeleccionado)
                {
                    MessageBox.Show("Debe seleccionar un usuario.");
                    return;
                }

                Usuario_62_BP usuarioAModificar = ObtenerUsuarioDeCampos();

                if (usuarioAModificar != null)
                {
                    int filas = _usuarioBLL.Modificar(usuarioAModificar);

                    if (filas > 0)
                    {
                        MessageBox.Show("Usuario modificado con éxito.");
                        RellenarGrilla();
                        LimpiarCampos();
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
        }
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHabilitarConsulta_Click(object sender, EventArgs e)
        {
            CambiarModo(1);
        }
        private void CambiarModo(int modo)
        {
            RellenarGrilla();
            LimpiarCampos();
            switch (modo) {
                case 1:
                    setButtons(true);
                    setTextBoxs(true);
                    textBoxMensaje.Text = "Modo Consulta";
                    break;
                case 2:
                    setButtons(true);
                    setTextBoxs(true);
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
                    textBoxMensaje.Text = "Modo Modificar";
                    break;
                case 5:
                    setButtons(true);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "Modo Activar/Desactivar";
                    break;
                case 0:
                    LimpiarCampos();
                    setButtons(false);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "";
                    break;
                default:
                    LimpiarCampos();
                    setButtons(false);
                    setTextBoxs(false);
                    textBoxMensaje.Text = "";
                    break;
            }
            modoActual = modo;
        }
        private void filtrarUsuarios()
        {
             var listafiltrada = _listaUsuarios.Where(
                u =>
                (string.IsNullOrEmpty(textBoxDNI.Text) || u.Dni.Contains(textBoxDNI.Text)) &&
                (string.IsNullOrEmpty(textBoxApellidos.Text) || u.Apellido.Contains(textBoxApellidos.Text)) &&
                (string.IsNullOrEmpty(textBoxNombres.Text) || u.Nombre.Contains(textBoxNombres.Text)) &&
                (string.IsNullOrEmpty(textBoxRol.Text) || u.Rol.Contains(textBoxRol.Text)) &&
                (string.IsNullOrEmpty(textBoxEmail.Text) || u.Email.Contains(textBoxEmail.Text)) &&
                (string.IsNullOrEmpty(textBoxLogin.Text) || u.Login.Contains(textBoxLogin.Text)) &&
                (u.Bloqueo == checkBoxBloqueado.Checked) &&
                (u.Activo == checkBoxActivo.Checked)
            ).ToList();
            if (listafiltrada.Count > 0)
            {
                this.dataGridViewUsuarios.DataSource = listafiltrada;
            }
            else
            {
                MessageBox.Show("No hay Usuarios que cumplan con los filtros");
            }
            
        }
        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            switch (modoActual){
                case 1:
                    filtrarUsuarios();
                    break;
                case 2:
                    crearUsuario();
                    break;
                case 3:
                    desbloquearUsuario();
                    break;
                case 4:
                    modificarUsuario();
                    break;
                case 5:
                    activarUsuario();
                    break;
                case 0:
                    break;
                default:
                    break;
            }
            RellenarGrilla();
            LimpiarCampos();
        }
    }
}
