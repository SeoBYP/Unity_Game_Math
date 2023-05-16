using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void PrintMatrix(this TextMesh textMesh,Matrix4x4 matrix,bool isAdd = true)
    {
        if(textMesh == null)
        {
            Debug.Log("textMesh is null");
            return;
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append($"| {colorTextVec(matrix.GetRow(0))} |\n");//0번행
            sb.Append($"| {colorTextVec(matrix.GetRow(1))} |\n");//1번행
            sb.Append($"| {colorTextVec(matrix.GetRow(2))} |\n");//2번행
            sb.Append($"| {colorTextVec(matrix.GetRow(3))} |\n");//3번행
        }

        if (isAdd)
            textMesh.text += sb.ToString();
        else
            textMesh.text = sb.ToString();
    }

    public static void PrintMatrixMM(this TextMesh textMesh,Matrix4x4 matrix,bool isAdd = true)
    {
        if (textMesh == null)
        {
            Debug.Log("textMesh is null");
            return;
        }
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append($"| {colorText(matrix.m00)}  {colorText(matrix.m01)}  {colorText(matrix.m02)}  {colorText(matrix.m03)} |\n");//0번행
            sb.Append($"| {colorText(matrix.m10)}  {colorText(matrix.m11)}  {colorText(matrix.m12)}  {colorText(matrix.m13)} |\n");//1번행
            sb.Append($"| {colorText(matrix.m20)}  {colorText(matrix.m21)}  {colorText(matrix.m22)}  {colorText(matrix.m23)}|\n");//2번행
            sb.Append($"| {colorText(matrix.m30)}  {colorText(matrix.m31)}  {colorText(matrix.m32)}  {colorText(matrix.m33)} |\n");//3번행
        }

        if (isAdd)
            textMesh.text += sb.ToString();
        else
            textMesh.text = sb.ToString();
    }

    public static string colorText(float data)
    {
        string text = (data == 0.0f) ? data.ToString("0.0") : $"<color=magenta>{data}</color>";
        return text;
    }

    public static string colorText00(float data)
    {
        string text = (data == 0.0f) ? data.ToString("0.0") : $"<color=magenta>{data.ToString("0.0")}</color>";
        return text;
    }

    public static string colorTextVec(Vector4 vec)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append(colorText00(vec.x));
            sb.Append(",");
            sb.Append(colorText00(vec.y));
            sb.Append(",");
            sb.Append(colorText00(vec.z));
            sb.Append(",");
            sb.Append(colorText00(vec.w));
            sb.Append(",");
        }
        return sb.ToString();
    }
}
