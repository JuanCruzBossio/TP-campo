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
using SEG_62_BP.Observer;
using TP_campo_62_BP;

namespace TP_campo
{

    public partial class FamiliaGUI_62_BP : LocalizableForm_62_BP
    {
        public FamiliaGUI_62_BP()
        {
            InitializeComponent();
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            base.TraducirFormulario_62_BP(idioma_62_BP);
            ActualizarTextoModo_62_BP();
            ActualizarTreeViewDisponibles_62_BP();
            ActualizarTreeViewSeleccionados_62_BP();
        }
        //Variables
        FamiliaBLL_62_BP _familiaBLL_62_BP = new FamiliaBLL_62_BP();
        PatenteBLL_62_BP _patenteBLL_62_BP = new PatenteBLL_62_BP();
        List<Patente_62_BP> _listaTodasPatentes_62_BP = new List<Patente_62_BP>();
        List<Familia_62_BP> _listaTodasFamilias_62_BP = new List<Familia_62_BP>(); 
        List<ComponentePermiso_62_BP> _permisosSeleccionados = new List<ComponentePermiso_62_BP>();
        List<ComponentePermiso_62_BP> _permisosDisponibles = new List<ComponentePermiso_62_BP>();
        List<Patente_62_BP> _patentesSeleccionadas = new List<Patente_62_BP>();
        Familia_62_BP familiaEnEdicion_62_BP = new Familia_62_BP();
        //Modos Posibles:
        // 0 - Inicial
        // 1 - Crear
        // 2 - Modificar
        // 3 - Borrar
        private int modoActual_62_BP = 0;

        //Eventos
        private void FamiliaGUI_62_BP_Load(object sender, EventArgs e)
        {
            _listaTodasFamilias_62_BP =  _familiaBLL_62_BP.BuscarFamilias_62_BP();

            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();

            ActualizarGrillas();

            CambiarModo_62_BP(0);
        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if (treeViewSeleccionados.SelectedNode == null)
            {
                MostrarMensaje_62_BP("msg_permiso_debe_seleccionar_quitar", "Debe seleccionar un permiso para quitar.");
                return;
            }

            TreeNode nodo = treeViewSeleccionados.SelectedNode;

            if (nodo.Parent != null)
            {
                MostrarMensaje_62_BP("msg_permiso_debe_seleccionar_raiz_quitar", "Debe seleccionar el componente principal (Familia o Patente raiz) para poder quitarlo.");
                return;
            }

            ComponentePermiso_62_BP permiso = nodo.Tag as ComponentePermiso_62_BP;

            if (permiso == null)
                return;

            QuitarPermiso(permiso);

            ActualizarTreeViewSeleccionados_62_BP();
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            bool operacionExitosa = false;

            switch (modoActual_62_BP)
            {
                case 1:
                    operacionExitosa = crearFamilia_62_BP();
                    break;

                case 2:
                    operacionExitosa = modificarFamilia_62_BP();
                    break;

                case 3:
                    operacionExitosa = borrarFamilia_62_BP();
                    break;
            }

            if (operacionExitosa)
            {
                familiaEnEdicion_62_BP = null;
                _permisosSeleccionados.Clear();
                RecargarDatos_62_BP();

                CambiarModo_62_BP(0);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            familiaEnEdicion_62_BP = null;

            textBoxNombre.Clear();

            _permisosSeleccionados.Clear();


            RecargarDatos_62_BP();

            CambiarModo_62_BP(0);
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            familiaEnEdicion_62_BP = null;

            CambiarModo_62_BP(1);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            Familia_62_BP familiaSeleccionada = ObtenerFamiliaSeleccionada_62_BP();

            if (familiaSeleccionada == null)
            {
                MostrarMensaje_62_BP("msg_familia_debe_seleccionar", "Debe seleccionar una familia.");
                return;
            }

            familiaEnEdicion_62_BP = familiaSeleccionada;

            textBoxNombre.Text = familiaSeleccionada.Nombre_62_BP;

            _permisosSeleccionados = new List<ComponentePermiso_62_BP>(familiaSeleccionada.Hijos_62_BP);
            ActualizarGrillas();

            CambiarModo_62_BP(2);
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Familia_62_BP familiaSeleccionada =
                ObtenerFamiliaSeleccionada_62_BP();

            if (familiaSeleccionada == null)
            {
                MostrarMensaje_62_BP("msg_familia_debe_seleccionar", "Debe seleccionar una familia.");
                return;
            }

            familiaEnEdicion_62_BP = familiaSeleccionada;

            textBoxNombre.Text =
                familiaSeleccionada.Nombre_62_BP;

            _permisosSeleccionados =
                new List<ComponentePermiso_62_BP>(
                    familiaSeleccionada.Hijos_62_BP);
            ActualizarGrillas();

            CambiarModo_62_BP(3);
        }
        private void dataGridViewFamiliasYPatentes_SelectionChanged(object sender, EventArgs e)
        {
            if (modoActual_62_BP != 0)
                return;

            bool hayFamilia =
                EsFamiliaRaizSeleccionada_62_BP();

            buttonModificar.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(10)  && hayFamilia;
            buttonBaja.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(9) && hayFamilia;
        }
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (treeViewDisponibles.SelectedNode == null)
            {
                MostrarMensaje_62_BP("msg_permiso_debe_seleccionar", "Debe seleccionar un permiso.");
                return;
            }

            TreeNode nodo = treeViewDisponibles.SelectedNode;

            if (nodo.Parent == null)
            {
                MostrarMensaje_62_BP("msg_permiso_debe_seleccionar_familia_o_patente", "Debe seleccionar una Familia o una Patente.");
                return;
            }

            if (nodo.Tag is Patente_62_BP)
            {
                bool esPatenteRaiz = nodo.Parent.Tag is string tagStr && tagStr == "PATENTES";

                if (!esPatenteRaiz)
                {
                    MostrarMensaje_62_BP("msg_permiso_debe_seleccionar_familia_no_patente_hija", "Debe seleccionar la Familia y no una Patente perteneciente a ella.");
                    return;
                }
            }

            ComponentePermiso_62_BP permiso = treeViewDisponibles.SelectedNode.Tag as ComponentePermiso_62_BP;

            if (permiso == null)
                return;

            AgregarPermiso(permiso);

            ActualizarTreeViewSeleccionados_62_BP();
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

            buttonAplicar.Enabled = false;
            buttonCancelar.Enabled = false;

            switch (modo)
            {
                case 0: // Inicial

                    _permisosSeleccionados.Clear();

                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();

                    buttonCrear.Enabled =
                        SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(8);

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

                    textBoxMensaje.Text = Texto_62_BP("msg_modo_crear", "Modo Crear");

                    break;

                case 2: // Modificar

                    textBoxNombre.Enabled = true;

                    _permisosSeleccionados.Clear();

                    foreach (ComponentePermiso_62_BP permiso in familiaEnEdicion_62_BP.Hijos_62_BP)
                    {
                        _permisosSeleccionados.Add(permiso);
                    }

                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();

                    buttonAgregar.Enabled = true;
                    buttonQuitar.Enabled = true;
                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;

                    textBoxNombre.Text = familiaEnEdicion_62_BP.Nombre_62_BP;
                    textBoxMensaje.Text = Texto_62_BP("msg_modo_modificar", "Modo Modificar");

                    break;

                case 3: // Borrar

                    _permisosSeleccionados.Clear();

                    foreach (ComponentePermiso_62_BP permiso in familiaEnEdicion_62_BP.Hijos_62_BP)
                    {
                        _permisosSeleccionados.Add(permiso);
                    }

                    ActualizarTreeViewDisponibles_62_BP();
                    ActualizarTreeViewSeleccionados_62_BP();

                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;

                    textBoxNombre.Text = familiaEnEdicion_62_BP.Nombre_62_BP;
                    textBoxMensaje.Text = Texto_62_BP("msg_modo_borrar", "Modo Borrar");

                    break;
            }
        }

        private void ActualizarTextoModo_62_BP()
        {
            switch (modoActual_62_BP)
            {
                case 1:
                    textBoxMensaje.Text = Texto_62_BP("msg_modo_crear", "Modo Crear");
                    break;
                case 2:
                    textBoxMensaje.Text = Texto_62_BP("msg_modo_modificar", "Modo Modificar");
                    break;
                case 3:
                    textBoxMensaje.Text = Texto_62_BP("msg_modo_borrar", "Modo Borrar");
                    break;
            }
        }
        private Familia_62_BP ObtenerFamiliaSeleccionada_62_BP()
        {
            if (treeViewDisponibles.SelectedNode == null)
                return null;

            return treeViewDisponibles.SelectedNode.Tag as Familia_62_BP;
        }
        private bool EsFamiliaRaizSeleccionada_62_BP()
        {
            TreeNode nodo = treeViewDisponibles.SelectedNode;
            return nodo?.Tag is Familia_62_BP &&
                nodo.Parent?.Tag is string tagPadre &&
                tagPadre == "FAMILIAS";
        }
        private void RecargarDatos_62_BP()
        {
            _listaTodasFamilias_62_BP = _familiaBLL_62_BP.BuscarFamilias_62_BP();

            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();

            ActualizarGrillas();
        }
        private void ActualizarGrillas()
        {
            List<int> patentesCubiertas = ObtenerPatentesCubiertas();

            _permisosDisponibles.Clear();
            _patentesSeleccionadas.Clear();

            ActualizarTreeViewDisponibles_62_BP();
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


        private bool SonIguales_62_BP( ComponentePermiso_62_BP a, ComponentePermiso_62_BP b)
        {
            return a.GetType() == b.GetType()
                && a.Id_62_BP == b.Id_62_BP;
        }
        private bool crearFamilia_62_BP()
        {
            try
            {
                Familia_62_BP familia = ValidarFamilia_62_BP();
                if (familia == null)
                {
                    return false;
                }
                int filas = _familiaBLL_62_BP.Alta_62_BP(familia);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_familia_creada", "Familia creada con exito.");

                    return true;
                }

                MostrarMensaje_62_BP("msg_familia_crear_error", "No se pudo crear la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_crear_error_detalle", "Error al intentar crear: {0}", TraducirExcepcion_62_BP(ex)));
            }

            return false;
        }
        private bool modificarFamilia_62_BP()
        {
            try
            {
                if (familiaEnEdicion_62_BP == null)
                {
                    MostrarMensaje_62_BP("msg_familia_debe_seleccionar", "Debe seleccionar una familia.");

                    return false;
                }
                Familia_62_BP familia = ValidarFamilia_62_BP();

                if (familia == null)
                {
                    return false;
                }
                familia.Id_62_BP = familiaEnEdicion_62_BP.Id_62_BP;

                int filas =_familiaBLL_62_BP.Modificar_62_BP(familia);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_familia_modificada", "Familia modificada con exito.");

                    return true;
                }

                MostrarMensaje_62_BP("msg_familia_modificar_error", "No se pudo modificar la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_modificar_error_detalle", "Error al intentar modificar: {0}", TraducirExcepcion_62_BP(ex)));
            }

            return false;
        }
        private bool borrarFamilia_62_BP()
        {
            try
            {
                if (familiaEnEdicion_62_BP == null)
                {
                    MostrarMensaje_62_BP("msg_familia_debe_seleccionar", "Debe seleccionar una familia.");

                    return false;
                }

                int filas = _familiaBLL_62_BP.Baja_62_BP( familiaEnEdicion_62_BP);

                if (filas > 0)
                {
                    MostrarMensaje_62_BP("msg_familia_eliminada", "Familia eliminada con exito.");

                    return true;
                }

                MostrarMensaje_62_BP("msg_familia_eliminar_error", "No se pudo eliminar la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_eliminar_error_detalle", "Error al intentar eliminar: {0}", TraducirExcepcion_62_BP(ex)));
            }

            return false;
        }
        private Familia_62_BP ValidarFamilia_62_BP()
        {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MostrarMensaje_62_BP("msg_familia_nombre_obligatorio", "La familia debe tener un nombre.");
                return null;
            }

            if (_permisosSeleccionados == null || _permisosSeleccionados.Count == 0)
            {
                MostrarMensaje_62_BP("msg_familia_permiso_obligatorio", "La familia debe contener al menos un permiso (Familia o Patente).");
                return null;
            }

            Familia_62_BP familia = new Familia_62_BP();
            familia.Nombre_62_BP = textBoxNombre.Text;
            foreach (var permiso in _permisosSeleccionados)
            {
                familia.Agregar_62_BP(permiso);
            }
            return familia;
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

            TreeNode nodoFamilias = new TreeNode(Texto_62_BP("tree_familias", "Familias"));
            nodoFamilias.Tag = "FAMILIAS";

            TreeNode nodoPatentes = new TreeNode(Texto_62_BP("tree_patentes", "Patentes"));
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

        private void treeViewDisponibles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (modoActual_62_BP != 0)
                return;

            if (e.Node?.Tag is Familia_62_BP familia && EsFamiliaRaizSeleccionada_62_BP())
            {
                familiaEnEdicion_62_BP = familia;
            }
            else
            {
                familiaEnEdicion_62_BP = null;
            }

            bool hayFamilia = EsFamiliaRaizSeleccionada_62_BP();

            buttonModificar.Enabled =
                SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(10) &&
                hayFamilia;

            buttonBaja.Enabled =
                SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(9) &&
                hayFamilia;
        }
    }
}
