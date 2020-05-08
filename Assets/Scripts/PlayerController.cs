using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float speed = 2f;
    public int lifes = 3;
    public int flameRange = 3;
    public int bombLimit = 1;
    public bool isInvulnerable = false;
    public float blinkingRate = 0.3f;
    
    private Animator animator;
    private Vector2 velocity;
    private Rigidbody2D rigidBody;
    private BombSpawner bombSpawner;
    private SpriteRenderer spriteRenderer;
    private float blinkingTimer = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        bombSpawner = FindObjectOfType<BombSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {     

        Blink();

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            bombSpawner.Spawn(transform.position, flameRange, bombLimit);
        }

        if (Input.GetKey(KeyCode.D)) {
            //velocity.x = moveX * speed;
            velocity.x = speed;
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        } else if (Input.GetKey(KeyCode.A)) {
            //velocity.x = moveX * speed;
            velocity.x = -speed;
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
        } else {
            velocity.x = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            //velocity.y = moveY * speed;
            velocity.y = speed;
        } else if (Input.GetKey(KeyCode.S)) {
            //velocity.y = moveY * speed;
            velocity.y = -speed;
        } else {
            velocity.y = 0;
        }
    
        rigidBody.velocity = velocity;

        animator.SetFloat("WalkHorizontal", rigidBody.velocity.x);
        animator.SetFloat("WalkVertical", rigidBody.velocity.y);
    }

    private void Blink()
    {   
        if (!isInvulnerable) {
            spriteRenderer.enabled = true;
            return;
        }

        if (blinkingTimer >= blinkingRate) {
            spriteRenderer.enabled = true;
            blinkingTimer = 0;
        } else {
            spriteRenderer.enabled = false;
            blinkingTimer += Time.fixedDeltaTime;
        }
    }

    public void TakeDamage()
    {
        lifes -= 1;
        isInvulnerable = true;
        StartCoroutine("IvulnerableCoroutine");
    }

    public IEnumerator IvulnerableCoroutine()
    {
        yield return new WaitForSeconds(2f);
        isInvulnerable = false;
    }

}
