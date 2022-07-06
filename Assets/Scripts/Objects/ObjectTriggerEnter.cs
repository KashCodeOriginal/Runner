using UnityEngine;

public class ObjectTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
        if (collider.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
        }
    }
}
