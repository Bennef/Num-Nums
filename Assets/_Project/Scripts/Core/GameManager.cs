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

        private void Start()
        {
            _currentScore = 0;
            _uIManager = FindObjectOfType<UIManager>();
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
            _uIManager.SetScoreText(_currentScore);
        }
    }
}