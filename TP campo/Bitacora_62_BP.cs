using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_62_BP;
using SEG_62_BP;

namespace TP_campo_62_BP
{
    public partial class Bitacora_62_BP : Form
    {

        public Bitacora_62_BP()
        {
            InitializeComponent();
        }
        //Variables
        BitacoraBLL_62_BP bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        List<RegistroBitacora_62_BP> listaRegistrosBitacora_62_BP = new List<RegistroBitacora_62_BP>();
        UsuarioBLL_62_BP usuarioBLL_62_BP = new UsuarioBLL_62_BP();
        
        //Eventos
        private void Bitacora_62_BP_Load(object sender, EventArgs e)
        {
            dtp_fecha_fin.Value = DateTime.Now;
            dtp_fecha_ini.Value = dtp_fecha_fin.Value.AddDays(-3);
            listaRegistrosBitacora_62_BP = bitacoraBLL_62_BP.ObtenerBitacora_62_BP();
            List<RegistroBitacora_62_BP> ultimos3Dias = listaRegistrosBitacora_62_BP
                .Where(r => r.Fecha_62_BP >= dtp_fecha_ini.Value)
                .ToList();
            dgv_bitacora.DataSource = ultimos3Dias;

            if (ultimos3Dias.Count > 0)
            {
                Usuario_62_BP usuario = usuarioBLL_62_BP.Buscar_por_DNI_62_BP(ultimos3Dias[0].DniUsuario_62_BP);
                txt_nombre.Text = usuario.Nombre_62_BP;
                txt_apellido.Text = usuario.Apellido_62_BP;
            }
            else
            {
                txt_nombre.Text = "";
                txt_apellido.Text = "";
            }


            var usuarios = usuarioBLL_62_BP.TraerTodosUsuarios_62_BP();
            cmb_login.Items.Clear();
            foreach (var usuario in usuarios)
            {
                cmb_login.Items.Add(new ComboboxItem
                {
                    Text = $"{usuario.Nombre_62_BP} {usuario.Apellido_62_BP}",
                    Value = usuario.Dni_62_BP
                });
            }
            cmb_login.SelectedIndex = -1;

        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public override string ToString() { return Text; }
        }

        private void dgv_bitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgv_bitacora.CurrentRow != null && dgv_bitacora.CurrentRow.DataBoundItem is RegistroBitacora_62_BP registro)
            {
                Usuario_62_BP usuario = usuarioBLL_62_BP.Buscar_por_DNI_62_BP(registro.DniUsuario_62_BP);
                txt_nombre.Text = usuario.Nombre_62_BP;
                txt_apellido.Text = usuario.Apellido_62_BP;
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            LimpiarDTP();


            listaRegistrosBitacora_62_BP = bitacoraBLL_62_BP.ObtenerBitacora_62_BP();
            List<RegistroBitacora_62_BP> ultimos3Dias = listaRegistrosBitacora_62_BP
                .Where(r => r.Fecha_62_BP >= DateTime.Now.AddDays(-3))
                .ToList();
            dgv_bitacora.DataSource = ultimos3Dias;

            if (ultimos3Dias.Count > 0)
            {
                Usuario_62_BP usuario = usuarioBLL_62_BP.Buscar_por_DNI_62_BP(ultimos3Dias[0].DniUsuario_62_BP);
                txt_nombre.Text = usuario.Nombre_62_BP;
                txt_apellido.Text = usuario.Apellido_62_BP;
            }
            else
            {
                txt_nombre.Text = "";
                txt_apellido.Text = "";
            }
        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            string error;

            string login = cmb_login.SelectedItem is ComboboxItem item ? item.Value : string.Empty;
            // El valor de modulo NO se usa en la consulta todavia
            string evento = cmb_evento.SelectedItem != null ? cmb_evento.SelectedItem.ToString() : string.Empty;
            string criticidad = cmb_criticidad.SelectedItem != null ? cmb_criticidad.SelectedItem.ToString() : string.Empty;
            string fechaIni = dtp_fecha_ini.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtp_fecha_fin.Value.ToString("yyyy-MM-dd");

            var resultados = bitacoraBLL_62_BP.FiltrarBitacora_62_BP(
                fechaIni, fechaFin, login, null, evento, criticidad, out error);

            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv_bitacora.DataSource = null;
                return;
            }

            dgv_bitacora.DataSource = resultados;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            var registros = dgv_bitacora.DataSource as List<RegistroBitacora_62_BP>;
            if (registros == null || registros.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivo XML (*.xml)|*.xml";
            dlg.Title = "Guardar XML";
            dlg.FileName = $"Bitacora_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            string ruta = dlg.FileName;

            bitacoraBLL_62_BP.ExportarBitacoraAPDF(registros, ruta);

            MessageBox.Show($"Archivo PDF generado en:\n{ruta}", "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Funciones
        private void Limpiar()
        {
            txt_apellido.Clear();
            txt_nombre.Clear();
            cmb_criticidad.SelectedIndex = -1;
            cmb_evento.SelectedIndex = -1;
            cmb_modulo.SelectedIndex = -1;
            cmb_login.SelectedIndex = -1;
        }

        private void LimpiarDTP()
        {
            dtp_fecha_ini.Value = DateTime.Now;
            dtp_fecha_fin.Value = DateTime.Now;
        }
    }
}
