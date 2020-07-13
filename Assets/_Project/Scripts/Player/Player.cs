using Scripts.Audio;
using Scripts.Cameras;
using Scripts.Core;
using Scripts.Inputs;
using Scripts.UI;
using UnityEngine;

namespace Scripts.Actors
{
    public class Player : MonoBehaviour
    {
        [Header("Particle Effects")]
        [SerializeField] GameObject _deathParticles;
        [SerializeField] GameObject _getItemEffect;
        [Header("Player Movement")]
        [SerializeField] float _velocityFactor = 0.5f;
        [SerializeField] float _dragFactor = 0.925f;
        [SerializeField] float _maxVelocity = 6f;
        Vector3 _velocity = Vector3.zero;

        float _angle = 0;
        int _xSpeed = 3;
        Vector3 _pos;

        GameManager _gameManager;
        InputHandler _inputHandler;
        BackgroundColor _backgroundColor;
        CameraShake _cameraShake;
        AudioManager _audioManager;
        Animator _animator;

        public bool IsDead { get; set; }

        void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _inputHandler = FindObjectOfType<InputHandler>();
            _backgroundColor = FindObjectOfType<BackgroundColor>();
            _cameraShake = FindObjectOfType<CameraShake>();
            _audioManager = FindObjectOfType<AudioManager>();
            _animator = GetComponentInChildren<Animator>();
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
                _velocity += Vector3.up * _velocityFactor;
            }

            _velocity *= _dragFactor;
            _velocity = Vector3.ClampMagnitude(_velocity, _maxVelocity);
            _pos.y += _velocity.y * Time.deltaTime; 
        }

        void LookInDirectionOfTravel()
        {
            Vector3 direction = (_pos - transform.position).normalized;
            Quaternion look = Quaternion.LookRotation(direction, Vector3.back);
            transform.rotation = look;
        }

        void OnTriggerEnter(Collider other)
        {if (!IsDead)
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
        }

        void GetItem(Collider other)
        {
            _backgroundColor.SetBackgroundColor();
            _audioManager.PlayRandomSound(_audioManager.CatSounds);
            Destroy(Instantiate(_getItemEffect, other.transform.position, Quaternion.identity), 0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            _gameManager.AddScore();
        }
        
        void Dead()
        {
            IsDead = true;
            _animator.SetBool("isCrashed", true);
            _audioManager.PlaySound(_audioManager.Crash);
            _cameraShake.CallShake(); 
            Destroy(Instantiate(_deathParticles, transform.position, Quaternion.identity), 0.5f);
            _gameManager.CallGameOver();
        }
    }
}