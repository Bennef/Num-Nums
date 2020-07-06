using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] TextMeshProUGUI _currentScoreText;// Move to UI Manager
    int _currentScore;

    private void Start()
    {
        _currentScore = 0;
    }

    public void CallGameOver() => StartCoroutine(GameOver());

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void AddScore()
    {
        _currentScore++;
        SetScore();
    }
    void SetScore()  // Move to UI Manager
    {
        _currentScoreText.text = _currentScore.ToString();
    }
}