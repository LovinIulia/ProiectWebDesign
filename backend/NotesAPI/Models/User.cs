using MongoDB.Bson.Serialization.Attributes;

namespace NotesAPI.Models
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
