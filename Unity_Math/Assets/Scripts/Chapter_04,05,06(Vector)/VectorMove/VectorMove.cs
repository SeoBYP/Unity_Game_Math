using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMove : MonoBehaviour
{
    public Transform _target;
    [Range(1, 100)]
    public float _speed;
    public bool _isMoveNormarlize = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_target != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _isMoveNormarlize = !_isMoveNormarlize;
            }

            Vector3 dirVec = _target.position - transform.position;

            if (_isMoveNormarlize)
            {
                dirVec.Normalize();
                // => dirVec = dirVec / dirVec.magnitude;
            }
            transform.position += dirVec * _speed * Time.deltaTime;
        }
    }
}
