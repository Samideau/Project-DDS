using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class JSONReader
{
    public string urlImagePath;
    public string songName;
    public List<string> jsonFiles;

    public static JSONReader ReadJson(string jsonPath)
    {
        string json = "";
        using (StreamReader sr = new StreamReader(jsonPath))
        {
            json = sr.ReadToEnd();
        }
        Debug.Log(json);
        return JsonUtility.FromJson<JSONReader>(json);
    }

    public static void GetAllJsonFiles()
    {
        CoroutineController.Start(FetchJSON());
    }

    static IEnumerator FetchJSON()
    {
        UnityWebRequest uwr = UnityWebRequest.Get("https://samido.coeprozi.ovh/DDS/getFiles.php");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            string jsonFile = uwr.downloadHandler.text;
            Debug.Log(jsonFile);
        }
    }
}
