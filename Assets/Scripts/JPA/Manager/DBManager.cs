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
    List<CuentaUsuario> cuentasyContraseña;

    private void Awake()
    {
        _shared = this;
    }

    private void Start()
    {
        Inicializar();
        //ModificarScore("123");
        //ObtenerCuentaUsuarioPorNombreCuenta("asd");
        //print(ObtenerCuentaUsuarioPorNombreCuenta("ejemplo@gmail.com").score);
        //TopMejoresScore();
        //print(CrearCuenta(new CuentaUsuario("123123123", "q123weqwe", "0")));
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

    public int CrearCuenta(CuentaUsuario pCuentaUsuario) 
    {
        if (VerificarEstructuraCuenta(pCuentaUsuario.cuenta))
        {
            if (VerificarExistenciaCuenta(pCuentaUsuario.cuenta))
            {
                if (VerificarContraseñaValida(pCuentaUsuario.contrasenia))
                {
                    //Crear cuenta
                    CrearCuentaConfirmada(pCuentaUsuario);
                    return 0;
                }
                else 
                {
                    //Contraseña no valida
                    return 1;
                }
            }
            else 
            {
                //La cuenta ya existe
                return 2;
            }
        }
        else 
        {
            //Estructura de la cuenta no valida
            return 3;

        }
    }

    //----

    public void ModificarScoreMaximoCuenta(string pScore)
    {
        string cuentaActual_Id = PersistenciaCuentaIniciada._shared.CuentaActualIniciada;
        //string cuentaActual_Id = "ejemplo@gmail.com";

        if (cuentaActual_Id != "" && PermitirModificacionScore(cuentaActual_Id, pScore)) 
        {
            string filter = "{ 'cuenta' :" + " " + "'" + cuentaActual_Id + "'" + "}";
            string paramUpdate = "{$set: { 'score':'" + pScore + "' } }";

            var collec = database.GetCollection<BsonDocument>("CUENTAS");

            BsonDocument filterDoc = BsonDocument.Parse(filter);
            BsonDocument docuUpdate = BsonDocument.Parse(paramUpdate);

            collec.UpdateOne(filterDoc, docuUpdate);
        }
    }

    public bool IniciarSesion(string pCuenta, string pContrasenia)
    {
        CuentaUsuario cuentaUsuario = ObtenerCuentaUsuarioPorNombreCuenta(pCuenta);

        if (cuentaUsuario != null
                && cuentaUsuario.cuenta.Equals(pCuenta)
                    && cuentaUsuario.contrasenia.Equals(pContrasenia))
        {
            PersistenciaCuentaIniciada._shared.CuentaActualIniciada = cuentaUsuario.cuenta;
            return true;
        }
        else
        {
            //Datos incorrectos
            //Ventana cuanta o contraseña no validos
            return false;
        }
    }

    public CuentaUsuario[] TopMejoresScore() 
    {

        CuentaUsuario[] array = ObtenerListadoInformacionCuentas().ToArray();
        CuentaUsuario temporal;

        for (int i = 1; i < array.Length; i++) 
        {
            for (int j = array.Length - 1; j >= i; j--)
            {
                if (Int32.Parse(array[j].score)  < Int32.Parse(array[j-1].score)) 
                {
                    temporal = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temporal;
                }
            }
        }

        List<CuentaUsuario> listResult = new List<CuentaUsuario>();
        for (int k = 1; k <= array.Length && k <= 10; k++) 
        {
            listResult.Add(array[array.Length - k]);
        }

        //Prueba
        /*CuentaUsuario[] prueba = listResult.ToArray();
        for (int l = 0; l < listResult.ToArray().Length; l++) 
        {
            print(prueba[l].score);
        }*/

        
        return listResult.ToArray();
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
            else
            {
                //No hay internet
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e);
        }
    }

    bool VerificarExistenciaCuenta(string pCuenta) 
    {
        CuentaUsuario[] array = ObtenerListadoInformacionCuentas().ToArray();

        for (int i = 0; i < array.Length; i++) 
        {
            if (array[i].cuenta.Equals(pCuenta)) 
            {
                return !true;
            }
        }

        return !false;
    }

    //Si es de minimo 5 caracterizticas
    bool VerificarEstructuraCuenta(string pCuenta) 
    {
        if (pCuenta.Length >= 5)
        {
            return true;
        }
        else 
        {
           return false;
        }
    }

    //Minimo 6 caracteres - Maximo 20
    bool VerificarContraseñaValida(string pContraseña) 
    {
        if (pContraseña.Length >= 6 && pContraseña.Length <= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //-----
    List<CuentaUsuario> ObtenerListadoInformacionCuentas() 
    {
        cuentasyContraseña = new List<CuentaUsuario>();
        cuentasyContraseña = coleccion.Find(d => true).ToList();

        return cuentasyContraseña;
    }
    //----
    CuentaUsuario ObtenerCuentaUsuarioPorNombreCuenta(string pCuenta) 
    {
        CuentaUsuario cuentaUsuario = coleccion.Find(a => a.cuenta.Equals(pCuenta)).FirstOrDefault();
        return cuentaUsuario;
    }

    bool PermitirModificacionScore(string pCuenta, string pScore) 
    {
        CuentaUsuario usuarioActual = ObtenerCuentaUsuarioPorNombreCuenta(pCuenta);

        if (Int64.Parse(pScore) > Int64.Parse(usuarioActual.score))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
