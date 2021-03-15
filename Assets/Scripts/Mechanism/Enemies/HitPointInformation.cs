using UnityEngine;

public class HitPointInformation : MonoBehaviour
{
    [SerializeField] string _key;
    [SerializeField] Collider _colliderHitPoint;

    public string GetKey()
    {
        return _key;
    }

    public Collider GetColliderHitPoint()
    {
        return _colliderHitPoint;
    }
}
