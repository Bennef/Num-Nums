using Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        int _currentScore, _bestScore;
        UIManager _uIManager;

        void Start()
        {
            _currentScore = 0;
            _uIManager = FindObjectOfType<UIManager>();
            _uIManager.SetScoreText(_uIManager.BestScoreText, PlayerPrefs.GetInt("BestScore", 0));
            print(PlayerPrefs.GetInt("BestScore"));
        }

        public void CallGameOver() => StartCoroutine(GameOver());

        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(0.5f);
            _uIManager.ActivatePanel(_uIManager.GameOverPanel);
            yield break;
        }

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void AddScore()
        {
            _currentScore++;
            UpdateBestScore();
            _uIManager.SetScoreText(_uIManager.CurrentScoreText, _currentScore);
        }

        void UpdateBestScore()
        {
            if (_currentScore > PlayerPrefs.GetInt("BestScore"))
            {
                PlayerPrefs.SetInt("BestScore", _currentScore);
                _uIManager.SetScoreText(_uIManager.BestScoreText, _bestScore);
            }
        }
    }
}