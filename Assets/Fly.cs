using UnityEngine;

public class Fly : MonoBehaviour
{
    public float velocity = 2.25f;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        CatchFlyAction();
    }
    private void CatchFlyAction()
    {
        if (Input.GetMouseButtonDown(0)) {
            _rb.velocity = Vector2.up * velocity;
            TransformUp();
        } else {
            TransformDown();
        }
    }

    private void TransformUp()
    {
        transform.rotation = Quaternion.Euler(Vector3.forward  * 20);
    }

    private void TransformDown()
    {
        if (_rb.velocity.y < -0.5f) {
            transform.rotation = Quaternion.Euler(Vector3.forward  * -20);
        }
    }
}
