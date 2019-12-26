using RavenDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModulCommentatorModel
{
    public class SpecialQueryModel
    {
        DB_Operation operations;

        public SpecialQueryModel(DB_Operation operations)
        {
            this.operations = operations;
        }

        public List<Professor> GetAllDozents()
        {
            return operations.getAllDozents();
        }

        public List<ModulCount> GetModulCountList(Professor selectedDozent)
        {
            return this.operations.queryModulCount(selectedDozent.Id);
        }
    }
}
