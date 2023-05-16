using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector3 startPos;
    public Transform target;
    public LineRenderer Line;
    public float Rot;
    public float RotSpeed;
    public bool IsHit = false;

    float Dot = 0.0f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if (target != null) Dot = Vector2.Dot(target.right, transform.up);

        if(IsHit == true)
        {
            float length = (startPos - transform.position).magnitude;
            if(length > 0.1f)
            {
                if(Dot >= 0)
                {
                    transform.position += transform.up.normalized * Time.deltaTime * 2.0f;
                }
                else
                {
                    transform.position -= transform.up.normalized * Time.deltaTime * 2.0f;
                }
            }
            else if(length <= 0.1f)
            {
                IsHit = false;
            }
        }
        else
        {
            
        }
    }
    [ContextMenu("HitPlane")]
    public void HitPlane(Vector3 dirVec)
    {
        if(IsHit == false)
        {
            if(Dot >= 0)
            {
                transform.position += transform.up.normalized * 2.0f;
            }
            else
            {
                transform.position += -transform.up.normalized * 2.0f;
            }
            IsHit = true;
        }
    }
}
