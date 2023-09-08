using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Vector3 targetPos;
    public Vector3 originalPos;
    public Vector3 targetSize;
    public GameObject targetGameObj;
    public float speed;
    public float fadeDuration;
    public Image targetImage;
    public Vector3 targetRotation;
    public float rotateDuration;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SequenceTween()
    {
        Sequence sequence = DOTween.Sequence();
        //1st task
        sequence.Append(targetGameObj.transform.DOLocalMove(targetPos, speed).SetEase(Ease.Linear));
        //Delay for 2nd task
        sequence.AppendInterval(2);
        //2nd task
        sequence.Append(targetGameObj.transform.DOLocalMove(originalPos, speed).SetEase(Ease.Linear));
        //Delay for 3rd task
        sequence.AppendInterval(2);
        //3rd task
        sequence.Append(targetGameObj.transform.DOScale(Vector3.zero, speed).SetEase(Ease.Linear));
    }

    public void MoveTween()
    {
        targetGameObj.transform.DOLocalMove(targetPos, speed).SetEase(Ease.Linear).OnComplete(()=> ReturnPos());
    }

    public void ReturnPos()
    {
        targetGameObj.transform.DOLocalMove(originalPos, speed).SetEase(Ease.Linear);
    }

    public void ScaleTween()
    {
        targetGameObj.transform.DOScale(Vector3.zero, speed).SetEase(Ease.Linear);
    }

    public void FadeTween()
    {
        targetImage.DOFade(0, fadeDuration);
    }

    public void Rotation()
    {
        targetImage.transform.DOLocalRotate(targetRotation, rotateDuration).SetEase(Ease.Linear).SetLoops(10, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
