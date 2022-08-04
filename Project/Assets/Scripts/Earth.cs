using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public int plantNum;




    const string GOB_NAME = "Earth";

    static Earth instance;

    public static Earth I
    {
        get
        {
            if (instance == null)
            {
                var gob = new GameObject(GOB_NAME);
                gob.AddComponent<Earth>();
            }

            return instance;
        }
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(transform);
        instance = this;

    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
