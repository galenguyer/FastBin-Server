using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FastBin_Server.Database
{
    public class LiteDBClient
    {
        private LiteDatabase liteDatabase;
        private Random random = new Random();

        public LiteDBClient(string DbConnectionString)
        {
            liteDatabase = new LiteDatabase(DbConnectionString);
        }

        public string InsertText(TextSnippet snippet, string collectionName)
        {
            var _db = liteDatabase.GetCollection<TextSnippet>(collectionName);
            while (_db.FindById(snippet.Id) != null)
                snippet.Id += GetRandomChar();
            _db.Insert(snippet);
            return snippet.Id;
        }

        public TextSnippet RetrieveText(string id, string collectionName)
        {
            var _db = liteDatabase.GetCollection<TextSnippet>(collectionName);
            return _db.FindById(id);
        }

        private char GetRandomChar()
        {
            var chars = "abcdef0123456789";
            return chars[random.Next(0, 17)];
        }
    }
}
