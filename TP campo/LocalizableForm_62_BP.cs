using SEG_62_BP;
using SEG_62_BP.Observer;
using System;
using System.Windows.Forms;

namespace TP_campo_62_BP
{

    public class LocalizableForm_62_BP : Form, IObservadorIdioma_62_BP
    {
        protected override void OnLoad(EventArgs e)
        {

            SessionManager_62_BP.GetInstancia_62_BP().SuscribirObservador_62_BP(this);
            ActualizarIdioma_62_BP(SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP);

            base.OnLoad(e);

            ActualizarIdioma_62_BP(SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SessionManager_62_BP.GetInstancia_62_BP().DesuscribirObservador_62_BP(this);
            }

            base.Dispose(disposing);
        }

        public void ActualizarIdioma_62_BP(Idioma_62_BP idioma_62_BP)
        {
            if (idioma_62_BP == null || !idioma_62_BP.TieneTraduccionesValidas_62_BP())
            {
                return;
            }

            if (InvokeRequired)
            {
                Invoke(new Action(() => TraducirFormulario_62_BP(idioma_62_BP)));
            }
            else
            {
                TraducirFormulario_62_BP(idioma_62_BP);
            }
        }

        protected virtual void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            AplicarTraduccion_62_BP(this, idioma_62_BP);
            TraducirControlesRecursivo_62_BP(Controls, idioma_62_BP);
        }

        private void TraducirControlesRecursivo_62_BP(Control.ControlCollection controles_62_BP, Idioma_62_BP idioma_62_BP)
        {
            foreach (Control control_62_BP in controles_62_BP)
            {
                AplicarTraduccion_62_BP(control_62_BP, idioma_62_BP);

                if (control_62_BP is MenuStrip menuStrip_62_BP)
                {
                    TraducirMenuItems_62_BP(menuStrip_62_BP.Items, idioma_62_BP);
                }

                if (control_62_BP is DataGridView dataGridView_62_BP)
                {
                    TraducirColumnasDataGridView_62_BP(dataGridView_62_BP, idioma_62_BP);
                }

                if (control_62_BP.HasChildren)
                {
                    TraducirControlesRecursivo_62_BP(control_62_BP.Controls, idioma_62_BP);
                }
            }
        }

        private void TraducirMenuItems_62_BP(ToolStripItemCollection items_62_BP, Idioma_62_BP idioma_62_BP)
        {
            foreach (ToolStripItem item_62_BP in items_62_BP)
            {
                string traduccion_62_BP = idioma_62_BP.ObtenerTraduccion_62_BP(item_62_BP.Name);

                if (!string.IsNullOrEmpty(traduccion_62_BP))
                {
                    item_62_BP.Text = traduccion_62_BP;
                }

                if (item_62_BP is ToolStripMenuItem menuItem_62_BP && menuItem_62_BP.DropDownItems.Count > 0)
                {
                    TraducirMenuItems_62_BP(menuItem_62_BP.DropDownItems, idioma_62_BP);
                }
            }
        }

        private void TraducirColumnasDataGridView_62_BP(DataGridView dataGridView_62_BP, Idioma_62_BP idioma_62_BP)
        {
            foreach (DataGridViewColumn columna_62_BP in dataGridView_62_BP.Columns)
            {
                string claveEspecifica_62_BP = dataGridView_62_BP.Name + "." + columna_62_BP.Name;
                string claveGeneral_62_BP = columna_62_BP.Name;

                string traduccion_62_BP = idioma_62_BP.ObtenerTraduccion_62_BP(claveEspecifica_62_BP);

                if (string.IsNullOrEmpty(traduccion_62_BP))
                {
                    traduccion_62_BP = idioma_62_BP.ObtenerTraduccion_62_BP(claveGeneral_62_BP);
                }

                if (!string.IsNullOrEmpty(traduccion_62_BP))
                {
                    columna_62_BP.HeaderText = traduccion_62_BP;
                }
            }
        }

        private void AplicarTraduccion_62_BP(Control control_62_BP, Idioma_62_BP idioma_62_BP)
        {
            string claveEspecifica_62_BP = Name + "." + control_62_BP.Name;

            if (idioma_62_BP.Traducciones_62_BP != null &&
                idioma_62_BP.Traducciones_62_BP.ContainsKey(claveEspecifica_62_BP))
            {
                string traduccionEspecifica_62_BP = idioma_62_BP.Traducciones_62_BP[claveEspecifica_62_BP];

                if (!string.IsNullOrEmpty(traduccionEspecifica_62_BP))
                {
                    control_62_BP.Text = traduccionEspecifica_62_BP;
                }

                return;
            }

            string traduccionGeneral_62_BP = idioma_62_BP.ObtenerTraduccion_62_BP(control_62_BP.Name);

            if (!string.IsNullOrEmpty(traduccionGeneral_62_BP))
            {
                control_62_BP.Text = traduccionGeneral_62_BP;
            }
        }

        protected string Texto_62_BP(string clave_62_BP, string textoPorDefecto_62_BP)
        {
            Idioma_62_BP idioma_62_BP = SessionManager_62_BP.GetInstancia_62_BP().IdiomaActual_62_BP;

            if (idioma_62_BP == null)
            {
                return textoPorDefecto_62_BP;
            }

            string traduccion_62_BP = idioma_62_BP.ObtenerTraduccion_62_BP(clave_62_BP);

            return string.IsNullOrEmpty(traduccion_62_BP)
                ? textoPorDefecto_62_BP
                : traduccion_62_BP;
        }

        protected string TextoFormato_62_BP(string clave_62_BP, string textoPorDefecto_62_BP, params object[] valores_62_BP)
        {
            return string.Format(Texto_62_BP(clave_62_BP, textoPorDefecto_62_BP), valores_62_BP);
        }

        protected void MostrarMensaje_62_BP(string clave_62_BP, string textoPorDefecto_62_BP)
        {
            MessageBox.Show(Texto_62_BP(clave_62_BP, textoPorDefecto_62_BP));
        }

        protected DialogResult MostrarMensaje_62_BP(
            string clave_62_BP,
            string textoPorDefecto_62_BP,
            string claveTitulo_62_BP,
            string tituloPorDefecto_62_BP,
            MessageBoxButtons botones_62_BP,
            MessageBoxIcon icono_62_BP)
        {
            return MessageBox.Show(
                Texto_62_BP(clave_62_BP, textoPorDefecto_62_BP),
                Texto_62_BP(claveTitulo_62_BP, tituloPorDefecto_62_BP),
                botones_62_BP,
                icono_62_BP);
        }
    }
}
