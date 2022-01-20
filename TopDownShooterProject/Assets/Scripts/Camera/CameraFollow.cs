using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform objectToFollow;
    Vector3 offset;

    private void Awake()
    {
        objectToFollow = GameObject.Find("Player").transform;
        offset = this.transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 direction = objectToFollow.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, direction, 0.04f);
        this.transform.position = smoothPosition;
    }
}
