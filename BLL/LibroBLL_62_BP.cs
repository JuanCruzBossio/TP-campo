using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class LibroBLL_62_BP
    {
        private LibroMapper_62_BP _libroMapper_62_BP = new LibroMapper_62_BP();

        public int AgregarLibro_62_BP(LibroBE_62_BP libro)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _libroMapper_62_BP.AgregarLibro_62_BP(libro);
            }
            catch
            {
                throw new Exception("No se pudo agregar el libro.");
            }

            return filasAfectadas;
        }

        public int ModificarLibro_62_BP(LibroBE_62_BP libro)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _libroMapper_62_BP.ModificarLibro_62_BP(libro);
            }
            catch
            {
                throw new Exception("No se pudo modificar el libro.");
            }

            return filasAfectadas;
        }

        public LibroBE_62_BP BuscarLibro_62_BP(int? id = null, string titulo = null, string isbn = null)
        {
            LibroBE_62_BP libro = null;

            try
            {
                libro = _libroMapper_62_BP.BuscarLibro_62_BP(id, titulo, isbn);
            }
            catch
            {
                throw new Exception("No se pudo buscar el libro.");
            }

            return libro;
        }
    }
}
