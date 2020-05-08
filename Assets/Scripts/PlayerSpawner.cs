using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSpawner : MonoBehaviour
{   
    public bool isEnabled = true;
    public GameObject player;

    private MapCreator map;
    private bool spawned = false;

    void Start()
    {   
        map = FindObjectOfType<MapCreator>();
    }

    // void LateUpdate()
    // {
    //     if (!enabled || spawned || player == null) {
    //         return;
    //     }

    //     Vector3[] cells = map.spawnableCells.ToArray();

    //     Debug.Log(cells.Length);
    //     Instantiate(player, cells[(int) Random.Range(0, cells.Length)], Quaternion.identity);

    //     spawned = true;
    // }
}
