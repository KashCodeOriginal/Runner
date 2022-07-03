using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}
