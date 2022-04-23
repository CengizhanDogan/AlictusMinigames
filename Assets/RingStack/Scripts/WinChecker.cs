using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            upPos.y += 0.8f;
            transform.DOMove(upPos, 0.5f).OnComplete(() =>
            {
                transform.DOMove(startPos, 0.25f).SetEase(Ease.OutBounce);
            });
        }
    }
}
