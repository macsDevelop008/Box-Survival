using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class HitPoint : MonoBehaviour
{
    //Store information and Collitions points 
    [SerializeField] protected HitPointInformation[] _hitPointsInformationArray;

    //Store array HitPointInformation convert to Dictionary
    protected Dictionary<string, Collider> _hitPointsInformationDictionary;

    void Awake() 
    {   
        convertListingToDictionary();
    }

    //Convert array to Dictionary
    protected virtual void convertListingToDictionary()
    {
        _hitPointsInformationDictionary = new Dictionary<string, Collider>();

        try
        {
            for(int i = 0; i < _hitPointsInformationArray.Length; i++)
            {
                string key = _hitPointsInformationArray[i].GetKey();
                Collider colliderHitPoint = _hitPointsInformationArray[i].GetColliderHitPoint();

                _hitPointsInformationDictionary.Add(key, colliderHitPoint);
            }
        }
        catch(Exception e)
        {
            Debug.LogError("There aren't hitPoints to convert :"+ e);
        }
    }

    //Activate CollisionHit for Key
    protected void activationCollisionHItForKey(string pKey)
    {
        Collider colliderHit;

        if(_hitPointsInformationDictionary.TryGetValue(pKey, out colliderHit))
        {
            //Activate Collider hit
            colliderHit.enabled = true;
        }
    }

    //Deactivate CollisionHit for Key
    protected void deactivationCollisionHItForKey(string pKey)
    {
        Collider colliderHit;

        if(_hitPointsInformationDictionary.TryGetValue(pKey, out colliderHit))
        {
            //Deactivate Collider hit
            colliderHit.enabled = false;
        }
    }
    
}
