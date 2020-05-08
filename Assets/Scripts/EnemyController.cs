using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D body;
    private TilemapPositioning tilemapPosition;
    private Vector3 lastPosition;
    private Vector3 nextPosition;
    private Vector2 velocity;

    private Vector3Int actualCell;
    private Vector3Int nextCell;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tilemapPosition = FindObjectOfType<TilemapPositioning>();

        nextPosition = transform.position;

        nextCell = actualCell;
    }

    void Update()
    {  

        if (body.transform.position.Round(1) == nextPosition.Round(1)) {
            List<Vector3> avaiablePositions = tilemapPosition.AvaiablePositions(transform.position);

            if (avaiablePositions.Count > 0) {
                lastPosition = transform.position;
                nextPosition = avaiablePositions[Random.Range(0, avaiablePositions.Count)];
            }
        } else {
            Debug.Log(transform.position.x);
            body.transform.position = Vector3.Lerp(transform.position, nextPosition, speed * Time.deltaTime);
        }
       
    }
}
