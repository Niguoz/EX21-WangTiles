using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WangTiles
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] 
        [Range(0,15)]private int _val;
        void Start()
        {
            Doors(_val);

        }


        void Doors(int val)
        {
            if((val & 1) == 1)
            {
                Debug.Log("North Door");
            }
            if((val & 2) == 2)
            {
                Debug.Log("East Door");
            }
            if((val & 4) == 4)
            {
                Debug.Log("South Door");
            }
            if((val & 8) == 8)
            {
                Debug.Log("West Door");
            }
            if(val == 0)
            {
                Debug.Log("No Doors");
            }
        }
    }
}
