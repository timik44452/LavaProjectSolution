using UnityEngine;

public class Arrow : Projectile
{
    private void FixedUpdate()
    {
        float positionDelta = speed * Time.fixedDeltaTime;

        transform.position += positionDelta * transform.forward;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, positionDelta))
        {
            IHittedObject hittedObject = raycastHit.collider.GetComponentInParent<IHittedObject>();

            hittedObject?.Hit(new HitData(speed * mass, raycastHit.point, transform.forward, raycastHit.collider));

            transform.position = raycastHit.point + 0.1F * positionDelta * transform.forward;

            transform.parent = raycastHit.transform;

            Destroy(this);
        }
    }
}
