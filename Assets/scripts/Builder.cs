using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private float _checkDistanse;
    [SerializeField] private Transform _reycastPoint;
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private BuildPreview _buildPreview;

    private RaycastHit _hitinfo;

    private Vector3 BuildPosition => _hitinfo.transform.position + _hitinfo.normal;

    private void Update()
    {
        Debug.DrawRay(_reycastPoint.position, _reycastPoint.forward * 10, Color.red);

        if (_hitinfo.transform == null)
            return;

        if (Input.GetMouseButtonDown(0))
            Build();
    }

    private void FixedUpdate()
    {
        if (_hitinfo.transform == null)
        {
            _buildPreview.Disable();
        }

        if(Physics.Raycast(_reycastPoint.position, _reycastPoint.forward, out _hitinfo, _checkDistanse))
        {
            if(_buildPreview.IsActive == false)
            {
                _buildPreview.Enable();
            }

            _buildPreview.SetPosition(BuildPosition);
        }
    }

    private void Build()
    {
        Vector3 position = BuildPosition;  

        Instantiate(_blockPrefab, position, Quaternion.identity);
    }
}
