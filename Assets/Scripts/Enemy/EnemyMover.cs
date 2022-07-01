using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _velocityMultiplier;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.AddForce(Vector3.back * (_speed * _velocityMultiplier) * Time.deltaTime);
    }
}
