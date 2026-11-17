using System;
using System.Data;
using MAPPER_62_BP;

namespace BLL_62_BP
{
    public class ReporteBLL_62_BP
    {
        private readonly ReporteMapper_62_BP _reporteMapper_62_BP = new ReporteMapper_62_BP();

        public DataTable ObtenerRankingLectores_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarPeriodo_62_BP(fechaDesde, fechaHasta);

            try
            {
                return _reporteMapper_62_BP.ObtenerRankingLectores_62_BP(fechaDesde, fechaHasta);
            }
            catch
            {
                throw new Exception("No se pudo obtener el ranking de lectores.");
            }
        }

        public DataTable ObtenerRankingLibros_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarPeriodo_62_BP(fechaDesde, fechaHasta);

            try
            {
                return _reporteMapper_62_BP.ObtenerRankingLibros_62_BP(fechaDesde, fechaHasta);
            }
            catch
            {
                throw new Exception("No se pudo obtener el ranking de libros.");
            }
        }

        public DataTable ObtenerInformeMorosidad_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarPeriodo_62_BP(fechaDesde, fechaHasta);

            try
            {
                return _reporteMapper_62_BP.ObtenerInformeMorosidad_62_BP(fechaDesde, fechaHasta);
            }
            catch
            {
                throw new Exception("No se pudo obtener el informe de morosidad y cumplimiento.");
            }
        }

        public DataTable ObtenerDemandaInsatisfecha_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            ValidarPeriodo_62_BP(fechaDesde, fechaHasta);

            try
            {
                return _reporteMapper_62_BP.ObtenerDemandaInsatisfecha_62_BP(fechaDesde, fechaHasta);
            }
            catch
            {
                throw new Exception("No se pudo obtener el informe de demanda insatisfecha.");
            }
        }

        private void ValidarPeriodo_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde.Date > fechaHasta.Date)
            {
                throw new ArgumentException("La fecha desde no puede ser posterior a la fecha hasta.");
            }
        }
    }
}
