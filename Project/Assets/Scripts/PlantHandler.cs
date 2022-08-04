using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{

    public int plantNum = 100;

    public List<Plant> plants;

    private void Awake()
    {
        plants = new List<Plant>();

        for (int i = 0; i < plantNum; i++)
        {
            PlantGenerator.I.CreatePlant(transform);
            plants.Add(PlantGenerator.I.plant);
        }

    }




    const string GOB_NAME = "PlantHandler";

    static PlantHandler instance;

    public static PlantHandler I
    {
        get
        {
            if (instance == null)
            {
                var gob = new GameObject(GOB_NAME);
                gob.AddComponent<PlantHandler>();
            }

            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }
}

