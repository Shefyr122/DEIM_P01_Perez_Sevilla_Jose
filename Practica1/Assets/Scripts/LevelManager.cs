using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Image fadeScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fadeScreen.DOFade(0, 1);
    }

    
}
