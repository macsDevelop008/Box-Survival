using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class DBManager : MonoBehaviour
{
    
    public static DBManager _shared;

    MongoClient client;
    IMongoDatabase database;
    IMongoCollection<CuentaUsuario> coleccion;

    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        Inicializar();
    }

    void Inicializar() 
    {
        try
        {
            //Si hay conexion a internet
            if (ConeccionInternet._shared.coneccionRed())
            {
                //Conecta con Mongodb Atlas                
                client = new MongoClient("mongodb+srv://admin:123@zombie-world.e5nf4." +
                    "mongodb.net/myFirstDatabase?" +
                    "retryWrites=true&w=majority");
                //Conecta con la base de datos.
                database = client.GetDatabase("PROYECTO");
                //Conecta con la coleccion.
                coleccion = database.GetCollection<CuentaUsuario>("CUENTAS");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    public void CrearCuenta(CuentaUsuario pCuentaUsuario) 
    {

    }

    void CrearCuentaConfirmada(CuentaUsuario pCuentaUsuario) 
    {
        try
        {
            //Si hay conexion a internet
            if (ConeccionInternet._shared.coneccionRed())
            {
                //Insertar registro.
                coleccion.InsertOne(pCuentaUsuario);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    public bool VerificarExistenciaCuenta(string pCuenta) 
    {
        return false;
    }

    //Si es @gmail.com - @hotmail.com - @yahoo.com
    public bool VerificarEstructuraCuenta(string pCuenta) 
    {
        return false;
    }

    //Minimo 6 caracteres - Maximo 20
    public bool VerificarContraseñaValida(string pContraseña) 
    {
        return true;
    }

}
