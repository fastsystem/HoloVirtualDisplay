using UnityEngine;
using System.Collections;
using System;
 
public class OggVideoStreamingTexture : MonoBehaviour {
 
    public string OggVideoURL;
    public GameObject GameobjectForVideoTexture;
 
    void Start () {
        StreamPlayVideoAsTexture();
    }
 
    public void StreamPlayVideoAsTexture()
    {
        if (this.OggVideoURL!="") {
            StartCoroutine(StartStream(this.OggVideoURL));
        }
    }
 
    protected IEnumerator StartStream(String url)
    {
         MovieTexture movieTexture;
 
        //エラー2つ出るが無視してOK
        //https://issuetracker.unity3d.com/issues/movietexture-fmod-error-when-trying-to-play-video-using-www-class
        Debug.Log("Ignore following two errors");
        WWW videoStreamer = new WWW(url);
        movieTexture = videoStreamer.GetMovieTexture();
        while (!movieTexture.isReadyToPlay)
        {
            yield return 0;
        }
        GameobjectForVideoTexture.GetComponent<Renderer>().material.mainTexture = movieTexture;
        // AudioSource audioSource = GameobjectForVideoTexture.AddComponent<AudioSource>();
        // audioSource.clip = movieTexture.audioClip;
        movieTexture.Play();
        // audioSource.Play();
    }
 
}