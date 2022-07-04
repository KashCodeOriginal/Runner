using UnityEngine;

public class RandomPositionMover : MonoBehaviour
{
    [Header("Min and max points of road")]
    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;
    
    [Header("Height of object on road")]
    [SerializeField] private int _height;

    [Header("Start position by Z-axis")]
    [SerializeField] private int _zPos;


    System.Random random = new System.Random();
    
    public void MoveToGeneratedPosition(GameObject gameObject)
    {
        gameObject.transform.position = RandomPositionGenerator();
    }

    private Vector3 RandomPositionGenerator()
    {
        Vector3 _position = new Vector3(random.Next(_minX,_maxX)/100f,_height,_zPos); // 100f - devide to do float coordinates
        return _position;
    }
}
