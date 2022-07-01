using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float XMin;
    [SerializeField] private float XMax;
    
    private PlayerMover _playerMover;
    
    private Vector2 _startPos;
    private float targetPosx;

    private void Start()
    {
        _playerMover = gameObject.GetComponent<PlayerMover>();
        targetPosx = transform.position.x;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float posx = Input.mousePosition.x - _startPos.x;

            targetPosx = Mathf.Clamp(transform.position.x + posx, XMin, XMax);
        }
        _playerMover.TryMove(targetPosx);
    }
}
