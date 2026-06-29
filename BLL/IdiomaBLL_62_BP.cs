using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SEG_62_BP.Observer;

namespace BLL_62_BP
{
   
    public class IdiomaBLL_62_BP
    {
        public const int IdiomaEspanol_62_BP = 1;
        public const int IdiomaIngles_62_BP = 2;
        public const int IdiomaAleman_62_BP = 3;

        public const string CodigoEspanol_62_BP = "es-AR";
        public const string CodigoIngles_62_BP = "en-US";
        public const string CodigoAleman_62_BP = "de-DE";
  
        private readonly string _rutaCarpetaIdiomas_62_BP;


        public IdiomaBLL_62_BP()
        {

            _rutaCarpetaIdiomas_62_BP = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Idiomas"
            );


            if (!Directory.Exists(_rutaCarpetaIdiomas_62_BP))
            {
                Directory.CreateDirectory(_rutaCarpetaIdiomas_62_BP);
            }
        }

        public SEG_62_BP.Observer.Idioma_62_BP CargarIdioma_62_BP(string codigoCultura_62_BP)
        {
            if (string.IsNullOrWhiteSpace(codigoCultura_62_BP))
                throw new ArgumentException("El código de cultura no puede estar vacío.", nameof(codigoCultura_62_BP));


            string rutaArchivo_62_BP = Path.Combine(_rutaCarpetaIdiomas_62_BP, $"{codigoCultura_62_BP}.json");

            if (!File.Exists(rutaArchivo_62_BP))
                throw new FileNotFoundException($"Archivo de idioma no encontrado: {rutaArchivo_62_BP}");

            try
            {

                string contenidoJson_62_BP = File.ReadAllText(rutaArchivo_62_BP);


                var diccionarioTraduccionesRaw_62_BP = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenidoJson_62_BP);


                if (diccionarioTraduccionesRaw_62_BP == null || diccionarioTraduccionesRaw_62_BP.Count == 0)
                {
                    throw new InvalidOperationException($"Archivo de idioma vacío: {rutaArchivo_62_BP}");
                }


                var idioma_62_BP = new SEG_62_BP.Observer.Idioma_62_BP(
                    nombre_62_BP: codigoCultura_62_BP,
                    traducciones_62_BP: diccionarioTraduccionesRaw_62_BP
                );

                return idioma_62_BP;
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Error al parsear JSON en {rutaArchivo_62_BP}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al cargar idioma {codigoCultura_62_BP}: {ex.Message}", ex);
            }
        }

        public string ObtenerCodigoIdioma_62_BP(int idIdioma_62_BP)
        {
            switch (idIdioma_62_BP)
            {
                case IdiomaIngles_62_BP:
                    return CodigoIngles_62_BP;
                case IdiomaAleman_62_BP:
                    return CodigoAleman_62_BP;
                case IdiomaEspanol_62_BP:
                default:
                    return CodigoEspanol_62_BP;
            }
        }

        public int ObtenerIdIdioma_62_BP(string codigoCultura_62_BP)
        {
            if (string.Equals(codigoCultura_62_BP, CodigoIngles_62_BP, StringComparison.OrdinalIgnoreCase))
                return IdiomaIngles_62_BP;

            if (string.Equals(codigoCultura_62_BP, CodigoAleman_62_BP, StringComparison.OrdinalIgnoreCase))
                return IdiomaAleman_62_BP;

            return IdiomaEspanol_62_BP;
        }


        public List<string> ObtenerIdiomasDisponibles_62_BP()
        {
            var idiomas_62_BP = new List<string>();

            if (!Directory.Exists(_rutaCarpetaIdiomas_62_BP))
                return idiomas_62_BP;


            var archivos_62_BP = Directory.GetFiles(_rutaCarpetaIdiomas_62_BP, "*.json");

            foreach (var archivo_62_BP in archivos_62_BP)
            {

                string nombreSinExtension_62_BP = Path.GetFileNameWithoutExtension(archivo_62_BP);
                idiomas_62_BP.Add(nombreSinExtension_62_BP);
            }

            return idiomas_62_BP;
        }
    }
}
