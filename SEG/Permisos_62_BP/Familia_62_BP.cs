using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG.Permisos;

namespace SEG.Permisos_62_BP
{
    public class Familia_62_BP : ComponentePermiso_62_BP
    {
        public List<ComponentePermiso_62_BP> Hijos_62_BP { get; }

        public Familia_62_BP()
        {
            Hijos_62_BP = new List<ComponentePermiso_62_BP>();
        }

        public override void Agregar_62_BP(ComponentePermiso_62_BP componente)
        {
            if (RevisarSiTienePermiso(componente))
            {
                throw new Exception("No se pudo agregar el Permiso porque ya se tiene");
            }
                Hijos_62_BP.Add(componente);
        }

        public override void Quitar_62_BP(ComponentePermiso_62_BP componente)
        {
            Hijos_62_BP.Remove(componente);
        }

        public override ComponentePermiso_62_BP ObtenerHijo_62_BP(int indice)
        {
            return Hijos_62_BP[indice];
        }
        public override bool RevisarSiTienePermiso(ComponentePermiso_62_BP permiso)
        {
            foreach (var hijo in Hijos_62_BP)
            {
                if (hijo.RevisarSiTienePermiso(permiso))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
