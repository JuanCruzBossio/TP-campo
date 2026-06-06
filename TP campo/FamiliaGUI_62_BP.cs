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

namespace TP_campo
{
    public partial class FamiliaGUI_62_BP : Form
    {
        public FamiliaGUI_62_BP()
        {
            InitializeComponent();
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
            dataGridViewFamiliasYPatentes.ReadOnly = true;
            dataGridViewFamiliaNueva.ReadOnly = true;
            dataGridViewPatentesSeleccionadaas.ReadOnly = true;
            dataGridViewFamiliasYPatentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFamiliasYPatentes.MultiSelect = false;
            dataGridViewPatentesSeleccionadaas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPatentesSeleccionadaas.MultiSelect = false;
            _listaTodasFamilias_62_BP =  _familiaBLL_62_BP.BuscarFamilias_62_BP();

            _listaTodasPatentes_62_BP = _patenteBLL_62_BP.BuscarPatentes_62_BP();

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
            Familia_62_BP familiaSeleccionada =
                ObtenerFamiliaSeleccionada_62_BP();

            if (familiaSeleccionada == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una familia.");
                return;
            }

            familiaEnEdicion_62_BP = familiaSeleccionada;

            textBoxNombre.Text = familiaSeleccionada.Nombre_62_BP;

            _permisosSeleccionados = new List<ComponentePermiso_62_BP>(familiaSeleccionada.Hijos_62_BP);
            dataGridViewFamiliasYPatentes.ClearSelection();
            dataGridViewFamiliasYPatentes.CurrentCell = null;
            ActualizarGrillas();

            CambiarModo_62_BP(2);
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {
            Familia_62_BP familiaSeleccionada =
                ObtenerFamiliaSeleccionada_62_BP();

            if (familiaSeleccionada == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una familia.");
                return;
            }

            familiaEnEdicion_62_BP = familiaSeleccionada;

            textBoxNombre.Text =
                familiaSeleccionada.Nombre_62_BP;

            _permisosSeleccionados =
                new List<ComponentePermiso_62_BP>(
                    familiaSeleccionada.Hijos_62_BP);
            dataGridViewFamiliasYPatentes.ClearSelection();
            dataGridViewFamiliasYPatentes.CurrentCell = null;
            ActualizarGrillas();

            CambiarModo_62_BP(3);
        }
        private void dataGridViewFamiliasYPatentes_SelectionChanged(object sender, EventArgs e)
        {
            if (modoActual_62_BP != 0)
                return;

            bool hayFamilia =
                ObtenerFamiliaSeleccionada_62_BP() != null;

            buttonModificar.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(10)  && hayFamilia;
            buttonBaja.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(9) && hayFamilia;
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
            switch (modo)
            {
                case 0: // Inicial
                    buttonCrear.Enabled = SessionManager_62_BP.GetInstancia_62_BP().TienePermiso_62_BP(8);
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

                    textBoxNombre.Text = familiaEnEdicion_62_BP.Nombre_62_BP ?? "";
                    textBoxMensaje.Text = "Modo Modificar";

                    break;
                case 3: // Borrar

                    buttonAplicar.Enabled = true;
                    buttonCancelar.Enabled = true;

                    textBoxNombre.Text = familiaEnEdicion_62_BP.Nombre_62_BP ?? "";
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
            foreach (Familia_62_BP familia in _listaTodasFamilias_62_BP)
            {
                bool seleccionada = false;
                if (familiaEnEdicion_62_BP != null && familia.Id_62_BP == familiaEnEdicion_62_BP.Id_62_BP)
                {
                    continue;
                }
                foreach (ComponentePermiso_62_BP permiso in _permisosSeleccionados)
                {
                    if (SonIguales_62_BP( permiso, familia))
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
                Familia_62_BP familia = new Familia_62_BP();

                familia.Nombre_62_BP = textBoxNombre.Text;
                foreach (var permiso in _permisosSeleccionados)
                {
                    familia.Agregar_62_BP(permiso);
                }
                int filas = _familiaBLL_62_BP.Alta_62_BP(familia);

                if (filas > 0)
                {
                    MessageBox.Show(
                        "Familia creada con éxito.");

                    return true;
                }

                MessageBox.Show(
                    "No se pudo crear la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al intentar crear: "
                    + ex.Message);
            }

            return false;
        }
        private bool modificarFamilia_62_BP()
        {
            try
            {
                if (familiaEnEdicion_62_BP == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una familia.");

                    return false;
                }

                familiaEnEdicion_62_BP.Nombre_62_BP = textBoxNombre.Text;
                familiaEnEdicion_62_BP.Hijos_62_BP.Clear();
                foreach (var permiso in _permisosSeleccionados)
                {
                    familiaEnEdicion_62_BP.Agregar_62_BP(permiso);
                }
                int filas =_familiaBLL_62_BP.Modificar_62_BP(familiaEnEdicion_62_BP);

                if (filas > 0)
                {
                    MessageBox.Show(
                        "Familia modificada con éxito.");

                    return true;
                }

                MessageBox.Show(
                    "No se pudo modificar la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al intentar modificar: "
                    + ex.Message);
            }

            return false;
        }
        private bool borrarFamilia_62_BP()
        {
            try
            {
                if (familiaEnEdicion_62_BP == null)
                {
                    MessageBox.Show(
                        "Debe seleccionar una familia.");

                    return false;
                }

                int filas = _familiaBLL_62_BP.Baja_62_BP( familiaEnEdicion_62_BP);

                if (filas > 0)
                {
                    MessageBox.Show(
                        "Familia eliminada con éxito.");

                    return true;
                }

                MessageBox.Show(
                    "No se pudo eliminar la familia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al intentar eliminar: "
                    + ex.Message);
            }

            return false;
        }
    }
}
