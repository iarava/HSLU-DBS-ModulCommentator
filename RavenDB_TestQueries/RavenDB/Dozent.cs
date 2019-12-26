using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Professor
    {
        public string Id { get; set; }
        public string kuerzel { get; set; }
        public string email { get; set; }
        public string nachname { get; set; }
        public string vorname { get; set; }

        public Professor(string _id, string _kuerzel, string _email, string _nachname, string _vorname)
        {
            Id = _id;
            kuerzel = _kuerzel;
            email = _email;
            nachname = _nachname;
            vorname = _vorname;
        }
    }
}
