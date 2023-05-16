using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity2 : MonoBehaviour
{
    public float RotValue = 60f;
    public float startSpeed = 10f;
    public Transform StartPos;
    public Transform LineRot;
    public GameObject Ball;
    public TextMesh text1;
    private float changespeed = 5;
    // Update is called once per frame
    void Update()
    {
        float rot = Input.GetAxis("Vertical");
        if(rot != 0)
        {
            RotValue += rot * Time.deltaTime * changespeed;
            
        }
        float speed = Input.GetAxis("Horizontal");
        if (speed != 0)
        {
            startSpeed += speed * Time.deltaTime * changespeed;
        }
        LineRot.rotation = Quaternion.Euler(0, 0, RotValue);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Ball != null)
            {
                GameObject go = Instantiate(Ball);
                MoveBall mb = go.GetComponent<MoveBall>();
                mb.InitData(RotValue, startSpeed, StartPos.position);
            }
        }
        PrintText();
    }

    private void PrintText()
    {
        if(text1 != null)
        {
            text1.text = "";
            text1.text += $"각도 : {RotValue}\n";
            text1.text += $"속도 : {startSpeed}\n";
        }
    }
}
