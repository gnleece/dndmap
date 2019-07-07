using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    void Update()
    {
        Touch[] myTouches = Input.touches;
        if (Input.touchCount > 0)
        {
            //Debug.Log("TOUCHES:");
            for (int i = 0; i < Input.touchCount; i++)
            {
                //Debug.Log($"{myTouches[i].fingerId}");
            }
        }
    }
}
