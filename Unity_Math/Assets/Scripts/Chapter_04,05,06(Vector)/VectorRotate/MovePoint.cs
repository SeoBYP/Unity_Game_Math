using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _points;
    public int index;
    public bool _isMoveNormalize = true;
    void Start()
    {
        index = 0;
        _target = _points[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(_target != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMoveNormalize = !_isMoveNormalize;
            }
            Vector3 dirVec = (_target.position - transform.position);
            float length = dirVec.magnitude;
            if(length <= 0.2f)
            {
                index++;
                index = (index >= _points.Length) ? 0 : index;

                _target = _points[index];
            }

            if (_isMoveNormalize) dirVec = dirVec.normalized;
            transform.position += dirVec * 2f * Time.deltaTime;
            //각도 작업
            //Mathf.Atan(dirVec.y / dirVec.x) = dirVec의 y분의 x로 나눈것의 라디안 값을 리턴한다.
            float rot = Mathf.Atan(dirVec.y / dirVec.x);
            //rot(라디안)을 * Mathf.Rad2Deg하면서 각도 값으로 변환해준다.
            float degree = rot * Mathf.Rad2Deg;
            //dirVec가 반대 방향이면 현재 회전값에다가 180도를 더해서 회전시켜준다.
            if (dirVec.x < 0)
                degree = 180 + degree;
            transform.rotation = Quaternion.Euler(0, 0, degree);
        }
    }
}
