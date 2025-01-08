using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class clsUriBase
    {
        internal static String getUriBase()
        {
            return "https://pokeapi.co/api/v2/pokemon?offset=0&limit=20";
        }
    }
}
