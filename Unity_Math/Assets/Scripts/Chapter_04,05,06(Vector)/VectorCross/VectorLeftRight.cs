using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLeftRight : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public TextMesh textMesh;

    public LineRenderer line;

    [Range(10, 50)]
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //k의 부등호(A X B) * UP벡터(벡터 A,B의 외적 결과값에 UP백터의 내적하면)
    void Update()
    {
        Vector3 dir = Player.position - Target.position;
        Vector3 cross = Vector3.Cross(Player.forward, dir);
        float dotUP = Vector3.Dot(cross.normalized, Vector3.up);

        //위아래
        Vector3 crossFor = Vector3.Cross(Player.forward, dir);
        float dotFor = Vector3.Dot(crossFor.normalized, Vector3.right);

        Debug.Log("cross : " + cross);
        Debug.Log("dot : " + dotUP);
        Debug.Log("dotFor : " + dotFor);

        line.SetPositions(new Vector3[] { Target.position, dir });
        line.startColor = Color.yellow;
        line.endColor = Color.yellow;

        if (Input.GetKey(KeyCode.Space))
        {
            float angleY = dotUP > 0 ? -rotateSpeed : rotateSpeed;
            float y = (angleY * Time.deltaTime) + Player.rotation.eulerAngles.y;

            float angleX = dotFor > 0 ? -rotateSpeed : rotateSpeed;
            float x = (angleX * Time.deltaTime) + Player.rotation.eulerAngles.x;

            Player.rotation = Quaternion.Euler(x, y, 0);
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        {
            sb.Append("cross: " + cross);
            sb.Append("\n");
            sb.Append("dot: " + dotUP);
            sb.Append("\n");
            sb.Append("dotFor: " + dotFor);

            textMesh.text = sb.ToString();
        }
    }
}
