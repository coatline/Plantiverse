using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{

    public int currentState;

    public List<StateInfo> stateInfos;

    void OnEnable()
    {
        stateInfos = new List<StateInfo>();

        DontDestroyOnLoad(transform);
        instance = this;
    }


    public void NewState(int state)
    {
        var newState = new StateInfo();

        newState.state = state;

        stateInfos.Add(newState);
    }

    public StateInfo GetState(int state)
    {
        var stateWanted = 0;

        for (int i = stateInfos.Count - 1; i >= 0; i--)
        {
            if (stateInfos[i].state == state)
            {
                stateWanted = state;
            }
        }

        if (stateWanted == 0)
        {
            Debug.LogError($"The state {stateInfos[state]} is null");
            return null;
        }
        else
        {
            return stateInfos[stateWanted];
        }

    }

    public class StateInfo
    {
        public int state;

        public int plantsUsed = 0;

        public int homesPlaced = 0;
        public int buildingsPlaced = 0;
        public int menPlaced = 0;
    }


    const string GOB_NAME = "Earth";

    static InfoHandler instance;

    public static InfoHandler I
    {
        get
        {
            if (instance == null)
            {
                var gob = new GameObject(GOB_NAME);
                gob.AddComponent<InfoHandler>();
            }

            return instance;
        }
    }
}
