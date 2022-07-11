using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _height;
    [SerializeField] private float _distance;
    private Vector3 _targetPosition;

    private void LateUpdate()
    {
        _targetPosition = _target.position;
        _targetPosition -= _target.forward * _distance;
        _targetPosition += Vector3.up * _height;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}
