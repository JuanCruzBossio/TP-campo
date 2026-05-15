using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private void UsuarioGUI_62_BP_Load(object sender, EventArgs e)
        {
            RellenarGrilla();
        }
        private void RellenarGrilla()
        {
            this.dataGridViewUsuarios.DataSource = _usuarioBLL.TraerTodosUsuarios();
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCampos((Usuario_62_BP)dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem);
            hayUsuarioSeleccionado = true;
            textBoxDNI.Enabled = false;
            checkBoxActivo.Enabled = false;
            checkBoxBloqueado.Enabled = false;
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
            try
            {
                if (hayUsuarioSeleccionado)
                {
                    MessageBox.Show("No puede crear un Usuario ya creado.");
                    return;
                }
                
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
            LimpiarCampos();
        }

        private void buttonActivar_Click(object sender, EventArgs e)
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
    }
}
