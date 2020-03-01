using UnityEngine;

public class LookAtMouseSimple : MonoBehaviour
{
    private void Update()
    {
        var camera = Camera.main;
        var position = transform.position;
        var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        var offset = mousePosition - position;
        var rotation = transform.eulerAngles;

        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        rotation.z = angle;
        transform.eulerAngles = rotation;
    }
}