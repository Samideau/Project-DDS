using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject redTiles;
    [SerializeField] private GameObject blueTiles;
    [SerializeField] private GameObject greenTiles;
    [SerializeField] private GameObject yellowTiles;

    private GameObject healthBar;
    private GameObject healthBarSlider;
    private GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(0).transform.GetChild(0).gameObject;
        healthBarSlider = healthBar.transform.GetChild(0).gameObject;
        score = transform.GetChild(0).transform.GetChild(1).gameObject;

        GameManager.playerHealth = 100.0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.GetComponent<Slider>().value = GameManager.playerHealth;
        score.transform.GetChild(0).GetComponent<TMP_Text>().text = GameManager.score.ToString();

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //ROUGE 
        {
            Debug.Log("Rouge");
            OnLeftArrowPressed();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) //BLEU
        {
            Debug.Log("Bleu");
            OnRightArrowPressed();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) //VERT
        {
            Debug.Log("Vert");
            OnUpArrowPressed();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) //JAUNE
        {
            Debug.Log("Jaune");
            OnDownArrowPressed();
        }
    }

    private void TakingDamage(float damage)
    {
        if (GameManager.playerHealth - damage <= 0.0f)
        {
            GameManager.playerHealth = 0.0f;
        }
        else
        {
            GameManager.playerHealth -= damage;
        }
        
    }

    private void GainLife(float amount)
    {
        if(GameManager.playerHealth + amount >= 100.0f)
        {
            GameManager.playerHealth = 100.0f;
        }
        else
        {
            GameManager.playerHealth += amount;
        }
    }

    private void OnLeftArrowPressed()
    {
        if(redTiles.transform.childCount > 0)
        {
            Transform tileStart = redTiles.transform.GetChild(0).transform.GetChild(0);
            Transform tileEnd = redTiles.transform.GetChild(0).transform.GetChild(1);
            int gainScore = 0;
            float lifeGain = 0.0f;

            float distance = Vector2.Distance(tileStart.position, tileEnd.position);
            //Debug.Log(distance);

            if (distance < 0.5f) //ok
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.4f) //bien
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.3f) //super
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.2f) //excellent
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.1f) //parfait
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            GainLife(lifeGain);
            GainScore(gainScore);

            if(gainScore == 0)
            {
                TakingDamage(10.0f);
            }

            Destroy(redTiles.transform.GetChild(0).gameObject);
        }
        else
        {
            TakingDamage(10.0f);
        }
    }

    private void OnRightArrowPressed()
    {
        if (blueTiles.transform.childCount > 0)
        {
            Transform tileStart = blueTiles.transform.GetChild(0).transform.GetChild(0);
            Transform tileEnd = blueTiles.transform.GetChild(0).transform.GetChild(1);
            int gainScore = 0;
            float lifeGain = 0.0f;

            float distance = Vector2.Distance(tileStart.position, tileEnd.position);
            //Debug.Log(distance);

            if (distance < 0.5f) //ok
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.4f) //bien
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.3f) //super
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.2f) //excellent
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.1f) //parfait
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            GainLife(lifeGain);
            GainScore(gainScore);

            if (gainScore == 0)
            {
                TakingDamage(10.0f);
            }

            Destroy(blueTiles.transform.GetChild(0).gameObject);
        }
        else
        {
            TakingDamage(10.0f);
        }
    }

    private void OnUpArrowPressed()
    {
        if (greenTiles.transform.childCount > 0)
        {
            Transform tileStart = greenTiles.transform.GetChild(0).transform.GetChild(0);
            Transform tileEnd = greenTiles.transform.GetChild(0).transform.GetChild(1);
            int gainScore = 0;
            float lifeGain = 0.0f;

            float distance = Vector2.Distance(tileStart.position, tileEnd.position);
            //Debug.Log(distance);

            if (distance < 0.5f) //ok
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.4f) //bien
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.3f) //super
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.2f) //excellent
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.1f) //parfait
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            GainLife(lifeGain);
            GainScore(gainScore);

            if (gainScore == 0)
            {
                TakingDamage(10.0f);
            }

            Destroy(greenTiles.transform.GetChild(0).gameObject);
        }
        else
        {
            TakingDamage(10.0f);
        }
    }

    private void OnDownArrowPressed()
    {
        if (yellowTiles.transform.childCount > 0)
        {
            Transform tileStart = yellowTiles.transform.GetChild(0).transform.GetChild(0);
            Transform tileEnd = yellowTiles.transform.GetChild(0).transform.GetChild(1);
            int gainScore = 0;
            float lifeGain = 0.0f;

            float distance = Vector2.Distance(tileStart.position, tileEnd.position);
            //Debug.Log(distance);

            if (distance < 0.5f) //ok
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.4f) //bien
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.3f) //super
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.2f) //excellent
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            if (distance < 0.1f) //parfait
            {
                lifeGain += 1.0f;
                gainScore += 5;
            }

            GainLife(lifeGain);
            GainScore(gainScore);

            if (gainScore == 0)
            {
                TakingDamage(10.0f);
                //Fail Sound
            }
            else
            {
                //Clic sound
            }

            Destroy(yellowTiles.transform.GetChild(0).gameObject);
        }
        else
        {
            TakingDamage(10.0f);
        }
    }

    private void GainScore(int score)
    {
        GameManager.score += score;
    }
}
