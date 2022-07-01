using UnityEngine;

public class ObjectTriggerEnter : MonoBehaviour
{
    [SerializeField] private RandomPositionMover _randomPositionMover;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _randomPositionMover.MoveToGeneratedPosition(collider.gameObject);
        }
    }
}
