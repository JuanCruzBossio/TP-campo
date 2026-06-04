using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG.Permisos
{
    public abstract class ComponentePermiso_62_BP
    {
        public int Id_62_BP { get; set; }

        public string Nombre_62_BP { get; set; }

        public virtual void Agregar_62_BP(ComponentePermiso_62_BP componente)
        {
            throw new NotSupportedException(
                "Este componente no admite elementos hijos.");
        }

        public virtual void Quitar_62_BP(ComponentePermiso_62_BP componente)
        {
            throw new NotSupportedException(
                "Este componente no admite elementos hijos.");
        }

        public virtual ComponentePermiso_62_BP ObtenerHijo_62_BP(int indice)
        {
            throw new NotSupportedException(
                "Este componente no posee elementos hijos.");
        }
    }
}
