using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    public float distance = 0.5f;
    public bool isGrounded = false;

    void Update()
    {
        var position = transform.position;
        var nudge = Vector3.up * 0.1f;
        position += nudge;
        var direction = Vector3.down;
        Debug.DrawLine(position, position + direction * distance);
        var raycastHit2D = Physics2D.Raycast(position, direction, distance, LayerMask.GetMask("Default"));
        isGrounded = raycastHit2D.collider;
    }
}
