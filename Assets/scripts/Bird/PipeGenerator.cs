using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ObjectPool _pool;

    private void Start()
    {
        
    }

    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var pipe = _pool.GetObject();
    }
}
