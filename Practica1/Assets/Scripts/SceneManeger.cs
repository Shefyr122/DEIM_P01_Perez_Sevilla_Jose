using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManeger : MonoBehaviour
{

    public RectTransform startButton;
    public Ease startButtonEase;
    public Image fadeScreen;

    private void Start()
    {
        startButton.DOScale(20, 2).SetEase(startButtonEase).OnComplete(() =>
        {
            startButton.DOShakePosition(1, 100, vibrato:100).SetLoops(-1);
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
