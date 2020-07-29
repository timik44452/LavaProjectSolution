using UnityEngine;

public class AimSystem : MonoBehaviour
{
    public static AimSystem Instance { get; private set; }


    private bool _isHitted;
    private Vector3 _point;

    private Camera _camera;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        _isHitted = Physics.Raycast(ray, out RaycastHit raycastHit);
        _point = raycastHit.point;
    }

    public bool TryGetPoint(out Vector3 point)
    {
        point = _point;
        return _isHitted;
    }
}
