using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCross : MonoBehaviour
{
    public Transform vec1;
    public Transform vec2;
    public Transform vec3;
    public TextMesh textMesh;

    Vector3 cVec;
    // Update is called once per frame
    void Update()
    {
        CrossVector();

        Vector3 dir = cVec - vec3.position;
        if (dir.magnitude >= 0.1f) vec3.position += dir.normalized * Time.deltaTime;
    }

    void CrossVector()
    {
        cVec = Vector3.Cross(vec1.position, vec2.position);
        //cVec = Vector3.Cross(vec2.position, vec1.position); => 교환법칙 성립 안함


        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("Vec1 : " + vec1.position);
            sb.Append("\n");
            sb.Append("Vec2 : " + vec2.position);
            sb.Append("\n");
            sb.Append("Vec3 : " + cVec);

            textMesh.text = sb.ToString();
        }
    }

    public static Vector3 MyCross(Vector3 v1, Vector3 v2)
    {
        float x = v1.y * v2.z - v1.z * v2.y;
        float y = v1.z * v2.x - v1.x * v2.z;
        float z = v1.x * v2.y - v1.y * v2.x;

        return new Vector3(x, y, z);
    }
}
