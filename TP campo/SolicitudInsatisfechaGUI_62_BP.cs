using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;
using TP_campo_62_BP;

namespace TP_campo
{
    public partial class SolicitudInsatisfechaGUI_62_BP : LocalizableForm_62_BP
    {
        private readonly SolicitudInsatisfechaBLL_62_BP _solicitudInsatisfechaBLL_62_BP =
            new SolicitudInsatisfechaBLL_62_BP();
        private readonly LibroBLL_62_BP _libroBLL_62_BP = new LibroBLL_62_BP();

        public SolicitudInsatisfechaGUI_62_BP()
        {
            InitializeComponent();
            buttonBuscarSolicitudes.Click += buttonBuscarSolicitudes_Click;
            buttonAceptarSolicitud.Click += buttonAceptarSolicitud_Click;
            dataGridViewSolicitudes.SelectionChanged += dataGridViewSolicitudes_SelectionChanged;
        }

        private void buttonBuscarSolicitudes_Click(object sender, EventArgs e)
        {
            int? idSolicitud = ObtenerIdOpcional_62_BP(
                textBoxNumeroSolicitud.Text,
                Texto_62_BP("campo_solicitud", "solicitud"));
            if (textBoxNumeroSolicitud.Text.Trim().Length > 0 && !idSolicitud.HasValue)
            {
                return;
            }

            int? idLibro = ObtenerIdOpcional_62_BP(
                textBoxNumeroLibro.Text,
                Texto_62_BP("campo_libro", "libro"));
            if (textBoxNumeroLibro.Text.Trim().Length > 0 && !idLibro.HasValue)
            {
                return;
            }

            try
            {
                List<SolicitudInsatisfechaBE_62_BP> solicitudes =
                    _solicitudInsatisfechaBLL_62_BP.BuscarSolicitudesInsatisfechas_62_BP(
                        idSolicitud,
                        idLibro,
                        textBoxDNI.Text.Trim());

                LlenarSolicitudes_62_BP(solicitudes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_solicitud_busqueda_error",
                    "No se pudieron buscar las solicitudes: {0}",
                    ex.Message));
            }
        }

        private void LlenarSolicitudes_62_BP(List<SolicitudInsatisfechaBE_62_BP> solicitudes)
        {
            dataGridViewSolicitudes.Rows.Clear();

            foreach (SolicitudInsatisfechaBE_62_BP solicitud in solicitudes)
            {
                LibroBE_62_BP libro = _libroBLL_62_BP.BuscarLibro_62_BP(id: solicitud.id_libro_62_BP);
                int indice = dataGridViewSolicitudes.Rows.Add();
                DataGridViewRow fila = dataGridViewSolicitudes.Rows[indice];
                fila.Tag = solicitud;
                fila.Cells["colIdSolicitud"].Value = solicitud.id_solicitud_62_BP;
                fila.Cells["colIdLibro"].Value = solicitud.id_libro_62_BP;
                fila.Cells["colTituloLibro"].Value = libro == null ? string.Empty : libro.titulo_62_BP;
                fila.Cells["colAutorLibro"].Value = libro == null ? string.Empty : libro.autor_62_BP;
                fila.Cells["colDniSolicitante"].Value = solicitud.dni_lector_62_BP;
                fila.Cells["colFechaSolicitud"].Value = solicitud.fecha_62_BP.ToString("dd/MM/yyyy HH:mm");
                fila.Cells["colAceptada"].Value = solicitud.aceptada_62_BP
                    ? Texto_62_BP("estado_si", "Sí")
                    : Texto_62_BP("estado_no", "No");
            }

            dataGridViewSolicitudes.ClearSelection();
            ActualizarBotones_62_BP();
        }

        private void dataGridViewSolicitudes_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotones_62_BP();
        }

        private void ActualizarBotones_62_BP()
        {
            buttonAceptarSolicitud.Enabled = false;

            if (dataGridViewSolicitudes.SelectedRows.Count != 1)
            {
                return;
            }

            SolicitudInsatisfechaBE_62_BP solicitud =
                dataGridViewSolicitudes.SelectedRows[0].Tag as SolicitudInsatisfechaBE_62_BP;

            buttonAceptarSolicitud.Enabled = solicitud != null && !solicitud.aceptada_62_BP;
        }

        private void buttonAceptarSolicitud_Click(object sender, EventArgs e)
        {
            AceptarSolicitud_62_BP();
        }

        private void AceptarSolicitud_62_BP()
        {
            if (dataGridViewSolicitudes.SelectedRows.Count != 1)
            {
                return;
            }

            DataGridViewRow fila = dataGridViewSolicitudes.SelectedRows[0];
            SolicitudInsatisfechaBE_62_BP solicitud = fila.Tag as SolicitudInsatisfechaBE_62_BP;
            if (solicitud == null)
            {
                return;
            }

            solicitud.aceptada_62_BP = true;

            try
            {
                if (_solicitudInsatisfechaBLL_62_BP.ModificarSolicitudInsatisfecha_62_BP(solicitud) <= 0)
                {
                    throw new Exception(Texto_62_BP(
                        "msg_solicitud_actualizacion_error",
                        "No se pudo actualizar la solicitud."));
                }

                fila.Cells["colAceptada"].Value = Texto_62_BP("estado_si", "Sí");
                ActualizarBotones_62_BP();

                MostrarMensaje_62_BP(
                    "msg_solicitud_aceptada",
                    "Solicitud aceptada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_solicitud_estado_error",
                    "No se pudo actualizar el estado de la solicitud: {0}",
                    ex.Message));
            }
        }

        private int? ObtenerIdOpcional_62_BP(string texto, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return null;
            }

            int id;
            if (!int.TryParse(texto.Trim(), out id) || id <= 0)
            {
                MessageBox.Show(TextoFormato_62_BP(
                    "msg_numero_entero_positivo",
                    "El número de {0} debe ser un número entero positivo.",
                    nombreCampo));
                return null;
            }

            return id;
        }
    }
}
