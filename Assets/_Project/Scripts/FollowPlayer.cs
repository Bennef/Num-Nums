using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int yOffset;
    float smoothTime = 0.0f;
    Vector3 velocity = Vector3.zero;
    
    void LateUpdate() => Follow();

    void Follow()
    {
        Vector3 targetPosition = player.transform.TransformPoint(new Vector3(0, yOffset, -10));
        targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}