using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace SnakeBody
{
    public class  PointerManager : MonoBehaviour
    {
    
    
        public class Pointer //class used to create and store position and rotation.
        {
            public Vector3 Position; //stores position.
            public Quaternion Rotation; //stores rotation.

            public Pointer(Vector3 pos, Quaternion rot) //used when creating markers to give position and rotation.
            {
                Position = pos;
                Rotation = rot;
            }
        }

        public SinglyLinkedLists.LinkedList<Pointer> PointerList = new SinglyLinkedLists.LinkedList<Pointer>(); //creating a list of markers to keep track of
        //the markers in the class.

        private void FixedUpdate()
        {
            UpdatePointList();
        }


        public void UpdatePointList()
        {
            //takes the pointerlist and using the add function to add to the list and take pos+rot from the class Pointer.
            PointerList.Add(new Pointer(transform.position, transform.rotation));
        }

        public void ClearPointerList() //clears the list, then add the current position if list would encounter problems.
        {
            PointerList.Clear();
            PointerList.Add(new Pointer(transform.position, transform.rotation));
        }

    }
} 
