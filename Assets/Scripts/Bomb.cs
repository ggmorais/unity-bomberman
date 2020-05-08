using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float countDown = 2f;
    public int flameRange = 2;

    void Update()
    {
        countDown -= Time.deltaTime;

        MapDestroyer map = FindObjectOfType<MapDestroyer>();

        if (countDown <= 0f) {
            map.Explode(transform.position, flameRange);
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

}
