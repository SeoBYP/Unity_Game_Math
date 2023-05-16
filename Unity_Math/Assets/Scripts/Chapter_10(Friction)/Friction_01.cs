using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[ExecuteInEditMode]
public class Friction_01 : MonoBehaviour
{
    [System.Serializable]
    public class PhysicsData
    {
        public Rigidbody2D rigidbody;
        public PhysicsMaterial2D physicsMaterial;
        public BoxCollider2D boxCollider;
    }
    public GameObject box;
    public GameObject slope;
    public GameObject Root;

    public PhysicsData boxPhysicData = new PhysicsData();
    public PhysicsData slopePhysicData;

    public TextMesh textMesh;

    public Vector2 InitVec;
    public float rot = -10f;

    private void Start()
    {
        InitVec = box.transform.localPosition;
        rot = Root.transform.localEulerAngles.z;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boxPhysicData.rigidbody.velocity = Vector2.zero;
            box.transform.localPosition = InitVec;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Root.transform.rotation = Quaternion.Euler(0, 0, --rot * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Root.transform.rotation = Quaternion.Euler(0, 0, ++rot * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name.Equals("Friction_01"))
                SceneManager.LoadScene("Friction_02");
            if (SceneManager.GetActiveScene().name.Equals("Friction_02"))
                SceneManager.LoadScene("Friction_03");
            else
                SceneManager.LoadScene("Friction_01");
        }

    }

    private void FixedUpdate()
    {
        //아래로 미끄러지는 힘 F = mgSin0
        //정지 마찰 계수 f = umgCos0
        float rot = 360 - Root.transform.eulerAngles.z;

        /*
         * float gravity = 9.81f;
         * float staticFriction = boxPhysicData.physicsMaterial.friction;
         * float Force = boxPhysicData.rigidbody.mass * gravity * Mathf.Sin(Mathf.De2Rad * rot);
         * float Friction = staticFriction* boxPhysicData.rigidbody.mass * gravity * Mathf.Cos(Mathf.De2Rad * rot);
         */

        float Force = Mathf.Sin(Mathf.Deg2Rad * rot);
        float staticFriction = boxPhysicData.physicsMaterial.friction;
        float Friction = staticFriction * Mathf.Cos(Mathf.Deg2Rad * rot);

        if(textMesh != null)
        {
            textMesh.text = "";
            textMesh.text += $"Velocity : {boxPhysicData.rigidbody.velocity} \n";
            textMesh.text += $"정지마찰계수 : {staticFriction} \n";
            textMesh.text += $"Force : {Force} \n";
            textMesh.text += $"Friction : {Friction} \n";
            textMesh.text += $"Force - Friction : {Force - Friction} \n";
            textMesh.text += $"Rot : {rot} \n";
        }
    }

}
