using Scripts.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        int _currentScore;
        UIManager _uIManager;

        void Start()
        {
            _currentScore = 0;
            _uIManager = FindObjectOfType<UIManager>();
            _uIManager.SetScoreText(_uIManager.BestScoreText, PlayerPrefs.GetInt("BestScore", 0));
        }

        public void CallGameOver() => StartCoroutine(GameOver());

        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(0.5f);
            _uIManager.ActivatePanel(_uIManager.GameOverPanel);
            yield break;
        }

        IEnumerator Restart() 
        {
            yield return new WaitForSeconds(0.1f); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            yield break;
        }

        public void CallRestart() => StartCoroutine(Restart());

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
                _uIManager.SetScoreText(_uIManager.BestScoreText, PlayerPrefs.GetInt("BestScore"));
            }
        }
    }
}