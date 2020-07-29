using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.01F, 100F)]
    public float moveSpeed = 1.0F;
    [Range(0.01F, 100F)]
    public float rotateSpeed = 1.0F;

    public Vector3 anchorOffset;

    public Transform target;
    public Transform anchor;

    private void LateUpdate()
    {
        if (anchor == null || target == null)
        {
            return;
        }
        
        Vector3 newPosition = anchor.position + anchorOffset;
        Quaternion newRotation = Quaternion.LookRotation(target.transform.position - transform.position);

        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }
}
