using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RavenDB
{
    public class DB_Operation
    {
        IDocumentStore store;

        public DB_Operation()
        {
            store = DocumentStoreHolder.Store;
        }

        public void addStudent(Student student)
        {
            addStudent(student.Id, student.username, student.email, student.nachname, student.vorname);
        }

        public void addStudent(string id, string username, string email, string nachname, string vorname)
        {
            int s_id = Int32.Parse(getAllStudents().Last().Id.Split('/')[1]) + 1;
            using (IDocumentSession session = store.OpenSession())
            {
                Student newStudent = new Student("student/"+s_id, username, email, nachname, vorname);
                session.Store(newStudent);
                session.SaveChanges();
            }
        }


        //Beispiel von Präsentator um student zu holen
        /*public Student GetStuden(string vorname)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var student = session.Query<Student>().Where<Student>(x => x.nachname == vorname).First();
                return student;
            }
        }*/

        public void addDozent(Professor dozent)
        {
            addDozent(dozent.Id, dozent.vorname, dozent.nachname, dozent.kuerzel, dozent.email);
        }

        public void addDozent(string id, string kuerzel, string email, string nachname, string vorname)
        {
            int d_id = Int32.Parse(getAllDozents().Last().Id.Split('/')[1]) + 1;
            using (IDocumentSession session = store.OpenSession())
            {
                Professor newDozent = new Professor("professor/"+d_id, kuerzel, email, nachname, vorname);
                session.Store(newDozent);
                session.SaveChanges();
            }
        }

        public void addModul(Modul modul)
        {
            addModul(modul.Id, modul.bezeichnung, modul.kuerzel, modul.verantwortlicher);
        }

        public void addModul(string id, string bezeichnung, string kuerzel, string verantwortlicher)
        {
            int m_id = Int32.Parse(getAllModuls().Last().Id.Split('/')[1]) + 1;
            using (IDocumentSession session = store.OpenSession())
            {
                Modul newModul = new Modul("modul/"+m_id, bezeichnung, kuerzel, verantwortlicher);
                session.Store(newModul);
                session.SaveChanges();
            }
        }

        public void addComment(Comment comment)
        {
            addComment(comment.Id, comment.text, comment.geschrieben_von, comment.modul, comment.Dozenten);
        }

        public void addComment(string id, string text, string geschrieben_von, string modul, List<string> dozenten)
        {
            int c_id = Int32.Parse(getAllComments().Last().Id.Split('/')[1]) + 1;
            using (IDocumentSession session = store.OpenSession())
            {
                Comment newComment = new Comment("comment/"+c_id, text, geschrieben_von, modul, dozenten);
                session.Store(newComment);
                session.SaveChanges();
            }
        }

        public Student getStudent(string id)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var student = session.Query<Student>().Where<Student>(x => x.Id == id).First();
                return student;
            }
        }

        public List<Student> getAllStudents()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var students = session.Query<Student>().ToList();
                return students;
            }
        }

        public Professor getDozent(string id)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var dozent = session.Query<Professor>().Where<Professor>(x => x.Id == id).First();
                return dozent;
            }
        }

        public List<Professor> getAllDozents()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var dozenten = session.Query<Professor>().ToList();
                return dozenten;
            }
        }

        public Modul getModul(string id)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var modul = session.Query<Modul>().Where<Modul>(x => x.Id == id).First();
                return modul;
            }
        }
        public List<Modul> getAllModuls()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var moduls = session.Query<Modul>().ToList();
                return moduls;
            }
        }

        public Comment getComment(string id)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var comment = session.Query<Comment>().Where<Comment>(x => x.Id == id).First();
                return comment;
            }
        }

        public List<Comment> getAllComments()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                var comments = session.Query<Comment>().ToList();
                return comments;
            }
        }

        public List<ModulCount> queryModulCount(string dozentId)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                List<ModulCount> modulCount = new List<ModulCount>();
                var moduls = session.Query<Modul>().Where<Modul>(x => x.verantwortlicher == dozentId).ToList();
                foreach (Modul modul in moduls)
                {
                    var commentsCount = session.Query<Comment>().Where<Comment>(y => y.modul == modul.Id).Count();
                    modulCount.Add(new ModulCount {bezeichnung = modul.bezeichnung, kuerzel = modul.kuerzel, count = commentsCount});
                }
                return modulCount;
            }
        }

        /*public List<ProfCount> queryProfCount(string dozentId)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                List<ProfCount> profCount = new List<ProfCount>();
                var commentsCount = session.Query<Comment>().Where<Comment>(x => );
                profCount.Add(new ProfCount { name = .bezeichnung, vorname = modul.kuerzel, count = commentsCount });
                return profCount;
            }
        }*/

        public List<string> queryComments(string modulId)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                List<string> commentsText = new List<string>();
                var comments = session.Query<Comment>().Where<Comment>(x => x.modul == modulId).ToList();
                foreach(Comment comment in comments)
                {
                    commentsText.Add(comment.text);
                }
                return commentsText;
            }
        }

        /*public Dozenten getDozent(string id)
        {
            Dozenten dozent = null;

            using (IDocumentSession session = store.OpenSession())
            {
                dozent = session.Load<Dozenten>(id);
            }

            return dozent;
        }

        public Student getStudent(string id)
        {
            Student student = null;

            using (IDocumentSession session = store.OpenSession())
            {
                student = session.Load<Student>(id);
            }

            return student;
        }

        public Modul getModul(string id)
        {
            Modul modul = null;

            using (IDocumentSession session = store.OpenSession())
            {
                modul = session.Load<Modul>(id);
            }

            return modul;
        }*/
    }

    
}
