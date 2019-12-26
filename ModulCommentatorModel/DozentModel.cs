using ModulCommentatorModel;
using RavenDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModulCommentatorModel
{
    public class DozentModel {

        protected DB_Operation db_operation;

        public DozentModel(DB_Operation db_operation)
        {
            this.db_operation = db_operation;
        }

        public List<Professor> GetDozentenListe()
        {
            return db_operation.getAllDozents();
        }

        public void CreateProfessor(Professor doz)
        {
            this.db_operation.addDozent(doz);
        }

        public Professor createDozentFromKey(string key)
        {
            Professor doz = db_operation.getDozent(key);
            return doz;
        }
    }
}
