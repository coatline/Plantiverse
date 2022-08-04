using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class State : MonoBehaviour
{
    [SerializeField] GameObject housePrefab;
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] GameObject man;
    [SerializeField] TMP_Text text;
    [SerializeField] AudioClip plantSound;

    AudioSource audio;
    GroundScript gs;

    public int plantsUsed = 0;

    public int homesPlaced = 0;
    public int buildingsPlaced = 0;
    public int menPlaced = 0;

    private void Awake()
    {

        audio = GetComponent<AudioSource>();
        gs = FindObjectOfType<GroundScript>();

        var info = InfoHandler.I.GetState(InfoHandler.I.currentState);

        if(info == null)
        {
            Debug.LogError("Info is null");
        }

        info.buildingsPlaced = buildingsPlaced;
        info.homesPlaced = homesPlaced;
        info.menPlaced = menPlaced;
        info.plantsUsed = plantsUsed;

        gs.plantsUsed = plantsUsed;
    }

    private void OnDisable()
    {
        //var info = Earth.I.infos[Earth.I.totalStatesCreated - 1];

        //buildingsPlaced = info.buildingsPlaced;
        //homesPlaced = info.homesPlaced;
        //menPlaced = info.menPlaced;
        //plantsUsed = info.plantsUsed;
    }

    void Start()
    {
        text.text = $"Plants: {Earth.I.plantNum}";

        //place men
        for (int i = 0; i < menPlaced; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, -.5f), 0);
            Instantiate(man, pos, Quaternion.identity);
        }

        //place houses
        for (int i = 0; i < homesPlaced; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 0f), 0);
            Instantiate(housePrefab, pos, Quaternion.identity);
        }

        //place buildings
        for (int i = 0; i < buildingsPlaced; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-14f, -11f), 0);
            Instantiate(buildingPrefab, pos, Quaternion.identity);
        }

    }

    public void AddPlants()
    {
        if (Earth.I.plantNum <= 0)
        {
            return;
        }

        if (plantsUsed < 40)
        {
            gs.AddPlant();
            Earth.I.plantNum--;
            plantsUsed++;
            text.text = $"Plants: {Earth.I.plantNum}";
        }

        else if (plantsUsed >= 40 && plantsUsed < 60)
        {
            Earth.I.plantNum--;
            menPlaced++;
            plantsUsed++;
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 0f), 0);
            Instantiate(man, pos, Quaternion.identity);
            text.text = $"Plants: {Earth.I.plantNum}";
        }

        else if ((plantsUsed >= 60 && plantsUsed < 80))
        {
            Earth.I.plantNum--;
            homesPlaced++;
            plantsUsed++;
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 0f), 0);
            Instantiate(housePrefab, pos, Quaternion.identity);
            text.text = $"Plants: {Earth.I.plantNum}";
        }

        else if (plantsUsed >= 80 && plantsUsed < 100)
        {
            Earth.I.plantNum--;
            buildingsPlaced++;
            plantsUsed++;
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 0f), 0);
            Instantiate(buildingPrefab, pos, Quaternion.identity);
            text.text = $"Plants: {Earth.I.plantNum}";
        }
        else
        {
            Earth.I.plantNum--;
            menPlaced++;
            plantsUsed++;
            Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 0f), 0);
            Instantiate(man, pos, Quaternion.identity);
            text.text = $"Plants: {Earth.I.plantNum}";
        }

        audio.PlayOneShot(plantSound);
    }

}
