using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField]Image info;
    [SerializeField] Image pointer;
    [SerializeField] TMP_Text text;

    public Plant plant;

    void Start()
    {
        text.text = $"Species: {plant.myName}\nDescription: {plant.description}\nRarity: {plant.rarity}";
    }

    public void OnClick()
    {
        if (!info.IsActive())
        {
            info.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            pointer.gameObject.SetActive(true);
        }
        else
        {
            info.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
            pointer.gameObject.SetActive(false);
        }
    }
}
