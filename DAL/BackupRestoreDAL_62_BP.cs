using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_62_BP;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public class BackupRestoreDAL_62_BP
    {
        private Acceso_62_BP _acceso_62_BP = new Acceso_62_BP();
        SqlConnection conexion_62_BP = new SqlConnection(@"Data Source=.;Initial Catalog=master;Integrated Security=True;");
        public int Backup_62_BP(string ruta)
        {
            string rutaTemporalSQL = @"C:\Windows\Temp\temp_backup_62_bp.bak";
            if (File.Exists(rutaTemporalSQL)) { File.Delete(rutaTemporalSQL); }

            string query = $"USE master; BACKUP DATABASE TP_Campo_62_BP TO DISK = '{rutaTemporalSQL}' WITH FORMAT, INIT;";

            _acceso_62_BP.ejecutarScript_62_BP(query);

            if (File.Exists(rutaTemporalSQL))
            {
                if (File.Exists(ruta)) {
                    File.Delete(ruta);
                }

                File.Move(rutaTemporalSQL, ruta);
                return 1;
            }

            return 0;
        }

        public int Restore_62_BP(string ruta)
        {
            int res = 0;
            try
            {
                string query =
                "ALTER DATABASE TP_Campo_62_BP SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                $"RESTORE DATABASE TP_Campo_62_BP FROM DISK = '{ruta}' WITH REPLACE; " +
                "ALTER DATABASE TP_Campo_62_BP SET MULTI_USER;";

                conexion_62_BP.Open();

                SqlCommand comando = new SqlCommand(query, conexion_62_BP);

                res = comando.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                conexion_62_BP.Close();
            }
            
            return res;
        }
    }
}
