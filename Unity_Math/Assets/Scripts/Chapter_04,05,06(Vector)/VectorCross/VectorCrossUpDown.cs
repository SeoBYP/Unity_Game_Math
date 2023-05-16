using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCrossUpDown : MonoBehaviour
{
    public Transform RotateVecTF;
    public Transform Vec1;
    public Transform Vec3;
    public TextMesh textMesh;

    //public LineRenderer line1;
    //public LineRenderer lineDir;
    //public LineRenderer lineCross;

    Vector3 cVec;

    private void Update()
    {
        CrossVector();
        Vector3 dir = cVec - Vec3.position;
        if (dir.magnitude >= 0.1f) Vec3.position += dir * Time.deltaTime * 5.0f;

        //SetLine(line1, RotateVecTF.right, Color.yellow);
    }

    void CrossVector()
    {
        Vector3 dir = Vec1.position - RotateVecTF.position;
        cVec = Vector3.Cross(RotateVecTF.right, dir);

        //SetLine(lineDir, dir, Color.red);
        //SetLine(lineCross, cVec, Color.blue);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("Dir : " + dir);
            sb.Append("\n");
            sb.Append("cVec : " + cVec);
            sb.Append("\n");
            string str = cVec.z < 0 ? "아래에 위치" : "위에 위치";
            sb.Append(str);

            textMesh.text = sb.ToString();
        }
    }

    private void SetLine(LineRenderer line,Vector3 dir,Color color)
    {
        line.SetPositions(new Vector3[] { line.transform.position, dir });
        line.startColor = color;
        line.endColor = color;
    }
}
