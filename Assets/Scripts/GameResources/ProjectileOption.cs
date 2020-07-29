using UnityEngine;

[CreateAssetMenu]
public class ProjectileOption : ScriptableObject
{
    public float force = 1.0F;
    public Projectile projectilePrototype;
}
