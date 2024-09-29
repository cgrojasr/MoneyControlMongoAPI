using System;
using CR.MongoControlMongo.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CR.MongoControlMongo.API.Services;

public class MongoDBService
{
    private readonly IMongoCollection<UsuarioModel> _usuarioCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DataBaseName);
        _usuarioCollection = database.GetCollection<UsuarioModel>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<UsuarioModel>> GetAsync(){
        return await _usuarioCollection.Find(new BsonDocument()).ToListAsync();
    }
}
