using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float movementVelocity = 10;
    public float jumpForce = 30;
    public new Rigidbody2D rigidbody2D;
    private bool jump;

    private void OnValidate()
    {
        if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
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
            input = new Vector2(0, 1);
            rigidbody2D.AddForce(input * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
