using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CR.MoneyControlMongo.API.Models;

public class TransaccionTipoModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("id")]
    public string id_tipo_transaccion { get; set; } = string.Empty;
    public string nombre { get; set; } = string.Empty;
}
