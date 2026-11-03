using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using BE_62_BP;

namespace MAPPER_62_BP
{
    public class MultaMapper_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        public int AgregarMulta_62_BP(MultaBE_62_BP multa)
        {
            string query = "INSERT INTO Multa_62_BP (id_prestamo_62_BP, monto_62_BP, pagada_62_BP) VALUES (@idPrestamo, @monto, @pagada);SELECT SCOPE_IDENTITY();";

            SqlParameter[] parametros =
            {
                new SqlParameter("@idPrestamo", multa.id_prestamo_62_BP),
                new SqlParameter("@monto", multa.monto_62_BP),
                new SqlParameter("@pagada", multa.pagada_62_BP)
            };

            object resultado = _acceso_62_BP.escalar_62_BP(query, parametros);
            return Convert.ToInt32(Convert.ToDecimal(resultado));
        }

        public int ModificarMulta_62_BP(MultaBE_62_BP multa)
        {
            string query = "UPDATE Multa_62_BP SET id_prestamo_62_BP = @idPrestamo, monto_62_BP = @monto, pagada_62_BP = @pagada WHERE id_multa_62_BP = @id";

            SqlParameter[] parametros =
            {
                new SqlParameter("@id", multa.id_multa_62_BP),
                new SqlParameter("@idPrestamo", multa.id_prestamo_62_BP),
                new SqlParameter("@monto", multa.monto_62_BP),
                new SqlParameter("@pagada", multa.pagada_62_BP)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public MultaBE_62_BP BuscarMulta_62_BP(int? id = null, int idPrestamo = 0)
        {
            StringBuilder query = new StringBuilder("SELECT id_multa_62_BP, id_prestamo_62_BP, monto_62_BP, pagada_62_BP FROM Multa_62_BP WHERE 1=1");

            List<SqlParameter> parametros = new List<SqlParameter>();

            if (id.HasValue)
            {
                query.Append(" AND id_multa_62_BP = @id");
                parametros.Add(new SqlParameter("@id", id.Value));
            }

            if (idPrestamo > 0)
            {
                query.Append(" AND id_prestamo_62_BP = @idPrestamo");
                parametros.Add(new SqlParameter("@idPrestamo", idPrestamo));
            }

            DataTable tabla = _acceso_62_BP.leer_62_BP(query.ToString(), parametros.ToArray());

            if (tabla != null && tabla.Rows.Count > 0)
            {
                return new MultaBE_62_BP
                {
                    id_multa_62_BP = Convert.ToInt32(tabla.Rows[0]["id_multa_62_BP"]),
                    id_prestamo_62_BP = Convert.ToInt32(tabla.Rows[0]["id_prestamo_62_BP"]),
                    monto_62_BP = Convert.ToInt32(tabla.Rows[0]["monto_62_BP"]),
                    pagada_62_BP = Convert.ToBoolean(tabla.Rows[0]["pagada_62_BP"])
                };
            }

            return null;
        }
    }
}
