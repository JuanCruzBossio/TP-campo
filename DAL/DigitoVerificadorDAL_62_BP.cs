using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using SEG;

namespace DAL
{
    public class DigitoVerificadorDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();

        private DigitoVerificadorVertical_62_BP MapearDVV(DataRow fila)
        {
            return new DigitoVerificadorVertical_62_BP
            {
                Tabla_62_BP = fila["tabla_62_BP"].ToString(),
                DVV_62_BP = fila["dvv_62_BP"].ToString()
            };
        }

        public List<DigitoVerificadorVertical_62_BP> BuscarDVV_62_BP()
        {
            string query = "SELECT * FROM DigitoVerificadorVertical_62_BP";
            List<DigitoVerificadorVertical_62_BP> listaDVV = null;

            DataTable tabla = _acceso_62_BP.leer_62_BP(query, null);

            if (tabla != null && tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    listaDVV.Add(MapearDVV(fila));
                }
            }
            return listaDVV;
        }
        public DigitoVerificadorVertical_62_BP BuscarDVV_62_BP(string tabla)
        {
            string query = "SELECT * FROM DigitoVerificadorVertical_62_BP WHERE tabla_62_BP = @tabla";
            DigitoVerificadorVertical_62_BP dvv = null;
            SqlParameter[] parametros =
            {
                new SqlParameter("@tabla", tabla)
            };

            DataTable table = _acceso_62_BP.leer_62_BP(query, parametros);

            if (table != null && table.Rows.Count > 0)
            {
                return MapearDVV(table.Rows[0]);
            }
            return null;
        }

        public int AltaDVV_62_BP(string tabla, string dvv)
        {
            string query = "INSERT INTO DigitoVerificadorVertical_62_BP(tabla_62_BP,dvv_62_BP) VALUES(@tabla,@dvv)";

            SqlParameter[] parametros =
            {
                new SqlParameter("@tabla", tabla),
                new SqlParameter("@dvv", dvv)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }

        public int ActualizarDVV_62_BP(string tabla, string dvv)
        {
            string query =  "UPDATE DigitoVerificadorVertical_62_BP SET dvv_62_BP = @dvv WHERE tabla_62_BP = @tabla";

            SqlParameter[] parametros =
            {
                new SqlParameter("@tabla", tabla),
                new SqlParameter("@dvv", dvv)
            };

            return _acceso_62_BP.escribir_62_BP(query, parametros);
        }
        public string ObtenerStringDVV_62_BP(string tabla)
        {
            string query = $"SELECT DVH_62_BP FROM {tabla} ORDER BY DVH_62_BP";

            DataTable table = _acceso_62_BP.leer_62_BP(query, null);

            string returnString = "";

            if (table != null)
            {
                foreach (DataRow fila in table.Rows)
                {
                    returnString += fila["DVH_62_BP"].ToString();
                }
            }

            return returnString;
        }
    }
}
