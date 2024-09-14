using System;
using CR.MoneyControlMongo.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CR.MoneyControlMongo.API.Services;

public class UsuarioService
{
    private readonly IMongoCollection<UsuarioModel> _usuarioCollection;

    public UsuarioService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DataBaseName);
        //_usuarioCollection = database.GetCollection<UsuarioModel>(mongoDBSettings.Value.CollectionName);
        _usuarioCollection = database.GetCollection<UsuarioModel>("usuario");
    }

    public async Task<List<UsuarioModel>> GetAsync(){
        return await _usuarioCollection.Find(new BsonDocument()).ToListAsync();
    }
}
