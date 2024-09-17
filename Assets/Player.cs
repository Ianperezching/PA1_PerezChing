using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _myRBD;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce = 10f;
    private Vector2 _movement;
    private bool isGrounded = true;

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(_movement.x, _myRBD.velocity.y, _movement.y);
        _myRBD.velocity = Vector3.Lerp(_myRBD.velocity, targetVelocity, Time.fixedDeltaTime * velocity);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>() * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            _myRBD.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
