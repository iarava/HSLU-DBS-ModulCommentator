using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Comment
    {
        public string Id { get; set; }
        public string text { get; set; }
        public string geschrieben_von { get; set; }
        public string modul { get; set; }
        public List<string> Dozenten { get; set; }

        public Comment(string _id, string _text, string _student_id, string _modul_id, List<string> _dozenten_id)
        {
            Id = _id;
            text = _text;
            geschrieben_von = _student_id;
            modul = _modul_id;
            Dozenten = _dozenten_id;
        }
    }
}
