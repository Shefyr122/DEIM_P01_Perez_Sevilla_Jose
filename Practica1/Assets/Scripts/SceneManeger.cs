using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManeger : MonoBehaviour
{

    public RectTransform titulo;
    public Ease tituloease;

    public RectTransform startButton;
    public Ease startButtonEase;

    public RectTransform startButton2;
    public Ease startButtonEase2;
    public Image fadeScreen;

    public int tiempoAparicion;

    private void Start()
    {
        titulo.DOScale(10, tiempoAparicion).SetEase(tituloease).OnComplete(() =>
        {
            titulo.DOShakePosition(1, 20, vibrato: 20).SetLoops(-1);

            startButton.DOScale(10, tiempoAparicion).SetEase(startButtonEase).OnComplete(() =>
            {
                startButton.DOShakePosition(1, 20, vibrato: 20).SetLoops(-1);

                startButton2.DOScale(10, tiempoAparicion).SetEase(startButtonEase2).OnComplete(() =>
                {
                    startButton2.DOShakePosition(1, 20, vibrato: 20).SetLoops(-1);
                });
            });

        });

        
    }

    public void Jugar()
    {
        fadeScreen.DOFade(1, 2).OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
        

    }


}
