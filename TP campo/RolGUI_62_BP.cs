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
using SEG.Permisos;
using SEG.Permisos_62_BP;
using SEG_62_BP;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class RolGUI_62_BP : LocalizableForm_62_BP
    {
        public RolGUI_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        FamiliaBLL_62_BP _familiaBLL_62_BP = new FamiliaBLL_62_BP();
        PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        RolBLL_62_BP _rolBLL_62_BP = new RolBLL_62_BP();
        List<Patente_62_BP> _listaTodasPatentes_62_BP = new List<Patente_62_BP>();
        List<Familia_62_BP> _listaTodasFamilias_62_BP = new List<Familia_62_BP>();
        List<Rol_62_BP> _listaTodosRoles_62_BP = new List<Rol_62_BP>();
        List<ComponentePermiso_62_BP> _permisosSeleccionados = new List<ComponentePermiso_62_BP>();
        List<ComponentePermiso_62_BP> _permisosDisponibles = new List<ComponentePermiso_62_BP>();
        List<Patente_62_BP> _patentesSeleccionadas = new List<Patente_62_BP>();
        Rol_62_BP _rolEnEdicion_62_BP = new Rol_62_BP();

        //Modos Posibles:
        // 0 - Inicial
        // 1 - Crear
        // 2 - Modificar
        // 3 - Borrar
        private int modoActual_62_BP = 0;
        private void RolGUI_62_BP_Load(object sender, EventArgs e)
        {
            dataGridViewFamiliasYPatentes.ReadOnly = true;
            dataGridViewFamiliaNueva.ReadOnly = true;
            dataGridViewPatentesSeleccionadaas.ReadOnly = true;
            dataGridViewRoles.ReadOnly = true;
            dataGridViewFamiliasYPatentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFamiliasYPatentes.MultiSelect = false;
            dataGridViewPatentesSeleccionadaas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPatentesSeleccionadaas.MultiSelect = false;
            dataGridViewRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoles.MultiSelect = false;
            _listaTodasFamilias_62_BP =  _familiaBLL_62_BP.BuscarFamilias_62_BP();

            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();

            _listaTodosRoles_62_BP = _rolBLL_62_BP.BuscarRoles_62_BP();
            ActualizarGrillaRoles();
            ActualizarGrillas();

            CambiarModo_62_BP(0);
        }
        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFamiliaNueva.CurrentRow == null)
                return;

            ComponentePermiso_62_BP permiso = (ComponentePermiso_62_BP)dataGridViewFamiliaNueva.CurrentRow.DataBoundItem;

            QuitarPermiso(permiso);
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            bool operacionExitosa = false;

            switch (modoActual_62_BP)
            {
                case 1:
                    operacionExitosa = crearRol_62_BP();
                    break;

                case 2:
                    operacionExitosa = modificarRol_62_BP();
                    break;

                case 3:
                    operacionExitosa = borrarRol_62_BP();
                    break;
            }

            if (operacionExitosa)
            {
                _rolEnEdicion_62_BP = null;
                _permisosSeleccionados.Clear();
                RecargarDatos_62_BP();

                CambiarModo_62_BP(0);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            _rolEnEdicion_62_BP = null;

            textBoxNombre.Clear();

            _permisosSeleccionados.Clear();


            RecargarDatos_62_BP();

            CambiarModo_62_BP(0);
        }


        private void buttonCrear_Click(object sender, EventArgs e)
        {
            _rolEnEdicion_62_BP = null;

            CambiarModo_62_BP(1);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Rol_62_BP rolSeleccionado = ObtenerRolSeleccionado_62_BP();

            if (rolSeleccionado == null)
            {
                MostrarMensaje_62_BP("msg_rol_debe_seleccionar", "Debe seleccionar un Rol.");
                return;
            }

            _rolEnEdicion_62_BP = rolSeleccionado;

            textBoxNombre.Text = rolSeleccionado.Nombre_62_BP;

            _permisosSeleccionados = new List<ComponentePermiso_62_BP>(rolSeleccionado.Permisos_62_BP);
            dataGridViewFamiliasYPatentes.ClearSelection();
            dataGridViewFamiliasYPatentes.CurrentCell = null;
            ActualizarGrillas();

            CambiarModo_62_BP(2);
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Rol_62_BP rolSeleccionado = ObtenerRolSeleccionado_62_BP();

            if (rolSeleccionado == null)
            {
                MostrarMensaje_62_BP("msg_rol_debe_seleccionar", "Debe seleccionar un Rol.");
                return;
            }

            _rolEnEdicion_62_BP = rolSeleccionado;

            textBoxNombre.Text = rolSeleccionado.Nombre_62_BP;

            _permisosSeleccionados = new List<ComponentePermiso_62_BP>(rolSeleccionado.Permisos_62_BP);
            dataGridViewFamiliasYPatentes.ClearSelection();
            dataGridViewFamiliasYPatentes.CurrentCell = null;
            ActualizarGrillas();

            CambiarModo_62_BP(3);
        }
        private void dataGridViewRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (modoActual_62_BP != 0)
                return;

            Rol_62_BP rol = ObtenerRolSeleccionado_62_BP();

            bool hayRol = rol != null;

            buttonModificar.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(7) && hayRol;
            buttonBaja.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(6) && hayRol;

            if (!hayRol)
            {
                _permisosSeleccionados.Clear();
                ActualizarGrillas();
                return;
            }

            _permisosSeleccionados =  new List<ComponentePermiso_62_BP>(rol.Permisos_62_BP);

            ActualizarGrillas();
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (dataGridViewFamiliasYPatentes.CurrentRow == null)
                return;

            ComponentePermiso_62_BP permiso = (ComponentePermiso_62_BP)dataGridViewFamiliasYPatentes.CurrentRow.DataBoundItem;

            AgregarPermiso(permiso);
        }
        //Funciones:
        private void CambiarModo_62_BP(int modo)
        {
            modoActual_62_BP = modo;
            textBoxNombre.Enabled = false;
            textBoxNombre.Text = "";
            textBoxMensaje.Text = "";
            buttonCrear.Enabled = false;
            buttonModificar.Enabled = false;

            buttonBaja.Enabled = false;
            buttonAgregar.Enabled = false;
            buttonQuitar.Enabled = false;
            dataGridViewFamiliasYPatentes.ClearSelection();
            dataGridViewRoles.ClearSelection();
            switch (modo)
            {
                case 0: // Inicial
                    buttonCrear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(5);
                    break;

                case 1: // Crear

                    textBoxNombre.Enabled = true;
                    _permisosSeleccionados.Clear();
                    ActualizarGrillas();

                    buttonAgregar.Enabled = true;
                    buttonQuitar.Enabled = true;
                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;

                    textBoxMensaje.Text = "Modo Crear";

                    break;

                case 2: // Modificar

                    textBoxNombre.Enabled = true;
                    buttonAgregar.Enabled = true;
                    buttonQuitar.Enabled = true;
                    
                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;

                    textBoxNombre.Text = _rolEnEdicion_62_BP.Nombre_62_BP ?? "";
                    textBoxMensaje.Text = "Modo Modificar";

                    break;
                case 3: // Borrar

                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;
                    textBoxNombre.Text = _rolEnEdicion_62_BP.Nombre_62_BP ?? "";
                    textBoxMensaje.Text = "Modo Borrar";

                    break;
            }
        }
        private Familia_62_BP ObtenerFamiliaSeleccionada_62_BP()
        {
            if (dataGridViewFamiliasYPatentes.SelectedRows.Count == 0)
                return null;

            ComponentePermiso_62_BP componente = (ComponentePermiso_62_BP)dataGridViewFamiliasYPatentes.CurrentRow.DataBoundItem;

            if (componente is Familia_62_BP familia)
            {
                return familia;
            }

            return null;
        }
        private Rol_62_BP ObtenerRolSeleccionado_62_BP()
        {
            if (dataGridViewRoles.SelectedRows.Count == 0)
                return null;

            Rol_62_BP rol = (Rol_62_BP)dataGridViewRoles.CurrentRow.DataBoundItem;


            return rol;
        }
        private void RecargarDatos_62_BP()
        {
            _listaTodosRoles_62_BP = _rolBLL_62_BP.BuscarRoles_62_BP();

            _listaTodasFamilias_62_BP = _familiaBLL_62_BP.BuscarFamilias_62_BP();

            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();
            ActualizarGrillaRoles();
            ActualizarGrillas();
        }
        private void ActualizarGrillas()
        {
            List<int> patentesCubiertas = ObtenerPatentesCubiertas();

            _permisosDisponibles.Clear();
            _patentesSeleccionadas.Clear();
            foreach (Familia_62_BP familia in _listaTodasFamilias_62_BP)
            {
                bool seleccionada = false;
                if (_rolEnEdicion_62_BP != null && familia.Id_62_BP == _rolEnEdicion_62_BP.Id_62_BP)
                {
                    continue;
                }
                foreach (ComponentePermiso_62_BP permiso in _permisosSeleccionados)
                {
                    if (SonIguales_62_BP(permiso, familia))
                    {
                        seleccionada = true;
                        break;
                    }
                }

                if (!seleccionada)
                {
                    _permisosDisponibles.Add(familia);
                }
            }

            foreach (Patente_62_BP patente in _listaTodasPatentes_62_BP)
            {
                bool seleccionada = false;
                if (patentesCubiertas.Contains(patente.Id_62_BP))
                {
                    _patentesSeleccionadas.Add(patente);
                }
                foreach (ComponentePermiso_62_BP permiso in _permisosSeleccionados)
                {
                    if (SonIguales_62_BP(permiso, patente))
                    {
                        seleccionada = true;
                        break;
                    }
                }

                if (!seleccionada && !patentesCubiertas.Contains(patente.Id_62_BP))
                {
                    _permisosDisponibles.Add(patente);
                }
            }

            dataGridViewFamiliasYPatentes.DataSource = null;
            dataGridViewFamiliasYPatentes.DataSource = _permisosDisponibles;

            dataGridViewFamiliaNueva.DataSource = null;
            dataGridViewFamiliaNueva.DataSource = _permisosSeleccionados;

            dataGridViewPatentesSeleccionadaas.DataSource = null;
            dataGridViewPatentesSeleccionadaas.DataSource = _patentesSeleccionadas;

            dataGridViewFamiliasYPatentes.Columns["Id_62_BP"].Visible = false;
            dataGridViewPatentesSeleccionadaas.Columns["Id_62_BP"].Visible = false;
            dataGridViewFamiliaNueva.Columns["Id_62_BP"].Visible = false;
            
        }
        private void ActualizarGrillaRoles()
        {
            dataGridViewRoles.DataSource = null;
            dataGridViewRoles.DataSource = _listaTodosRoles_62_BP;
            dataGridViewRoles.Columns["Id_62_BP"].Visible = false;
        }

        private List<int> ObtenerPatentesCubiertas()
        {
            List<int> ids = new List<int>();

            foreach (ComponentePermiso_62_BP permiso in _permisosSeleccionados)
            {
                ObtenerPatentesRecursivas(permiso, ids);
            }

            return ids;
        }

        private void ObtenerPatentesRecursivas(
            ComponentePermiso_62_BP componente,
            List<int> ids)
        {
            if (componente is Patente_62_BP)
            {
                if (!ids.Contains(componente.Id_62_BP))
                {
                    ids.Add(componente.Id_62_BP);
                }
            }
            else if (componente is Familia_62_BP familia)
            {
                foreach (ComponentePermiso_62_BP hijo in familia.Hijos_62_BP)
                {
                    ObtenerPatentesRecursivas(hijo, ids);
                }
            }
        }

        private void AgregarPermiso(ComponentePermiso_62_BP permiso)
        {
            bool existe = false;

            foreach (ComponentePermiso_62_BP p in _permisosSeleccionados)
            {
                if (SonIguales_62_BP(p, permiso))
                {
                    existe = true;
                    break;
                }
            }

            if (!existe)
            {
                _permisosSeleccionados.Add(permiso);

                if (permiso is Familia_62_BP familia)
                {
                    List<int> patentesFamilia = new List<int>();
                    ObtenerPatentesRecursivas(familia, patentesFamilia);

                    _permisosSeleccionados.RemoveAll(p =>
                        p is Patente_62_BP patente &&
                        patentesFamilia.Contains(patente.Id_62_BP));
                }
            }

            ActualizarGrillas();
        }

        private void QuitarPermiso(ComponentePermiso_62_BP permiso)
        {
            for (int i = 0; i < _permisosSeleccionados.Count; i++)
            {
                if (SonIguales_62_BP(_permisosSeleccionados[i], permiso))
                {
                    _permisosSeleccionados.RemoveAt(i);
                    break;
                }
            }

            ActualizarGrillas();
        }


        private bool SonIguales_62_BP(ComponentePermiso_62_BP a, ComponentePermiso_62_BP b)
        {
            return a.GetType() == b.GetType()
                && a.Id_62_BP == b.Id_62_BP;
        }
        private bool crearRol_62_BP()
        {
            try
            {
                Rol_62_BP rol = new Rol_62_BP();

                rol.Nombre_62_BP = textBoxNombre.Text;
                foreach (var permiso in _permisosSeleccionados)
                {
                    rol.Agregar_62_BP(permiso);
                }
                int filas = _rolBLL_62_BP.Alta_62_BP(rol);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_rol_creado", "Rol creado con exito.");

                    return true;
                }
                MostrarMensaje_62_BP("msg_rol_crear_error", "No se pudo crear el rol.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_crear_error_detalle", "Error al intentar crear: {0}", ex.Message));
            }

            return false;
        }
        private bool modificarRol_62_BP()
        {
            try
            {
                if (_rolEnEdicion_62_BP == null)
                {
                    MostrarMensaje_62_BP("msg_rol_debe_seleccionar", "Debe seleccionar un rol.");

                    return false;
                }

                _rolEnEdicion_62_BP.Nombre_62_BP = textBoxNombre.Text;
                _rolEnEdicion_62_BP.Permisos_62_BP.Clear();
                foreach (var permiso in _permisosSeleccionados)
                {
                    _rolEnEdicion_62_BP.Agregar_62_BP(permiso);
                }
                int filas = _rolBLL_62_BP.Modificar_62_BP(_rolEnEdicion_62_BP);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_rol_modificado", "Rol modificado con exito.");

                    return true;
                }

                MostrarMensaje_62_BP("msg_rol_modificar_error", "No se pudo modificar el Rol.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_modificar_error_detalle", "Error al intentar modificar: {0}", ex.Message));
            }

            return false;
        }
        private bool borrarRol_62_BP()
        {
            try
            {
                if (_rolEnEdicion_62_BP == null)
                {
                    MostrarMensaje_62_BP("msg_rol_debe_seleccionar", "Debe seleccionar un Rol.");

                    return false;
                }

                int filas = _rolBLL_62_BP.Baja_62_BP(_rolEnEdicion_62_BP);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_rol_eliminado", "Rol eliminado con exito.");

                    return true;
                }

                MostrarMensaje_62_BP("msg_rol_eliminar_error", "No se pudo eliminar el Rol.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_eliminar_error_detalle", "Error al intentar eliminar: {0}", ex.Message));
            }

            return false;
        }
    }
}
