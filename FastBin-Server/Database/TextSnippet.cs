using LiteDB;
using System;

namespace FastBin_Server.Database
{
    public class TextSnippet
    {
        [BsonId]
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public TextSnippet(string id, string text)
        {
            this.Id = id;
            this.Text = text;
            this.CreatedAt = DateTimeOffset.UtcNow;
        }

        public TextSnippet()
        {

        }
    }
}
