using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_01 : MonoBehaviour
{
    public Transform movementObj;
    public Transform rigidbodyObj;

    private void Start()
    {
        if(movementObj != null)
        {
            movementObj.gameObject.AddComponent<MoveComponent>();
        }
        if(rigidbodyObj != null)
        {
            rigidbodyObj.gameObject.AddComponent<MoveRigidbody>();
        }
    }
}
