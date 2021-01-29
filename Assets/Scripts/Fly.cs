using System;
using TMPro;
using Services;
using UnityEngine;

namespace Scripts
{
    public class Fly : MonoBehaviour
    {
        public Sprite jump;
        public Sprite fall;
        private SpriteRenderer _SpriteRenderer;
        private AudioSource jumpSound;

        private Rigidbody2D _rb;

        //private Animator _anim;
        private const string FlyAnimation = "isFlying";

        public GameManager gameManager;
        private float velocity = 1.75f;

        // Start is called before the first frame update
        private void Start()
        {
            _SpriteRenderer = GetComponent<SpriteRenderer>();
            jumpSound = GetComponent<AudioSource>();
            jumpSound.volume = .1f;
            _rb = GetComponent<Rigidbody2D>();
            //_anim = GetComponent<Animator>();
            velocity *= DifficultyService.getDifficultyVelocityMultiplier();
        }

        // Update is called once per frame
        private void Update()
        {
            CatchFlyAction();
        }

        private void CatchFlyAction()
        {
            if (Time.timeScale == 0) return;
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
                _rb.velocity = Vector2.up * velocity;
                TransformUp();
                _SpriteRenderer.sprite = jump;
                jumpSound.Play();
            }
            else {
                TransformDown();
            }
        }

        private void TransformUp()
        {
            //_anim.SetBool(FlyAnimation, true);
            transform.rotation = Quaternion.Euler(Vector3.forward * 20);
        }

        private void TransformDown()
        {
            if (!(_rb.velocity.y < -0.5f)) return;
            //_anim.SetBool(FlyAnimation, false);
            transform.rotation = Quaternion.Euler(Vector3.forward * -20);
            _SpriteRenderer.sprite = fall;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            gameManager.GameOver();
        }
    }
}