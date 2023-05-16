using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDotMove : MonoBehaviour
{
    public Transform _target;
    public LineRenderer _line;
    public bool _isFollow = false;
    public float _moveSpeed = 1.0f;
    public float _rot;
    public float _rotSpeed = 1.0f;
    public bool _isNormalized = true;

    private void Awake()
    {
        _rot = transform.localEulerAngles.z;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isNormalized = !_isNormalized;
        }

        DrawForwardLine();
        MoveFollow();

        _rot += Time.deltaTime * _rotSpeed;
        transform.localRotation = Quaternion.Euler(0, 0, _rot);
    }

    private float MyRot(Vector2 v1, Vector2 v2)
    {
        return v1.x * v2.x + v1.y * v2.y;
    }

    private void DrawForwardLine()
    {
        if (_line == null) return;

        _line.transform.rotation = Quaternion.identity;

        _line.SetPositions(new Vector3[] {transform.position, transform.up * 2f });
        _line.startColor = Color.red;
        _line.endColor = Color.red;
    }

    private void MoveFollow()
    {
        Vector3 dir = _target.position - transform.position;
        if (_isNormalized) dir = dir.normalized;
        float dot = Vector2.Dot(transform.up, dir);

        _isFollow = dot > 0.6f && dir.magnitude < 2.0f;
        if (_isFollow)
        {
            //Vector3 dit = _target.position - transform.position;
            transform.position += transform.up.normalized * Time.deltaTime * _moveSpeed;
        }
    }
}
