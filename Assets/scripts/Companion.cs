using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _lengthRay;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _rotationCenter;
    private void Start()
    {
        _offset = transform.position - _rotationCenter.position;
    }

    private void Update()
    {
        transform.position = _rotationCenter.position + _offset;
        transform.RotateAround(_rotationCenter.position, Vector3.up, _speed * Time.deltaTime);
        _offset = transform.position - _rotationCenter.position;
        transform.LookAt(_target.position);
        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.red);
    }
}
