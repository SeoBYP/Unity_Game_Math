using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix01 : MonoBehaviour
{
    public TextMesh text1;
    public TextMesh text2;
    public TextMesh text3;
    public TextMesh text4;
    public TextMesh text5;

    int index = 0;
    public float rot = 45f;
    public Vector3 _scaleVec;

    void Start()
    {
        PrintMatrixBasic01(text1, new Vector2(1, 2), Vector4.zero, Vector4.zero, Vector4.zero);
        PrintMatrixBasic02(text2, new Vector2(1, 2), new Vector2(3, 4), Vector4.zero, Vector4.zero);

        Matrix4x4 matTranslate = Matrix4x4.Translate(new Vector2(1, 2));
        text3.text = "TransLate\n";
        text3.PrintMatrixMM(matTranslate);

        Matrix4x4 matScale = Matrix4x4.Scale(_scaleVec);
        text5.text = "Scale\n";
        text5.PrintMatrixMM(matScale);

        InvokeRepeating(nameof(ChangeRotate), 1f, 1f);
    }
    //y=> x=> z
    public void ChangeRotate()
    {
        Matrix4x4 matRotate = Matrix4x4.zero;

        matRotate = index switch
        {
            0 => Matrix4x4.Rotate(Quaternion.Euler(0, rot, 0)),
            1 => Matrix4x4.Rotate(Quaternion.Euler(rot, 0, 0)),
            _ => Matrix4x4.Rotate(Quaternion.Euler(0, 0, rot)),
        };
        string eulerStr = index switch
        {
            0 => $"(0,{rot},0)\n",
            1 => $"({rot},0,0)\n",
            _ => $"(0,0,{rot})\n",
        };

        text4.text = eulerStr;
        text4.PrintMatrix(matRotate);
        index++;
        if (index > 2)
            index = 0;
    }

   
    public void PrintMatrixBasic01(TextMesh textMesh,Vector4 pos1,Vector4 pos2,Vector4 pos3,Vector4 pos4)
    {
        if(textMesh == null)
        {
            Debug.Log("textMesh is null");
            return;
        }

        var matrix = Matrix4x4.zero;
        matrix.SetColumn(0, pos1);
        matrix.SetColumn(1, pos2);
        matrix.SetColumn(2, pos3);
        matrix.SetColumn(3, pos4);

        textMesh.text = pos1.ToString() + "\n";
        textMesh.PrintMatrix(matrix);
    }

    public void PrintMatrixBasic02(TextMesh textMesh, Vector4 pos1, Vector4 pos2, Vector4 pos3, Vector4 pos4)
    {
        if (textMesh == null)
        {
            Debug.Log("textMesh is null");
            return;
        }

        var matrix = Matrix4x4.zero;
        matrix.SetColumn(0, pos1);
        matrix.SetColumn(1, pos2);
        matrix.SetColumn(2, pos3);
        matrix.SetColumn(3, pos4);

        textMesh.text = pos1.ToString() + "\n";
        textMesh.PrintMatrix(matrix);
    }
}
