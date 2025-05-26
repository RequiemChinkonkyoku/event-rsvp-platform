using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.Entities;

public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("Title")]
    public string Title { get; set; }
    
    [BsonElement("isComplete")]
    public bool IsComplete { get; set; }
}