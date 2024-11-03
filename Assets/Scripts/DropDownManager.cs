using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<string> listFilesSong = new();
    private TMP_Dropdown dropdown;

    void Start()
    {
        UpdateSongList();
    }

    public void UpdateSongList()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();
        listFilesSong = GameManager.GetAllJsonFilesName();
        //Debug.Log(listFilesSong.Count);
        string finalFile = "";
        foreach (string file in listFilesSong)
        {
            finalFile = file;
            finalFile = finalFile.Replace(Application.dataPath + "/JSON/", "");
            finalFile = finalFile.Replace(".json", "");
            if (finalFile.Length > 55)
            {
                finalFile = finalFile.Remove(52);
                finalFile += "...";
            }
                
            dropdown.options.Add(new TMP_Dropdown.OptionData(finalFile));
        }
    }

    public void onPlayPressed()
    {
        //Debug.Log(dropdown.options.IndexOf(dropdown.options[dropdown.value]));
        //Debug.Log(dropdown.options[dropdown.value].text);

        int indexSong = dropdown.options.IndexOf(dropdown.options[dropdown.value]);
        //Debug.Log(listFilesSong[indexSong]);
        GameManager.PlayGame(listFilesSong[indexSong]);
    }

    public void onHighScoresPressed()
    {
        //HighScores
    }
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
