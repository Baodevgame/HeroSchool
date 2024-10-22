using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    public float moveSpeed { get; set; } = 20f;
    public float jumpForce { get; set; } = 10f;
    public bool isGrounded { get; set; } = false;
    public Rigidbody2D rb { get; set; }

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if(isGrounded&&Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        transform.Translate(movement  * Time.deltaTime);
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
