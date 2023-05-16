using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toque : MonoBehaviour
{
    public float amount = 0;
    public float timer = 0;

    public Rigidbody2D _rigidbody2D;
    public Rigidbody _rigidbody;
    public TextMesh textMesh1;
    public TextMesh textMesh2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetVelocity();
            timer = 3f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            amount += 1;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            amount -= 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rigidbody.angularDrag -= 0.01f;
            _rigidbody2D.angularDrag -= 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rigidbody.angularDrag += 0.01f;
            _rigidbody2D.angularDrag += 0.01f;
        }
        if (timer <= 0)
        {
            ResetVelocity();
            timer = 0f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        SetText();

        if (_rigidbody2D != null)
        {
            float v = amount * Time.fixedDeltaTime;
            _rigidbody2D.AddTorque(v);
        }

        if (_rigidbody != null)
        {
            float v = amount * Time.fixedDeltaTime;
            _rigidbody.AddTorque(transform.right * v);
        }
    }

    private void ResetVelocity()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.angularVelocity = 0.0f;
    }

    private void SetText()
    {
        if (textMesh1 != null)
        {
            textMesh1.text = "";
            textMesh1.text += "Torque";
            textMesh1.text += $"\ntimer : {timer}";
            textMesh1.text += $"\namount : {amount}";
            textMesh1.text += $"\nangularDrag : {_rigidbody2D.angularDrag}";
            textMesh1.text += $"\nangularVelocity : {_rigidbody2D.angularVelocity}";
            textMesh1.text += $"\nrotation : {_rigidbody2D.transform.rotation}";
        }
        if (textMesh2 != null)
        {
            textMesh2.text = "";
            textMesh2.text += "Torque";
            textMesh2.text += $"\ntimer : {timer}";
            textMesh2.text += $"\namount : {amount}";
            textMesh2.text += $"\nangularDrag : {_rigidbody.angularDrag}";
            textMesh2.text += $"\nangularVelocity : {_rigidbody.angularVelocity}";
            textMesh2.text += $"\nrotation : {_rigidbody.transform.rotation}";
        }
    }
}
