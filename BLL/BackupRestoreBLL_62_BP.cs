using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_62_BP;
using DAL;
using DAL_62_BP;

namespace BLL
{
    public class BackupRestoreBLL_62_BP
    {
        private BackupRestoreDAL_62_BP _backupRestoreDAL = new BackupRestoreDAL_62_BP();
        private BitacoraBLL_62_BP _bitacoraBLL_62_BP = new BitacoraBLL_62_BP();

        public int RealizarBackup_62_BP(string ruta)
        {
            var filasAfectadas = 0;

            try
            {
                filasAfectadas = _backupRestoreDAL.Backup_62_BP(ruta);

                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Se realizo Backup de Base de Datos en la ruta: " + ruta, 2);
                
                filasAfectadas = 1;
            }
            catch (Exception ex)
            {
                throw new Exception( "No se pudo realizar el Backup de la Base de Datos.");
            }

            return filasAfectadas;
        }
        public int RealizarRestore_62_BP(string ruta)
        {
            var filasAfectadas = 0;

            try
            {
                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Se inicia Restore de Base de Datos desde la ruta: " + ruta,5);

                filasAfectadas = _backupRestoreDAL.Restore_62_BP(ruta);

                _bitacoraBLL_62_BP.RegistrarBitacora_62_BP("Se realizo Restore de Base de Datos desde la ruta: " + ruta, 5);
                filasAfectadas = 1;
            }
            catch (Exception)
            {
                throw new Exception( "No se pudo realizar el Restore de la Base de Datos.");
            }

            return filasAfectadas;
        }
    }
}
