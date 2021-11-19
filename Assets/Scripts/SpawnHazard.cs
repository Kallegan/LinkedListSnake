using System;
using UnityEngine;
using SinglyLinkedLists;
using Random = UnityEngine.Random;
using Audio;
using Score;
using SnakeBody;
using Unity.Mathematics;

public class SpawnHazard : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject explosion;
    public LayerMask playerLayer;
    public Transform detonationPoint;

    private float speed;
    public float spawnRate; //sets spawn rate for hazard to 5sec default.
    public float detonationRange = 5f;
    //public int explosionDamage = 5; //use for later.

    void Start()
    {
        speed = Random.Range(100, 200); //wanted different speed for meteor after each "respawn" so used random.
        spawnRate = Random.Range(5f, 10f); //lifetime for each differs.
        InvokeRepeating(nameof(SpawnMeteor), spawnRate, spawnRate); //invokes new spawns depending on spawnrate.
    }

    public void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed * Time.deltaTime; //very simple movement using speed
        //and prefabs gravity.
    }

    private void SpawnMeteor()
    {
        RandomizePosition(); //new pos.
    }

    private void Explode() //didnt have time to finnish this yet. Will implement later in my own time.
    {
        Instantiate(explosion, transform.position, quaternion.identity);
        Collider2D[] detonate = Physics2D.OverlapCircleAll
            (detonationPoint.position, detonationRange, playerLayer);
        foreach (Collider2D player in detonate)
        {
            //todo: add damage to each hit bodypart, if bodyparts health <=0, remove from list and destroy.
        }
    }

    public void RandomizePosition()
    {
        Explode();
        Bounds bounds = gridArea.bounds;
        float x = Random.Range(bounds.max.x, bounds.max.x+10);
        float y = bounds.max.y;

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            Triggers.gameOver = true;
        }
        if (other.CompareTag("Body"))
        {
            //todo: when comet pass body, remove score from player? play warning sound/screen effect
        }
    }
}
