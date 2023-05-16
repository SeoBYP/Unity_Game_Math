using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Rigidbody2D circlr1;
    public Rigidbody2D circlr2;
    public Rigidbody2D circlr3;
    public Rigidbody2D circlr4;

    public bool isStart = false;

    List<Rigidbody2D> listRigid = new List<Rigidbody2D>();
    List<Vector3> listInitPos = new List<Vector3>();
    List<TextMesh> listText = new List<TextMesh>();

    // Start is called before the first frame update
    void Start()
    {
        listRigid.Add(circlr1);
        listRigid.Add(circlr2);
        listRigid.Add(circlr3);
        listRigid.Add(circlr4);

        foreach(var item in listRigid)
        {
            listInitPos.Add(item.transform.position);
            listText.Add(item.GetComponentInChildren<TextMesh>());
        }

        SetDrag(1.0f,0);
        SetDrag(0.7f,1);
        SetDrag(0.5f,2);
        SetDrag(0.3f,3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReSetVelocity();
            isStart = true;
        }
    }

    private void FixedUpdate()
    {
        if(isStart)
        {
            AddForce();
            isStart = false;
        }

        SetText();
    }

    private void SetDrag(float drag, int index)
    {
        listRigid[index].drag = drag;
    }

    private void ReSetVelocity()
    {
        foreach(var item in listRigid)
        {
            item.velocity = Vector3.zero;
        }

        for(int i = 0; i < listRigid.Count; i++)
        {
            listRigid[i].transform.position = listInitPos[i];
        }
    }

    private void AddForce()
    {
        foreach(var item in listRigid)
        {
            item.AddForce(Vector3.right * 4f,ForceMode2D.Impulse);
        }
    }

    private void SetText()
    {
        for(int i = 0; i < listText.Count; i++)
        {
            listText[i].text = "";
            listText[i].text += $"v:{listRigid[i].velocity}";
            listText[i].text += $",drag:{listRigid[i].drag}";
            listText[i].text += $"\nposition.x:{listRigid[i].transform.position.x}";
        }
    }
}
