using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MyApp.DAL.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public string? Author { get; set; }
    public bool? Published { get; set; }
}
