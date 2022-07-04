using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;

    [SerializeField] private float _allowedTimeWithoutTouching;

    [SerializeField] private RandomPositionMover _randomPositionMover;

    [SerializeField] private GameValuesChanger gameValuesChanger;
    
    private PlayerMover _playerMover;
    
    private Vector2 _startPos;
    private float targetPosx;

    private float _passedTimeWithoutTouching;

    private void Start()
    {
        _playerMover = gameObject.GetComponent<PlayerMover>();
        targetPosx = transform.position.x;
    }

    private void Update()
    {
        _passedTimeWithoutTouching += Time.deltaTime;
        
        gameValuesChanger.TryDecreaseInactiveValue(ref _allowedTimeWithoutTouching);
        
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float posx = Input.mousePosition.x - _startPos.x;

            targetPosx = Mathf.Clamp(transform.position.x + posx, _xMin, _xMax);

            _passedTimeWithoutTouching = 0;
            
            _randomPositionMover.IsPlayerInactive = false;
        }
        else
        {
            if (_passedTimeWithoutTouching >= _allowedTimeWithoutTouching)
            {
                _randomPositionMover.IsPlayerInactive = true;
                _passedTimeWithoutTouching = 0;
            }
        }
        _playerMover.TryMove(targetPosx);
    }
}
