using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 distance;

    public Vector3 posStart;

    public List<Transform> position = new List<Transform>();
    
    public Vector3 StartPosition;
    public GroupBlock groupBlock;

    public void addBlock(BlockModel BlockModel)
    {
        position.Add(BlockModel.transform);
    }

    private void Start()
    {
        groupBlock = this.GetComponent<GroupBlock>();
    }

    int Count = 4;
    private void GetMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        GetMousePos();
        distance = (Vector2)(mousePos - transform.position);
        Vector2 target = (Vector2)(mousePos - distance);
        groupBlock.touchDown(new Vector3(target.x, target.y, -1));

    }
    private void OnMouseUp()
    {
        
        //List<BlockModel> list = new List<BlockModel>();
        //for (int i = 0; i < position.Count; i++)
        //{
        //    Transform item = position[i];
        //    BlockModel BlockModel = Grid.Instance.WorldToGridPosition(item.transform.position.x, item.transform.position.y);
        //    if (BlockModel == null)
        //        break;
        //    //back start position 
        //    list.Add(BlockModel);
        //}
        //if (list.Count == 4)
        //{
        //    luu(list);
        //}
        //else
        //    transform.position = posStart;
        groupBlock.touchUp();
    }
  
    private void OnMouseDrag()
    {
        GetMousePos();
        Vector2 target = (Vector2)(mousePos - distance);
        transform.position = new Vector3(target.x,target.y,-1);
        groupBlock.touchDrag();
       
    }
    public void luu(List<BlockModel> list)
    {
    //    List<BlockModel> listCheck = new List<BlockModel>();
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        //if (list[i]._Active.active==false)
    //        //{
    //        //    listCheck.Add(list[i]);
    //        //}
    //        //else
    //        //    break;
    //    }

    //    if (listCheck.Count == 4)
    //    {
    //        Grid.Instance.to(listCheck);
    //        if (Shape.Instance.List.transform.childCount == 1)
    //            Shape.Instance.createRandom();
    //        GameObject.Destroy(gameObject);
           
    //    }
    //    else
    //        transform.position = posStart;
    }

     

}


