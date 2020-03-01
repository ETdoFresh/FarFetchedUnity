using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float movementVelocity = 10;
    public float jumpForce = 30;
    public new Rigidbody2D rigidbody2D;
    public CheckGrounded checkGrounded;
    private bool jump;

    private void OnValidate()
    {
        if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
        if (!checkGrounded) checkGrounded = GetComponent<CheckGrounded>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            jump = true;
    }

    private void FixedUpdate()
    {
        var velocityY = new Vector2(0, rigidbody2D.velocity.y);
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rigidbody2D.velocity = input * movementVelocity + velocityY;

        if (jump)
        {
            jump = false;

            if (checkGrounded && checkGrounded.isGrounded)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }
}
