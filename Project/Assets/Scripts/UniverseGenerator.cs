using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseGenerator : MonoBehaviour
{
    [SerializeField] GalaxyGenerator[] ggPrefabs;

    int yPos;
    int galaxyHeight = 19;

    private void Start()
    {
        var rand = Random.Range(0, ggPrefabs.Length);
        var newO = Instantiate(ggPrefabs[rand], new Vector3(0, yPos, 0), Quaternion.identity, transform);
        newO.GetComponent<BoxCollider2D>().enabled = true;
        yPos += galaxyHeight;
    }

    void Update()
    {
        if (Camera.main.transform.position.y > (yPos - galaxyHeight))
        {
            var rand = Random.Range(0, ggPrefabs.Length);
            Instantiate(ggPrefabs[rand], new Vector3(0, yPos, 0), Quaternion.identity, transform);
            yPos += galaxyHeight;
        }
    }
}
