using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDot : MonoBehaviour
{
    public Transform _vecA;
    public Transform _vecB;

    public TextMesh _textDot;
    public TextMesh _textMyDot;
    public TextMesh _textDegree;

    public LineRenderer[] _lines;
    public int _lineIndex = -1;

    // Update is called once per frame
    void Update()
    {
        if(_vecA != null && _vecB != null)
        {
            Vector2 v1 = _vecA.position;
            Vector2 v2 = _vecB.position;

            float dot = Vector2.Dot(v1, v2);
            float myDot = MyDot(v1, v2);

            if (_textDot != null)
                _textDot.text = "Dot : " + dot.ToString();

            if (_textMyDot != null)
                _textMyDot.text = "MyDot : " + myDot.ToString();

            if (_textDegree != null)
                _textDegree.text = "q : " + Mathf.Rad2Deg * Mathf.Acos(dot / (v2.magnitude * v1.magnitude));

            DrawLine(v1, Color.blue, 0);
            DrawLine(v2, Color.green, 1);
        }
    }

    private float MyDot(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    private void DrawLine(Vector3 target,Color color,int index)
    {
        LineRenderer line = _lines[index];
        line.SetPositions(new Vector3[] { Vector3.zero, target });
        line.startColor = color;
        line.endColor = color;

        Debug.DrawLine(Vector3.zero, target, Color.red);
    }
}
