using UnityEngine;

public class birdTracker : MonoBehaviour
{
    [SerializeField] private birdMover _bird;
    [SerializeField] private float _xOffest;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffest;
        transform.position = position;
    }
}
