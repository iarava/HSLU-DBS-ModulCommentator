using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDB
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            Student student1 = new Student("", "stu3", "stu1@stud.hslu.ch", "Test", "Student1");
            Student student2 = new Student("", "stu4", "stu2@stud.hslu.ch", "Test", "Student2");
            
            operation.addStudent(student1);
            operation.addStudent(student2);
            
            Professor dozent1 = new Professor("Dozent|", "doz1", "doz1@stud.hslu.ch", "Test", "Dozent1");
            Professor dozent2 = new Professor("Dozent|", "doz2", "doz2@stud.hslu.ch", "Test", "Dozent2");

            operation.addDozent(dozent1);
            operation.addDozent(dozent2);

            List<Professor> dozenten = operation.getAllDozents();

            Modul modul1 = new Modul("Modul|", "TestModul1", "TM1", dozenten.First().Id);
            Modul modul2 = new Modul("Modul|", "TestModul2", "TM2", dozenten.Last().Id);

            operation.addModul(modul1);
            operation.addModul(modul2);

            List<Student> studenten = operation.getAllStudents();
            List<Modul> module = operation.getAllModuls();
            List<string> dozentenById = new List<string>();

            foreach(Professor dozent in dozenten)
            {
                dozentenById.Add(dozent.Id);
            }

            Comment comment = new Comment("Kommentar|", "Test1", studenten.Last().Id, module.First().Id, dozentenById);            

            operation.addComment(comment);
            
            //List<Modul> module = operation.getAllModuls();
            //List<Professor> dozenten = operation.getAllDozents();
            /*
            foreach (string text in operation.queryComments(module.First().Id))
            {
                Console.WriteLine(text);
            }*/
            /*
            foreach(ModulCount modul in operation.queryModulCount("professor/5"))
            {
                Console.WriteLine(modul.bezeichnung + "\t" + modul.kuerzel + "\t" + modul.count);
            }
            System.Threading.Thread.Sleep(120000);*/
        }
    }
}
