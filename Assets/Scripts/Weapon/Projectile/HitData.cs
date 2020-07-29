using UnityEngine;

public struct HitData
{
    public float force;
    public Vector3 point;
    public Vector3 direction;
    public Collider collider;

    public HitData(float force, Vector3 point, Vector3 direction, Collider collider)
    {
        this.force = force;
        this.point = point;
        this.direction = direction;
        this.collider = collider;
    }
}
