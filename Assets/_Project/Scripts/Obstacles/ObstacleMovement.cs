using UnityEngine;

namespace Scripts.Obstacles
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] int _rotationSpeed;

        void Update()
        {
            if (_rotationSpeed != 0)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * _rotationSpeed);
            }
        }
    }
}