using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{

    private static LevelGenerator instance;


    public List<GameObject> piece;

    private void Awake()
    {
        //Inicia el singleton
        instance = this;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddNewPiece()
    {

        Instantiate(instance.piece[Random.Range(0,instance.piece.Count)], new Vector3(0, -16, 0), Quaternion.identity);

    }




}
