using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SetBackGroundImage : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Sprite img;
    [SerializeField] private GameObject backgroundImage;
    [SerializeField] private Sprite defaultSprite;
    static private Sprite mySprite;

    void Start()
    {
        StartCoroutine(GetTexture(GameManager.urlImagePath));
        /*JSONReader jsonReader = JSONReader.ReadJson("{ \"urlImagePath\": \"https://c4.wallpaperflare.com/wallpaper/317/238/475/house-dragonmaid-kitchen-dragonmaid-anime-anime-girls-yu-gi-oh-hd-wallpaper-preview.jpg\"}");

        Debug.Log(jsonReader.urlImagePath);
        StartCoroutine(GetTexture(jsonReader.urlImagePath));*/

        //GetComponent<UnityEngine.UI.Image>().sprite = img; -> Passer en param
    }

    IEnumerator GetTexture(string path)
    {

        if(path.IndexOf("http") != -1) 
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(path);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                GameManager.ReturnToMainMenu();
            }
            else
            {
                //yield return new WaitForSecondsRealtime(1.0f);

                Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                backgroundImage.GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Imgs/" + path);// -> doit se trouver dans le dossier Resources
        }

        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
