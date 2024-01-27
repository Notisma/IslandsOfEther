using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

/** Utils */
public static class U
{
    public static void PrintList<T>(List<T> l)
    {
        string result = "list : ";
        foreach (var item in l)
        {
            result += item + ", ";
        }
        Debug.Log(result);
    }
}