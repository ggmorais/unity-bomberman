using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{   
    public int spawnChance = 30;
    public int flameUpgrade = 0;
    public int bombLimitUpgrade = 0;
    public float speedUpgrade = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            PlayerController player = other.GetComponentInParent<PlayerController>();

            player.flameRange += flameUpgrade;
            player.bombLimit += bombLimitUpgrade;
            player.speed += speedUpgrade;

            Destroy(gameObject);
        }
    }
}
