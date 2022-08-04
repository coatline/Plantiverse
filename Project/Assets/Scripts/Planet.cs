using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    SpriteRenderer sr;

    public List<Plant> plants;

    public int plantNum;

    void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();

        float randRed = Random.Range(0, 1f);
        float randBlue = Random.Range(0, 1f);
        float randGreen = Random.Range(0, 1f);

        sr.color = new Color(randRed, randBlue, randGreen);

        var size = Random.Range(.5f, 4f);

        plantNum = Random.Range(0, 3);

        transform.localScale = new Vector3(size, size, 1);

    }

    private void Update()
    {
        var field = transform.Find("GravityField");
        if(field == null)
        {
            Destroy(gameObject);
        }
    }

    public void AddPlant(Plant newPlant)
    {   
        plants.Add(newPlant);
    }

}
