using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Score
{
    
    //experimented with some form of immortality but didnt complete in time. Will implement in a later stage.
    public class CollectablesPower: MonoBehaviour
    {
        public bool immortal = false;
        public GameObject effect;
        public BoxCollider2D gridArea;


        public void Start()
        {
            RandomizePosition();
        }

        public void Update()
        {
            if (!gameObject)
            {
                Invoke(nameof(Respawn), 10f);
            }
        }
    
        void Respawn()
        {
            Instantiate(gameObject);
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

        private void OnTriggerEnter(Collider other)
        {
            Instantiate(effect, transform.position, quaternion.identity);
            immortal = true;
            Invoke(nameof(ResetInvulnerability), 3); //invokes method that switches bool immortal back to false;
            Destroy(gameObject);
        }
    

        void ResetInvulnerability()
        {
            immortal = false;
        }

    }
}