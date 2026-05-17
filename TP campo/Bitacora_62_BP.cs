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

namespace TP_campo_62_BP
{
    public partial class Bitacora_62_BP: Form
    {

        BitacoraBLL_62_BP bitacoraBLL_62_BP = new BitacoraBLL_62_BP();
        List<RegistroBitacora_62_BP> todos_62_BP = new List<RegistroBitacora_62_BP>();
        UsuarioBLL_62_BP usuarioBLL_62_BP = new UsuarioBLL_62_BP(); 

        public Bitacora_62_BP()
        {
            InitializeComponent();
        }

        private void Bitacora_62_BP_Load(object sender, EventArgs e)
        {
            todos_62_BP = bitacoraBLL_62_BP.ObtenerBitacora_62_BP();            
            List<RegistroBitacora_62_BP> ultimos3Dias = todos_62_BP
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

        private void dgv_bitacora_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgv_bitacora.CurrentRow != null && dgv_bitacora.CurrentRow.DataBoundItem is RegistroBitacora_62_BP registro)
            {
                Usuario_62_BP usuario = usuarioBLL_62_BP.Buscar_por_DNI_62_BP(registro.DniUsuario_62_BP);
                txt_nombre.Text = usuario.Nombre_62_BP;
                txt_apellido.Text = usuario.Apellido_62_BP;
            }
        }
    }
}
