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

        // Variables
        FamiliaBLL_62_BP _familiaBLL_62_BP = new FamiliaBLL_62_BP();
        PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        RolBLL_62_BP _rolBLL_62_BP = new RolBLL_62_BP();

        List<Patente_62_BP> _listaTodasPatentes_62_BP = new List<Patente_62_BP>();
        List<Familia_62_BP> _listaTodasFamilias_62_BP = new List<Familia_62_BP>();
        List<Rol_62_BP> _listaTodosRoles_62_BP = new List<Rol_62_BP>();
        List<ComponentePermiso_62_BP> _permisosSeleccionados = new List<ComponentePermiso_62_BP>();

        private Rol_62_BP _rolEnEdicion_62_BP = null;

        // Modos Posibles:
        // 0 - Inicial
        // 1 - Crear
        // 2 - Modificar
        // 3 - Borrar
        private int modoActual_62_BP = 0;

        private void RolGUI_62_BP_Load(object sender, EventArgs e)
        {
            dataGridViewRoles.ReadOnly = true;
            dataGridViewRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRoles.MultiSelect = false;

            RecargarDatos_62_BP();
            CambiarModo_62_BP(0);
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (treeViewDisponibles.SelectedNode == null)
            {
                MessageBox.Show("Debe seleccionar un permiso.");
                return;
            }

            TreeNode nodo = treeViewDisponibles.SelectedNode;

            if (nodo.Parent == null)
            {
                MessageBox.Show("Debe seleccionar una Familia o una Patente.");
                return;
            }

            if (nodo.Tag is Patente_62_BP)
            {
                bool esPatenteRaiz = nodo.Parent.Tag is string tagStr && tagStr == "PATENTES";
                if (!esPatenteRaiz)
                {
                    MessageBox.Show("Debe seleccionar la Familia y no una Patente perteneciente a ella.");
                    return;
                }
            }

            ComponentePermiso_62_BP permiso = nodo.Tag as ComponentePermiso_62_BP;
            if (permiso == null) return;

            AgregarPermiso(permiso);
            ActualizarTreeViewSeleccionados_62_BP();
        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if (treeViewSeleccionados.SelectedNode == null)
            {
                MessageBox.Show("Debe seleccionar un permiso para quitar.");
                return;
            }

            TreeNode nodo = treeViewSeleccionados.SelectedNode;

            if (nodo.Parent != null)
            {
                MessageBox.Show("Debe seleccionar el componente principal (Familia o Patente raíz) para poder quitarlo.");
                return;
            }

            ComponentePermiso_62_BP permiso = nodo.Tag as ComponentePermiso_62_BP;
            if (permiso == null) return;

            QuitarPermiso(permiso);
            ActualizarTreeViewSeleccionados_62_BP();
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

            _permisosSeleccionados.Clear();
            if (hayRol)
            {
                _permisosSeleccionados.AddRange(rol.Permisos_62_BP);
            }

            ActualizarTreeViewSeleccionados_62_BP();
        }

        // Funciones
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
            buttonAplicar.Enabled = false;
            buttonCancelar.Enabled = false;

            dataGridViewRoles.ClearSelection();

            switch (modo)
            {
                case 0: // Inicial
                    _permisosSeleccionados.Clear();
                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();
                    buttonCrear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(5);
                    break;

                case 1: // Crear
                    textBoxNombre.Enabled = true;
                    _permisosSeleccionados.Clear();
                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();

                    buttonAgregar.Enabled = true;
                    buttonQuitar.Enabled = true;
                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;
                    textBoxMensaje.Text = "Modo Crear";
                    break;

                case 2: // Modificar
                    textBoxNombre.Enabled = true;
                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();
                    textBoxNombre.Text = _rolEnEdicion_62_BP.Nombre_62_BP;
                    buttonAgregar.Enabled = true;
                    buttonQuitar.Enabled = true;
                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;
                    textBoxMensaje.Text = "Modo Modificar";
                    break;

                case 3: // Borrar
                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();
                    textBoxNombre.Text = _rolEnEdicion_62_BP.Nombre_62_BP;

                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;
                    textBoxMensaje.Text = "Modo Borrar";
                    break;
            }
        }

        private Rol_62_BP ObtenerRolSeleccionado_62_BP()
        {
            if (dataGridViewRoles.CurrentRow == null)
                return null;

            return dataGridViewRoles.CurrentRow.DataBoundItem as Rol_62_BP;
        }

        private void RecargarDatos_62_BP()
        {
            _listaTodosRoles_62_BP = _rolBLL_62_BP.BuscarRoles_62_BP();
            _listaTodasFamilias_62_BP = _familiaBLL_62_BP.BuscarFamilias_62_BP();
            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();

            ActualizarGrillaRoles();
            ActualizarTreeViewDisponibles_62_BP();
            ActualizarTreeViewSeleccionados_62_BP();
        }

        private void ActualizarGrillaRoles()
        {
            dataGridViewRoles.DataSource = null;
            dataGridViewRoles.DataSource = _listaTodosRoles_62_BP;
            if (dataGridViewRoles.Columns["Id_62_BP"] != null)
                dataGridViewRoles.Columns["Id_62_BP"].Visible = false;
        }

        private void ObtenerPatentesRecursivas(ComponentePermiso_62_BP componente, List<int> ids)
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
        }

        private bool SonIguales_62_BP(ComponentePermiso_62_BP a, ComponentePermiso_62_BP b)
        {
            return a.GetType() == b.GetType() && a.Id_62_BP == b.Id_62_BP;
        }

        private Rol_62_BP ValidarRol_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("El Rol debe tener un nombre.");
                return null;
            }

            if (_permisosSeleccionados == null || _permisosSeleccionados.Count == 0)
            {
                MessageBox.Show("El Rol debe contener al menos un permiso (Familia o Patente).");
                return null;
            }


            Rol_62_BP rol = new Rol_62_BP();
            rol.Nombre_62_BP = textBoxNombre.Text;
            foreach (var permiso in _permisosSeleccionados)
            {
                rol.Agregar_62_BP(permiso);
            }

            return rol;
        }

        private bool crearRol_62_BP()
        {
            try
            {
                Rol_62_BP rol = ValidarRol_62_BP();
                if (rol == null) {
                    return false;
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

                Rol_62_BP rol = ValidarRol_62_BP();
                if (rol == null)
                {
                    return false;
                }
                rol.Nombre_62_BP = textBoxNombre.Text;
                rol.Id_62_BP = _rolEnEdicion_62_BP.Id_62_BP;

                int filas = _rolBLL_62_BP.Modificar_62_BP(rol);
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

        private TreeNode CrearNodoFamilia_62_BP(Familia_62_BP familia)
        {
            TreeNode nodo = new TreeNode(familia.Nombre_62_BP);
            nodo.Tag = familia;

            foreach (ComponentePermiso_62_BP hijo in familia.Hijos_62_BP)
            {
                if (hijo is Familia_62_BP familiaHija)
                {
                    nodo.Nodes.Add(CrearNodoFamilia_62_BP(familiaHija));
                }
                else if (hijo is Patente_62_BP patente)
                {
                    TreeNode nodoPatente = new TreeNode(patente.Nombre_62_BP);
                    nodoPatente.Tag = patente;
                    nodo.Nodes.Add(nodoPatente);
                }
            }
            return nodo;
        }

        private void ActualizarTreeViewDisponibles_62_BP()
        {
            treeViewDisponibles.Nodes.Clear();

            TreeNode nodoFamilias = new TreeNode("Familias");
            nodoFamilias.Tag = "FAMILIAS";

            TreeNode nodoPatentes = new TreeNode("Patentes");
            nodoPatentes.Tag = "PATENTES";

            foreach (Familia_62_BP familia in _listaTodasFamilias_62_BP)
            {
                nodoFamilias.Nodes.Add(CrearNodoFamilia_62_BP(familia));
            }

            foreach (Patente_62_BP patente in _listaTodasPatentes_62_BP)
            {
                TreeNode nodoPatente = new TreeNode(patente.Nombre_62_BP);
                nodoPatente.Tag = patente;
                nodoPatentes.Nodes.Add(nodoPatente);
            }

            treeViewDisponibles.Nodes.Add(nodoFamilias);
            treeViewDisponibles.Nodes.Add(nodoPatentes);
            treeViewDisponibles.ExpandAll();
        }

        private void ActualizarTreeViewSeleccionados_62_BP()
        {
            treeViewSeleccionados.Nodes.Clear();

            foreach (ComponentePermiso_62_BP permiso in _permisosSeleccionados)
            {
                if (permiso is Familia_62_BP familia)
                {
                    treeViewSeleccionados.Nodes.Add(CrearNodoFamilia_62_BP(familia));
                }
                else if (permiso is Patente_62_BP patente)
                {
                    TreeNode nodo = new TreeNode(patente.Nombre_62_BP);
                    nodo.Tag = patente;
                    treeViewSeleccionados.Nodes.Add(nodo);
                }
            }
            treeViewSeleccionados.ExpandAll();
        }
    }
}