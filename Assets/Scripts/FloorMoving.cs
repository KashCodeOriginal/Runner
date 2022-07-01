using UnityEngine;

public class FloorMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void Update()
    {
        gameObject.transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
}
