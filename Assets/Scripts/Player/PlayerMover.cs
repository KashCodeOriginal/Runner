using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void TryMove(float targetPosx)
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosx, _speed * Time.deltaTime), transform.position.y, transform.position.z);
    }
}
