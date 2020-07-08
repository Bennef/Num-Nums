using Scripts.Cameras;
using Scripts.Core;
using Scripts.Inputs;
using Scripts.UI;
using UnityEngine;

namespace Scripts.Actors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject _deathParticles, _itemEffect;
        [SerializeField] float _maxVelocity;
        [SerializeField] float velocityFactor = 0.01f;
        [SerializeField] float dragFactor = 0.5f;
        [SerializeField] float maxVelocity = 6f;
        Vector3 velocity = Vector3.zero;

        float _angle = 0;
        int _xSpeed = 3;
        int _ySpeed = 2;
        Vector3 _pos;

        //Rigidbody _rb;
        GameManager _gameManager;
        InputHandler _inputHandler;
        BackgroundColor _backgroundColor;
        CameraShake _cameraShake;

        SpriteRenderer _spriteRenderer;

        public bool IsDead { get; set; }

        void Awake()
        {
            //_rb = GetComponent<Rigidbody>();
            _gameManager = FindObjectOfType<GameManager>();
            _inputHandler = FindObjectOfType<InputHandler>();
            _backgroundColor = FindObjectOfType<BackgroundColor>();
            _cameraShake = FindObjectOfType<CameraShake>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void FixedUpdate()
        {
            if (!IsDead)
            {
                MovePLayer();
            }
        }

        void MovePLayer()
        {
            SetXelocity();
            SetYVelocity();
            LookInDirectionOfTravel();
            transform.position = _pos;
        }

        private void SetXelocity()
        {
            _pos = transform.position;
            _pos.x = Mathf.Cos(_angle) * 2;
            _angle += Time.deltaTime * _xSpeed;
        }

        private void SetYVelocity()
        {
            if (_inputHandler.GetForwardButton() || _inputHandler.GetTouch())
            {
                velocity += new Vector3(0, 1, 0) * velocityFactor * 1000;
            }

            velocity *= dragFactor;
            velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
            _pos.y += velocity.y * Time.deltaTime; 
        }

        void LookInDirectionOfTravel()
        {
            Vector3 direction = (_pos - transform.position).normalized;
            Quaternion look = Quaternion.LookRotation(direction, Vector3.back);
            transform.rotation = look;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Dead();
            }
            else if (other.gameObject.CompareTag("Item"))
            {
                GetItem(other);
            }
        }

        void GetItem(Collider2D other)
        {
            _backgroundColor.SetBackgroundColor();
            Destroy(Instantiate(_itemEffect, other.transform.position, Quaternion.identity), 0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            _gameManager.AddScore();
        }

        void Dead()
        {
            IsDead = true;
            _cameraShake.CallShake(); 
            Destroy(Instantiate(_deathParticles, transform.position, Quaternion.identity), 0.5f);
            _spriteRenderer.enabled = false;
            //_rb.velocity = new Vector2(0, 0);
            //_rb.isKinematic = true;
            _gameManager.CallGameOver();
        }
    }
}