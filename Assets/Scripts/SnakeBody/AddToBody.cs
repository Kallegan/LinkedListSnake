using Score;
using UnityEngine;

namespace SnakeBody
{
    public class AddToBody : MonoBehaviour
    {
        [SerializeField] private GameObject body;

        private BodyManager bodyM;

        private void Start()
        {
            bodyM = GetComponent<BodyManager>();
        }

        private void Update()
        {
            if (Collectibles.Collect)
            {
                bodyM.AddBodyParts(body);
                
                
            }
        
        }
    }
}
