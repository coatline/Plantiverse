using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGenerator : MonoBehaviour
{
    [SerializeField] Plant plantPrefab = null;
    [SerializeField] Sprite[] plantSprite = null;
    [SerializeField] Sprite bacteriaSprite = null;

    [SerializeField] string[] prefixes = null;
    [SerializeField] string[] suffixes = null;

    [SerializeField] string[] adjectives = null;

    public Plant plant = null;

    public void CreatePlant(Transform position)
    {
        int randPre = Random.Range(0, prefixes.Length);
        int randSuf = Random.Range(0, suffixes.Length);

        var newPlant = Instantiate(plantPrefab, position.position, Quaternion.identity, transform);

        newPlant.myName = $"{prefixes[randPre]}{suffixes[randSuf]}";

        int randAdj = Random.Range(0, adjectives.Length);
        int randAdjective = Random.Range(0, adjectives.Length);

        if (randAdj == randAdjective)
        {
            randAdjective = Random.Range(0, adjectives.Length);
        }

        newPlant.description = $"{adjectives[randAdj]} and {adjectives[randAdjective]}";

        if ((adjectives[randAdj] == "Big" && adjectives[randAdjective] == "Tiny") || (adjectives[randAdjective] == "Big" && adjectives[randAdj] == "Tiny"))
        {
            randAdjective = Random.Range(0, adjectives.Length);
            randAdj = Random.Range(0, adjectives.Length);
            newPlant.description = $"{adjectives[randAdj]} and {adjectives[randAdjective]}";
        }
        if ((adjectives[randAdj] == "Short" && adjectives[randAdjective] == "Tall") || (adjectives[randAdjective] == "Short" && adjectives[randAdj] == "Tall"))
        {
            randAdjective = Random.Range(0, adjectives.Length);
            randAdj = Random.Range(0, adjectives.Length);
            newPlant.description = $"{adjectives[randAdj]} and {adjectives[randAdjective]}";
        }

        var chance = Random.Range(0, 100);

        if (chance < 50)
        {
            chance = Random.Range(0, 100);
        }
        if (chance <= 25)
        {
            chance = Random.Range(0, 100);
        }
        if (chance < 10)
        {
            chance = Random.Range(0, 100);
        }

        newPlant.chance = chance;

        var randSpriteIndex = Random.Range(0, plantSprite.Length);

        newPlant.mySprite = plantSprite[randSpriteIndex];

        var rando = Random.Range(0, 1f);
        var randt = Random.Range(0, 1f);
        var randf = Random.Range(0, 1f);

        newPlant.color = new Color(rando, randf, randt);

        var randman = Random.Range(.1f, 100);

        if (randman == 1)
        {
            newPlant.myName = "Unknown";
            newPlant.description = "Unknown";
            newPlant.mySprite = bacteriaSprite;
            newPlant.chance = 2;

            var randob = Random.Range(0, 1f);
            var randtb = Random.Range(0, 1f);
            var randfb = Random.Range(0, 1f);

            newPlant.color = new Color(randob, randfb, randtb);
        }

        plant = newPlant;
    }

    const string GOB_NAME = "PlantHandler";

    static PlantGenerator instance;

    public static PlantGenerator I
    {
        get
        {
            if (instance == null)
            {
                var gob = new GameObject(GOB_NAME);
                gob.AddComponent<PlantGenerator>();
            }

            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }
}
