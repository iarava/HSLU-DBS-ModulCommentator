using Raven.Client.Documents;
using System;

namespace RavenDB
{
    public class DocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store => store.Value;

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                Urls = new[] { "http://10.177.1.204:8080" },
                Database = "Kommunikationssystem"
            }.Initialize();

            return store;
        }
    }
}

