using Score;
using UnityEngine;

namespace SnakeBody
{
    public class AddToBody : MonoBehaviour
    {
        [SerializeField] private GameObject body;
        [SerializeField] private GameObject tail;

        public static bool addToScore;
        private BodyManager bodyM;

        private void Start()
        {
            bodyM = GetComponent<BodyManager>();
        }

        private void LateUpdate()
        {
            if (Collectibles.collect)
            {
                bodyM.AddBodyParts(body);
                bodyM.RemoveBodyTail();
                bodyM.AddBodyParts(tail);
                addToScore = true;
                Collectibles.collect = false;
            }
        
        }
    }
}
