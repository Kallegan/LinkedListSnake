using System;
using Unity.Mathematics;
using UnityEngine;

namespace SnakeBody
{
    public class BodyManager : MonoBehaviour
    {

        public GameObject head;
        public GameObject tail;
        public GameObject deathEffect;
   
        [SerializeField] private float segmentDistance = 0.2f;
        [SerializeField] float moveSpeed = 300; //body movement speed.
        [SerializeField] float turnRate = 200; //body turn rate.
        private SinglyLinkedLists.LinkedList<GameObject> _mainBody = new SinglyLinkedLists.LinkedList<GameObject>();
        private SinglyLinkedLists.LinkedList<GameObject> _bodySegments = new SinglyLinkedLists.LinkedList<GameObject>();

        private float _segmentGrowth = 0;
        //test 
        public BoxCollider2D gridArea;

        void Start()
        {
            StartingBody();
        }

        private void Update()
        {
            if (Triggers.GameOver || _mainBody.Count <= 0)
            {
                GameOver();
            }
        }

        private void FixedUpdate()
        {
            ManageBody(); 
            BodyMovement();
            ScreenWrap();
        }

        private void GameOver()
        {
            for (int i = _mainBody.Count - 1; i >= 0; i--)
            {
                Instantiate(deathEffect, _mainBody[i].transform.position, quaternion.identity);
                Destroy(gameObject);
            }
        }
        void ManageBody()
        {
            if (_bodySegments.Count > 0)
            {
                CreateBodySegments();
            }

            for (int i = _mainBody.Count - 1; i >= 0; i--) //forr loop, removes unused bodyparts in list.
            {
                if (_mainBody[i] == null)
                {
                    _mainBody.Remove(i);
                }
            }
            if(_mainBody.Count == 0)
                Destroy(this) ;
        }

        void BodyMovement()
        {
            if (_mainBody.Count >= 1) //if the body exist, add velocity.
            {
                _mainBody[0].GetComponent<Rigidbody2D>().velocity = 
                    _mainBody[0].transform.right * moveSpeed * Time.deltaTime;
            }
            if (Input.GetAxis("Horizontal") != 0 && _mainBody.Count >= 1) //turns the head depending on turn rate.
            {
                _mainBody[0].transform.Rotate(new Vector3
                    (0,0,-turnRate * Time.deltaTime *Input.GetAxis("Horizontal")));
            }

            if (_mainBody.Count > 1)
            {
                for (int i = 1; i < _mainBody.Count; i++)
                {
                    PointerManager tempPointer = _mainBody[i - 1].GetComponent<PointerManager>();
                    _mainBody[i].transform.position = tempPointer.PointerList[0].Position;
                    _mainBody[i].transform.rotation = tempPointer.PointerList[0].Rotation;
                    tempPointer.PointerList.Remove(0);
                }
            }
        }
        void ScreenWrap() //method used for screenwrapping. Tried implementing my own using the same bounds as fruit spawn.
        {
            if (Triggers.OutOfBound && _mainBody.Count >= 1) //added body check to prevent triggers searching when dead.
            {
                Bounds bounds = gridArea.bounds; //created bounds to check if players head is outside trigger area.
                //check for each direction if player is crossing the 2dcollider trigger, and if so sets x/y
                //to opposite direction using the min/max values from bounds and applying to head node so others can follow.
                if (bounds.max.x< _mainBody[0].transform.position.x && bounds.min.y < _mainBody[0].transform.position.y)
                {
                    _mainBody[0].transform.position = new Vector3(bounds.min.x, _mainBody[0].transform.position.y, 0.0f);
                    Triggers.OutOfBound = false;
                }
            
                if (bounds.min.x > _mainBody[0].transform.position.x && bounds.min.y < _mainBody[0].transform.position.y)
                {
                    _mainBody[0].transform.position = new Vector3(bounds.max.x, _mainBody[0].transform.position.y, 0.0f);
                    Triggers.OutOfBound = false;
                }

                if (bounds.min.x<_mainBody[0].transform.position.x && bounds.min.y>_mainBody[0].transform.position.y)
                {
                    _mainBody[0].transform.position = new Vector3(_mainBody[0].transform.position.x, bounds.max.y, 0.0f);
                    Triggers.OutOfBound = false;
                }
            
                if (bounds.max.x>_mainBody[0].transform.position.x && bounds.max.y<_mainBody[0].transform.position.y)
                {
                    _mainBody[0].transform.position = new Vector3(_mainBody[0].transform.position.x, bounds.min.y, 0.0f);
                    Triggers.OutOfBound = false;
                }
            }
        }

        private void StartingBody()
        {
            if (_mainBody.Empty) //set up main body (head of the snake).
            {
                _bodySegments.Add(head);
                _bodySegments.Add(tail);

                var transform1 = transform;
                GameObject temp1 = Instantiate(_bodySegments[0], transform1.position, transform1.rotation, transform1);
                if(!temp1.GetComponent<PointerManager>())
                {
                    temp1.AddComponent<PointerManager>();
                }
                if (!temp1.GetComponent<Rigidbody2D>())
                {
                    temp1.AddComponent<Rigidbody2D>();
                    temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                _mainBody.Add(temp1);
                _bodySegments.Remove(0);
            }
        }
        
    
        void CreateBodySegments()
        
        {
            
            PointerManager tempPointer = _mainBody[_mainBody.Count - 1].GetComponent<PointerManager>();
            if (_segmentGrowth == 0)
            {
                tempPointer.ClearPointerList();
            }
        
            _segmentGrowth += Time.deltaTime;
        
            if (_segmentGrowth > segmentDistance)
            {
           
                GameObject temp = Instantiate(_bodySegments[0], tempPointer.PointerList[0].Position,
                    tempPointer.PointerList[0].Rotation, transform);
                if (!temp.GetComponent<PointerManager>())
                {
                    temp.AddComponent<PointerManager>();
                }

                if (!temp.GetComponent<Rigidbody2D>())
                {
                    temp.AddComponent<Rigidbody2D>();
                    temp.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                _mainBody.Add(temp);
                _bodySegments.Remove(0);
                temp.GetComponent<PointerManager>().ClearPointerList();
                _segmentGrowth = 0;
            }
        
        }

        public void AddBodyParts(GameObject obj)
        {
            _bodySegments.Add(obj);
        }

        public void RemoveBodyTail()
        {
            Destroy(_mainBody[_mainBody.Count+1]);
            _mainBody.Remove(_mainBody.Count + 1);
        }
    }
} 
