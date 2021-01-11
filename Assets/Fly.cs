using System;
using TMPro;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private const string FlyAnimation = "isFlying";

    public GameManager gameManager;
    private float velocity = 1.75f;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        CatchFlyAction();
    }
    private void CatchFlyAction()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
            _rb.velocity = Vector2.up * velocity;
            TransformUp();
        } else {
            TransformDown();
        }
    }

    private void TransformUp()
    {
        _anim.SetBool(FlyAnimation, true);
        transform.rotation = Quaternion.Euler(Vector3.forward  * 20);
    }

    private void TransformDown()
    {
        if (_rb.velocity.y < -0.5f) {
            _anim.SetBool(FlyAnimation, false);
            transform.rotation = Quaternion.Euler(Vector3.forward  * -20);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameManager.GameOver();
    }
}
