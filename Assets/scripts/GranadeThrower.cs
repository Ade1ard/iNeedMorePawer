using UnityEngine;

public class GranadeThrower : MonoBehaviour
{
    [SerializeField] private Granade _granadePrefab;
    [SerializeField] private float _throwForce;
    [SerializeField] private Transform _throwPoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(_granadePrefab, _throwPoint.position, _throwPoint.rotation).Throw(_throwPoint.forward * _throwForce);
        }
    }
}
