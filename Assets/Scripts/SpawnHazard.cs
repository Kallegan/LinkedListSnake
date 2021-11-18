using System;
using UnityEngine;
using SinglyLinkedLists;
using Random = UnityEngine.Random;
using Audio;

public class SpawnHazard : MonoBehaviour
{
    public GameObject meteorPrefab;
    
    public BoxCollider2D gridArea;

    private float speed = 100;

    public float spawnRate = 20f; //sets spawn rate for hazard to 5sec default.

    void Start()
    {
        InvokeRepeating(nameof(SpawnMeteor), this.spawnRate, this.spawnRate);
    }

    public void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed * Time.deltaTime;
    }


    private void SpawnMeteor()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
    Bounds bounds = gridArea.bounds;
    //used random.range and the bounds +1/-1 to avoid collectables clipping outside of bounds. 
    float x = Random.Range(bounds.min.x+1, bounds.max.x-1); 
    float y = Random.Range(bounds.min.y+1, bounds.max.y-1);

    transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            Triggers.GameOver = true;
        }
    }
}
