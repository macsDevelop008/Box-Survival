using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WarriorTwoSwordsHitPointsAttackController : HitPoint
{
    //Time activating HitColliders
    public const float TIME_OF_LIFE_HIT_COLLIDERS = 1.0f;


    //All HitCollisions - Activate after a while deactivate
    public async void eventHitCollision(string pKey)
    {
        base.activationCollisionHItForKey(pKey);

        await Task.Delay(TimeSpan.FromSeconds(TIME_OF_LIFE_HIT_COLLIDERS));

        base.deactivationCollisionHItForKey(pKey);
    }
}
