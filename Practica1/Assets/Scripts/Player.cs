using UnityEngine;

public class Player : MonoBehaviour
{

    public int velocidad;
    private Rigidbody2D rb;

    //[RequireComponent(typeof(Rigidbody2D))]

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        velocidad = 3;

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.A));
        {

            transform.Translate(-velocidad * Time.deltaTime,0,0);

        }

        */

        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidad, rb.linearVelocity.y);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Damage"))
        {
            Destroy(gameObject);
        }

    }

}
