using UnityEngine;
using UnityEngine.UI; //Activa el codigo de la UI
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static float velocidad;
    public int puntos;
    public TMP_Text marcadorpuntos;
    private Rigidbody2D rb;

    //[RequireComponent(typeof(Rigidbody2D))]

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        velocidad = 3;
        puntos = 0;
        

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

        marcadorpuntos.text = "Points: " + puntos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Damage"))
        {
            Player.velocidad = (velocidad * 0);
            Invoke("gameover", 1);
            //Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Puntos"))
        {

            Player.velocidad = (float)(velocidad + 0.2);
            print(velocidad);
            puntos = puntos + 1;
            

        }

    }



    void gameover()
    {

        SceneManager.LoadScene(0);

    }

}
