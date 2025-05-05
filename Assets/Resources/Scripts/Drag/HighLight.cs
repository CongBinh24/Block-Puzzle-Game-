using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    public GameObject highlight;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                //Debug.Log(mousePos.x);
                //Debug.Log(mousePos.y);
                //screenToWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
                Vector2 MousetoWorld = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));

                //Debug.LogError(screenToWorld);
            }
        }
    }
}
