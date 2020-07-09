using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Scripts.Core
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] GameObject _startButton, _blackFader;
        [SerializeField] AudioSource _catASrc;
        AudioSource _aSrc;

        void Start() => _aSrc = GetComponent<AudioSource>();

        public void CallLoadMethod() => StartCoroutine(LoadMainScene());

        IEnumerator LoadMainScene()
        {
            _startButton.SetActive(false);
            _blackFader.SetActive(true);
            _aSrc.Play();
            _animator.SetBool("hasStarted", true);
            yield return new WaitForSeconds(1.1f);
            _catASrc.Play();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(1);
            yield break;
        }
    }
}