using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;

    public void CallGameOver() => StartCoroutine(GameOver());

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}