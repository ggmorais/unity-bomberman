using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPositioning : MonoBehaviour
{
    public Tilemap tilemap;

    public Vector3Int ObjectOnCell(Vector2 actualPosition)
    {
        return tilemap.WorldToCell(actualPosition);
    }

    public Vector3Int AvaiableCells(Vector2 actualPosition)
    {   
        List<Vector3Int> cells = new List<Vector3Int>();
        Vector3Int cell = tilemap.WorldToCell(actualPosition);

        Vector3Int right = new Vector3Int(cell.x + 1, cell.y, cell.z);
        Vector3Int left = new Vector3Int(cell.x - 1, cell.y, cell.z);
        Vector3Int up   = new Vector3Int(cell.x, cell.y - 1, cell.z);
        Vector3Int down = new Vector3Int(cell.x, cell.y + 1, cell.z);

        if (!tilemap.HasTile(right))
            cells.Add(right);

        if (!tilemap.HasTile(left))
            cells.Add(left);
        
        if (!tilemap.HasTile(up))
            cells.Add(up);
        
        if (!tilemap.HasTile(down))
            cells.Add(down);

        return cells[Random.Range(0, cells.Count)];
    }

    public List<Vector3> AvaiablePositions(Vector2 actualPosition)
    {   
        List<Vector3> positions = new List<Vector3>();
        Vector3Int cell = tilemap.WorldToCell(actualPosition);

        Vector3Int right = new Vector3Int(cell.x + 1, cell.y, cell.z);
        Vector3Int left = new Vector3Int(cell.x - 1, cell.y, cell.z);
        Vector3Int up   = new Vector3Int(cell.x, cell.y - 1, cell.z);
        Vector3Int down = new Vector3Int(cell.x, cell.y + 1, cell.z);

        if (!tilemap.HasTile(right))
            positions.Add(tilemap.GetCellCenterWorld(right));

        if (!tilemap.HasTile(left))
            positions.Add(tilemap.GetCellCenterWorld(left));
        
        if (!tilemap.HasTile(up))
            positions.Add(tilemap.GetCellCenterWorld(up));
        
        if (!tilemap.HasTile(down))
            positions.Add(tilemap.GetCellCenterWorld(down));

        return positions;
    }

}
