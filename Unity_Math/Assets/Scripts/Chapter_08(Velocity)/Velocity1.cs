using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity1 : MonoBehaviour
{
    Vector2 posVec01;
    Vector2 posVec02;
    [Range(1, 8)]
    public float speed01 = 2;
    private float displacement01 = 0;

    [Range(0, 8)]
    public float acceleration = 0.2f;
    public float displacement02 = 0;

    private float startTime = 0.0f;
    public float deltaTime = 0.0f;

    public Transform trans01;
    public Transform trans02;

    public TextMesh text1;
    public TextMesh text2;

    private void Start()
    {
        startTime = Time.time;

        posVec01 = trans01.position;
        displacement01 = posVec01.x;

        posVec02 = trans02.position;
        displacement02 = posVec02.x;
    }

    private void Update()
    {
        deltaTime = Time.time - startTime;

        float delta01 = (speed01 * deltaTime);
        posVec01.x = displacement01 + delta01;
        trans01.position = posVec01;

        float delta02 = (acceleration / 2 * Mathf.Pow(deltaTime, 2));
        posVec02.x = displacement02 + delta02;
        trans02.position = posVec02;

        PrintData();
    }

    private void PrintData()
    {
        if(text1 != null)
        {
            text1.text = "";
            text1.text += $"speed01 : {speed01}\n";
            text1.text += $"posVec01 : {posVec01.x}\n";

            text2.text = "";
            text2.text += $"acceleration : {acceleration}\n";
            text2.text += $"posVec02 : {posVec02.x}\n";
        }
    }
}
