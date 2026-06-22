using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SEG_62_BP.Observer
{
   
    public class Idioma_62_BP
    {
      
        public string Nombre_62_BP { get; set; }

        public Dictionary<string, string> Traducciones_62_BP { get; set; }
      
        public Idioma_62_BP()
        {
            Nombre_62_BP = string.Empty;
            Traducciones_62_BP = new Dictionary<string, string>();
        }

        public Idioma_62_BP(string nombre_62_BP, Dictionary<string, string> traducciones_62_BP)
        {
            Nombre_62_BP = nombre_62_BP;
            Traducciones_62_BP = traducciones_62_BP ?? new Dictionary<string, string>();
        }
    }
}