using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_62_BP;
using BLL_62_BP;

namespace TP_campo
{
    public partial class ManejoPrestamosGUI_62_BP : Form
    {
        private readonly PrestamoBLL_62_BP _prestamoBLL_62_BP = new PrestamoBLL_62_BP();

        public ManejoPrestamosGUI_62_BP()
        {
            InitializeComponent();
            buttonBuscarPrestamos.Click += buttonBuscarPrestamos_Click;
            ConfigurarDataGridViewPrestamos();
        }

        private void ConfigurarDataGridViewPrestamos()
        {
            dataGridViewPrestamosFiltrados.AutoGenerateColumns = false;
            dataGridViewPrestamosFiltrados.AllowUserToAddRows = false;
            dataGridViewPrestamosFiltrados.ReadOnly = true;
            dataGridViewPrestamosFiltrados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridViewPrestamosFiltrados.Columns.Add("colIdPrestamo", "Num. Préstamo");
            dataGridViewPrestamosFiltrados.Columns.Add("colDni", "DNI Lector");
            dataGridViewPrestamosFiltrados.Columns.Add("colFechaPrestamo", "Fecha Préstamo");
            dataGridViewPrestamosFiltrados.Columns.Add("colFechaLimite", "Fecha Límite");
            dataGridViewPrestamosFiltrados.Columns.Add("colFinalizado", "Finalizado");
        }

        private void buttonBuscarPrestamos_Click(object sender, EventArgs e)
        {
            int? idPrestamo = null;
            string textoId = textBoxNumeroPrestamo.Text.Trim();

            if (!string.IsNullOrWhiteSpace(textoId))
            {
                int id;
                if (!int.TryParse(textoId, out id) || id <= 0)
                {
                    MessageBox.Show("El número de préstamo debe ser un número entero positivo.");
                    return;
                }

                idPrestamo = id;
            }

            try
            {
                List<PrestamoBE_62_BP> prestamos = _prestamoBLL_62_BP.BuscarPrestamos_62_BP(
                    idPrestamo,
                    textBoxDNI.Text.Trim());

                LlenarDataGridViewPrestamos(prestamos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron buscar los préstamos: " + ex.Message);
            }
        }

        private void LlenarDataGridViewPrestamos(List<PrestamoBE_62_BP> prestamos)
        {
            dataGridViewPrestamosFiltrados.Rows.Clear();

            if (prestamos == null)
            {
                return;
            }

            foreach (PrestamoBE_62_BP prestamo in prestamos)
            {
                int indice = dataGridViewPrestamosFiltrados.Rows.Add();
                DataGridViewRow fila = dataGridViewPrestamosFiltrados.Rows[indice];
                fila.Cells["colIdPrestamo"].Value = prestamo.id_prestamo_62_BP;
                fila.Cells["colDni"].Value = prestamo.dni_lector_62_BP;
                fila.Cells["colFechaPrestamo"].Value = prestamo.fecha_prestamo_62_BP.ToString("dd/MM/yyyy HH:mm");
                fila.Cells["colFechaLimite"].Value = prestamo.fecha_limite_62_BP.ToString("dd/MM/yyyy HH:mm");
                fila.Cells["colFinalizado"].Value = prestamo.finalizado_62_BP ? "Sí" : "No";
            }
        }
    }
}
