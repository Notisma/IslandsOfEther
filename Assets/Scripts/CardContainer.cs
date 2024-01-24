using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardContainer : MonoBehaviour
{
    public GameObject cardArena;
    public Vector3[] placedPos;
    public bool[] placed;

    private void Start()
    {
        placed = new bool[6];
        placedPos = new Vector3[6];
        placedPos[0] = new Vector3((float)-5.2, (float)0.2, 0);
        placedPos[1] = new Vector3((float)-3.5, (float)0.2, 0);
        placedPos[2] = new Vector3((float)-1.8, (float)0.2, 0);
        placedPos[3] = new Vector3((float)-0.1, (float)0.2, 0);
        placedPos[4] = new Vector3((float) 1.5, (float)0.2, 0);
        placedPos[5] = new Vector3((float) 3.2, (float)0.2, 0);
    }
}
