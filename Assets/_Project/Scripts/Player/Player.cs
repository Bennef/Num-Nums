using Scripts.Core;
using Scripts.Inputs;
using UnityEngine;

namespace Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject _deathParticles;
        float _angle = 0;
        int _xSpeed = 3;
        int _ySpeed = 2;
        Vector2 _pos;
        bool _isDead;
        Rigidbody2D _rb;
        GameManager _gameManager;
        InputHandler _inputHandler;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _gameManager = FindObjectOfType<GameManager>();
            _inputHandler = FindObjectOfType<InputHandler>();
        }

        void Update()
        {
            if (!_isDead)
            {
                MovePLayer();
                GetInput();
            }
        }

        private void GetInput()
        {
            if (_inputHandler.GetForwardButton() || _inputHandler.GetTouch())
            {
                _rb.AddForce(new Vector2(0, _ySpeed));
            }
            else
            {
                if (_rb.velocity.y > 0)
                {
                    _rb.AddForce(new Vector2(0, -_ySpeed));
                }
                else
                {
                    _rb.velocity = new Vector2(_rb.velocity.x, 0);
                }
            }
        }

        private void MovePLayer()
        {
            _pos = transform.position;
            _pos.x = Mathf.Cos(_angle) * 2;
            transform.position = _pos;
            _angle += Time.deltaTime * _xSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Dead();
            }
            else if (collision.gameObject.CompareTag("Item"))
            {
                _gameManager.AddScore();
            }
        }

        private void Dead()
        {
            _isDead = true;
            Instantiate(_deathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            _gameManager.CallGameOver();
        }
    }
}