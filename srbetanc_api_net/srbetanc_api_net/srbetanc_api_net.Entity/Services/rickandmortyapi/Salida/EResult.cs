using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srbetanc_api_net.Entity.Services.rickandmortyapi.Salida
{
    public class EResult
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;

    }
}
