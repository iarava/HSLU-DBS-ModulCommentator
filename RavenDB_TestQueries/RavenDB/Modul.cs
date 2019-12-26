using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Modul
    {
        public string Id { get; set; }
        public string bezeichnung { get; set; }
        public string kuerzel { get; set; }
        public string verantwortlicher { get; set; }

        public Modul(string _id, string _bezeichnung, string _kuerzel, string _dozenten_id)
        {
            Id = _id;
            bezeichnung = _bezeichnung;
            kuerzel = _kuerzel;
            verantwortlicher = _dozenten_id;
        }
    }
}
