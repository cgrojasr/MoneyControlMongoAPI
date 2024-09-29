using System;
using CR.MoneyControlMongo.API.Models;
using Microsoft.AspNetCore.Mvc;
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

    public async Task<string> Registrar([FromBody] UsuarioModel usuarioModel){
        await _usuarioCollection.InsertOneAsync(usuarioModel);   
        return usuarioModel.id;
    }

    public async Task<UsuarioModel> Autenticar(AuthenticatorModel authenticatorModel){
        // var filter = Builders<UsuarioModel>.Filter.And(
        //     Builders<UsuarioModel>.Filter.Eq("correo", authenticatorModel.correo),
        //     Builders<UsuarioModel>.Filter.Eq("password", authenticatorModel.password)
        // );
        // return await _usuarioCollection.Find(filter).FirstOrDefaultAsync();
        return await _usuarioCollection.Find(x=>x.correo.Equals(authenticatorModel.correo) && x.password.Equals(authenticatorModel.password)).FirstOrDefaultAsync();
    }
}
