using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public Text myInfo;
    public Color color;
    public int chance;
    public string myName;
    public string description;
    public string rarity; // 0-5 vrare  6-20 rare  21-40 unCommon  41-60 common
    public Sprite mySprite;

    void Start()
    {

        if(chance == 0 || chance == 1)
        {
            chance = 1;
            rarity = "Legendary";
        }
        else if (chance <= 5 && chance > 0)
        {
            rarity = "Very Rare";
        }
        else if (chance <= 20 && chance >= 6)
        {
            rarity = "Rare";
        }
        else if (chance <= 40 && chance >= 21)
        {
            rarity = "Uncommon";
        }
        else if (chance <= 60 && chance >= 41)
        {
            rarity = "Common";
        }
        else if (chance <= 100 && chance >= 61)
        {
            rarity = "Very Common";
        }

    }

}
