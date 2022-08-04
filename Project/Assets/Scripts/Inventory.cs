using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image itemDisplayPrefab;
    Player player;
    List<Plant> items;
    int xPos = 1;
    int xOffset = 360;

    private void Start()
    {
        items = new List<Plant>();
        player = FindObjectOfType<Player>();
        player.SetInventory(this);
    }

    public void AddPlant(List<Plant> plants)
    {
        for (int i = 0; i < plants.Count; i++)
        {
            items.Add(plants[i]);
            var display = Instantiate(itemDisplayPrefab, transform);
            display.sprite = plants[i].mySprite;
            display.rectTransform.anchoredPosition = new Vector3(xPos - xOffset, 0, 0);
            xPos += 50;
            display.color = plants[i].color;
            display.GetComponentInChildren<InventoryIcon>().plant = plants[i];
        }

    }
}
