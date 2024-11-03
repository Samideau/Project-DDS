using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public static class GameManager
{
    private static string filePath = Application.dataPath + "/JSON/";
    
    private const string MAINMENUNAME = "MainMenu";
    private const string GAMENAME = "DDS";
    
    public static int score = 0;
    public static float playerHealth;

    public static string urlImagePath = "";
    public static string songName = "";

    public static List<string> GetAllJsonFilesName()
    {
        JSONReader.GetAllJsonFiles();
        return null;
    }
    public static void Replay()
    {
        NewGame();
        SceneManager.LoadScene(GAMENAME);
    }

    private static void NewGame()
    {
        score = 0;
    }

    public static void PlayGame(string jsonSongPath)
    {
        JSONReader jsonreader = JSONReader.ReadJson(jsonSongPath);
        Debug.Log(jsonreader.urlImagePath);
        if (jsonreader.urlImagePath != null && jsonreader.songName != null && jsonreader.urlImagePath.Length > 0 && jsonreader.songName.Length > 0) 
        {
            urlImagePath = jsonreader.urlImagePath;
            songName = jsonreader.songName;

            SceneManager.LoadScene(GAMENAME);
        }
        else
            Debug.Log("Fichier json non-conforme, impossible de lancer la musique");
        
    }

    public static void ReturnToMainMenu()
    {
        SceneManager.LoadScene(MAINMENUNAME);
    }

}
