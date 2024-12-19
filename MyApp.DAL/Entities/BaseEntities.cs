using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MyApp.DAL.Entities;

public abstract class BaseEntity
{
    [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
