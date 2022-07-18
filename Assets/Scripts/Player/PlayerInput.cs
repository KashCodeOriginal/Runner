using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    public event UnityAction<bool> IsPlayerInactive;

    [SerializeField] private float _swipeRange;
    
    [SerializeField] private float _xMin;
    [SerializeField] private float _xMax;

    [SerializeField] private float _sensivity;

    [SerializeField] private float _allowedTimeWithoutTouching;
    [SerializeField] private float _minimalTimeWithoutTouching;
    [SerializeField] private float _decreaseStep;

    [SerializeField] private GameValuesChanger gameValuesChanger;
    
    private PlayerMover _playerMover;
    private Player _player;
    
    private Vector2 _startPos;
    private float targetPosx;

    private float _passedTimeWithoutTouching;

    private Animator _animator;
    private Animation _animation;

    private float _posy;
    private bool _canSwipe = true;
    private void Start()
    {
        _playerMover = gameObject.GetComponent<PlayerMover>();
        _player = gameObject.GetComponent<Player>();
        _animator = gameObject.GetComponent<Animator>();
        _animation = gameObject.GetComponent<Animation>();
        targetPosx = transform.position.x;
    }

    private void Update()
    {
        _passedTimeWithoutTouching += Time.deltaTime;
        gameValuesChanger.TryDecreaseValue(ref _allowedTimeWithoutTouching,_minimalTimeWithoutTouching, _decreaseStep);
        
        if (Input.GetMouseButtonDown(0))
        {
            _startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float posx = (Input.mousePosition.x - _startPos.x);
            
            _posy = (Input.mousePosition.y - _startPos.y);
            
            targetPosx = Mathf.Clamp(transform.position.x + posx * _sensivity, _xMin, _xMax);

            _passedTimeWithoutTouching = 0;

            if (_canSwipe == true)
            {
                if (_posy > _swipeRange)
                {
                    Jump();
                    _canSwipe = false;
                }
                else if (_posy < -_swipeRange)
                {
                    Slide();
                    _canSwipe = false;
                }
            }
            IsPlayerInactive?.Invoke(false);
        }
        else
        {
            if (_passedTimeWithoutTouching >= _allowedTimeWithoutTouching)
            {
                IsPlayerInactive?.Invoke(true);
                _passedTimeWithoutTouching = 0;
            }
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            _canSwipe = true;
        }
        _playerMover.TryMove(targetPosx);
        _player.gameObject.transform.position = new Vector3(_player.gameObject.transform.position.x, _player.gameObject.transform.position.y, -8.5f);
    }
    private void Jump()
    {
        _animator.SetTrigger("Jump");
        _animation.Play("ColliderUp1");
    }
    private void Slide()
    {
        _animator.SetTrigger("Slide");
        _animation.Play("ColliderDown");
    }
}
