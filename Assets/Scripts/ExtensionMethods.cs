using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ExtensionMethods
{
    
    public static Vector3 Round(this Vector3 vector, int decimalHouses = 2)
    {
        float multiplier = 1;

        for (int i = 0; i < decimalHouses; i++)
        {
            multiplier *= 10f;
        }
        return new Vector3(
            Mathf.Round(vector.x * multiplier) / multiplier,
            Mathf.Round(vector.y * multiplier) / multiplier,
            Mathf.Round(vector.z * multiplier) / multiplier);
    }

}
