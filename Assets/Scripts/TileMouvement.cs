using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMouvement : MonoBehaviour
{

    [SerializeField] private float minX = -5.6f;
    [SerializeField] private float minY = -2.0f;
    [SerializeField] private float maxX = 5.6f;
    [SerializeField] private float maxY = 2.0f;
    [SerializeField] private float zAxis = 99.0f;

    private readonly float minXDecalage = -1f;
    private readonly float minYDecalage = -1f;
    private readonly float maxXDecalage = 1f;
    private readonly float maxYDecalage = 1f;

    private float xAxis;
    private float yAxis;
    private float xAxisChild;
    private float yAxisChild;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("X : " + Random.Range(minX, maxX));
        //Debug.Log("Y : " + Random.Range(minY, maxY));
        xAxis = Random.Range(minX, maxX);
        yAxis = Random.Range(minY, maxY);
        transform.position = new Vector3(xAxis, yAxis, zAxis);

        xAxisChild = Random.Range(minXDecalage, maxXDecalage);
        yAxisChild = Random.Range(minYDecalage, maxYDecalage);

        if(xAxisChild >= 0.0f)
        {
            xAxisChild += 1.0f;
        }
        else
        {
            xAxisChild -= 1.0f;
        }

        if(yAxisChild >= 0.0f) 
        {
            yAxisChild += 1.0f; 
        }
        else
        { 
            yAxisChild -= 1.0f; 
        }

        transform.GetChild(0).transform.position = new Vector3(xAxis + xAxisChild, yAxis + yAxisChild, zAxis);

        StartCoroutine(1f.Tweeng((p) => transform.GetChild(0).transform.position = p, transform.GetChild(0).transform.position, transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.GetChild(0).transform.position, transform.position);
        //Debug.Log(distance);

        if (distance < 0.01f)
        {
            TakingDamage(10.0f);
            //fail sound
            Destroy(gameObject);
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
}
