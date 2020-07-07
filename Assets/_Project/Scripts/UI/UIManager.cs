using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject _gameOverPanel;
        [SerializeField] TextMeshProUGUI _currentScoreText;
        [SerializeField] TextMeshProUGUI _bestScoreText;

        public GameObject GameOverPanel { get => _gameOverPanel; }
        public TextMeshProUGUI CurrentScoreText { get => _currentScoreText; set => _currentScoreText = value; }
        public TextMeshProUGUI BestScoreText { get => _bestScoreText; set => _bestScoreText = value; }

        public void SetScoreText(TextMeshProUGUI textToUpdate, int scoreToSet) => textToUpdate.text = scoreToSet.ToString();

        public void ActivatePanel(GameObject panelToActivate) => panelToActivate.SetActive(true);
    }
}