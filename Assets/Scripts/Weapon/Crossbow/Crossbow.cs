using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float reloadingDuration = 1.0F;

    public Transform from;

    private float _reloadingTimer = 0.0F;
    private ProjectileOption _projectileOption;

    private const float defaultProjectileForce = 100;
    private const float minArrowSpeed = 0.1F;
    private const float maxArrowSpeed = 20.0F;

    private void Update()
    {
        if (_reloadingTimer > 0)
        {
            _reloadingTimer -= Time.deltaTime;
        }
        else if (Input.GetMouseButtonDown(0) && AimSystem.Instance.TryGetPoint(out Vector3 point) && _projectileOption != null)
        {
            Shot(from.position, point);
            _reloadingTimer = reloadingDuration;
        }
    }

    public void SetProjectileOption(ProjectileOption projectileOption)
    {
        _projectileOption = projectileOption;
    }

    private void Shot(Vector3 from, Vector3 to)
    {
        var arrowGameObject = Instantiate(_projectileOption.projectilePrototype, from, Quaternion.LookRotation(to - from));
        var arrowComponent = arrowGameObject.GetComponent<Arrow>();

        float force = _projectileOption ? _projectileOption.force : defaultProjectileForce;
        float speed = Mathf.Clamp(force, minArrowSpeed, maxArrowSpeed);
        float mass = force / speed;

        arrowComponent.speed = speed;
        arrowComponent.mass = mass;
    }
}
