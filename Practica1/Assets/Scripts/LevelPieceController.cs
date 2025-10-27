using UnityEngine;

public class LevelPieceController : MonoBehaviour
{
    public int velocidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        velocidad = 4;

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, velocidad * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("WorldDestroyer"))
        {

            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {

            LevelGenerator.AddNewPiece();
            

        }

    }

}
