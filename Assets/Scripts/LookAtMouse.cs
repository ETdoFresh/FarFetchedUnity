using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public SpriteRenderer headSprite;
    public SpriteRenderer bodySprite;
    public float lookDownMaxAngle = -30;
    public float lookUpMaxAngle = 90;

    private void OnValidate()
    {
        if (!headSprite) headSprite = GetComponent<SpriteRenderer>();
        if (!bodySprite) bodySprite = GetComponentInParent<SpriteRenderer>();
    }

    private void Update()
    {
        var camera = Camera.main;
        var characterHeadPosition = transform.position;
        var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var offset = mousePosition - characterHeadPosition;
        var characterHeadRotation = transform.eulerAngles;

        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        characterHeadRotation.z = angle;

        var flip = angle < -90 || angle > 90;
        headSprite.flipX = flip;
        bodySprite.flipX = flip;

        if (flip)
        {
            characterHeadRotation.z -= 180;
            if (characterHeadRotation.z < 0 && characterHeadRotation.z >= -90 && characterHeadRotation.z < -lookUpMaxAngle)
                characterHeadRotation.z = -lookUpMaxAngle;
            if (characterHeadRotation.z > -360 && characterHeadRotation.z <= -270 && characterHeadRotation.z > -360 -lookDownMaxAngle)
                characterHeadRotation.z = -lookDownMaxAngle;
            transform.eulerAngles = characterHeadRotation;
        }
        else
        {
            characterHeadRotation.z = Mathf.Max(characterHeadRotation.z, lookDownMaxAngle);
            characterHeadRotation.z = Mathf.Min(characterHeadRotation.z, lookUpMaxAngle);
            transform.eulerAngles = characterHeadRotation;
        }
    }
}
