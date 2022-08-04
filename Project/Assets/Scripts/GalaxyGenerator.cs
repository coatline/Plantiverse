using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour
{
    [SerializeField] Planet planetPrefab;
    List<Planet> planets;

    int planetNum;

    void Start()
    {
        planets = new List<Planet>();

        planetNum = Random.Range(2, 9);

        for (int i = 0; i < planetNum; i++)
        {
            var randPoint = Random.Range(0, transform.childCount);

            if (!transform.GetChild(randPoint).CompareTag("SpawnPoint"))
            {
                i++;
            }
            else
            {
                var newPlanet = Instantiate(planetPrefab, transform.GetChild(randPoint).transform.position, Quaternion.identity);

                //Destroy(transform.GetChild(randPoint).gameObject);

                planets.Add(newPlanet);
            }

        }

        for (int i = 0; i < planets.Count; i++)
        {
            planets[i].transform.SetParent(transform);

            //var spawnPoint = Random.Range(0, planets[i].transform.childCount);
            //Destroy(planets[i].transform.GetChild(spawnPoint).gameObject);

            for (int x = 0; x < planets[i].plantNum; x++)
            {
                var rand = Random.Range(0, PlantHandler.I.plants.Count);
                planets[i].plants.Add(PlantHandler.I.plants[rand]);
            }
        }
    }

}
