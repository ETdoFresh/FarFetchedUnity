using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public new Rigidbody2D rigidbody2D;
    public GameObject explosion;

    private void OnValidate()
    {
        if (!rigidbody2D) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(var contact in collision.contacts)
            Instantiate(explosion, contact.point, Quaternion.identity);
        Destroy(gameObject);
    }
}
