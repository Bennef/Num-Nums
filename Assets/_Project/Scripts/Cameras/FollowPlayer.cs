using UnityEngine;

namespace Scripts.Cameras
{
    public class FollowPlayer : MonoBehaviour
    {
        [SerializeField] int _yOffset;
        float _smoothTime = 0.0f;
        Vector3 _velocity = Vector3.zero;
        GameObject _player;

        void Start() => _player = GameObject.Find("Player");

        void LateUpdate() => Follow();

        void Follow()
        {
            if (_player != null)
            {
                Vector3 targetPosition = _player.transform.TransformPoint(new Vector3(0, -_yOffset, -10));
                targetPosition = new Vector3(0, targetPosition.y, targetPosition.z);

                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
            }
        }
    }
}