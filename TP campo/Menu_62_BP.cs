using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_62_BP;
using SEG_62_BP;
using TP_campo;

namespace TP_campo_62_BP
{

    public partial class Menu_62_BP : LocalizableForm_62_BP
    {
        public Menu_62_BP()
        {
            InitializeComponent();
            cambiarIdiomaToolStripMenuItem.Click += cambiarIdiomaToolStripMenuItem_Click;
            solicitarTextoToolStripMenuItem.Click += solicitarTextoToolStripMenuItem_Click;
            manejarSolicitudesToolStripMenuItem.Click += manejarSolicitudesToolStripMenuItem_Click;
        }
        //Variables
        private UsuarioBLL_62_BP _usuarioBLL_62_BP = new UsuarioBLL_62_BP();
        private string _nombreUsuario_62_BP = "";
        private bool _cerrandoPorLogout_62_BP = false;
        private bool _cerrandoAplicacion_62_BP = false;

        //Eventos
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioGUI_62_BP usuarioGUI = new UsuarioGUI_62_BP();
            usuarioGUI.MdiParent = this;
            usuarioGUI.Show();
        }

        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarClaveGUI_62_BP cambiarClaveGUI = new CambiarClaveGUI_62_BP();
            cambiarClaveGUI.MdiParent = this;
            cambiarClaveGUI.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarSesion_62_BP(true);
        }

        public void CerrarSesion_62_BP(bool mostrarMensaje)
        {
            try
            {
                if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP != null)
                {
                    _usuarioBLL_62_BP.Logout_62_BP();
                }

                if (mostrarMensaje)
                {
                    MostrarMensaje_62_BP("msg_logout_exito", "Sesion cerrada con exito.");
                }

                Form login = Application.OpenForms["Login_62_BP"];

                if (login != null)
                {
                    login.Show();
                }

                _cerrandoPorLogout_62_BP = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_logout_error_detalle", "Error al cerrar sesion: {0}", TraducirExcepcion_62_BP(ex)));
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Bitacora_62_BP bitacoraForm = new Bitacora_62_BP();
            bitacoraForm.MdiParent = this;
            bitacoraForm.Show();        
        }

        private void reLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login_62_BP LoginForm = new Login_62_BP();
            LoginForm.MdiParent = this;
            LoginForm.Show();
        }

        private void Menu_62_BP_Load(object sender, EventArgs e)
        {
            _nombreUsuario_62_BP = SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Nombre_62_BP + " "+ SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP.Apellido_62_BP;
            ActualizarTextoUsuarioLogueado_62_BP();
            AplicarPermisos_62_BP();
        }


        protected override void TraducirFormulario_62_BP(SEG_62_BP.Observer.Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);
            ActualizarTextoUsuarioLogueado_62_BP();
            ventasToolStripMenuItem.Text = Texto_62_BP("ventas_prestamo", "Prestamo");
            carritoToolStripMenuItem.Text = Texto_62_BP("ventas_prestamo_solicitar", "Solicitar");
            facturarToolStripMenuItem.Text = Texto_62_BP("ventas_prestamo_devolver", "Devolver");
            despacharToolStripMenuItem.Text = Texto_62_BP("ventas_prestamo_multas", "Multas");
            lectoresToolStripMenuItem.Text = Texto_62_BP("maestros_lectores", "Lectores");
            agregarLectorToolStripMenuItem.Text = Texto_62_BP("maestros_lectores_agregar", "Agregar");
            listaLectorToolStripMenuItem.Text = Texto_62_BP("maestros_lectores_listado", "Listado");
            librosToolStripMenuItem.Text = Texto_62_BP("maestros_libros", "Libros");
        }

        private void ActualizarTextoUsuarioLogueado_62_BP()
        {
            if (string.IsNullOrWhiteSpace(_nombreUsuario_62_BP))
            {
                labelNombre.Text = string.Empty;
                return;
            }

            labelNombre.Text = Texto_62_BP("label_usuario_logueado", "Usuario Logueado:") + " " + _nombreUsuario_62_BP;
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamiliaGUI_62_BP FamiliaForm = new FamiliaGUI_62_BP();
            FamiliaForm.MdiParent = this;
            FamiliaForm.Show();
        }

        private void agregarLectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarLectorGUI_62_BP agregarLectorForm = new AgregarLectorGUI_62_BP("");
            agregarLectorForm.MdiParent = this;
            agregarLectorForm.Show();
        }

        private void librosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaLibroGUI_62_BP listaLibroForm = new ListaLibroGUI_62_BP();
            listaLibroForm.MdiParent = this;
            listaLibroForm.Show();
        }

        private void listaLectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaLectorGUI_62_BP listaLectorForm = new ListaLectorGUI_62_BP();
            listaLectorForm.MdiParent = this;
            listaLectorForm.Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolGUI_62_BP RolForm = new RolGUI_62_BP();
            RolForm.MdiParent = this;
            RolForm.Show();
        }
        private void AplicarPermisos_62_BP()
        {
            SessionManager_62_BP session = SessionManager_62_BP.GetInstancia_62_BP();

            usuariosToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(1) ||
                session.TienePermiso_62_BP(2) ||
                session.TienePermiso_62_BP(3) ||
                session.TienePermiso_62_BP(4);

            rolesToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(5) ||
                session.TienePermiso_62_BP(6) ||
                session.TienePermiso_62_BP(7);

            familiasToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(8) ||
                session.TienePermiso_62_BP(9) ||
                session.TienePermiso_62_BP(10);

            backupToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(11);

            bitacoraToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(13);

            digitoVerificadorToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(14);

            reLoginToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(15);

            cambiarClaveToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(16);

            cambiarIdiomaToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(17);

            agregarLectorToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(19);
            listaLectorToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(27);
            lectoresToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(19) ||
                session.TienePermiso_62_BP(27);

            librosToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(26);

            carritoToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(20);
            facturarToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(21);
            despacharToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(22);
            ventasToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(20) ||
                session.TienePermiso_62_BP(21) ||
                session.TienePermiso_62_BP(22);

            solicitarTextoToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(23);
            manejarSolicitudesToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(24) ||
                session.TienePermiso_62_BP(25);
            comprasToolStripMenuItem.Enabled =
                session.TienePermiso_62_BP(23) ||
                session.TienePermiso_62_BP(24) ||
                session.TienePermiso_62_BP(25);
        }

        private void digitoVerificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DigitoVerificadorGUI_62_BP DigitoVerificadorForm = new DigitoVerificadorGUI_62_BP();
            DigitoVerificadorForm.MdiParent = this;
            DigitoVerificadorForm.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupRestoreGUI_62_BP BackupRestoreForm = new BackupRestoreGUI_62_BP();
            BackupRestoreForm.MdiParent = this;
            BackupRestoreForm.Show();
        }


        private void cambiarIdiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarIdiomaGUI_62_BP cambiarIdiomaForm = new CambiarIdiomaGUI_62_BP();
            cambiarIdiomaForm.MdiParent = this;
            cambiarIdiomaForm.Show();
        }

        private void Menu_62_BP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cerrandoPorLogout_62_BP || _cerrandoAplicacion_62_BP)
            {
                return;
            }

            try
            {
                if (SessionManager_62_BP.GetInstancia_62_BP().UsuarioLogueado_62_BP != null)
                {
                    _usuarioBLL_62_BP.Logout_62_BP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_logout_error_detalle", "Error al cerrar sesion: {0}", TraducirExcepcion_62_BP(ex)));
            }
            finally
            {
                _cerrandoAplicacion_62_BP = true;
                Application.Exit();
            }
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void carritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrestamoGUI_62_BP prestamoForm = new PrestamoGUI_62_BP();
            prestamoForm.MdiParent = this;
            prestamoForm.Show();
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejoPrestamosGUI_62_BP manejoPrestamosForm = new ManejoPrestamosGUI_62_BP();
            manejoPrestamosForm.MdiParent = this;
            manejoPrestamosForm.Show();
        }

        private void despacharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultaGUI_62_BP multaForm = new MultaGUI_62_BP();
            multaForm.MdiParent = this;
            multaForm.Show();
        }

        private void manejarSolicitudesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SolicitudInsatisfechaGUI_62_BP solicitudesForm = new SolicitudInsatisfechaGUI_62_BP();
            solicitudesForm.MdiParent = this;
            solicitudesForm.Show();
        }

        private void solicitarTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibroGUI_62_BP libroForm = new LibroGUI_62_BP();
            libroForm.MdiParent = this;
            libroForm.Show();
        }

        private void rankingLectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirReporte_62_BP(ReporteGUI_62_BP.REPORTE_RANKING_LECTORES_62_BP);
        }

        private void rankingLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirReporte_62_BP(ReporteGUI_62_BP.REPORTE_RANKING_LIBROS_62_BP);
        }

        private void morosidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirReporte_62_BP(ReporteGUI_62_BP.REPORTE_MOROSIDAD_62_BP);
        }

        private void demandaInsatisfechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirReporte_62_BP(ReporteGUI_62_BP.REPORTE_DEMANDA_INSATISFECHA_62_BP);
        }

        private void AbrirReporte_62_BP(int tipoReporte)
        {
            ReporteGUI_62_BP reporteForm = new ReporteGUI_62_BP(tipoReporte);
            reporteForm.MdiParent = this;
            reporteForm.Show();
        }

        private void bitacoraToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
