using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        [SerializeField] TextMeshProUGUI _currentScoreText;

        public GameObject GameOverPanel { get => _gameOverPanel; }

        public void SetScoreText(int scoreToSet) => _currentScoreText.text = scoreToSet.ToString();

        public void ActivatePanel(GameObject panelToActivate) => panelToActivate.SetActive(true);
    }
}