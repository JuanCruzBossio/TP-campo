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

        public List<LibroBE_62_BP> BuscarTodosLosLibros_62_BP()
        {
            List<LibroBE_62_BP> libros = null;

            try
            {
                libros = _libroMapper_62_BP.BuscarTodosLosLibros_62_BP();
            }
            catch
            {
                throw new Exception("No se pudieron obtener los libros.");
            }

            return libros;
        }

        public List<LibroBE_62_BP> BuscarLibrosConFiltros_62_BP(string titulo, string autor, string genero, string isbn)
        {
            List<LibroBE_62_BP> libros = null;

            try
            {
                libros = _libroMapper_62_BP.BuscarLibrosConFiltros_62_BP(titulo, autor, genero, isbn);
            }
            catch
            {
                throw new Exception("No se pudieron buscar los libros con los filtros especificados.");
            }

            return libros;
        }

        public int MarcarPrestado_62_BP(int idLibro)
        {
            try
            {
                return _libroMapper_62_BP.MarcarPrestado_62_BP(idLibro);
            }
            catch
            {
                throw new Exception("No se pudo marcar el libro como prestado.");
            }
        }

        public int MarcarDisponible_62_BP(int idLibro)
        {
            try
            {
                return _libroMapper_62_BP.MarcarDisponible_62_BP(idLibro);
            }
            catch
            {
                throw new Exception("No se pudo marcar el libro como disponible.");
            }
        }
    }
}
