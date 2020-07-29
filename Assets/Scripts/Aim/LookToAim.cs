using UnityEngine;

public class LookToAim : MonoBehaviour
{
    [Range(0.01F, 100F)]
    public float rotationSpeed = 1.0F;

    public Vector3 rotationOffset = Vector3.zero;


    private void Update()
    {
        if (AimSystem.Instance.TryGetPoint(out Vector3 point))
        {
            Quaternion rotation = Quaternion.LookRotation(point - transform.position);

            rotation.eulerAngles += rotationOffset;

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
