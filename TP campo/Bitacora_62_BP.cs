using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_campo
{
    public partial class Bitacora_62_BP: Form
    {
        public Bitacora_62_BP()
        {
            InitializeComponent();
        }

        private void Bitacora_62_BP_Load(object sender, EventArgs e)
        {
            var bitacoraBLL = new BLL.BitacoraBLL_62_BP();
            var todos = bitacoraBLL.ObtenerBitacora();

            var ultimos3Dias = todos
                .Where(r => r.Fecha >= DateTime.Now.AddDays(-3))
                .ToList();
            dgv_bitacora.DataSource = ultimos3Dias;
        }
    }
}
