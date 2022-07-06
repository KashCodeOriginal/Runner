using UnityEngine;

public class ObjectTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }

        if (collider.gameObject.tag == "Coin")
        {
            collider.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}
