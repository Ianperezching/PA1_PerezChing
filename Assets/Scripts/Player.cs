using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _myRBD;
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce = 10f;
    public int vida = 10;
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

        }else if (collision.gameObject.CompareTag("Salida"))
        {
            SceneManager.LoadScene("Victoria 1");

        }else if (collision.gameObject.CompareTag("Muerte"))
        {
            SceneManager.LoadScene("Derrota");
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            vida = vida - 1;
            Debug.Log("Peronaje recibe daño");
            Debug.Log("vida: "+ vida);
            if (vida <= 0)
            {
                SceneManager.LoadScene("Derrota");
            }
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
