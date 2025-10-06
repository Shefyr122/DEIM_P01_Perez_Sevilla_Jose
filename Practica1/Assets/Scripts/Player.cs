using UnityEngine;

public class Player : MonoBehaviour
{

    public int velocidad;
    Rigidbody2D rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        velocidad = 3;

    }

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidad, rb.linearVelocity.y);

    }
}
