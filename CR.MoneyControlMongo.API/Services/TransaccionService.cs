using System;
using CR.MoneyControlMongo.API.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CR.MoneyControlMongo.API.Services;

public class TransaccionService
{
    private readonly IMongoCollection<TransaccionTipoModel> _tipoTransaccionCollection;

    public TransaccionService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DataBaseName);
        //_usuarioCollection = database.GetCollection<UsuarioModel>(mongoDBSettings.Value.CollectionName);
        _tipoTransaccionCollection = database.GetCollection<TransaccionTipoModel>("transaccion_tipo");
    }

    public async Task<List<TransaccionTipoModel>> GetAsync(){
        return await _tipoTransaccionCollection.Find(new BsonDocument()).ToListAsync();
    }
}
