using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class SetBackgroundMusic : MonoBehaviour
{
    private const string PREFIXPATH = "Musics/";
    

    void Start()
    {
        //StartCoroutine(LoadSongCoroutine(GameManager.songPath));
        StartCoroutine(StartSong(1.0f));
    }

    IEnumerator StartSong(float timer)
    {
        yield return new WaitForSeconds(timer);
        Debug.Log(PREFIXPATH + GameManager.songName);
        AudioClip audioClip = Resources.Load<AudioClip>(PREFIXPATH + GameManager.songName);
        GetComponent<AudioSource>().PlayOneShot(audioClip, 0.2f);
    }

    /*IEnumerator LoadSongCoroutine(string path)
    {
        Debug.Log(Application.dataPath + PREFIXPATH + path);
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + PREFIXPATH + path, AudioType.WAV))
        {
            ((DownloadHandlerAudioClip)www.downloadHandler).streamAudio = true;
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
                GameManager.ReturnToMainMenu();
                yield break;
            }

            audioSource.PlayOneShot(DownloadHandlerAudioClip.GetContent(www));

            DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)www.downloadHandler;

            if (dlHandler.isDone)
            {
                AudioClip audioClip = dlHandler.audioClip;

                if (audioClip != null)
                {
                    

                    Debug.Log("Playing song using Audio Source!");

                }
                else
                {
                    Debug.Log("Couldn't find a valid AudioClip :(");
                }
            }
            else
            {
                Debug.Log("The download process is not completely finished.");
            }
        }
    }*/
}
