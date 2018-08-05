using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour {

    private int urlIndex = 0;

    public List<string> Urls;

    public GameObject ScreenPrefab;

    public GameObject CreateScreen(Vector3 startPosition)
    {
        var gm = Instantiate(ScreenPrefab, startPosition, Quaternion.identity);
        gm.transform.localScale.Set(0, 0, 0);
        gm.GetComponent<OggVideoStreamingTexture>().OggVideoURL = Urls[GetNowUrlIndex()];
        return gm;
    }

    private int GetNowUrlIndex()
    {
        int now = urlIndex++;
        if (Urls.Count <= urlIndex)
            urlIndex = 0;
        return now;
    }
}
