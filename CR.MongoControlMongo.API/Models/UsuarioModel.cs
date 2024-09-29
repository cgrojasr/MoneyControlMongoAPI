using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CR.MongoControlMongo.API.Models;

public class UsuarioModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; } = string.Empty;
    public string nombre { get; set; } = string.Empty;
    public string apellido { get; set; } = string.Empty;
    public string correo { get; set; } = string.Empty;
    public string password { get; set; } = string.Empty;
}
