using System.Collections;
using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    GameObject _playerObj;

    void Start()
    {
        _playerObj = GameObject.Find("Player");
        StartCoroutine(CalcDistanceToPlayer());
    }

    IEnumerator CalcDistanceToPlayer()
    {
        while (true)
        {
            if (_playerObj.transform.position.y - transform.position.y > 25)
            {
                Destroy(this.gameObject);
            }
            yield return new WaitForSeconds(1);
        }
    }
}