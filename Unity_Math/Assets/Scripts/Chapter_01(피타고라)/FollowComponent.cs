using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    [SerializeField] private Transform _targetObject;
    [SerializeField] private Vector3 _dirVec;
    [SerializeField] private float _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_targetObject != null)
        {
            float x = _targetObject.position.x - transform.position.x;
            float y = _targetObject.position.y - transform.position.y;
            //피타고라스의 정리
            double total = Math.Pow(x, 2) + Math.Pow(y, 2);
            double range = Math.Sqrt(total);

            if(range > 0.1f && range < 3.0f)
            {
                _dirVec = new Vector3(x, y, 0);
                transform.position += _dirVec * _moveSpeed * Time.deltaTime;
            }

        }
    }
}
