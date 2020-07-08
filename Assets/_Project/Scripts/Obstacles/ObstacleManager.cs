using UnityEngine;

namespace Scripts.Obstacles

{
    public class ObstacleManager : MonoBehaviour
    {
        [SerializeField] GameObject _playerObj;
        [SerializeField] GameObject[] _obstaclesArray;

        int _obstacleCount;

        int _playerDistanceIndex = -1;
        int _obstacleIndex = 0;
        int _distanceToNext = 25;

        void Start()
        {
            _obstacleCount = _obstaclesArray.Length;
            InstantiateObstacles();
        }

        void Update()
        {
            int playerDistance = (int)(_playerObj.transform.position.y / (_distanceToNext / 2));

            if (_playerDistanceIndex != playerDistance)
            {
                InstantiateObstacles();
                _playerDistanceIndex = playerDistance;
            }
        }

        public void InstantiateObstacles()
        {
            int randomInt = Random.Range(0, _obstacleCount);

            GameObject newObstacle = Instantiate(_obstaclesArray[randomInt], 
                new Vector3(0, _obstacleIndex * _distanceToNext), 
                Quaternion.identity);

            newObstacle.transform.SetParent(transform);
            _obstacleIndex++;
        }
    }
}