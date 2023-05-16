using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Vector3 _dirVec;
    public TextMesh textMesh;

    public Rigidbody _rigidbody;
    public bool isVelocity = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        textMesh = gameObject.GetComponentInChildren<TextMesh>();

        _rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = Vector3.zero;
            isVelocity = !isVelocity;
        }
    }

    private void Move()
    {
        if(_rigidbody != null)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            _dirVec = new Vector3(x, y, 0) * moveSpeed;

            if (isVelocity)
                _rigidbody.velocity = _dirVec;
            else
                _rigidbody.AddForce(_dirVec);

            textMesh.text = nameof(Rigidbody) + "\n"
                + nameof(FixedUpdate) + "\n"
                + _rigidbody.velocity + "\n"
                + "deltaTIme:" + Time.deltaTime + "\n"
                + "fixedDeltaTIme" + Time.fixedDeltaTime;
        }

    }
}
