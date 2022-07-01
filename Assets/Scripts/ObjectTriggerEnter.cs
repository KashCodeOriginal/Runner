using System;
using UnityEngine;

public class ObjectTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Floor")
        {
            collider.transform.position = new Vector3(0, 0, 42);
        }
    }
}
