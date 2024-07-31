using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveFollower : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position, _speed * Time.deltaTime);
        // ходит шагами в процентах от растояния между обьектами
        // никогда не достигнет точки назначения
    }
}
