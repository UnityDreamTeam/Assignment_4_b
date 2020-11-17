using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMover2 : MonoBehaviour
{
    [SerializeField] Transform OriginalObject;

    void LateUpdate()
    {
        //Get the actual position of the original
        Vector3 pos = OriginalObject.position;

        float HalfScreenSizeX = CalculateHalfScreenSize();

        //Add the screen size
        pos.x += HalfScreenSizeX * 2;

        // wrap around if necessary
        if (pos.x > HalfScreenSizeX * 2)
            pos.x -= HalfScreenSizeX * 4;

        transform.position = pos;
    }
    float CalculateHalfScreenSize()
    {
        float aspect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().aspect;
        float ortoSize = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        return aspect * ortoSize;
    }
}
