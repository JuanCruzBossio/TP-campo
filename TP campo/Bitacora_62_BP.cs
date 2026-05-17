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
using SEG;

namespace TP_campo
{
    public partial class Bitacora_62_BP: Form
    {

        BitacoraBLL_62_BP bitacoraBLL = new BLL.BitacoraBLL_62_BP();
        List<RegistroBitacora_62_BP> todos = new List<RegistroBitacora_62_BP>();
        UsuarioBLL_62_BP usuarioBLL = new UsuarioBLL_62_BP(); 

        public Bitacora_62_BP()
        {
            InitializeComponent();
        }

        private void Bitacora_62_BP_Load(object sender, EventArgs e)
        {
            todos = bitacoraBLL.ObtenerBitacora();            
            List<RegistroBitacora_62_BP> ultimos3Dias = todos
                .Where(r => r.Fecha >= DateTime.Now.AddDays(-3))
                .ToList();
            dgv_bitacora.DataSource = ultimos3Dias;

            if (ultimos3Dias.Count > 0)
            {
                usuarioBLL.Buscar_por_DNI(ultimos3Dias[0].DniUsuario.ToString());
                Usuario_62_BP usuario = usuarioBLL.Buscar_por_DNI(ultimos3Dias[0].DniUsuario.ToString());
                txt_nombre.Text = usuario.Nombre; 
                txt_apellido.Text = usuario.Apellido;
            }
            else
            {
                txt_nombre.Text = "";
                txt_apellido.Text = "";
            }


        }

        private void dgv_bitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgv_bitacora.CurrentRow != null && dgv_bitacora.CurrentRow.DataBoundItem is RegistroBitacora_62_BP registro)
            {
                Usuario_62_BP usuario = usuarioBLL.Buscar_por_DNI(registro.DniUsuario.ToString());
                txt_nombre.Text = usuario.Nombre;
                txt_apellido.Text = usuario.Apellido;
            }
        }
    }
}
