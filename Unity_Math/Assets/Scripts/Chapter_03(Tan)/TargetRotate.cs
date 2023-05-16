using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    public Transform _target;
    public Transform _root;
    public GameObject _shot;

    private float degree;

    private void Start()
    {
        InvokeRepeating("CreateShot", 1.0f, 1.0f);
    }

    private void Update()
    {
        if(_target != null)
        {
            float x = _target.position.x - _root.position.x;
            float y = _target.position.y - _root.position.y;
            float tan = y / x;

            float radianTan = Mathf.Atan(tan);
            degree = Degrees2Rad(radianTan);

            _root.localRotation = Quaternion.Euler(0, 0, degree);

        }
    }

    float Degrees2Rad(float rad)
    {
        return rad * 180f / Mathf.PI;
    }

    private void CreateShot()
    {
        if(_shot != null)
        {
            GameObject obj = Instantiate<GameObject>(_shot, _root.position, Quaternion.identity);
            ShotMove shotMove = obj.GetComponent<ShotMove>();

            if (transform.localPosition.x > 0)
                degree += 100;

            shotMove.SetDegree(degree);
            Destroy(obj, 10.0f);
        }
    }
}
