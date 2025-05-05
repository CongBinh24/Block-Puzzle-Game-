using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Vector3 screenToWorld;
    public Grid Grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    {
        //        Debug.Log(mousePos.x);
        //        Debug.Log(mousePos.y);
        //        screenToWorld = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        //        Vector2 MousetoWorld = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        //         transform.position = MousetoWorld;
        //         BlockModel BlockModel = Grid.WorldToGridPosition(MousetoWorld.x,MousetoWorld.y);
        //         //if (BlockModel == null) Debug.Log("Khong ton tai grisSquare tai diem nay");
        //         // else
        //         // {
        //         // Debug.Log("BlockModel: x=" + BlockModel.x + "- " + "y= " + BlockModel.y);
        //         // }
        //        Debug.LogError(screenToWorld);
        //    }
        //}
    }
}
