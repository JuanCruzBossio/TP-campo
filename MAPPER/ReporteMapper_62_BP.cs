using System;
using System.Data;
using System.Data.SqlClient;
using DAL_62_BP;

namespace MAPPER_62_BP
{
    public class ReporteMapper_62_BP
    {
        private readonly Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public DataTable ObtenerRankingLectores_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
                WITH RankingLectores AS
                (
                    SELECT
                        p.dni_lector_62_BP AS DNI,
                        LTRIM(RTRIM(ISNULL(l.nombre_62_BP, '') + ' ' + ISNULL(l.apellido_62_BP, ''))) AS NombreApellidoLector,
                        COUNT(DISTINCT p.id_prestamo_62_BP) AS CantidadPrestamos,
                        COUNT(d.id_libro_62_BP) AS CantidadEjemplaresSolicitados
                    FROM Prestamo_62_BP p
                    INNER JOIN Lector_62_BP l
                        ON l.dni_62_BP = p.dni_lector_62_BP
                    INNER JOIN DetallePrestamo_62_BP d
                        ON d.id_prestamo_62_BP = p.id_prestamo_62_BP
                    WHERE p.fecha_prestamo_62_BP >= @fechaDesde
                      AND p.fecha_prestamo_62_BP < @fechaHastaExclusiva
                    GROUP BY
                        p.dni_lector_62_BP,
                        l.nombre_62_BP,
                        l.apellido_62_BP
                )
                SELECT
                    ROW_NUMBER() OVER (
                        ORDER BY CantidadEjemplaresSolicitados DESC, CantidadPrestamos DESC, DNI ASC
                    ) AS PosicionRanking,
                    DNI,
                    NombreApellidoLector,
                    CantidadPrestamos,
                    CantidadEjemplaresSolicitados
                FROM RankingLectores
                ORDER BY PosicionRanking;";

            return EjecutarReporte_62_BP(query, fechaDesde, fechaHasta);
        }

        public DataTable ObtenerRankingLibros_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
                WITH RankingLibros AS
                (
                    SELECT
                        l.isbn_62_BP AS ISBN,
                        l.titulo_62_BP AS TituloLibro,
                        l.autor_62_BP AS Autor,
                        l.genero_62_BP AS Genero,
                        COUNT(d.id_libro_62_BP) AS CantidadVecesSolicitado,
                        COUNT(DISTINCT p.dni_lector_62_BP) AS CantidadLectoresDistintos
                    FROM Prestamo_62_BP p
                    INNER JOIN DetallePrestamo_62_BP d
                        ON d.id_prestamo_62_BP = p.id_prestamo_62_BP
                    INNER JOIN Libro_62_BP l
                        ON l.id_libro_62_BP = d.id_libro_62_BP
                    WHERE p.fecha_prestamo_62_BP >= @fechaDesde
                      AND p.fecha_prestamo_62_BP < @fechaHastaExclusiva
                    GROUP BY
                        l.isbn_62_BP,
                        l.titulo_62_BP,
                        l.autor_62_BP,
                        l.genero_62_BP
                )
                SELECT
                    ROW_NUMBER() OVER (
                        ORDER BY CantidadVecesSolicitado DESC, CantidadLectoresDistintos DESC, TituloLibro ASC
                    ) AS PosicionRanking,
                    ISBN,
                    TituloLibro,
                    Autor,
                    Genero,
                    CantidadVecesSolicitado,
                    CantidadLectoresDistintos
                FROM RankingLibros
                ORDER BY PosicionRanking;";

            return EjecutarReporte_62_BP(query, fechaDesde, fechaHasta);
        }

        public DataTable ObtenerInformeMorosidad_62_BP(DateTime fechaDesde, DateTime fechaHasta)
        {
            string query = @"
                WITH MultasPorPrestamo AS
                (
                    SELECT
                        m.id_prestamo_62_BP,
                        COUNT(m.id_multa_62_BP) AS CantidadMultas,
                        SUM(CASE WHEN m.motivo_62_BP LIKE 'Devolución fuera de término%' THEN 1 ELSE 0 END) AS MultasPorMora,
                        SUM(CASE WHEN m.motivo_62_BP LIKE 'Libro perdido%' THEN 1 ELSE 0 END) AS MultasPorPerdida,
                        SUM(m.monto_62_BP) AS MontoTotalMultas,
                        SUM(CASE WHEN m.pagada_62_BP = 1 THEN m.monto_62_BP ELSE 0 END) AS MontoPagado,
                        SUM(CASE WHEN m.pagada_62_BP = 0 THEN m.monto_62_BP ELSE 0 END) AS MontoPendiente,
                        MAX(CASE WHEN m.motivo_62_BP LIKE 'Devolución fuera de término%' THEN 1 ELSE 0 END) AS TieneMultaPorMora
                    FROM Multa_62_BP m
                    GROUP BY m.id_prestamo_62_BP
                ),
                ResumenLectores AS
                (
                    SELECT
                        p.dni_lector_62_BP AS DNI,
                        LTRIM(RTRIM(ISNULL(l.nombre_62_BP, '') + ' ' + ISNULL(l.apellido_62_BP, ''))) AS NombreApellidoLector,
                        COUNT(p.id_prestamo_62_BP) AS CantidadPrestamos,
                        SUM(CASE
                            WHEN p.finalizado_62_BP = 1 AND ISNULL(mp.TieneMultaPorMora, 0) = 0 THEN 1
                            ELSE 0
                        END) AS PrestamosFinalizadosEnTermino,
                        SUM(CASE
                            WHEN p.finalizado_62_BP = 1 AND ISNULL(mp.TieneMultaPorMora, 0) = 1 THEN 1
                            ELSE 0
                        END) AS PrestamosFinalizadosFueraTermino,
                        SUM(CASE
                            WHEN p.finalizado_62_BP = 0 AND p.fecha_limite_62_BP >= CAST(GETDATE() AS date) THEN 1
                            ELSE 0
                        END) AS PrestamosActivosEnTermino,
                        SUM(CASE
                            WHEN p.finalizado_62_BP = 0 AND p.fecha_limite_62_BP < CAST(GETDATE() AS date) THEN 1
                            ELSE 0
                        END) AS PrestamosActivosVencidos,
                        SUM(ISNULL(mp.CantidadMultas, 0)) AS CantidadMultas,
                        SUM(ISNULL(mp.MultasPorMora, 0)) AS MultasPorMora,
                        SUM(ISNULL(mp.MultasPorPerdida, 0)) AS MultasPorPerdida,
                        SUM(ISNULL(mp.MontoTotalMultas, 0)) AS MontoTotalMultas,
                        SUM(ISNULL(mp.MontoPagado, 0)) AS MontoPagado,
                        SUM(ISNULL(mp.MontoPendiente, 0)) AS MontoPendiente
                    FROM Prestamo_62_BP p
                    INNER JOIN Lector_62_BP l
                        ON l.dni_62_BP = p.dni_lector_62_BP
                    LEFT JOIN MultasPorPrestamo mp
                        ON mp.id_prestamo_62_BP = p.id_prestamo_62_BP
                    WHERE p.fecha_prestamo_62_BP >= @fechaDesde
                      AND p.fecha_prestamo_62_BP < @fechaHastaExclusiva
                    GROUP BY
                        p.dni_lector_62_BP,
                        l.nombre_62_BP,
                        l.apellido_62_BP
                )
                SELECT
                    ROW_NUMBER() OVER (
                        ORDER BY MontoTotalMultas DESC, CantidadMultas DESC, DNI ASC
                    ) AS PosicionRanking,
                    DNI,
                    NombreApellidoLector,
                    CantidadPrestamos,
                    PrestamosFinalizadosEnTermino,
                    PrestamosFinalizadosFueraTermino,
                    PrestamosActivosEnTermino,
                    PrestamosActivosVencidos,
                    CantidadMultas,
                    MultasPorMora,
                    MultasPorPerdida,
                    MontoTotalMultas,
                    MontoPagado,
                    MontoPendiente,
                    CASE
                        WHEN MontoPendiente > 0 THEN 'Con deuda'
                        ELSE 'Sin deuda'
                    END AS EstadoDeCuenta
                FROM ResumenLectores
                ORDER BY PosicionRanking;";

            return EjecutarReporte_62_BP(query, fechaDesde, fechaHasta);
        }

        private DataTable EjecutarReporte_62_BP(string query, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("@fechaDesde", SqlDbType.DateTime) { Value = fechaDesde.Date },
                new SqlParameter("@fechaHastaExclusiva", SqlDbType.DateTime) { Value = fechaHasta.Date.AddDays(1) }
            };

            return _acceso_62_BP.leer_62_BP(query, parametros);
        }
    }
}
