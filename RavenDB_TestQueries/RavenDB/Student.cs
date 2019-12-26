using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    public class Student
    {
        public string Id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string nachname { get; set; }
        public string vorname { get; set; }

        public Student(string _id, string _username, string _email, string _nachname, string _vorname)
        {
            Id = _id;
            username = _username;
            email = _email;
            nachname = _nachname;
            vorname = _vorname;
        }
    }
}
