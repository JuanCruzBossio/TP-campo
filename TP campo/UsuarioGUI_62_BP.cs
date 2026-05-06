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

        private void button1_Click(object sender, EventArgs e)
        {

        }

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

                textBoxBloqueado.Text = usuario.Bloqueo.ToString();
                textBoxActivo.Text = usuario.Activo.ToString();
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
                    Bloqueo = Convert.ToBoolean(textBoxBloqueado.Text),
                    Activo = Convert.ToBoolean(textBoxActivo.Text)
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
                Usuario_62_BP nuevoUsuario = ObtenerUsuarioDeCampos();

                if (nuevoUsuario != null)
                {
                    int resultado = _usuarioBLL.Alta(nuevoUsuario);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Usuario creado con éxito.");
                        RellenarGrilla();
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
    }
}
