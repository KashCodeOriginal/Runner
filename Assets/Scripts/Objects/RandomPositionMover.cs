using UnityEngine;

public class RandomPositionMover : MonoBehaviour
{
    [SerializeField] private int minX;
    [SerializeField] private int maxX;
    System.Random random = new System.Random();
    
    public void MoveToGeneratedPosition(GameObject gameObject)
    {
        gameObject.transform.position = RandomPositionGenerator();
    }

    private Vector3 RandomPositionGenerator()
    {
        Vector3 _position = new Vector3(random.Next(minX,maxX)/100f,0.5f,45);
        return _position;
    }
}
