using UnityEngine;

public class RandomPositionMover : MonoBehaviour
{
    public bool IsPlayerInactive;
    
    [Header("Min and max points of road")]
    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;
    
    [Header("Height of object on road")]
    [SerializeField] private float _height;

    [Header("Start position by Z-axis")]
    [SerializeField] private float _zPos;

    [SerializeField] private Transform _playerTransform;

    System.Random random = new System.Random();
    
    public void MoveToPosition(GameObject gameObject)
    {
        if (IsPlayerInactive == true)
        {
            gameObject.transform.position = new Vector3(_playerTransform.position.x,_height,_zPos);
            IsPlayerInactive = false;
        }
        else
        {
            gameObject.transform.position = RandomPositionGenerator();
        }
    }
    private Vector3 RandomPositionGenerator()
    {
        Vector3 _position = new Vector3(random.Next(_minX,_maxX)/100f,_height,_zPos); // 100f - devide to do float coordinates
        return _position;
    }

    
}
