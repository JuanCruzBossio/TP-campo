using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEG.Permisos;

namespace SEG.Permisos_62_BP
{
    public class Rol_62_BP
    {
        public int Id_62_BP { get; set; }

        public string Nombre_62_BP { get; set; }

        public List<ComponentePermiso_62_BP> Permisos_62_BP { get; set; }

        public Rol_62_BP()
        {
            Permisos_62_BP = new List<ComponentePermiso_62_BP>();
        }

        public void AgregarPermiso_62_BP(ComponentePermiso_62_BP permiso)
        {
            Permisos_62_BP.Add(permiso);
        }

        public void QuitarPermiso_62_BP(ComponentePermiso_62_BP permiso)
        {
            Permisos_62_BP.Remove(permiso);
        }
    }
}
