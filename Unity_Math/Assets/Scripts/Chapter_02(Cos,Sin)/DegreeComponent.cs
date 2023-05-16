using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegreeComponent : MonoBehaviour
{
    [Range(1, 4)]
    public float scalar = 0.0f;
    [Range(0,360)]
    public float degress = 0.0f;
    float dTime = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CosAndSin1();
        //CosAndSin2();
        CosAndSin3();
    }

    void CosAndSin1()
    {
        dTime += Time.deltaTime;
        float delta = scalar * Mathf.Sin(dTime);

        //방향(x,y)
        float x = delta * Mathf.Cos(Degrees2Rad(degress));
        float y = delta * Mathf.Sin(Degrees2Rad(degress));

        Vector3 dirVec = new Vector3(x, y, 0);

        transform.position = dirVec;
    }

    Vector3 dirvec = Vector3.zero;
    void CosAndSin2()
    {
        degress += Time.deltaTime * 50;

        float x = scalar * Mathf.Cos(Degrees2Rad(degress));
        float y = scalar * Mathf.Sin(Degrees2Rad(degress));
        //기본 원형의 x값에서 새로운 Cos값을 새로 더해준다.
        //=> 그래서 원형을 그릴려고 할때 한번더 라디안값이 더해지면서 각도가 수시로 변한다.
        x += scalar * Mathf.Cos(Degrees2Rad(degress * 3));

        dirvec = new Vector3(x, y, 0);
        transform.localPosition = dirvec;
    }

    public float speed = 0.0f;
    void CosAndSin3()
    {
        degress += Time.deltaTime * speed;
        if (degress > 360) degress = 0;

        float x = scalar * Mathf.Cos(Degrees2Rad(degress));
        float y = scalar * Mathf.Sin(Degrees2Rad(degress));

        dirvec = new Vector3(x, y, 0);
        transform.localPosition = dirvec;
    }

    //각도값에 PI를 곱하고 180으로 나눈 값 => 실제 Degree값에 대한 라디안 값으로 반환
    float Degrees2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180f;
    }
}
