using UnityEngine;

namespace Scripts.Cameras
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] Vector3 _yOffset;
        Transform _player;

        void Start() => _player = GameObject.Find("Player").GetComponent<Transform>();

        void LateUpdate() => Follow();

        void Follow()
        {
            if (_player != null)
            {
                Vector3 targetPosition = transform.position;
                targetPosition.y = (_player.position + _yOffset).y;
                transform.position = targetPosition;
            }
        }
    }
}