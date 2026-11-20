using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_62_BP;
using MAPPER_62_BP;
using BLL;
using SEG_62_BP;

namespace BLL_62_BP
{
    public class LibroBLL_62_BP
    {
        private LibroMapper_62_BP _libroMapper_62_BP = new LibroMapper_62_BP();
        private Encriptacion_62_BP _encriptacionSEG_62_BP = new Encriptacion_62_BP();
        private DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP = new DigitoVerificadorBLL_62_BP();

        public int AgregarLibro_62_BP(LibroBE_62_BP libro)
        {
            int filasAfectadas = 0;

            try
            {
                filasAfectadas = _libroMapper_62_BP.AgregarLibro_62_BP(libro);
                if (filasAfectadas > 0)
                {
                    ActualizarLibroDVH_62_BP(filasAfectadas);
                }
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
                if (filasAfectadas > 0)
                {
                    ActualizarLibroDVH_62_BP(libro.id_libro_62_BP);
                }
            }
            catch
            {
                throw new Exception("No se pudo modificar el libro.");
            }

            return filasAfectadas;
        }

        public LibroBE_62_BP BuscarLibro_62_BP(int? id = null, string titulo = null, string isbn = null, bool? prestado = null)
        {
            LibroBE_62_BP libro = null;

            try
            {
                libro = _libroMapper_62_BP.BuscarLibro_62_BP(id, titulo, isbn, prestado);
            }
            catch
            {
                throw new Exception("No se pudo buscar el libro.");
            }

            return libro;
        }

        public List<LibroBE_62_BP> BuscarTodosLosLibros_62_BP(bool? prestado = null)
        {
            List<LibroBE_62_BP> libros = null;

            try
            {
                libros = _libroMapper_62_BP.BuscarTodosLosLibros_62_BP(prestado);
            }
            catch
            {
                throw new Exception("No se pudieron obtener los libros.");
            }

            return libros;
        }

        public List<LibroBE_62_BP> BuscarLibrosConFiltros_62_BP(string titulo, string autor, string genero, string isbn, bool? prestado = null)
        {
            List<LibroBE_62_BP> libros = null;

            try
            {
                libros = _libroMapper_62_BP.BuscarLibrosConFiltros_62_BP(titulo, autor, genero, isbn, prestado);
            }
            catch
            {
                throw new Exception("No se pudieron buscar los libros con los filtros especificados.");
            }

            return libros;
        }

        public List<LibroBE_62_BP> BuscarLibrosAlternativos_62_BP(LibroBE_62_BP libroSolicitado)
        {
            List<LibroBE_62_BP> alternativas = new List<LibroBE_62_BP>();

            if (libroSolicitado == null)
            {
                return alternativas;
            }

            try
            {
                // Primera búsqueda: un libro disponible del mismo autor.
                List<LibroBE_62_BP> librosMismoAutor = BuscarLibrosConFiltros_62_BP(
                    null, libroSolicitado.autor_62_BP, null, null, false);

                LibroBE_62_BP alternativaAutor = librosMismoAutor
                    .FirstOrDefault(libro => !EsMismoLibro_62_BP(libro, libroSolicitado));

                if (alternativaAutor != null)
                {
                    alternativas.Add(alternativaAutor);
                }

                // Segunda búsqueda: un libro disponible del mismo género.
                List<LibroBE_62_BP> librosMismoGenero = BuscarLibrosConFiltros_62_BP(
                    null, null, libroSolicitado.genero_62_BP, null, false);

                LibroBE_62_BP alternativaGenero = librosMismoGenero
                    .FirstOrDefault(libro => !EsMismoLibro_62_BP(libro, libroSolicitado)
                        && !alternativas.Any(alternativa => EsMismoLibro_62_BP(libro, alternativa)));

                if (alternativaGenero != null)
                {
                    alternativas.Add(alternativaGenero);
                }
            }
            catch
            {
                throw new Exception("No se pudieron buscar los libros alternativos.");
            }

            return alternativas;
        }

        private bool EsMismoLibro_62_BP(LibroBE_62_BP primerLibro, LibroBE_62_BP segundoLibro)
        {
            if (primerLibro == null || segundoLibro == null)
            {
                return false;
            }

            if (primerLibro.id_libro_62_BP == segundoLibro.id_libro_62_BP)
            {
                return true;
            }

            return !string.IsNullOrWhiteSpace(primerLibro.isbn_62_BP)
                && primerLibro.isbn_62_BP == segundoLibro.isbn_62_BP;
        }

        public int MarcarPrestado_62_BP(int idLibro)
        {
            try
            {
                int filas = _libroMapper_62_BP.MarcarPrestado_62_BP(idLibro);
                if (filas > 0) ActualizarLibroDVH_62_BP(idLibro);
                return filas;
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
                int filas = _libroMapper_62_BP.MarcarDisponible_62_BP(idLibro);
                if (filas > 0) ActualizarLibroDVH_62_BP(idLibro);
                return filas;
            }
            catch
            {
                throw new Exception("No se pudo marcar el libro como disponible.");
            }
        }

        public int ActualizarLibroDVH_62_BP(int idLibro)
        {
            LibroBE_62_BP libro = _libroMapper_62_BP.BuscarLibro_62_BP(id: idLibro);
            if (libro == null) return 0;
            string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(libro.ObtenerCadenaDVH_62_BP());
            int filas = _libroMapper_62_BP.ActualizarDVH_62_BP(idLibro, dvh);
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Libro_62_BP");
            return filas;
        }

        public int RecalcularDVH_62_BP()
        {
            int filas = 0;
            foreach (LibroBE_62_BP libro in _libroMapper_62_BP.BuscarTodosLosLibros_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(libro.ObtenerCadenaDVH_62_BP());
                filas += _libroMapper_62_BP.ActualizarDVH_62_BP(libro.id_libro_62_BP, dvh);
            }
            _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Libro_62_BP");
            return filas;
        }

        public List<LibroBE_62_BP> BuscarErrorDVH_62_BP()
        {
            List<LibroBE_62_BP> errores = new List<LibroBE_62_BP>();
            foreach (LibroBE_62_BP libro in _libroMapper_62_BP.BuscarTodosLosLibros_62_BP())
            {
                string dvh = _encriptacionSEG_62_BP.EncriptarConSHA256_62_BP(libro.ObtenerCadenaDVH_62_BP());
                if (dvh != _libroMapper_62_BP.BuscarDVH_62_BP(libro.id_libro_62_BP)) errores.Add(libro);
            }
            return errores;
        }
    }
}
