using UnityEngine;
using UnityEngine.UI; //Activa el codigo de la UI
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{

    public static float velocidad;
    public int score;
    public int puntos;
    public TMP_Text marcadorpuntos;
    public TMP_Text marcadorrecord;
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
        //FingerMovement();
        ScreenBordersMovement();



        //rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocidad, rb.linearVelocity.y);
        /*if (Input.GetKey(KeyCode.A));
    {

        transform.Translate(-velocidad * Time.deltaTime,0,0);

    }

    */

        marcadorpuntos.text = "Points: " + puntos;
        marcadorrecord.text = "Record: " + PlayerPrefs.GetInt("score");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Damage"))
        {
            Player.velocidad = (velocidad * 0);
            Invoke("SaveScore", 0);
            Invoke("gameover", 1);
            //Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Puntos"))
        {

            Player.velocidad = (float)(velocidad + 0.2);
            puntos++;
            

        }

    }



    void gameover()
    {

        SceneManager.LoadScene(0);

    }


    void SaveScore()
    {

        if(puntos >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.SetInt("score", puntos);
        }

    }

    private void FingerMovement()
    {
        if (Input.touchCount > 0) //Comprueba si se toca la pantalla
        {
            float fingerMovementX = Input.touches[0].deltaPosition.x;
            //transform.Translate(fingerMovementX * SpeedTreeWindAsset * Time.deltaTime, 0, 0);
            rb.linearVelocityX = fingerMovementX*velocidad;

        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

    private void ScreenBordersMovement()
    {
        if (Input.touchCount > 0)
        {
            float touchSceenPosition = Input.touches[0].position.x;
            float screenCenter = Screen.width / 2;
            if (touchSceenPosition > screenCenter)
            {
                rb.linearVelocityX = velocidad;
            }
            else
            {
                rb.linearVelocityX = -velocidad;
            }


        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

}
