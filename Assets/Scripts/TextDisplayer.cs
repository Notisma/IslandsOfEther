using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDisplayer : MonoBehaviour
{
    public static TextDisplayer I;

    private TextMeshProUGUI ui;

    public bool debug;

    private void Start()
    {
        if (I == null) I = this;
        ui = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void DisplayText(string msg)
    {
        if (debug) DisplayPlaceholderText(msg);
        else DisplayUIText(msg);
    }

    private void DisplayPlaceholderText(string msg)
    {
        Debug.Log("Game says : " + msg);
    }

    private void DisplayUIText(string msg)
    {
        ui.text = msg;
    }
}