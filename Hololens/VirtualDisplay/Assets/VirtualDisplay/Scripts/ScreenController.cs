using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    void Start ()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        this.StartAnimationShow();
	}
	
	void Update ()
    {
	}

    private void StartAnimationShow(int stage = 0)
    {
        switch (stage)
        {
            case 0: // 拡大
                iTween.MoveTo(gameObject, iTween.Hash("z", transform.position.z - 0.2, "time", 2.0f, "isLocal", true));
                iTween.ScaleTo(gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "time", 2.0f, "isLocal", true));
                break;
        }
    }
}
