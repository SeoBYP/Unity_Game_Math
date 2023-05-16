using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public float Angle;
    public float Distance;

    public LineRenderer[] Lines;
    public LineRenderer[] TargetLines;
    public List<Transform> ListTargets;

    private class TargetData
    {
        public Vector3 dir;
        public float magnitude;
        public TargetData(Vector3 dir,float magnitude)
        {

        }
    }
    private List<TargetData> ListDetects = new List<TargetData>();

    private void Start()
    {
        
    }

    private void Update()
    {
        {
            Vector3 liftDir = GetDirecntion(-Angle / 2);
            Vector3 rightDir = GetDirecntion(Angle / 2);

            //Debug.DrawLine(transform.position, liftDir, Color.white, Distance);
            //Debug.DrawLine(transform.position, rightDir, Color.white, Distance);
        }
        {
            ListDetects.Clear();

            int targetCount = 0;
            for(int i = 0; i < ListTargets.Count; i++)
            {
                Transform targetTF = ListTargets[i];

                Vector3 dirVec = targetTF.position - transform.position;

                float dot = Vector3.Dot(transform.up, dirVec.normalized);
                float targetCos = Mathf.Cos((Angle / 2) * Mathf.Deg2Rad);
                float magnitude = dirVec.magnitude;

                if(targetCos < dot && magnitude < Distance)
                {
                    targetTF.Rotate(new Vector3(0,0,dot) * Time.deltaTime * 200f);

                    targetCount++;
                    ListDetects.Add(new TargetData(dirVec, magnitude));
                }
            }

            //foreach(var item in TargetLines)
            //{
            //    item.gameObject.SetActive(false);
            //}
            for(int i = 0; i < ListDetects.Count; i++)
            {
                print("타겟");
                //if(TargetLines.Length >= ListDetects.Count)
                //{
                //    TargetLines[i].gameObject.SetActive(true);

                //}
            }
        }
    }

    private Vector2 GetDirecntion(float angle)
    {
        Vector2 dirVEc = Vector3.zero;

        angle += transform.eulerAngles.z;
        float x = Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = Mathf.Cos(angle * Mathf.Deg2Rad);

        dirVEc = new Vector2(x, y);
        return dirVEc;
    }
}
