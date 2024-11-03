using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void onReplayPressed()
    {
        GameManager.Replay();
    }

    public void onMainMenuPressed()
    {
        GameManager.ReturnToMainMenu();
    }

    public void onQuitPressed()
    {
        Application.Quit();
    }
}
