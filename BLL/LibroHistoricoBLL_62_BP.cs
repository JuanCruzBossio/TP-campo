using System;
using System.Collections.Generic;
using BE_62_BP;
using BLL;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class LibroHistoricoBLL_62_BP
    {
        private readonly LibroHistoricoMapper_62_BP _libroHistoricoMapper_62_BP =
            new LibroHistoricoMapper_62_BP();
        private readonly DigitoVerificadorBLL_62_BP _digitoVerificadorBLL_62_BP =
            new DigitoVerificadorBLL_62_BP();
        private readonly BitacoraBLL_62_BP _bitacoraBLL_62_BP =
            new BitacoraBLL_62_BP();

        public List<LibroHistoricoBE_62_BP> BuscarTodosLosHistoricos_62_BP()
        {
            return BuscarHistoricos_62_BP();
        }

        public List<LibroHistoricoBE_62_BP> BuscarHistoricos_62_BP(
            int? idLibro = null,
            bool? prestado = null,
            bool? actual = null)
        {
            try
            {
                return _libroHistoricoMapper_62_BP.BuscarHistoricos_62_BP(idLibro, prestado, actual);
            }
            catch
            {
                throw new Exception("No se pudo obtener el historial de libros.");
            }
        }

        public LibroHistoricoBE_62_BP BuscarHistoricoPorId_62_BP(int idHistorico)
        {
            if (idHistorico <= 0)
            {
                throw new ArgumentException("El ID historico debe ser mayor que cero.");
            }

            try
            {
                return _libroHistoricoMapper_62_BP.BuscarHistoricoPorId_62_BP(idHistorico);
            }
            catch
            {
                throw new Exception("No se pudo obtener la version historica del libro.");
            }
        }

        public int RecuperarEstado_62_BP(int idHistorico)
        {
            if (idHistorico <= 0)
            {
                throw new ArgumentException("El ID historico debe ser mayor que cero.");
            }

            LibroHistoricoBE_62_BP historico = BuscarHistoricoPorId_62_BP(idHistorico);
            if (historico == null)
            {
                throw new InvalidOperationException("No existe la version historica seleccionada.");
            }

            if (historico.actual_62_BP)
            {
                throw new InvalidOperationException("La version seleccionada ya es la version actual.");
            }

            try
            {
                int idLibro = _libroHistoricoMapper_62_BP.RecuperarEstado_62_BP(idHistorico);
                if (idLibro <= 0)
                {
                    throw new Exception("No se pudo recuperar el estado del libro.");
                }

                _digitoVerificadorBLL_62_BP.ActualizarTablaDVV_62_BP("Libro_62_BP");

                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP(
                    "LibroHistorico",
                    "RecuperarEstado",
                    "Recuperacion del estado historico " + idHistorico +
                    " para el libro " + idLibro,
                    2);

                return idLibro;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch
            {
                throw new Exception("No se pudo recuperar el estado historico del libro.");
            }
        }
    }
}
