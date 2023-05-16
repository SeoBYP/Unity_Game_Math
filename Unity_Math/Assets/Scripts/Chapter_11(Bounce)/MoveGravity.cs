using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        if(rigidbody2D != null)
        {
            rigidbody2D.velocity = -Vector2.up * 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
