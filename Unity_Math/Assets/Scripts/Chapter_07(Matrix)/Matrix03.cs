using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix03 : MonoBehaviour
{
    public TextMesh text1;
    public TextMesh text2;
    public TextMesh text3;
    public TextMesh text4;
    public TextMesh text5;
    public TextMesh text6;

    public Transform Target;

    private void Update()
    {
        if (Target == null) return;

        {
            Matrix4x4 pos = Matrix4x4.Translate(Target.position);
            text1.PrintMatrix(pos, false);
        }
        {
            Matrix4x4 rot = Matrix4x4.Rotate(Target.localRotation);
            text2.PrintMatrix(rot, false);
        }
        {
            Matrix4x4 scale = Matrix4x4.Scale(Target.localScale);
            text3.PrintMatrix(scale, false);
        }
        {
            Matrix4x4 matrix4X4 = Matrix4x4.TRS(Target.position, Target.localRotation,Target.localScale);
            text4.PrintMatrix(matrix4X4, false);
        }
        //InverseMatrix 적용
        {
            Matrix4x4 matrix4X4 = Target.localToWorldMatrix;
            text5.PrintMatrix(matrix4X4.inverse, false);
        }
        {
            Matrix4x4 matrix4X4 = Target.localToWorldMatrix;
            text6.PrintMatrix(matrix4X4, false);
        }
    }
}
