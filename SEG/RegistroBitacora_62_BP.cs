using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEG_62_BP
{
    public class RegistroBitacora_62_BP
    {
        private int id_62_BP;

        public int Id_62_BP
        {
            get { return id_62_BP; }
            set { id_62_BP = value; }
        }

        private DateTime fecha_62_BP;

        public DateTime Fecha_62_BP
        {
            get { return fecha_62_BP; }
            set { fecha_62_BP = value; }
        }

        private string dniUsuario_62_BP;

        public string DniUsuario_62_BP
        {
            get { return dniUsuario_62_BP; }
            set { dniUsuario_62_BP = value; }
        }

        private string mensaje_62_BP;

        public string Mensaje_62_BP
        {
            get { return mensaje_62_BP; }
            set { mensaje_62_BP = value; }
        }

        private int criticidad_62_BP;

        public int Criticidad_62_BP
        {
            get { return criticidad_62_BP; }
            set { criticidad_62_BP = value; }
        }
    }
}
