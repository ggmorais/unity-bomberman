using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapCreator : MonoBehaviour
{  
    public bool isEnabled = true;
    public Tilemap tilemap;
    public Tile destructibleTile;
    public Tile wallTile;
    public CollectableController[] collectables;
    public int blocksChance = 3;
    public int collectableChance = 20;

    private List<Vector3Int> freeCells = new List<Vector3Int>();

    void Start()
    {

        if (!isEnabled) return;

        Spawner[] spawnPoints = FindObjectsOfType<Spawner>();
        List<Vector3Int> spawnPosis = new List<Vector3Int>();

        foreach (var spawnPos in spawnPoints) {
            spawnPosis.Add(tilemap.WorldToCell(spawnPos.transform.position));
        }

        foreach (var pos in tilemap.cellBounds.allPositionsWithin) {
            
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);

            if (!tilemap.HasTile(localPlace)) {
                if (Random.Range(1, blocksChance) == 1) {
                    bool isSpawnPoint = spawnPosis.Contains(localPlace);

                    foreach (var collectable in collectables) {
                        if (!isSpawnPoint && Random.Range(1, collectable.spawnChance) == 1) {
                            Instantiate(collectable, tilemap.GetCellCenterWorld(localPlace), Quaternion.identity);
                            break;
                        }
                    }

                    if (!isSpawnPoint) tilemap.SetTile(localPlace, destructibleTile);
                }
            }
        }
        
    }
    
}
