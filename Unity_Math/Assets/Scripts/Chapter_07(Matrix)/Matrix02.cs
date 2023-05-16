using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix02 : MonoBehaviour
{
    public TextMesh text1;
    public TextMesh text2;
    public TextMesh text3;
    public TextMesh text4;
    public TextMesh text5;
    public TextMesh text6;

    public Vector3 zeroVec = Vector3.zero;
    public Vector3 vecPos = new Vector3(-3,3,0);
    public Vector3 vecRot;
    public Vector3 vecScale = new Vector3(1.0f,0.5f,1.0f);
    public Vector3 vecInit;

    [Header("타겟")]
    public Transform target;
    public int index;

    private void Start()
    {
        vecInit = target.localScale;

        InvokeRepeating(nameof(ChangePosition), 1f, 2f);
        InvokeRepeating(nameof(ChangeRotation), 1f, 2f);
        InvokeRepeating(nameof(ChangeScale), 1f, 2f);
    }

    private void ChangePosition()
    {
        index = (++index) > 1 ? 0 : index;
        if (index == 0)
        {
            Matrix4x4 matTranslate = Matrix4x4.Translate(zeroVec);
            text1.PrintMatrix(matTranslate, false);
            target.position = matTranslate.GetColumn(3);
        }
        else
        {
            {
                Matrix4x4 matTranslate = Matrix4x4.Translate(target.position);
                target.position = matTranslate.MultiplyPoint(vecPos);

                text1.PrintMatrix(Matrix4x4.Translate(target.position), false);
            }
        }
        text3.text = $"pos : {target.position}";
    }
    private void ChangeRotation()
    {
        if (index == 0)
        {
            target.rotation = Quaternion.identity;

            Matrix4x4 matTranslate = Matrix4x4.Rotate(target.rotation);
            text2.PrintMatrix(matTranslate, false);
        }
        else
        {
            Matrix4x4 matRot = Matrix4x4.Rotate(Quaternion.Euler(vecRot));
            text2.PrintMatrix(Matrix4x4.Translate(target.position), false);

            {
                Vector3 up = matRot.GetColumn(1);

                float dot = Vector3.Dot(Vector3.up, up);
                float degree = Mathf.Acos(dot / (Vector3.up.magnitude * up.magnitude)) * Mathf.Rad2Deg;

                target.rotation = Quaternion.Euler(0, 0, degree);
            }
        }
        text4.text = $"rot : {target.eulerAngles}";
    }
    private void ChangeScale()
    {
        if(index == 0)
        {
            target.localScale = vecInit;

            Matrix4x4 matrixScale = Matrix4x4.Scale(target.localScale);
            text6.PrintMatrix(matrixScale, false);
        }
        else
        {
            target.localScale = vecScale;

            Matrix4x4 matrixScale = Matrix4x4.Scale(target.localScale);
            text6.PrintMatrix(matrixScale, false);
        }
        text5.text = $"scale : {target.localScale}";
    }
}
