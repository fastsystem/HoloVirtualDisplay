using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusController : MonoBehaviour, IInputClickHandler
{
    ScreensManager screenManager;

    void Awake()
    {
        screenManager = FindObjectOfType<ScreensManager>();
    }

    void Start ()
    {
    }
	
	void Update ()
    {
        this.UpdateAnimationWaiting();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        this.StartAnimationFun();
    }

    private void UpdateAnimationWaiting()
    {
        //設定した速さで、Y軸に回転します。
        float speed = 10f;
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void StartAnimationFun(int stage = 0)
    {
        switch (stage)
        {
            case 0: // 拡大
                iTween.MoveTo(gameObject, iTween.Hash("y", 0.03, "time", 0.5f, "isLocal", true));
                iTween.ScaleTo(gameObject, iTween.Hash("x", 1.1, "y", 1.1, "z", 1.1, "time", 0.5f, "isLocal", true, "onComplete", "StartAnimationFun", "onCompleteParams", ++stage));
                break;

            case 1: // ディスプレイポップ
                screenManager.CreateScreen(this.gameObject.transform.position);
                this.StartAnimationFun(++stage);
                break;

            case 2: // 縮小
                iTween.MoveTo(gameObject, iTween.Hash("y", 0.0, "time", 0.3f, "isLocal", true));
                iTween.ScaleTo(gameObject, iTween.Hash("x", 1.0, "y", 1.0, "z", 1.0, "time", 0.3f, "isLocal", true, "onComplete", "StartAnimationFun", "onCompleteParams", ++stage));
                break;
        }
    }
}
