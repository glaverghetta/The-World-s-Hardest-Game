using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int totalDeaths = 0;

    public Rigidbody2D playerRB;
    public float speed = 3;

    private Vector3 startingPos;    // where the player starts the level

    public event Action OnPlayerDeath; // event to run when the player dies. Should update deathText in the ui and respawn the coins
    public delegate void AcquireCoinDelegate(GameObject obj);
    public event AcquireCoinDelegate OnAcquireCoin;
    public event Action OnCheckpointEntered;    // event to run when player enters a checkpoint.
    public event Action OnKeyFound;             // event to run when player collects the key

    void Start()
    {
        playerRB.freezeRotation = true;
        startingPos = transform.position;
    }

    void FixedUpdate()
    { 
        // 2D Player movement
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;
        Vector2 moveAmount = velocity * Time.deltaTime;

        playerRB.velocity = moveAmount;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy collisions
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            Die();
        }

        if (collision.gameObject.tag.Equals("Coin"))
        {
            if (OnAcquireCoin != null)
            {
                OnAcquireCoin(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag.Equals("Checkpoint"))
        {
            startingPos = collision.transform.position;
            if (OnCheckpointEntered != null)
            {
                OnCheckpointEntered();
            }
        }

        if(collision.gameObject.tag.Equals("Key"))
        {
            OnKeyFound();
        }
    }

    // Move player back to start and increment death counter
    void Die()
    {
        totalDeaths++;
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }

        transform.position = new Vector3(startingPos.x, startingPos.y, -1); //startingPos;
    }
}
