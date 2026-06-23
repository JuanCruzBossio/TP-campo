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
using TP_campo_62_BP;

namespace TP_campo
{

    public partial class CambiarIdiomaGUI_62_BP : LocalizableForm_62_BP
    {

        private Idioma_62_BP _idiomaBLL_62_BP = new Idioma_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();

        public CambiarIdiomaGUI_62_BP()
        {
            InitializeComponent();

            Load += CambiarIdiomaGUI_62_BP_Load;
            btn_cambiar_idioma.Click += btn_cambiar_idioma_Click;
        }

        private void CambiarIdiomaGUI_62_BP_Load(object sender, EventArgs e)
        {
            try
            {
                txt_idioma_actual.ReadOnly = true;

                SEG_62_BP.Observer.Idioma_62_BP idiomaActual_62_BP =
                    SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP;

                txt_idioma_actual.Text = idiomaActual_62_BP != null
                    ? idiomaActual_62_BP.Nombre_62_BP
                    : string.Empty;

                cmb_idioma.DataSource = _idiomaBLL_62_BP.ObtenerIdiomasDisponibles_62_BP();
                cmb_idioma.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_idiomas_cargar_error", "No se pudieron cargar los idiomas disponibles: {0}", ex.Message));
            }
        }


        private void btn_cambiar_idioma_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_idioma.SelectedItem == null)
                {
                    MostrarMensaje_62_BP("msg_idioma_obligatorio", "Debe seleccionar un idioma.");
                    return;
                }

                string codigoIdioma_62_BP = cmb_idioma.SelectedItem.ToString();
                SEG_62_BP.Observer.Idioma_62_BP idiomaActual_62_BP =
                    SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP;

                if (idiomaActual_62_BP != null &&
                    string.Equals(idiomaActual_62_BP.Nombre_62_BP, codigoIdioma_62_BP, StringComparison.OrdinalIgnoreCase))
                {
                    MostrarMensaje_62_BP("msg_idioma_ya_actual", "El idioma seleccionado ya es el idioma actual.");
                    return;
                }

                SEG_62_BP.Observer.Idioma_62_BP idioma_62_BP = _idiomaBLL_62_BP.CargarIdioma_62_BP(codigoIdioma_62_BP);

                SessionManager_62_BP.GetInstancia_62_BP().CambiarIdioma_62_BP(idioma_62_BP);


                string idiomaAnterior_62_BP = idiomaActual_62_BP != null
                    ? idiomaActual_62_BP.Nombre_62_BP
                    : "Sin idioma";

                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                    "Cambio de idioma de " + idiomaAnterior_62_BP + " a " + idioma_62_BP.Nombre_62_BP,
                    2);

                txt_idioma_actual.Text = idioma_62_BP.Nombre_62_BP;
                MostrarMensaje_62_BP("msg_idioma_cambiado", "Idioma cambiado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP("msg_idioma_cambiar_error", "No se pudo cambiar el idioma: {0}", ex.Message));
            }
        }

        private void btn_cambiar_idioma_Click_1(object sender, EventArgs e)
        {

        }
    }
}
