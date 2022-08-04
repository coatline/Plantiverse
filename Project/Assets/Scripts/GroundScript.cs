using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    SpriteRenderer sr;

    public int plantsUsed;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        var g = plantsUsed * .025f;
        sr.color = new Color(0, g, 0);
    }

    public void AddPlant()
    {
        sr.color += new Color(0, .025f, 0);
    }
}
