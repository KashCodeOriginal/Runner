using UnityEngine;

public class ObjectTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            
        }
    }
}
