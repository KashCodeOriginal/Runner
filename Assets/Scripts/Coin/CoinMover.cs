using UnityEngine;

public class CoinMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }
}
