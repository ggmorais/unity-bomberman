using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile destructibleTile;
    public GameObject explosionPrefab;

    public void Explode(Vector2 pos, int range)
    {
        Vector3Int cell = tilemap.WorldToCell(pos);

        Vector2Int[] positions = new Vector2Int[4];

        positions[0] = new Vector2Int(1, 0);
        positions[1] = new Vector2Int(-1, 0);
        positions[2] = new Vector2Int(0, 1);
        positions[3] = new Vector2Int(0, -1);

        foreach (Vector2Int ps in positions) {
            for (int i = 0; i < range; i++) {
                if (!ExplodeCell(cell + new Vector3Int(ps.x * i, ps.y * i, 0))) {
                    break;
                }
            }
        }
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        
        if (tile == destructibleTile) {
            tilemap.SetTile(cell, null);
            Instantiate(explosionPrefab, tilemap.GetCellCenterWorld(cell), Quaternion.identity);
        }

        if (tile == wallTile || tile == destructibleTile) {
            return false;
        }

        GameObject explosion = Instantiate(explosionPrefab, tilemap.GetCellCenterWorld(cell), Quaternion.identity);
        PlayerController player = FindObjectOfType<PlayerController>();

        if (player && !player.isInvulnerable && tilemap.WorldToCell(player.transform.position) == cell) {
            player.TakeDamage();
        }

        // Destroy(explosion, 1f);

        foreach (CollectableController collectable in FindObjectsOfType<CollectableController>()) {
            Vector3 collectablePos = tilemap.WorldToCell(collectable.transform.position);

            if (collectablePos == cell) {
                Destroy(collectable.gameObject);
            }
        }

        foreach (Bomb bomb in bombs) {
            Vector3 bombPos = tilemap.WorldToCell(bomb.transform.position);

            if (bombPos == cell) {
                bomb.countDown = 0.1f;
            }
        }
        
        return true;
    }

}
