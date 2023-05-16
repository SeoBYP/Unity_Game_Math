using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove : MonoBehaviour
{
    private float _scalar = 0.0f;
    [SerializeField] private float Degree;

    private Vector3 startPos;
    public void SetDegree(float degree) => Degree = degree;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        _scalar += Time.deltaTime;

        float x = _scalar * Mathf.Cos(Degree2Rad(Degree));
        float y = _scalar * Mathf.Sin(Degree2Rad(Degree));

        Vector3 dirVec = startPos + new Vector3(x, y, 0);
        transform.localPosition = dirVec;
    }

    float Degree2Rad(float degrees)
    {
        return degrees * Mathf.PI / 180f;
    }
}
