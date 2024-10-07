using System.Text.Json.Serialization;
using Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Service.DataStorage.MongoDataStorage.Documents;

[BsonIgnoreExtraElements]
public class DeviceDocument
{
    [BsonElement("_id")]
    [JsonPropertyName("_id")]
    [BsonId]
    public string Id { get; set; }

    [BsonElement("serialNumber")]
    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; set; }

    [BsonElement("name")]
    [JsonPropertyName("name")]
    [BsonIgnoreIfNull]
    public string? Name { get; set; }

    [BsonElement("description")]
    [JsonPropertyName("description")]
    [BsonIgnoreIfNull]
    public string? Description { get; set; }

    [BsonElement("status")]
    [JsonPropertyName("status")]
    [BsonRepresentation(BsonType.String)]
    public DeviceStatus Status { get; set; }

    [BsonElement("createdAt")]
    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }
}