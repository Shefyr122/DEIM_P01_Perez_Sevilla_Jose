using UnityEngine;
using UnityEngine.UI; //Activa el codigo de la UI
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using DG.Tweening;


public class Player : MonoBehaviour
{

    public static float velocidad;
    public int score;
    public int puntos;
    public TMP_Text marcadorpuntos;
    public TMP_Text marcadorrecord;
    private Rigidbody2D rb;
    public BoxCollider2D box;
    public int salto;
    private bool saltando;

    public ParticleSystem particle1;
    public ParticleSystem particle2;

    public GameObject Snow;
    public GameObject SnowL;
    public GameObject SnowR;
    public GameObject SnowTrailL;
    public GameObject SnowTrailR;
    public Transform sombra;

    public Transform prota;



    //[RequireComponent(typeof(Rigidbody2D))]

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        velocidad = 3;
        puntos = 0;
        saltando = false;

    }

    // Update is called once per frame
    void Update()
    {
        //FingerMovement();
        ScreenBordersMovement();

        //Cambia la Simulation speed de las particulas a la del jugador
        ParticleSystem.MainModule mainModule1 = particle1.main;
        mainModule1.simulationSpeed = velocidad;

        ParticleSystem.MainModule mainModule2 = particle2.main;
        mainModule2.simulationSpeed = velocidad;

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

            marcadorpuntos.DOColor(Color.lightYellow, 1).OnComplete(() => {
                marcadorpuntos.DOColor(Color.black, 1);
            });
            Player.velocidad = (float)(velocidad + 0.2);
            puntos++;
            

        }

        if (collision.gameObject.CompareTag("Salto"))
        {
            Snow.SetActive(false);
            SnowTrailL.SetActive(false);
            SnowTrailR.SetActive(false);
            saltando = true;
            rb.linearVelocityX = 0;
            box.enabled = false;
            prota.DOScale(2, salto).OnComplete(() =>
            {
                prota.DOScale(1, salto).OnComplete(() =>
                {
                    box.enabled = true;
                    rb.linearVelocityX = velocidad;
                    saltando = false;
                    Snow.SetActive(true);
                    SnowTrailL.SetActive(true);
                    SnowTrailR.SetActive(true);

                });
                
            });

            sombra.DOScale(1, salto).OnComplete(() =>
            {
                sombra.DOScale(1, salto);
            });
            sombra.DOMoveY(-1, salto).OnComplete(() =>
            {
                sombra.DOMoveY(+3, salto);
            });

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
        if (Input.touchCount > 0 && saltando == false)
        {
            float touchSceenPosition = Input.touches[0].position.x;
            float screenCenter = Screen.width / 2;
            if (touchSceenPosition > screenCenter)
            {
                rb.linearVelocityX = velocidad;
                Snow.SetActive(false);
                SnowR.SetActive(false);
                SnowL.SetActive(true);

            }
            else
            {
                rb.linearVelocityX = -velocidad;
                Snow.SetActive(false);
                SnowR.SetActive(true);
                SnowL.SetActive(false);
            }


        }
        else
        {
            rb.linearVelocityX = 0;
            Snow.SetActive(true);
            SnowR.SetActive(false);
            SnowL.SetActive(false);
        }
    }

}
