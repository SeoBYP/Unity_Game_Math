using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDownComponent : MonoBehaviour
{
    [Range(10, 50)]
    public float speed = 10.0f;
    [Range(1, 4)]
    public float scalar = 0.0f;
    public float degress = 0.0f;

    float y = 0.0f;
    private void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        degress += Time.deltaTime * speed;

        Vector3 direction = new Vector3(transform.localPosition.x, y + Mathf.Sin(Degrees2Rad(degress)) * scalar, 0);
        transform.localPosition = direction;
    }

    //각도값에 PI를 곱하고 180으로 나눈 값 => 실제 Degree값에 대한 라디안 값으로 반환
    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180f;
    }
}
