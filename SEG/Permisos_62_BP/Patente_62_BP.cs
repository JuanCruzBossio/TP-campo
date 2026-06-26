using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG.Permisos;

namespace SEG.Permisos_62_BP
{
    public class Patente_62_BP : ComponentePermiso_62_BP
    {
        public override bool RevisarSiTienePermiso(ComponentePermiso_62_BP permiso)
        {
            if( permiso is Patente_62_BP && permiso.Id_62_BP == this.Id_62_BP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
