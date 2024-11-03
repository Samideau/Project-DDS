using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject hudCanvas;
    [SerializeField] private PlayerManager player;

    [SerializeField] private GameObject redTileSpawner;
    [SerializeField] private GameObject blueTileSpawner;
    [SerializeField] private GameObject greenTileSpawner;
    [SerializeField] private GameObject yellowTileSpawner;

    [SerializeField] private GameObject redTilePrefab;
    [SerializeField] private GameObject blueTilePrefab;
    [SerializeField] private GameObject greenTilePrefab;
    [SerializeField] private GameObject yellowTilePrefab;

    private bool hasSongStarted = false;
    private int typeTile = -1;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(initGame());
        InvokeRepeating("SpawnerTiles", 1.1f, 1.0f);
    }

    IEnumerator initGame()
    {
        yield return new WaitForSecondsRealtime(1.1f);
        hasSongStarted = true;   
    }

    private void SpawnerTiles() 
    {
        int tmpValue = Random.Range(0, 4);
        
        if(tmpValue == typeTile) //Je ne veux pas 2x la même tile d'affilé, on verra si on garde ça
        {
            if(tmpValue == 3)
            {
                tmpValue--;
            }
            else
            {
                tmpValue++;
            }
        }

        typeTile = tmpValue;
        Debug.Log(typeTile);

        switch(typeTile)
        {
            case 0:
                SpawnRedTile();
                break;
            case 1:
                SpawnBlueTile();
                break;
            case 2:
                SpawnGreenTile();
                break;
            case 3:
                SpawnYellowTile();
                break;
            default:
                Debug.Log("SPAWNERTILE DEFAULT VALUE REACHED");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if((!GetComponent<AudioSource>().isPlaying && hasSongStarted) || player.playerHealth <= 0.0f)
        {
            GameOver();
        }*/
    }

    private void GameOver()
    {
        //FIN DE PARTIE
        Time.timeScale = 0.0f;
        hudCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    private void SpawnRedTile()
    {
        Instantiate(redTilePrefab, redTileSpawner.transform);
    }

    private void SpawnBlueTile()
    {
        Instantiate(blueTilePrefab, blueTileSpawner.transform);
    }

    private void SpawnGreenTile()
    {
        Instantiate(greenTilePrefab, greenTileSpawner.transform);
    }

    private void SpawnYellowTile()
    {
        Instantiate(yellowTilePrefab, yellowTileSpawner.transform);
    }
}
