using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour
{   
    public Tilemap tilemap;
    public GameObject bombPrefab;
    public GameObject owner;
    public bool spawnWithClick;
    public int activeBombs;

    void Update()
    {
        activeBombs = FindObjectsOfType<Bomb>().Length;

        if (Input.GetMouseButtonDown(0)) {
            
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(worldPos);
            Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
            Debug.Log(cellCenter);
            // Tile tile = tilemap.GetTile<Tile>(cell);

            // if (tile == null) {
            //     Instantiate(bombPrefab, cellCenter, Quaternion.identity);
            // }  
        }
    }

    public void Spawn(Vector2 position, int flameRange, int bombLimit)
    {   
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        Vector3Int cell = tilemap.WorldToCell(position);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
        Tile tile = tilemap.GetTile<Tile>(cell);

        foreach (Bomb bomb in bombs) {
            if (tilemap.WorldToCell(bomb.transform.position) == cell) {
                return;
            }
        }

        if (bombLimit == activeBombs) {
            return;
        }

        if (tile == null) {
            GameObject bomb = Instantiate(bombPrefab, cellCenter, Quaternion.identity);
            bomb.GetComponent<Bomb>().flameRange = flameRange;
        }
    }
}
