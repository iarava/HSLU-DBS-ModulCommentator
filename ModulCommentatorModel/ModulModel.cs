using RavenDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModulCommentatorModel
{
    public class ModulModel
    {
        DB_Operation operations;

        public ModulModel(DB_Operation operations)
        {
            this.operations = operations;
        }

        public List<Professor> GetAllDozents()
        {
            return operations.getAllDozents();
        }

        public List<Modul> GetAllModuls()
        {
            return this.operations.getAllModuls();
        }
    }
}
