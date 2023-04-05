using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{

    Rigidbody2D rb;

    float horizontal_value;
    float moveSpeed_horizontal;
    bool canjump;
    float jumpForce;
    Vector2 ref_velocity;
    bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed_horizontal = 800f;
        ref_velocity = Vector2.zero;
        jumpForce = 10f;

    }

    // Update is called once per frame
    void Update()
    {

        horizontal_value = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            canjump = true;
        }
       


    }

    private void FixedUpdate()
    {


        Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, target_velocity, ref ref_velocity, 0.05f);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 60);

        if (canjump && IsGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            canjump = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //animController.SetBool("Jumping", false);
        IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //animController.SetBool("Jumping", true);
        IsGrounded = false;
    }

}
