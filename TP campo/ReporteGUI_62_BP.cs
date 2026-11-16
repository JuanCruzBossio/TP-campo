using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BLL_62_BP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SEG_62_BP.Observer;

namespace TP_campo_62_BP
{
    public partial class ReporteGUI_62_BP : LocalizableForm_62_BP
    {
        public const int REPORTE_RANKING_LECTORES_62_BP = 1;
        public const int REPORTE_RANKING_LIBROS_62_BP = 2;
        public const int REPORTE_MOROSIDAD_62_BP = 3;

        private readonly ReporteBLL_62_BP _reporteBLL_62_BP = new ReporteBLL_62_BP();
        private readonly int _reporteInicial_62_BP;
        private DataTable _reporteActual_62_BP;
        private bool _cargandoReportes_62_BP;

        public ReporteGUI_62_BP()
            : this(REPORTE_RANKING_LECTORES_62_BP)
        {
        }

        public ReporteGUI_62_BP(int reporteInicial)
        {
            InitializeComponent();

            _reporteInicial_62_BP = EsReporteValido_62_BP(reporteInicial)
                ? reporteInicial
                : REPORTE_RANKING_LECTORES_62_BP;
        }

        private void ReporteGUI_62_BP_Load(object sender, EventArgs e)
        {
            dateTimePickerHasta.Value = DateTime.Today;
            dateTimePickerDesde.Value = DateTime.Today.AddMonths(-1);
            CargarOpcionesReporte_62_BP(_reporteInicial_62_BP - 1);
            LimpiarResultados_62_BP();
        }

        private void comboBoxReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargandoReportes_62_BP)
            {
                return;
            }

            LimpiarResultados_62_BP();
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            if (comboBoxReporte.SelectedIndex < 0)
            {
                MostrarMensaje_62_BP(
                    "msg_reporte_seleccion_obligatoria",
                    "Debe seleccionar un reporte.",
                    "titulo_informacion",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                DateTime fechaDesde = dateTimePickerDesde.Value.Date;
                DateTime fechaHasta = dateTimePickerHasta.Value.Date;

                switch (comboBoxReporte.SelectedIndex + 1)
                {
                    case REPORTE_RANKING_LECTORES_62_BP:
                        _reporteActual_62_BP = _reporteBLL_62_BP
                            .ObtenerRankingLectores_62_BP(fechaDesde, fechaHasta);
                        break;

                    case REPORTE_RANKING_LIBROS_62_BP:
                        _reporteActual_62_BP = _reporteBLL_62_BP
                            .ObtenerRankingLibros_62_BP(fechaDesde, fechaHasta);
                        break;

                    case REPORTE_MOROSIDAD_62_BP:
                        _reporteActual_62_BP = _reporteBLL_62_BP
                            .ObtenerInformeMorosidad_62_BP(fechaDesde, fechaHasta);
                        break;
                }

                dataGridViewReportes.DataSource = null;
                dataGridViewReportes.Columns.Clear();
                dataGridViewReportes.DataSource = _reporteActual_62_BP;
                ConfigurarGrilla_62_BP();

                int cantidadResultados = _reporteActual_62_BP != null
                    ? _reporteActual_62_BP.Rows.Count
                    : 0;

                labelResumen.Text = TextoFormato_62_BP(
                    "reporte_cantidad_resultados",
                    "Resultados: {0}",
                    cantidadResultados);

                buttonExportar.Enabled = cantidadResultados > 0;

                if (cantidadResultados == 0)
                {
                    MostrarMensaje_62_BP(
                        "msg_reporte_sin_resultados",
                        "No se encontraron datos para el periodo seleccionado.",
                        "titulo_informacion",
                        "Informacion",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    TextoFormato_62_BP(
                        "msg_reporte_generar_error",
                        "No se pudo generar el reporte: {0}",
                        TraducirExcepcion_62_BP(ex)),
                    Texto_62_BP("titulo_error", "Error"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            dateTimePickerHasta.Value = DateTime.Today;
            dateTimePickerDesde.Value = DateTime.Today.AddMonths(-1);
            LimpiarResultados_62_BP();
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            if (_reporteActual_62_BP == null || _reporteActual_62_BP.Rows.Count == 0)
            {
                MostrarMensaje_62_BP(
                    "msg_exportar_sin_datos",
                    "No hay datos para exportar.",
                    "titulo_informacion",
                    "Informacion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Filter = Texto_62_BP("dialog_filtro_pdf", "Archivo PDF (*.pdf)|*.pdf");
                dialogo.Title = Texto_62_BP("dialog_guardar_pdf", "Guardar reporte PDF");
                dialogo.DefaultExt = "pdf";
                dialogo.AddExtension = true;
                dialogo.FileName = string.Format(
                    "{0}_{1:yyyyMMdd}_{2:yyyyMMdd}.pdf",
                    ObtenerNombreArchivoReporte_62_BP(),
                    dateTimePickerDesde.Value.Date,
                    dateTimePickerHasta.Value.Date);

                if (dialogo.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    ExportarPDF_62_BP(dialogo.FileName);

                    MessageBox.Show(
                        TextoFormato_62_BP(
                            "msg_exportar_pdf_generado",
                            "Archivo PDF generado en:\n{0}",
                            dialogo.FileName),
                        Texto_62_BP("titulo_exportacion_exitosa", "Exportacion exitosa"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        TextoFormato_62_BP(
                            "msg_reporte_exportar_error",
                            "No se pudo exportar el reporte: {0}",
                            TraducirExcepcion_62_BP(ex)),
                        Texto_62_BP("titulo_error", "Error"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarPDF_62_BP(string rutaArchivo)
        {
            Document documento = new Document(PageSize.A3.Rotate(), 20, 20, 25, 25);

            try
            {
                PdfWriter.GetInstance(documento, new FileStream(rutaArchivo, FileMode.Create));
                documento.Open();

                iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                iTextSharp.text.Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 7);
                iTextSharp.text.Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);

                documento.Add(new Paragraph(ObtenerNombreReporte_62_BP(), fuenteTitulo));
                documento.Add(new Paragraph(string.Format(
                    "{0:dd/MM/yyyy} - {1:dd/MM/yyyy}",
                    dateTimePickerDesde.Value.Date,
                    dateTimePickerHasta.Value.Date)));
                documento.Add(new Paragraph(" "));

                PdfPTable tabla = new PdfPTable(_reporteActual_62_BP.Columns.Count);
                tabla.WidthPercentage = 100;

                foreach (DataColumn columna in _reporteActual_62_BP.Columns)
                {
                    PdfPCell celdaEncabezado = new PdfPCell(new Phrase(columna.ColumnName, fuenteEncabezado));
                    celdaEncabezado.BackgroundColor = BaseColor.LIGHT_GRAY;
                    tabla.AddCell(celdaEncabezado);
                }

                foreach (DataRow fila in _reporteActual_62_BP.Rows)
                {
                    foreach (DataColumn columna in _reporteActual_62_BP.Columns)
                    {
                        string valor = fila[columna] == DBNull.Value
                            ? string.Empty
                            : fila[columna].ToString();

                        tabla.AddCell(new PdfPCell(new Phrase(valor, fuenteCelda)));
                    }
                }

                documento.Add(tabla);
            }
            finally
            {
                documento.Close();
            }
        }

        private void ConfigurarGrilla_62_BP()
        {
            dataGridViewReportes.ReadOnly = true;
            dataGridViewReportes.AllowUserToAddRows = false;
            dataGridViewReportes.AllowUserToDeleteRows = false;
            dataGridViewReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void LimpiarResultados_62_BP()
        {
            _reporteActual_62_BP = null;
            dataGridViewReportes.DataSource = null;
            dataGridViewReportes.Columns.Clear();
            labelResumen.Text = TextoFormato_62_BP("reporte_cantidad_resultados", "Resultados: {0}", 0);
            buttonExportar.Enabled = false;
        }

        private void CargarOpcionesReporte_62_BP(int indiceSeleccionado)
        {
            _cargandoReportes_62_BP = true;

            try
            {
                comboBoxReporte.Items.Clear();
                comboBoxReporte.Items.Add(Texto_62_BP("reporte_ranking_lectores", "Ranking de lectores"));
                comboBoxReporte.Items.Add(Texto_62_BP("reporte_ranking_libros", "Ranking de libros"));
                comboBoxReporte.Items.Add(Texto_62_BP("reporte_morosidad", "Morosidad y cumplimiento"));
                comboBoxReporte.SelectedIndex = indiceSeleccionado >= 0 && indiceSeleccionado < 3
                    ? indiceSeleccionado
                    : 0;
            }
            finally
            {
                _cargandoReportes_62_BP = false;
            }
        }

        private string ObtenerNombreReporte_62_BP()
        {
            switch (comboBoxReporte.SelectedIndex + 1)
            {
                case REPORTE_RANKING_LIBROS_62_BP:
                    return Texto_62_BP("reporte_ranking_libros", "Ranking de libros");
                case REPORTE_MOROSIDAD_62_BP:
                    return Texto_62_BP("reporte_morosidad", "Morosidad y cumplimiento");
                default:
                    return Texto_62_BP("reporte_ranking_lectores", "Ranking de lectores");
            }
        }

        private string ObtenerNombreArchivoReporte_62_BP()
        {
            switch (comboBoxReporte.SelectedIndex + 1)
            {
                case REPORTE_RANKING_LIBROS_62_BP:
                    return "RankingLibros";
                case REPORTE_MOROSIDAD_62_BP:
                    return "Morosidad";
                default:
                    return "RankingLectores";
            }
        }

        private bool EsReporteValido_62_BP(int reporte)
        {
            return reporte >= REPORTE_RANKING_LECTORES_62_BP
                && reporte <= REPORTE_MOROSIDAD_62_BP;
        }

        protected override void TraducirFormulario_62_BP(Idioma_62_BP idioma_62_BP)
        {
            int indiceSeleccionado = comboBoxReporte != null && comboBoxReporte.SelectedIndex >= 0
                ? comboBoxReporte.SelectedIndex
                : _reporteInicial_62_BP - 1;

            base.TraducirFormulario_62_BP(idioma_62_BP);

            if (comboBoxReporte != null)
            {
                CargarOpcionesReporte_62_BP(indiceSeleccionado);
            }
        }
    }
}
