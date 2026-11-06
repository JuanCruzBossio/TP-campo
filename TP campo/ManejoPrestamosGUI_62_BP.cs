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
        private readonly DetallePrestamoBLL_62_BP _detallePrestamoBLL_62_BP = new DetallePrestamoBLL_62_BP();
        private readonly LibroBLL_62_BP _libroBLL_62_BP = new LibroBLL_62_BP();
        private bool _prestamoSeleccionadoFinalizado_62_BP;

        public ManejoPrestamosGUI_62_BP()
        {
            InitializeComponent();
            buttonBuscarPrestamos.Click += buttonBuscarPrestamos_Click;
            buttonSeleccionarPrestamo.Click += buttonSeleccionarPrestamo_Click;
            buttonDevolverPrestamo.Click += buttonDevolverPrestamo_Click;
            dataGridViewPrestamosFiltrados.SelectionChanged += dataGridViewPrestamosFiltrados_SelectionChanged;
            dataGridViewDetallePrestamo.CellValueChanged += dataGridViewDetallePrestamo_CellValueChanged;
            dataGridViewDetallePrestamo.CurrentCellDirtyStateChanged += dataGridViewDetallePrestamo_CurrentCellDirtyStateChanged;
            ConfigurarDataGridViewPrestamos();
            ActualizarBotonSeleccionarPrestamo();
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

            dataGridViewDetallePrestamo.AutoGenerateColumns = false;
            dataGridViewDetallePrestamo.AllowUserToAddRows = false;
            dataGridViewDetallePrestamo.ReadOnly = false;
            dataGridViewDetallePrestamo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetallePrestamo.Columns.Add("colDetalleIdLibro", "ID Libro");
            dataGridViewDetallePrestamo.Columns.Add("colDetalleIdPrestamo", "ID Préstamo");
            DataGridViewCheckBoxColumn columnaDevuelto = new DataGridViewCheckBoxColumn
            {
                Name = "colDetalleDevuelto",
                HeaderText = "Devuelto",
                TrueValue = true,
                FalseValue = false
            };
            DataGridViewCheckBoxColumn columnaPerdido = new DataGridViewCheckBoxColumn
            {
                Name = "colDetallePerdido",
                HeaderText = "Perdido",
                TrueValue = true,
                FalseValue = false
            };
            dataGridViewDetallePrestamo.Columns.Add(columnaDevuelto);
            dataGridViewDetallePrestamo.Columns.Add(columnaPerdido);
            dataGridViewDetallePrestamo.Columns["colDetalleIdLibro"].ReadOnly = true;
            dataGridViewDetallePrestamo.Columns["colDetalleIdPrestamo"].ReadOnly = true;
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
                    buttonSeleccionarPrestamo.Enabled = false;
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
                buttonSeleccionarPrestamo.Enabled = false;
                MessageBox.Show("No se pudieron buscar los préstamos: " + ex.Message);
            }
        }

        private void LlenarDataGridViewPrestamos(List<PrestamoBE_62_BP> prestamos)
        {
            dataGridViewPrestamosFiltrados.Rows.Clear();
            dataGridViewDetallePrestamo.Rows.Clear();
            buttonDevolverPrestamo.Enabled = false;
            dataGridViewPrestamosFiltrados.ClearSelection();
            buttonSeleccionarPrestamo.Enabled = false;

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

            dataGridViewPrestamosFiltrados.ClearSelection();
            ActualizarBotonSeleccionarPrestamo();
        }

        private void dataGridViewPrestamosFiltrados_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonSeleccionarPrestamo();
        }

        private void ActualizarBotonSeleccionarPrestamo()
        {
            buttonSeleccionarPrestamo.Enabled = dataGridViewPrestamosFiltrados.SelectedRows.Count == 1;
        }

        private void buttonSeleccionarPrestamo_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrestamosFiltrados.SelectedRows.Count != 1)
            {
                return;
            }

            int idPrestamo = Convert.ToInt32(
                dataGridViewPrestamosFiltrados.SelectedRows[0].Cells["colIdPrestamo"].Value);

            _prestamoSeleccionadoFinalizado_62_BP = string.Equals(
                Convert.ToString(dataGridViewPrestamosFiltrados.SelectedRows[0].Cells["colFinalizado"].Value),
                "Sí",
                StringComparison.OrdinalIgnoreCase);
            dataGridViewDetallePrestamo.ReadOnly = _prestamoSeleccionadoFinalizado_62_BP;

            try
            {
                List<DetallePrestamoBE_62_BP> detalles =
                    _detallePrestamoBLL_62_BP.BuscarDetallesPorPrestamo_62_BP(idPrestamo);

                LlenarDataGridViewDetalles(detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron buscar los libros del préstamo: " + ex.Message);
            }
        }

        private void LlenarDataGridViewDetalles(List<DetallePrestamoBE_62_BP> detalles)
        {
            dataGridViewDetallePrestamo.Rows.Clear();

            foreach (DetallePrestamoBE_62_BP detalle in detalles)
            {
                int indice = dataGridViewDetallePrestamo.Rows.Add();
                DataGridViewRow fila = dataGridViewDetallePrestamo.Rows[indice];
                fila.Cells["colDetalleIdLibro"].Value = detalle.id_libro_62_BP;
                fila.Cells["colDetalleIdPrestamo"].Value = detalle.id_prestamo_62_BP;
                fila.Cells["colDetalleDevuelto"].Value = detalle.devuelto_62_BP;
                fila.Cells["colDetallePerdido"].Value = detalle.perdido_62_BP;
            }

            ActualizarBotonDevolverPrestamo();
        }

        private void dataGridViewDetallePrestamo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewDetallePrestamo.IsCurrentCellDirty)
            {
                dataGridViewDetallePrestamo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewDetallePrestamo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string nombreColumna = dataGridViewDetallePrestamo.Columns[e.ColumnIndex].Name;
            if (nombreColumna == "colDetalleDevuelto" && Convert.ToBoolean(dataGridViewDetallePrestamo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
            {
                dataGridViewDetallePrestamo.Rows[e.RowIndex].Cells["colDetallePerdido"].Value = false;
            }
            else if (nombreColumna == "colDetallePerdido" && Convert.ToBoolean(dataGridViewDetallePrestamo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
            {
                dataGridViewDetallePrestamo.Rows[e.RowIndex].Cells["colDetalleDevuelto"].Value = false;
            }

            ActualizarBotonDevolverPrestamo();
        }

        private void ActualizarBotonDevolverPrestamo()
        {
            if (_prestamoSeleccionadoFinalizado_62_BP)
            {
                buttonDevolverPrestamo.Enabled = false;
                return;
            }

            bool todosTienenEstado = dataGridViewDetallePrestamo.Rows.Count > 0;

            foreach (DataGridViewRow fila in dataGridViewDetallePrestamo.Rows)
            {
                bool devuelto = Convert.ToBoolean(fila.Cells["colDetalleDevuelto"].Value ?? false);
                bool perdido = Convert.ToBoolean(fila.Cells["colDetallePerdido"].Value ?? false);

                if (devuelto == perdido)
                {
                    todosTienenEstado = false;
                    break;
                }
            }

            buttonDevolverPrestamo.Enabled = todosTienenEstado;
        }

        private void buttonDevolverPrestamo_Click(object sender, EventArgs e)
        {
            if (!TodosLosDetallesTienenEstado())
            {
                ActualizarBotonDevolverPrestamo();
                return;
            }

            if (dataGridViewPrestamosFiltrados.SelectedRows.Count != 1)
            {
                return;
            }

            int idPrestamo = Convert.ToInt32(
                dataGridViewPrestamosFiltrados.SelectedRows[0].Cells["colIdPrestamo"].Value);

            try
            {
                foreach (DataGridViewRow fila in dataGridViewDetallePrestamo.Rows)
                {
                    bool devuelto = Convert.ToBoolean(fila.Cells["colDetalleDevuelto"].Value ?? false);
                    bool perdido = Convert.ToBoolean(fila.Cells["colDetallePerdido"].Value ?? false);

                    DetallePrestamoBE_62_BP detalle = new DetallePrestamoBE_62_BP
                    {
                        id_libro_62_BP = Convert.ToInt32(fila.Cells["colDetalleIdLibro"].Value),
                        id_prestamo_62_BP = idPrestamo,
                        devuelto_62_BP = devuelto,
                        perdido_62_BP = perdido
                    };

                    if (!_detallePrestamoBLL_62_BP.ModificarDetallePrestamo_62_BP(detalle))
                    {
                        throw new Exception("No se pudo actualizar el detalle del préstamo.");
                    }

                    if (devuelto)
                    {
                        if (_libroBLL_62_BP.MarcarDisponible_62_BP(detalle.id_libro_62_BP) <= 0)
                        {
                            throw new Exception("No se pudo marcar el libro como disponible.");
                        }
                    }
                    // Si el libro fue perdido, no se modifica: permanece prestado.
                }

                if (_prestamoBLL_62_BP.FinalizarPrestamo_62_BP(idPrestamo) <= 0)
                {
                    throw new Exception("No se pudo finalizar el préstamo.");
                }

                MessageBox.Show("Préstamo devuelto correctamente.");
                textBoxDNI.Clear();
                textBoxNumeroPrestamo.Clear();
                dataGridViewPrestamosFiltrados.Rows.Clear();
                buttonDevolverPrestamo.Enabled = false;
                dataGridViewDetallePrestamo.Rows.Clear();
                buttonSeleccionarPrestamo.Enabled = false;
                _prestamoSeleccionadoFinalizado_62_BP = false;
                dataGridViewDetallePrestamo.ReadOnly = false;
                dataGridViewPrestamosFiltrados.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo devolver el préstamo: " + ex.Message);
            }
        }

        private bool TodosLosDetallesTienenEstado()
        {
            if (dataGridViewDetallePrestamo.Rows.Count == 0)
            {
                return false;
            }

            foreach (DataGridViewRow fila in dataGridViewDetallePrestamo.Rows)
            {
                bool devuelto = Convert.ToBoolean(fila.Cells["colDetalleDevuelto"].Value ?? false);
                bool perdido = Convert.ToBoolean(fila.Cells["colDetallePerdido"].Value ?? false);

                if (devuelto == perdido)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
