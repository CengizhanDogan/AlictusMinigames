using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour
{
    #region Singleton
    public static WinChecker Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public int correctCount;

    public void CheckIfWon()
    {
        if(correctCount >= 2)
        {
            Vector3 startPos = transform.position;
            Vector3 upPos = startPos;
            upPos.y += 1.5f;
            transform.DOMove(upPos, 0.5f).OnComplete(() =>
            {
                transform.DOMove(startPos, 0.25f).SetEase(Ease.OutBounce);
                StartCoroutine(ResetScene());
            });
        }
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(1f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
