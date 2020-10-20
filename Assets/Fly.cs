using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float velocity = 2.25f;
    private Rigidbody2D rb;
    private GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.flyLitteBird();
    }

    /**
    * JUMP MY LITTLE FRIEND
    **/
    private void flyLitteBird()
    {
        if (Input.GetMouseButtonDown(0)) {
            this.rb.velocity = Vector2.up * this.velocity;
            this.transformUp();
        } else {
            this.transformDown();
        }
    }

    private void transformUp()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward  * 20);
    }

    private void transformDown()
    {
        if (rb.velocity.y < -0.5f) {
            transform.rotation = Quaternion.Euler(Vector3.forward  * -20);
        }
    }
}
