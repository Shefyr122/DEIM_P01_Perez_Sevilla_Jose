using UnityEngine;

public class LevelPieceController : MonoBehaviour
{
    
    public float size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, Player.velocidad * Time.deltaTime, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("WorldDestroyer"))
        {

            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {

            LevelGenerator.AddNewPiece(transform.position - new Vector3 (0, size, 0));
            

        }

    }

}
