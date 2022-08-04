using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    //state starts at one

    public void ChangeState(int state)
    {
        //if i already have that state created then i don't want to create it again, just set the current state on earth to the state

        if(InfoHandler.I.GetState(state) == null)
        {
            InfoHandler.I.NewState(state);

            InfoHandler.I.currentState = state;
        }

        SceneManager.LoadScene(4);
    }

}
