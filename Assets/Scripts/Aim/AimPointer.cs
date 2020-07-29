using System.Drawing;
using UnityEngine;

public class AimPointer : MonoBehaviour
{
    public float scalePerUnit = 1.0F;
    public float minAimPointScale = 1.0F;
    public float maxAimPointScale = 1.0F;

    public GameObject aimPrototype;

    private Transform _aimPoint;

    private void Start()
    {
        _aimPoint = Instantiate(aimPrototype).transform;    
    }

    private void Update()
    {
        if (AimSystem.Instance.TryGetPoint(out Vector3 point))
        {
            Vector3 normal = (transform.position - point).normalized;

            _aimPoint.position = point + normal * 0.01F;
            _aimPoint.rotation = Quaternion.LookRotation(-normal);
            _aimPoint.localScale = GetAimPointScale(Vector3.Distance(transform.position, point));
        }
    }

    private Vector3 GetAimPointScale(float distance)
    {
        float scale = Mathf.Clamp(scalePerUnit * distance, minAimPointScale, maxAimPointScale);

        return Vector3.one * scale;
    }
}
