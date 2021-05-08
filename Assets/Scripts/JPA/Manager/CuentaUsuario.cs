using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BsonIgnoreExtraElements]
public class CuentaUsuario : MonoBehaviour
{
    [BsonId]
    public ObjectId Id { get; set; }

    [BsonElement("cuenta")]
    public string cuenta { get; set; }
    [BsonElement("contrase�a")]
    public string contrasenia { get; set; }

    public CuentaUsuario(string pCuenta, string pContrase�a) 
    {
        this.cuenta = pCuenta;
        this.contrasenia = pContrase�a;
    }
}
