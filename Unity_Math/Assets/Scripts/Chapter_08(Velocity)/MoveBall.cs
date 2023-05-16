using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float Gravity = 9.81f;
    public Vector3 moveDirection;

    float frontDirectionSpeed = 0;
    float upDirectionSpeed = 0;
    Vector3 normalDirection;

    bool isInit = false;

    // Update is called once per frame
    void Update()
    {
        if (isInit == false) return;
        upDirectionSpeed -= Gravity * Time.deltaTime;
        Vector3 nextPosition = transform.position;

        nextPosition.x += frontDirectionSpeed * Time.deltaTime;
        nextPosition.y += upDirectionSpeed * Time.deltaTime;

        transform.position = nextPosition;

        if (transform.position.y <= -10) Destroy(gameObject);
    }

    public void InitData(float RotValue,float startSpeed,Vector3 startPos)
    {
        transform.position = startPos;

        moveDirection = new Vector3(Mathf.Cos(RotValue * Mathf.Deg2Rad), Mathf.Sin(RotValue * Mathf.Deg2Rad), 0);

        frontDirectionSpeed = moveDirection.x * startSpeed;
        upDirectionSpeed = moveDirection.y * startSpeed;

        isInit = true;
    }
}
