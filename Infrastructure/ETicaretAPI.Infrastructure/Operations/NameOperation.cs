using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Operations
{
    public class NameOperation
    {
        public static string CharacterRegulatory(string name)
        {
            name.Replace("\"", "");
            name.Replace("!", "");
            name.Replace(">", "");
            name.Replace("'", "");
            name.Replace("^", "");
            name.Replace("+", "");
            name.Replace("%", "");
            name.Replace("&", "");
            name.Replace("/", "");
            name.Replace("(", "");
            name.Replace(")", "");
            name.Replace("=", "");
            name.Replace("?", "");
            name.Replace("_", "");
            name.Replace(" ", "");
            name.Replace("@", "");
            name.Replace("₺", "");
            name.Replace("€", "");
            name.Replace("¨", "");
            name.Replace("æ", "");
            name.Replace("ß", "");
            name.Replace("~", "");
            name.Replace(",", "");
            name.Replace(";", "");
            name.Replace(":", "");
            name.Replace(".", "-");
            name.Replace("Ö", "o");
            name.Replace("ö", "o");
            name.Replace("Ü", "u");
            name.Replace("ü", "u");
            name.Replace("ı", "i");
            name.Replace("İ", "i");
            name.Replace("ğ", "g");
            name.Replace("Ğ", "g");
            name.Replace("â", "a");
            name.Replace("î", "i");
            name.Replace("Ş", "s");
            name.Replace("ş", "s");
            name.Replace("ç", "c");
            name.Replace("Ç", "c");
            name.Replace("<", "");
            name.Replace(">", "");
            name.Replace("|", "");
            name = name.Trim();
            return name;
        }
    }
}
