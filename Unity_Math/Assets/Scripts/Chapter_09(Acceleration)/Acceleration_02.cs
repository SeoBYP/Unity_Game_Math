using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_02 : MonoBehaviour
{
    public ForceMode setForceMode = ForceMode.Force;
    public List<Transform> listObject;

    public bool isMove = false;

    [System.Serializable]
    public class SetData
    {
        public Vector3 initVec;
        public Rigidbody rigidbody;
        public Vector3 dirVec;
        public float moveSpeed;
        public TextMesh textMesh;
        public ForceMode forceMode;

        public Vector3 DirVec { get => dirVec; set => dirVec = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

        public SetData(Rigidbody rigidbody,Vector3 dirVec, float movespeed)
        {
            this.initVec = rigidbody.transform.position;
            this.rigidbody = rigidbody;
            this.dirVec = dirVec;
            this.moveSpeed = movespeed;

            textMesh = rigidbody.gameObject.GetComponentInChildren<TextMesh>();

            this.dirVec *= moveSpeed;

            Vector3 scale = rigidbody.transform.Find("Sphere").localScale;
            scale.x += rigidbody.mass * 0.1f;
            scale.y += rigidbody.mass * 0.1f;
            rigidbody.transform.Find("Sphere").localScale = scale;
        }
        public void SetForceMode(ForceMode forceMode)
        {
            this.forceMode = forceMode;
        }
        public void Move()
        {
            if(rigidbody != null)
            {
                rigidbody.AddForce(dirVec, this.forceMode);
            }
        }

        public void ViewTextMesh()
        {
            textMesh.text = rigidbody.transform.name + "\n"
                + "mass:" + rigidbody.mass + "\n"
                + "forceMode:" + forceMode + "\n"
                + string.Format("Velocity:{0:0#.#0}", rigidbody.velocity);
        }

        public void Reset()
        {
            rigidbody.transform.position = initVec;
            rigidbody.velocity = Vector3.zero;
        }
    }
    public List<SetData> listDatas = new List<SetData>();

    private void Start()
    {
        foreach(var item in listObject)
        {
            listDatas.Add(new SetData(item.GetComponent<Rigidbody>(), Vector3.right, 5f));
        }
    }

    private void ChangeFOrceMode()
    {
        foreach (var item in listDatas)
        {
            item.Reset();
        }

        setForceMode += 1;

        if((int)setForceMode == 3 || (int)setForceMode == 4)
        {
            listDatas[0].SetForceMode(ForceMode.Force);
            listDatas[1].SetForceMode(ForceMode.Impulse);

            listDatas[2].SetForceMode(ForceMode.Acceleration);
            listDatas[3].SetForceMode(ForceMode.VelocityChange);
        }
        else if ((int)setForceMode == (int)ForceMode.Acceleration + 1)
        {
            setForceMode = ForceMode.Force;

            foreach(var item in listDatas)
            {
                item.SetForceMode(setForceMode);
            }
        }
        else
        {
            foreach(var item in listDatas)
            {
                item.SetForceMode(setForceMode);
            }
        }
        isMove = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeFOrceMode();
        }
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            foreach(var item in listDatas)
            {
                item.Move();
            }
            isMove = false;
        }
        foreach(var item in listDatas)
        {
            item.ViewTextMesh();
        }
    }
}
