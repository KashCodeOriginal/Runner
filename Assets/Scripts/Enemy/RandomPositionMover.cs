using System;
using UnityEngine;

public class RandomPositionMover : MonoBehaviour
{
    System.Random random = new System.Random();
    
    public void MoveToGeneratedPosition(GameObject gameObject)
    {
        gameObject.transform.position = RandomPositionGenerator();
    }

    public Vector3 RandomPositionGenerator()
    {
        Vector3 _position = new Vector3(random.Next(-155,155)/100f,0.5f,45);
        return _position;
    }
}
