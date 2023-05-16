using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private Vector3 _dirVec;
    [SerializeField] private float _moveSpeed = 2;

    private float degree;
    float tan = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _dirVec = new Vector3(x, y, 0);

        transform.position += _dirVec * Time.deltaTime * _moveSpeed;

        if (Input.GetKey(KeyCode.Q))
        {
            tan += 1;
            transform.localRotation = Quaternion.Euler(new Vector3(0,0, tan));
        }
        if (Input.GetKey(KeyCode.E))
        {
            tan += 1;
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -tan));
        }
    }

    float Degrees2Rad(float rad)
    {
        return rad * 180f / Mathf.PI;
    }

}
