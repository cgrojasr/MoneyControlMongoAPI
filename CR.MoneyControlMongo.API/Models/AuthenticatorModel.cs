using System;

namespace CR.MoneyControlMongo.API.Models;

public class AuthenticatorModel
{
    public string correo { get; set;} = string.Empty;
    public string password { get; set;} = string.Empty;
}
