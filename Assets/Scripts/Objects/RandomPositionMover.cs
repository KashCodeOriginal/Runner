using UnityEngine;


public class RandomPositionMover : MonoBehaviour
{
    [Header("Min and max points of road")]
    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;
    
    [Header("Height of object on road")]
    [SerializeField] private float _height;
    [SerializeField] private float _heightOfLongObjects;

    [Header("Start position by Z-axis")]
    [SerializeField] private float _zPos;

    [SerializeField] private Transform _playerTransform;

    System.Random random = new System.Random();

    [SerializeField] private PlayerInput _playerInput;

    private bool IsPlayerInactiveValue;
    
    public void MoveObjectToPosition(GameObject gameObject,bool isPositionRandom)
    {
        if (IsPlayerInactiveValue == true)
        {
            gameObject.transform.position = new Vector3(_playerTransform.position.x,_height,_zPos);
            IsPlayerInactiveValue = false;
        }
        else if (isPositionRandom == false)
        {
            gameObject.transform.position = new Vector3(0f,_heightOfLongObjects, _zPos);
        }
        else
        {
            gameObject.transform.position = RandomPositionGenerator();
        }
    }
    private Vector3 RandomPositionGenerator()
    {
        Vector3 _position = new Vector3(random.Next(_minX,_maxX)/100f,_height,_zPos); // 100f - divide to do float coordinates
        return _position;
    }

    private void OnEnable()
    {
        _playerInput.IsPlayerInactive += IsPlayerInactive;
    }

    private void OnDisable()
    {
        _playerInput.IsPlayerInactive -= IsPlayerInactive;
    }

    private void IsPlayerInactive(bool isPlayerInactive)
    {
        if (isPlayerInactive)
        {
            IsPlayerInactiveValue = true;
        }
        else
        {
            IsPlayerInactiveValue = false;
        }
    }
}
