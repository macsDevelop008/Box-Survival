using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BsonIgnoreExtraElements]
public class CuentaUsuario
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("cuenta")]
    public string cuenta { get; set; }

    [BsonElement("contrase�a")]
    public string contrasenia { get; set; }

    [BsonElement("score")]
    public string score { get; set; }

    public CuentaUsuario(string pCuenta, string pContrase�a, string pScore) 
    {
        this.cuenta = pCuenta;
        this.contrasenia = pContrase�a;
        this.score = pScore;
    }

    public override string ToString()
    {
        return "Cuenta: " + cuenta
                + "Contrase�a: "+ contrasenia
                + "Score :" + score;
    }
}
